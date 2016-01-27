using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using SharpMysql;


namespace ArcDB
{
    class ArticlePublish
    {
        #region Fields

        private int _pubID;                                                            //发布规则配置ID
        private string _coConnString;                                           //采集数据库连接配置
        private string _pubConnString;                                        //发布数据库连接配置
        private string _pubTablePrename;                                   //发布数据库表前缀
        private int _coTypeid;                                                      //采集文章分类
        private int _pubTypeid;                                                    //发布文章分类
        private string[] _pubFilterKeywords;                                //发布过滤关键词
        private int _pubNums;                                                     //发布数量
        private string _randomDateStart;                                    //随机发布时间的随机区间开始
        private string _randomDateStop;                                    //随机发布时间的随机区间结束
        private bool _isRecordError;                                           //是否开启错误记录
        private CancellationTokenSource _cancelTokenSource;  //用来获取取消事件的对象
        private string _pubState = "";                                         //保存当前采集状态
        private int _exportedArticleNums = 0;                            //保存当前已经储存到数据库的采集文章数
        private List<Exception> _pubExceptions;                       //记录异常错误
        private Exception _cancelException;                               //出发取消任务时候的取消异常
        private long _lastExportedCoid;                                     //最后导出的采集文章ID
        private long _lastExportedCmsid;                                  //最后导出的CMS文章ID


        #endregion

        #region Constructors
        public ArticlePublish(int pubID,string coConnString,string pubConnString,string pubTablePrename,int coTypeid,int pubTypeid,int pubNums,string[]pubFilterKeywords,string randomDateStart,string randomDateStop)
        {
            _pubID = pubID;
            _coConnString = coConnString;
            _pubConnString = pubConnString;
            _pubTablePrename = pubTablePrename;
            _coTypeid = coTypeid;
            _pubTypeid = pubTypeid;
            _pubFilterKeywords = pubFilterKeywords;
            _pubNums = pubNums;
            _randomDateStart = randomDateStart;
            _randomDateStop = randomDateStop;
            _pubExceptions = new List<Exception>();
            _lastExportedCoid = -1;
            _lastExportedCmsid = -1;
            _cancelTokenSource = new CancellationTokenSource();
        }
        #endregion Constructors

        #region Properties

        //当前发布ID
        public int PubID
        {
            get { return _pubID; }
        }
        //采集分类ID
        public int CoTypeID
        {
            get { return _coTypeid; }
        }

        //获取或修改是否保存错误异常
        public bool IsRecordError
        {
            get { return _isRecordError; }
            set
            {
                _isRecordError = value;
            }
        }

        //获取或修改取消令牌
        public CancellationTokenSource CancelTokenSource
        {
            get { return _cancelTokenSource; }
            set
            {
                _cancelTokenSource = value;
            }
        }
        //返回采集错误异常集合
        public List<Exception> PubException
        {
            get { return _pubExceptions; }
        }
        //返回取消异常
        public Exception CancelException
        {
            get { return _cancelException; }
        }

        //当前导出文章数量
        public int CurrentExportedArticles
        {
            get { return _exportedArticleNums; }
        }

        //当前发布状态
        public string PubState
        {
            get { return _pubState; }
            set { _pubState = value; }
        }
        //最后导出的采集文章ID
        public long LastExportedCoid
        {
            get { return _lastExportedCoid; }
        }
        //最后导出的CMS文章ID
        public long LastExportedCmsid
        {
            get { return _lastExportedCmsid; }
        }

        #endregion


        //通过datetime变量获取unix时间戳
        private long getUnixTime(DateTime dt)
        {
            TimeSpan ts;
            ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)ts.TotalSeconds;
        }

        //通过_randomDateStart 和randomDateStop获取随机发布时间，时间的范围是早上9点到晚上8点，及模拟正常的工作时间
        private long getRandomPubDate()
        {
            long pubDateUnixtime = 0;
            try
            {
                DateTime randomDateStart = DateTime.Parse(_randomDateStart);
                DateTime randomDateStop = DateTime.Parse(_randomDateStop);
                DateTime pubDate = DateTime.Parse(_randomDateStart);
                TimeSpan ts = randomDateStop - randomDateStart;
                int rndDays = (int)ts.TotalDays;
                double rndD;
                Random ran = new Random();
                if (rndDays!=0)
                {
                    rndD = ran.Next(0, rndDays);
                }
                else
                {
                    rndD = 0;
                }
                double rndM = ran.Next(0, 60);
                double rndH = ran.Next(9, 20);
                double rndS = ran.Next(0, 60);
                pubDate = pubDate.AddDays(rndD);
                pubDate = pubDate.AddHours(rndH);
                pubDate = pubDate.AddMinutes(rndM);
                pubDate = pubDate.AddSeconds(rndS);
                pubDateUnixtime = getUnixTime(pubDate);
                return pubDateUnixtime;
            }
            catch (Exception ex)
            {
                _pubExceptions.Add(ex);
                return pubDateUnixtime;
            }
        }

        //查寻符合发布条件的文章总数，根据文章总数随机一个从1到总数的数，作为获取一条记录的起始位置
        private int getRandomStartPosition(string sql)
        {
            int startPosition = 0;
            int recordCounts = 0;
            List<Dictionary<string, object>> dbResult;
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult == mySqlDB.SUCCESS && counts > 0)
            {
                recordCounts=int.Parse(dbResult[0]["count(aid)"].ToString());
                if (recordCounts!=0)
                {
                    Random rnd = new Random();
                    startPosition = rnd.Next(1, recordCounts);
                }
            }
            return startPosition;
        }
        //随机获取一条符合发布条件的文章记录
        private Dictionary<string,object> getOneRecord()
        {
            List<Dictionary<string, object>> dbResult;
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql = "select aid,litpic,title,source_site,description,content from arc_contents where type_id='" + _coTypeid.ToString() + "' and usedby_pc='no'";
            string countSql = "select count(aid) from arc_contents where type_id='" + _coTypeid.ToString() + "' and usedby_pc='no'";
            if (_pubFilterKeywords.Length>0)
            {
                sql = sql + " and (title like '%" + _pubFilterKeywords[0] + "%'";
                countSql = countSql + " and (title like '%" + _pubFilterKeywords[0] + "%'";
                for (int i = 1; i < _pubFilterKeywords.Length; i++)
                {
                    sql = sql + " or title like '%" + _pubFilterKeywords[i] + "%'";
                    countSql = countSql + " or title like '%" + _pubFilterKeywords[i] + "%'";
                }
                sql = sql + ")";
                countSql = countSql + ")";
            }
            int startPosition = getRandomStartPosition(countSql);
            if (startPosition!=0)
            {
                sql = sql + " order by aid limit "+startPosition.ToString()+",1";
            }
            else
            {
                sql = sql + " order by aid limit 1";
            }
            dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                return dbResult[0];
            }
            else
            {
                if (sResult!=mySqlDB.SUCCESS)
                {
                    Exception ex = new Exception(sResult);
                    ex.Data.Add("错误信息", "从指定采集分类中获取未发布文章错误");
                    ex.Data.Add("采集分类ID", _coTypeid);
                    _pubExceptions.Add(ex);
                }
                if (counts==0)
                {
                    Exception ex = new Exception(sResult);
                    ex.Data.Add("提示信息", "指定采集分类中已没有可发布的文章");
                    ex.Data.Add("采集分类ID", _coTypeid);
                    _cancelException = ex;
                }
                return null;
            }
        }

        //导出一篇文章到CMS中
        private bool exportOneRecord(Dictionary<string, object> coArticle,ref long cmsAid)
        {
            cmsAid = -1;                            //news表中插入记录后的ID值
            string typeid = "0";
            string title = coArticle["title"].ToString();
            string litpic = coArticle["litpic"].ToString();
            string sourceSite = coArticle["source_site"].ToString();
            string content = coArticle["content"].ToString();
            string description = coArticle["description"].ToString();
            string url = "";
            string status = "99";
            string sysadd = "1";
            string username = "妖妖";
            long pubDateUnixtime = getRandomPubDate();
            //将文章信息插入到news表中
            mySqlDB pubMyDB = new mySqlDB(_pubConnString);
            string sResult = "";
            int counts = 0;
            string sql = "insert into " + _pubTablePrename + "_news(catid,typeid,title,thumb,description,url,status,sysadd,username,inputtime,updatetime)";
            sql = sql + " values ('" + _pubTypeid + "'";
            sql = sql + ",'" + typeid + "'";
            sql = sql + ",'" + mySqlDB.EscapeString(title) + "'";
            sql = sql + ",'" + litpic + "'";
            sql = sql + ",'" + mySqlDB.EscapeString(description) + "'";
            sql = sql + ",'" + url + "'";
            sql = sql + ",'" + status + "'";
            sql = sql + ",'" + sysadd + "'";
            sql = sql + ",'" + username + "'";
            sql = sql + ",'" + pubDateUnixtime + "'";
            sql = sql + ",'" + pubDateUnixtime + "')";
            counts = pubMyDB.executeDMLSQL(sql, ref sResult);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                cmsAid = pubMyDB.LastInsertedId;
            }
            else
            {
                Exception ex = new Exception(sResult);
                ex.Data.Add("错误信息", "发布文章至news表错误");
                _pubExceptions.Add(ex);
                return false;
            }
            //将相应的文章数据插入到news_data表中
            string maxcharperpage = "3000";  //文章按多少字分页
            string paginationtype = "1";           //表示文章自动分页
            string groupids_view = "";
            string template = "";
            sql = "insert into " + _pubTablePrename + "_news_data(id,content,groupids_view,paginationtype,maxcharperpage,template,copyfrom)";
            sql = sql + " values ('" + cmsAid.ToString() + "'";
            sql = sql + ",'" + mySqlDB.EscapeString(content) + "'";
            sql = sql + ",'" + groupids_view + "'";
            sql = sql + ",'" + paginationtype + "'";
            sql = sql + ",'" + maxcharperpage + "'";
            sql = sql + ",'" + template + "'";
            sql = sql + ",'" + mySqlDB.EscapeString(sourceSite) + "')";
            counts = pubMyDB.executeDMLSQL(sql, ref sResult);
            if (sResult == mySqlDB.SUCCESS && counts > 0)
            {
            }
            else
            {
                Exception ex = new Exception(sResult);
                ex.Data.Add("错误信息", "发布文章至news_data表错误");
                ex.Data.Add("发布文章ID", cmsAid);
                _pubExceptions.Add(ex);
                return false;
            }
            //将相应的文章数据插入到hits表中
            string hitsid = "c-1-" + cmsAid.ToString();
            sql = "INSERT IGNORE INTO " + _pubTablePrename + "_hits(hitsid,catid) Values('" + hitsid + "','" + _pubTypeid + "')";
            counts = pubMyDB.executeDMLSQL(sql, ref sResult);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                return true;
            }
            else
            {
                Exception ex = new Exception(sResult);
                ex.Data.Add("错误信息", "发布文章-添加点击数记录至hits表错误");
                ex.Data.Add("发布文章ID",cmsAid);
                _pubExceptions.Add(ex);
            }
            return true;
        }

        //成功发布一篇文章后，更新采集文章库中对应文章的信息
        private bool updateCoArticle(long aid, long cmsAid)
        {
            bool isCorrectUpdated = true;
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql = "update arc_contents set cms_aid='" + cmsAid.ToString() + "' where aid='" + aid.ToString() + "'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS || counts == 0)
            {
                isCorrectUpdated = false;
                Exception ex = new Exception(sResult);
                ex.Data.Add("错误信息", "发布文章后更新cms_aid字段信息错误");
                ex.Data.Add("采集文章ID", aid);
                ex.Data.Add("发布文章ID", cmsAid);
            }
            sql = "update arc_contents set usedby_pc='yes' where aid='" + aid.ToString() + "'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS || counts == 0)
            {
                isCorrectUpdated = false;
                Exception ex = new Exception(sResult);
                ex.Data.Add("错误信息", "发布文章后更新usedby_pc字段信息错误");
                ex.Data.Add("采集文章ID", aid);
                ex.Data.Add("发布文章ID", cmsAid);
            }
            return isCorrectUpdated;
        }

        //发布指定 _pubNums 数量的文章
        public void ProcessPublishArticles()
        {
            _pubState = "发布文章";
            _exportedArticleNums = 0;
            CancellationToken forCancelToken = _cancelTokenSource.Token;
            for (int i = 0; i < _pubNums; i++)
            {
                if (forCancelToken.IsCancellationRequested)
                {
                    Exception ex = new Exception("取消发布文章");
                    ex.Data.Add("发布规则ID", _pubID);
                    _cancelException = ex;
                    break;
                }
                Dictionary<string, object> oneArticle = getOneRecord();
                if (oneArticle!=null)
                {
                    long cmsAid=-1;
                    bool isCorrectExported;
                    long aid = long.Parse(oneArticle["aid"].ToString());
                    isCorrectExported = exportOneRecord(oneArticle, ref  cmsAid);
                    if (isCorrectExported)
                    {
                        bool isCorrectUpdated;
                        isCorrectUpdated = updateCoArticle(aid, cmsAid);
                        if (!isCorrectUpdated)
                        {
                            //如果不能正确更新已经发布文章的信息，则终止发布处理
                            break;
                        }
                        _lastExportedCoid = aid;
                        _lastExportedCmsid = cmsAid;
                        _exportedArticleNums += 1;
                    }
                    else
                    {
                        //如果不能正确发布一篇文章，则终止发布处理
                        break;
                    }
                }
                else
                {
                    //如果不能获取到文章了，说明要么是数据库连接出错了，要么是当前采集分类下可发布的文章已经没有了，所以退出发布处理过程
                    break;
                }
            }
        }

    }
}
