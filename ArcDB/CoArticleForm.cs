using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpMysql;
using Murmur;
using HtmlAgilityPack;
using System.IO;
using ArticleCollect;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections;
using System.Collections.Concurrent;

namespace ArcDB
{
    public partial class CoArticleForm : Form
    {
        //private List<Dictionary<string, object>> _articleCollections;                           
        private ConcurrentDictionary<long, Dictionary<string, object>> _articleCoCollections; //采集对象集合，每一个集合中包括一个ArticleCollectOffline采集对象， 一个监控耗时的stopwatch对象
        private Dictionary<long, string> _dicCids;                                                       //采集规则ID和采集名称集合，
        private string _connString;                                                                               //数据库连接字符串
        System.Threading.Timer _timerUpdateForm;                                                  //listViewCoArticles状态更新定时器
        private Queue<long> _queueCids;                                                                  //采集规则ID队列
        Stopwatch swGlobal = new Stopwatch();                                                        //监控总任务时间
        private List<string> _hashList;                                                                         //用来检测采集文章URL HASH是否重复的集合
        private int _cfgPicNum=0;                                                                               //保存数据库图片总数，用来判断图片子域名
        private string _cfgBasePath="";                                                                       //图片保存根目录
        private string _cfgImgBaseurl="";                                                                   //图片网址所使用的域名
        private int _cfgDescriptionLength = 0;                                                           //生成文章概要时候生成概要的长度，此数据从数据库sys_config表中获取，如果数据没有配置则默认为120
        private List<Size> _cfgThumbSizeList;                                                        //需要生成多种规格缩略图所指定的宽度，此数据从数据库sys_config表cfg_thumb_size记录中获取，比如158*140表示宽158，高140，指定宽高则按Cut模式生成缩略图，只指定宽的话则按等比宽度生成。多种规格使用“|”分隔
        private int _cfgThumbWidthDefault = 0;                                                    //生成缩略图时设置的缩略图宽度，当从数据库中获取不到缩略图尺寸设置时使用
        private int _cfgThumbHeightDefault = 0;                                                   //生成缩略图时设置的缩略图高度，当从数据库中获取不到缩略图尺寸设置时使用
        private string _cfgPicNone = "";                                                                      //采集文章内容中出现图片找不到的情况时，使用默认的一张图片来替换找不到的图片

        public CoArticleForm(string connString, Dictionary<long, string> dicCids)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            _articleCoCollections = new ConcurrentDictionary<long, Dictionary<string, object>>();
            _dicCids = dicCids;
            _connString = connString;
        }
        //采集窗口要关闭时的处理
        private void CoArticleForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("关闭当前窗口将取消所有正在运行中的采集，是否继续？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                cancelAllTask();
                e.Cancel = true;
            }
        }
        //采集窗口关闭后的处理
        private void CoArticleForm_Closed(object sender, FormClosedEventArgs e)
        {
            cancelAllTask();
        }

        //用来监控当前并行采集中的各个进程的进度状态
        private void updateForm(object state)
        {
            foreach (var collectItem in _articleCoCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    if (currentCollectWork.CoState != "采集完毕" && currentCollectWork.CancelException == null && dic != null)
                    {
                        Stopwatch currentWatch = (Stopwatch)dic["watch"];
                        ListViewItem currentItem = listViewCoArticles.Items.Cast<ListViewItem>().First(item => item.SubItems[1].Text == currentCid.ToString());
                        listViewCoArticles.BeginUpdate();
                        if (currentCollectWork.CoState != "")
                        {
                            currentItem.SubItems[0].Text = currentCollectWork.CoState;
                        }
                        currentItem.SubItems[3].Text = currentCollectWork.CurrentProcessedListPages.ToString();
                        currentItem.SubItems[4].Text = currentCollectWork.CurrentGetArticlePages.ToString();
                        currentItem.SubItems[5].Text = currentCollectWork.CurrentNeedConums.ToString();
                        currentItem.SubItems[6].Text = currentCollectWork.CurrentProcessedArticles.ToString();
                        currentItem.SubItems[7].Text = currentCollectWork.CurrentSavedArticles.ToString();
                        string timeUsed = currentWatch.Elapsed.ToString();
                        currentItem.SubItems[8].Text = timeUsed.Remove(8, 8);
                        listViewCoArticles.EndUpdate();
                    }
                    else if (dic == null)
                    {
                        tboxErrorOutput.AppendText(string.Format("ID: {0} NULL \n", currentCid));
                    }
                    if (_articleCoCollections.Count > 0)
                    {
                        labTime.Text = string.Format("总共耗时： {0}\n", swGlobal.Elapsed.ToString());
                    }
                    else
                    {
                        tboxErrorOutput.AppendText("所有采集任务采集完成！");
                        swGlobal.Stop();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        //取消所有采集任务
        private void cancelAllTask()
        {
            _queueCids.Clear();
            foreach (var collectItem in _articleCoCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    if (currentCollectWork.CoState!="保存文章") //如果采集正在保存文章至数据库则不能取消
                    {
                        currentCollectWork.CancelToken.Cancel();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        //取消当前采集任务
        private void cancelCurrentTask()
        {
            foreach (var collectItem in _articleCoCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    if (currentCollectWork.CoState != "保存文章")//如果采集正在保存文章至数据库则不能取消
                    {
                        currentCollectWork.CancelToken.Cancel();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        //检查必填项是否正确填写，这里暂时只是用 string.IsNullOrWhiteSpace()判断是否为空值，未做进一步校验，以后完善
        private bool validateCoConfig(Dictionary<string, string> coConfigs)
        {
            foreach (KeyValuePair<string, string> kvp in coConfigs)
            {
                if (string.IsNullOrWhiteSpace(kvp.Value))
                {
                    return false;
                }
            }
            try
            {
                int startPageNumber = int.Parse(coConfigs["start_page_number"]);
                int stopPageNumber = int.Parse(coConfigs["stop_page_number"]);
                int subPageStartNum = int.Parse(coConfigs["arc_subpage_startnum"]);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //初始化listViewCoArticles表单，填充表单中的 采集状态，采集规则ID和采集规则名称
        private void initializeForm()
        {
            _queueCids = new Queue<long>();
            listViewCoArticles.BeginUpdate();
            foreach (KeyValuePair<long, string> kvp in _dicCids)
            {
                string[] subItems = new string[] { "待采集", kvp.Key.ToString(), kvp.Value, "0", "0", "0", "0", "0","0" };
                ListViewItem listItem = new ListViewItem(subItems);
                listViewCoArticles.Items.Add(listItem);
                _queueCids.Enqueue(kvp.Key);
            }
            listViewCoArticles.EndUpdate();
            listViewCoArticles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewCoArticles.GridLines = true;
        }

        //将多行文本转换成List<string>类型的对象返回
        private List<string> getLines(string text)
        {
            System.Windows.Forms.TextBox tempTbox = new System.Windows.Forms.TextBox();
            tempTbox.Multiline = true;
            tempTbox.Text = text;
            string[] linesArr = tempTbox.Lines;
            return linesArr.ToList<string>();
        }
        //从需要执行的采集Cid队列中获取一条CID记录
        private object queueLock = new object();
        private long getOneCid()
        {
            long cid = -1;
            lock (queueLock)
            {
                if (_queueCids.Count > 0)
                {
                    cid = _queueCids.Dequeue();
                }
            }
            return cid;
        }
        //从 _articleCollections监控采集状态集合中移出一条已经完成采集的记录
        private void removeOneCollection(long cid)
        {
            Dictionary<string, object> oneCollection = null;
            bool removed = false;
            do
            {
                removed = _articleCoCollections.TryRemove(cid, out oneCollection);
            } while (!removed);
        }


        //将传入的字符串通过murmurhash函数生成32位长的字符串
        private static string GetHashAsString(string stringToHash)
        {
            Murmur128 urlHash = MurmurHash.Create128(managed: false);
            byte[] urlbyte = System.Text.Encoding.UTF8.GetBytes(stringToHash);
            byte[] hash = urlHash.ComputeHash(urlbyte);

            //以下代码也可以用 BitConverter.ToString(hash)代替
            var builder = new StringBuilder(16);
            for (int i = 0; i < hash.Length; i++)
                builder.Append(hash[i].ToString("x2"));

            return builder.ToString();
        }

        //检查文章是否已经采集过, 将采集过的URL记录从采集对象中的文章页集合中剔除
        private object hashLock = new object();
        private void removeDumpArcpages(ArticleCollectOffline collectOffline)
        {
            List<Dictionary<string,string>> articleNeedCoPages = new List<Dictionary<string, string>>() ;
            List<Dictionary<string, string>> currentGetArcPages = collectOffline.CorrectArticlePages;
            if (_hashList == null)
            {
                mySqlDB myDB = new mySqlDB(_connString);
                string sResult = "";
                int counts = 0;
                string sql = "select hash from arc_contents";

                List<Dictionary<string, object>> hashDicList = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    _hashList = new List<string>();
                    foreach (var item in hashDicList)
                    {
                        lock (hashLock)
                        {
                            _hashList.Add(item["hash"].ToString());
                        }
                    }
                }
            }
            if (_hashList != null)
            {
                foreach (Dictionary<string,string> arcInfo in currentGetArcPages)
                {
                    if (!_hashList.Contains(GetHashAsString(arcInfo["arctitle"])))
                    {
                        articleNeedCoPages.Add(arcInfo);
                    }
                }
                collectOffline.CorrectArticlePages = articleNeedCoPages;
            }
        }

        //从数据库获取相关的配置信息
        private bool getSysConfig(ArticleCollectOffline collectOffline)
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = "";
            List<Dictionary<string, object>> dbResult;
            //读取保存图片的根目录变量
            if (_cfgBasePath=="")
            {
                sql = "select value from sys_config where varname='cfg_basepath'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    _cfgBasePath = dbResult[0]["value"].ToString();
                }
                else
                    return false;
            }
            //读取图片总数变量
            if (_cfgPicNum ==0)
            {
                sql = "select value from sys_config where varname='cfg_pic_num'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    _cfgPicNum = int.Parse(dbResult[0]["value"].ToString());
                }
                else
                    return false;
            }
            //读取base URL变量
            if (_cfgImgBaseurl=="")
            {
                sql = "select value from sys_config where varname='cfg_img_baseurl'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    _cfgImgBaseurl = dbResult[0]["value"].ToString();
                }
                else
                    return false;
            }
            //读取文章概要长度变量
            if (_cfgDescriptionLength == 0)
            {
                sql = "select value from sys_config where varname='cfg_description_dength'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    string temp = dbResult[0]["value"].ToString();
                    if (int.TryParse(temp,out _cfgDescriptionLength))
                    {
                        _cfgDescriptionLength = int.Parse(temp);
                    }else
                        _cfgDescriptionLength = 120;
                }
                else
                    _cfgDescriptionLength = 120;
            }

            //读取默认生成缩略图宽度参数
            if (_cfgThumbWidthDefault == 0)
            {
                sql = "select value from sys_config where varname='cfg_thumb_width'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    string temp = dbResult[0]["value"].ToString();
                    if (int.TryParse(temp, out _cfgThumbWidthDefault))
                    {
                        _cfgThumbWidthDefault = int.Parse(temp);
                    }
                    else
                        _cfgThumbWidthDefault = 300;
                }
                else
                    _cfgThumbWidthDefault = 300;
            }
            //读取默认生成缩略图高度参数
            if (_cfgThumbHeightDefault == 0)
            {
                sql = "select value from sys_config where varname='cfg_thumb_height'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    string temp = dbResult[0]["value"].ToString();
                    if (int.TryParse(temp, out _cfgThumbHeightDefault))
                    {
                        _cfgThumbHeightDefault = int.Parse(temp);
                    }
                    else
                        _cfgThumbHeightDefault = 300;
                }
                else
                    _cfgThumbHeightDefault = 300;
            }


            //读取生成多种规格缩略图宽度参数

            if (_cfgThumbSizeList == null)
            {
                _cfgThumbSizeList = new List<Size>();
                sql = "select value from sys_config where varname='cfg_thumb_size'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult==mySqlDB.SUCCESS && counts>0)
                {
                    string temp = dbResult[0]["value"].ToString();
                    string[] tempSizeArr = temp.Split('|');

                    List<string> tempSizeList = tempSizeArr.ToList();
                    foreach (string item in tempSizeList)
                    {
                        int width = 0;
                        int height = 0;
                        Size thumbSize=new Size();
                        thumbSize.Width = 0;thumbSize.Height = 0;
                        string[] tempSize = item.Split('*');
                        if (int.TryParse(tempSize[0],out width))
                        {
                            if (width>0)
                            {
                                thumbSize.Width = width;
                            }
                        }
                        if (tempSize.Count()>1 && thumbSize.Width>0)
                        {
                            if (int.TryParse(tempSize[1],out height))
                            {
                                if (height>0)
                                {
                                    thumbSize.Height = height;
                                }
                            }
                        }
                        if (thumbSize.Width>0)
                        {
                            _cfgThumbSizeList.Add(thumbSize);
                        }
                    }
                }
            }

            //读取采集文章内容中缺失图片默认替换图片参数
            if (_cfgPicNone == "")
            {
                sql = "select value from sys_config where varname='cfg_pic_none'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    _cfgPicNone = dbResult[0]["value"].ToString();
                }
                else //如果不能从数据库中正确读取参数，则使用第一个图片域名根目录下的none.jpg这张图片
                    _cfgPicNone= "http://img0."+_cfgImgBaseurl +"/none.jpg";
            }

            //如果未能正确获取到图片根目录或者图片域名参数，则返回失败
            if (_cfgBasePath==""||_cfgImgBaseurl=="")
            {
                return false;
            }
            return true;
        }

        //获取文章内容中的图片路径
        private List<string>getImgPath(string content, ArticleCollectOffline collectOffline)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            List<string> imgPathList = new List<string>();
            try
            {
                doc.LoadHtml(content);
                HtmlAgilityPack.HtmlNodeCollection imgNodes = doc.DocumentNode.SelectNodes("//img");
                foreach (HtmlAgilityPack.HtmlNode imgNode in imgNodes)
                {
                    string imgPath = imgNode.Attributes["src"].Value;
                    imgPathList.Add(imgPath);
                }
            }
            catch (Exception ex)
            {
                List<Exception> coException = collectOffline.CoException;
                coException.Add(ex);
            }
            return imgPathList;
        }

        //测试图片能否正确打开
        private bool testPicFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Image testPic = Image.FromFile(filePath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return false;
        }

        //测试文章中的图片至少要有一张能正确打开，否则就返回假（如果文章中所有的图片都不能正确打开，意味着此篇文章不需要入库）
        private bool testArcPics(List<string> imgPathList)
        {
            foreach (string picPath in imgPathList)
            {
                if (testPicFile(picPath)) //如果有一张图片能正确打开，就返回true
                {
                    return true;
                }
            }
            /*
            if (imgPathList.Count>0)  //此处判断还需要再改进，根绝采集规则中设置是否只采集带图片文章来判断
            {
                return false;
            }
            else
            {
                return true;
            }
            */
            //如果文章中不带任何图片，则返回false
            return false;
        }

        //根据文章内容获取文章概要
        private string getArticleDescription(string arcContent,ArticleCollectOffline collectOffline)
        {
            string description = "";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(arcContent);
                string arcContentPiece = doc.DocumentNode.InnerText;
                arcContentPiece = arcContentPiece.Replace("\r\n\t", "");
                arcContentPiece = arcContentPiece.Replace("\r\n", "");
                arcContentPiece = arcContentPiece.Replace("\r", "");
                arcContentPiece = arcContentPiece.Replace("\n", "");
                arcContentPiece = arcContentPiece.Replace("\t", "");
                arcContentPiece = arcContentPiece.Replace("&nbsp;", "");
                arcContentPiece = arcContentPiece.Replace("amp;", "");
                arcContentPiece = arcContentPiece.Replace(" ", "");
                if (arcContentPiece.Length > 200)
                {
                    arcContentPiece = arcContentPiece.Substring(0, 200);
                }
                description = ArcTool.GetDescription(arcContentPiece, _cfgDescriptionLength);
            }
            catch (Exception ex)
            {
                List<Exception> coException = collectOffline.CoException;
                ex.Data.Add("出错信息", "生成文章概要出错！");
                coException.Add(ex);
            }
            return description;
        }

        //更新数据系统配置表中的图片总数参数
        private bool updateCfgPicnum(ArticleCollectOffline collectOffline)
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = "update sys_config set value='" + _cfgPicNum.ToString() + "' where varname='cfg_pic_num'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                return true;
            }
            else
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                coException.Add(mysqlError);
                return false;
            }
        }

        private void updateThumbStatus(ArticleCollectOffline collectOffline,long picID)
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = "update arc_pics set is_thumb_maked='yes' where pid='" + picID.ToString() + "'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS) //如果更新文章内容出错，则将错误信息记录下来到当前采集对象中
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                mysqlError.Data.Add("错误类型", "数据库更新错误");
                mysqlError.Data.Add("数据表","arc_pics");
                mysqlError.Data.Add("ID", picID.ToString());
                coException.Add(mysqlError);
            }
        }

        //更新文章内容，这里是更新将文章内容中的本地路径替换成图片服务器访问的URL链接后的内容，包括增加文章缩略图
        private bool updateArcContent(ArticleCollectOffline collectOffline, long aid,string arcContent,string litpicUrl,string isAllpicCopied,long thumbPicID,int picCount)
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            //更新文章表
            string sql = "update arc_contents set content='" + mySqlDB.EscapeString(arcContent) + "',is_allpic_copied='"+isAllpicCopied+"' where aid='" + aid.ToString() + "'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS)
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                coException.Add(mysqlError);
                return false;
            }
            if (litpicUrl!="")
            {
                sql = "update arc_contents set litpic='" + mySqlDB.EscapeString(litpicUrl) + "' where aid='" + aid.ToString() + "'";
                counts = myDB.executeDMLSQL(sql, ref sResult);
                if (sResult != mySqlDB.SUCCESS) //如果更新文章内容出错，则将错误信息记录下来到当前采集对象中
                {
                    List<Exception> coException = collectOffline.CoException;
                    Exception mysqlError = new Exception(sResult);
                    coException.Add(mysqlError);
                    return false;
                }
            }
            if (thumbPicID!=0)
            {
                sql = "update arc_pics set is_thumb='yes' where pid='" + thumbPicID.ToString() + "'";
                counts = myDB.executeDMLSQL(sql, ref sResult);
                if (sResult != mySqlDB.SUCCESS) //如果更新文章内容出错，则将错误信息记录下来到当前采集对象中
                {
                    List<Exception> coException = collectOffline.CoException;
                    Exception mysqlError = new Exception(sResult);
                    coException.Add(mysqlError);
                    return false;
                }
            }
            sql = "update arc_contents set pic_count='" + picCount.ToString() + "' where aid='" + aid.ToString() + "'";
            counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS) //如果更新文章内容出错，则将错误信息记录下来到当前采集对象中
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                coException.Add(mysqlError);
                return false;
            }
            return true;
        }

        //更新采集规则项的最后采集配置表和分类表中的统计信息
        private void updateCoState(ArticleCollectOffline collectOffline)
        {
            long cid = collectOffline.Cid;
            long typeID = collectOffline.TypeID;
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            int coNums = collectOffline.CurrentSavedArticles;
            //更新采集配置表中的信息
            string sql = "update co_config set co_nums=co_nums+'" + coNums.ToString() + "'";
            sql = sql + ",co_time = CURRENT_TIMESTAMP";
            sql =sql+ " where cid='" + cid.ToString() + "'"; 
            counts =myDB.executeDMLSQL(sql, ref sResult);
            if (sResult!=mySqlDB.SUCCESS)
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                coException.Add(mysqlError);
            }
            //更新分类表中的统计信息
            sql = "update arc_type set total_nums=total_nums+'" + coNums.ToString() + "'";
            sql = sql + ",unused_nums=unused_nums+'" + coNums.ToString() + "'";
            sql = sql + " where tid='" + typeID.ToString() + "'"; counts = myDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS)
            {
                List<Exception> coException = collectOffline.CoException;
                Exception mysqlError = new Exception(sResult);
                coException.Add(mysqlError);
            }

        }

        //输出采集过程中的异常信息
        private void printErrors(List<Exception> coExption)
        {
            int count = 0;
            foreach (Exception item in coExption)
            {
                count = count + 1;
                tboxErrorOutput.AppendText(string.Format("Error {0}: --------------------------\n", count));
                tboxErrorOutput.AppendText(string.Format("From: {0}   Message:{1}\n", item.TargetSite, item.Message));
                if (item.Data != null)
                {
                    foreach (DictionaryEntry de in item.Data)
                    {
                        tboxErrorOutput.AppendText(string.Format("{0} : {1} \n", de.Key, de.Value));
                    }
                }

            }
        }

        //将文章保存进数据库,以及对文章内容中的图片做相关处理，复制到新的路径，以及生成最终的网络访问URL
        //保存文章过程中，有任何错误都将会中断文章保存，并输出相关错误提示
        //private object picNumLock = new object();
        private void saveArticles(ArticleCollectOffline collectOffline)
        {
            collectOffline.CoState = "保存文章";
            long cid = collectOffline.Cid;

            if (getSysConfig(collectOffline))  //正确获取相关配置参数后再进行下一步处理
            {
                string typeName = collectOffline.TypeName;
                string sourceSite = collectOffline.SourceSite;
                long typeID = 0;  //采集分类ID
                long sourceSiteID = 0;  //来源网址ID
                mySqlDB myDB = new mySqlDB(_connString);
                string sResult = "";
                int counts = 0;
                //获取当前采集分类ID，如果数据库不存在则将当前采集分类插入数据库
                List<Dictionary<string, object>> dbResult;
                string sql = "select tid from arc_type where type_name='" + typeName + "'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    typeID = long.Parse(dbResult[0]["tid"].ToString());
                }
                else
                {
                    sql = "insert into arc_type (type_name) values('" + typeName + "')";
                    counts = myDB.executeDMLSQL(sql, ref sResult);
                    if (sResult == mySqlDB.SUCCESS && counts > 0)
                    {
                        typeID = myDB.LastInsertedId;
                    }
                }
                sResult = "";
                counts = 0;
                //获取当前采集来源网址ID，如果数据库不存在则将当前采集分类插入数据库
                sql = "select id from source_site where source_site='" + sourceSite + "'";
                dbResult = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    sourceSiteID = long.Parse(dbResult[0]["id"].ToString());
                }
                else
                {
                    sql = "insert into source_site (source_site) values('" + sourceSite + "')";
                    counts = myDB.executeDMLSQL(sql, ref sResult);
                    if (sResult == mySqlDB.SUCCESS && counts > 0)
                    {
                        sourceSiteID = myDB.LastInsertedId;
                    }
                }
                if (typeID != 0 && sourceSiteID != 0)  //必须要正确获得 typeNameID 和 sourceSiteID后才进行下一步的文章和图片的处理
                {
                    collectOffline.TypeID = typeID;
                    List<Dictionary<string, string>> articles = collectOffline.Articles;

                    //遍历采集到的文章列表，对将文章插入到数据库表中,
                    //并将内容中的图片复制到新的系统配置的图片目录，生成图片的ULR，将文章内容中图片的本地链接为生成的带图片域名的URL
                    foreach (Dictionary<string, string> article in articles)
                    {
                        sResult = "";
                        counts = 0;
                        string arcContent = article["content"];
                        List<string> imgPathList = getImgPath(arcContent, collectOffline); //获取文章中的所有图片路径
                        //测试文章中的图片至少要有一张能正确打开，否则就返回假（如果文章中所有的图片都不能正确打开，意味着此篇文章不需要入库）
                        if (testArcPics(imgPathList))
                        {
                            string arcTitle = article["title"];
                            string arcUrl = article["url"];
                            string hash = GetHashAsString(arcTitle);
                            string description = getArticleDescription(arcContent, collectOffline);
                            long aid = 0;
                            sql = "insert into arc_contents (type_id,cid,title,source_site,description,content,url,hash) values ('" + typeID.ToString() + "'";
                            sql = sql + ",'" + cid.ToString() + "'";
                            sql = sql + ",'" + mySqlDB.EscapeString(arcTitle) + "'";
                            sql = sql + ",'" + mySqlDB.EscapeString(sourceSite) + "'";
                            sql = sql + ",'" + mySqlDB.EscapeString(description) + "'";
                            sql = sql + ",'" + mySqlDB.EscapeString(arcContent) + "'";
                            sql = sql + ",'" + mySqlDB.EscapeString(arcUrl) + "'";
                            sql = sql + ",'" + hash + "')";
                            counts = myDB.executeDMLSQL(sql, ref sResult);
                            if (sResult == mySqlDB.SUCCESS && counts > 0)
                            {
                                aid = myDB.LastInsertedId;
                            }
                            else   //如果插入文章内容出错，则将错误信息记录下来到当前采集对象中，并且中断当前采集过程，提示检查数据库
                            {
                                List<Exception> coException = collectOffline.CoException;
                                Exception mysqlError = new Exception(sResult);
                                coException.Add(mysqlError);
                                tboxErrorOutput.AppendText(string.Format("插入文章内容出错,中断采集过程！请检查数据库连接是否正常！错误信息：{0}\n", mysqlError.Message));
                                collectOffline.CoState = "采集错误";
                                cancelAllTask();
                                updateCoState(collectOffline);
                                return;
                            }
                            if (aid != 0)  //判断文章是否正确插入到数据库中，正确插入文章后返回的ID不会是0
                            {
                                collectOffline.CurrentSavedArticles++;
                                string isAllpicCopied = "yes";     //对应文章表中的is_allpic_copied字段，用来判断文章内容中的图片是否都正确处理了。初始为都能正确处理，如果处理过程中出错则设置为 "no"
                                string litpicUrl = "";
                                long thumbPicID = 0;
                                int picCount = 0;
                                foreach (string imgPath in imgPathList)  //循环处理文章中包含的图片，将图片复制到新的路径，用于图片服务器访问，生成图片最终用于网络访问的URL
                                {
                                    if (testPicFile(imgPath))
                                    {
                                        string fileExtenstion = Path.GetExtension(imgPath);
                                        sResult = "";
                                        counts = 0;
                                        string picFilePath = _cfgBasePath + @"src\"; //用来保存采集的图片要存储在采集服务器上的路径；
                                        string thumbFilePath = _cfgBasePath + @"thumb\"; //用来保存缩略图要存储在采集服务器上的路径；
                                        List<string> thumbListFileName = new List<string>(); //用来保存生成的多种规格缩略图保存路径；

                                        int firstSubDirNum = 0;  //一级子目录编号，同时也是图片域名的子域名编号
                                        int secondSubDirNum = 0;  //二级子目录编号
                                        firstSubDirNum = _cfgPicNum / 100000;
                                        secondSubDirNum = _cfgPicNum % 100000 / 10000;
                                        picFilePath = picFilePath + firstSubDirNum.ToString() + @"\" + secondSubDirNum;
                                        thumbFilePath = thumbFilePath + firstSubDirNum.ToString() + @"\" + secondSubDirNum;
                                        //建立图片目录
                                        if (!Directory.Exists(picFilePath))
                                        {
                                            Directory.CreateDirectory(picFilePath);
                                        }
                                        //建立缩略图目录
                                        if (!Directory.Exists(thumbFilePath))
                                        {
                                            Directory.CreateDirectory(thumbFilePath);
                                        }
                                        //生成图片和缩略图完整路径
                                        string randomFileName = Path.GetRandomFileName();
                                        string picFileName = picFilePath + @"\" + randomFileName + fileExtenstion;
                                        string thumbFileName = thumbFilePath + @"\" + randomFileName + "." + _cfgThumbWidthDefault.ToString() + fileExtenstion;
                                        if (_cfgThumbSizeList.Count>0)
                                        {
                                            foreach (Size thumbSize in _cfgThumbSizeList)
                                            {
                                                string tempFileName= thumbFilePath + @"\" + randomFileName+ "."+thumbSize.Width.ToString() + fileExtenstion;
                                                thumbListFileName.Add(tempFileName);
                                            }
                                        }
                                        //生成图片和缩略图完整URL
                                        string imgUrlPath = @"http://img" + firstSubDirNum.ToString() + @"." + _cfgImgBaseurl + @"/" + secondSubDirNum.ToString() + @"/";
                                        string imgUrl = imgUrlPath + randomFileName + fileExtenstion;
                                        string thumbUrlPath = @"http://thumb" + firstSubDirNum.ToString() + @"." + _cfgImgBaseurl + @"/" + secondSubDirNum.ToString() + @"/";
                                        string thumbUrl = thumbUrlPath + randomFileName + "." + _cfgThumbWidthDefault.ToString() + fileExtenstion;
                                        List<string>thumbListUrl = new List<string>();
                                        if (_cfgThumbSizeList.Count>0)
                                        {
                                            foreach (Size thumbSize in _cfgThumbSizeList)
                                            {
                                                string tempUrl= thumbUrlPath + randomFileName + "." + thumbSize.Width.ToString() + fileExtenstion;
                                                thumbListUrl.Add(tempUrl);
                                            }
                                        }
                                        while (File.Exists(picFileName))  //随机生成新的图片文件名，如果随机文件名重复则要反复生成，直到不重复为止
                                        {
                                            randomFileName = Path.GetRandomFileName();
                                            picFileName = picFilePath + @"\" + randomFileName + fileExtenstion;
                                            imgUrl = imgUrlPath + randomFileName + fileExtenstion;
                                            //拼接缩略图文件完整路径
                                            thumbFileName = thumbFilePath + @"\" + randomFileName + "." + _cfgThumbWidthDefault.ToString() + fileExtenstion;
                                            if (_cfgThumbSizeList.Count > 0)
                                            {
                                                List<string> tempListFileName = new List<string>();
                                                foreach (Size thumbSize in _cfgThumbSizeList)
                                                {
                                                    string tempFileName = thumbFilePath + @"\" + randomFileName + "." + thumbSize.Width.ToString() + fileExtenstion;
                                                    tempListFileName.Add(tempFileName);
                                                }
                                                thumbListFileName = tempListFileName;
                                            }
                                            //拼接缩略图完整URL
                                            thumbUrl = thumbUrlPath + randomFileName + "." + _cfgThumbWidthDefault.ToString() + fileExtenstion;
                                            if (_cfgThumbSizeList.Count > 0)
                                            {
                                                List<string> tempListUrl = new List<string>();
                                                foreach (Size thumbSize  in _cfgThumbSizeList)
                                                {
                                                    string tempUrl = thumbUrlPath + randomFileName + "." + thumbSize.Width.ToString() + fileExtenstion;
                                                    tempListUrl.Add(tempUrl);
                                                }
                                                thumbListUrl = tempListUrl;
                                            }
                                        }
                                        try
                                        {
                                            File.Copy(imgPath, picFileName);   //将源图片复制到新的路径中，用于图片服务器访问
                                            sql = "insert into arc_pics(cid,aid,ssid,pic_path,source_path,pic_url) values ('" + cid.ToString() + "'";
                                            sql = sql + ",'" + aid.ToString() + "'";
                                            sql = sql + ",'" + sourceSiteID.ToString() + "'";
                                            sql = sql + ",'" + mySqlDB.EscapeString(picFileName) + "'";
                                            sql = sql + ",'" + mySqlDB.EscapeString(imgPath) + "'";
                                            sql = sql + ",'" + imgUrl + "')";
                                            counts = myDB.executeDMLSQL(sql, ref sResult);
                                            if (sResult == mySqlDB.SUCCESS && counts > 0)
                                            {
                                                _cfgPicNum++;
                                                picCount++;
                                                if (!updateCfgPicnum(collectOffline))   //如果更新数据系统配置表中的图片总数参数失败的话，就退出当前图片处理过程，不然的话会导致图片总数出问题。
                                                {
                                                    List<Exception> coException = collectOffline.CoException;
                                                    Exception ex = new Exception("更新数据系统配置表中的图片总数参数失败！中断保存采集文章！请检查数据库连接是否正常！");
                                                    ex.Data.Add("文章ID", aid);
                                                    ex.Data.Add("文章标题", arcTitle);
                                                    ex.Data.Add("文章路径", arcUrl);
                                                    ex.Data.Add("图片源路径", imgPath);
                                                    ex.Data.Add("图片新路径", picFileName);
                                                    coException.Add(ex);
                                                    tboxErrorOutput.AppendText(string.Format("处理文章图片出错！文章ID：{0} 图片源路径：{1} 图片新路径：{2} 错误信息：{3}\n", aid, imgPath, picFileName, ex.Message));
                                                    collectOffline.CoState = "采集错误";
                                                    cancelAllTask();
                                                    updateCoState(collectOffline);
                                                    return;
                                                }
                                                arcContent = arcContent.Replace(imgPath, imgUrl);
                                                //如果数据库中配置了生成多种规格缩略图参数则按生成多种缩略图规格参数来生成缩略图
                                                if (_cfgThumbSizeList.Count>0)
                                                {
                                                    for (int i = 0; i < thumbListFileName.Count; i++)
                                                    {
                                                        bool isThumbGenerated = false;
                                                        Size thumbSize = _cfgThumbSizeList[i];
                                                        if (thumbSize.Height==0)
                                                        {
                                                            isThumbGenerated = ArcTool.MakeThumb(picFileName, thumbListFileName[i], thumbSize.Width, 0, "W");
                                                        }
                                                        else
                                                        {
                                                            isThumbGenerated = ArcTool.MakeThumb(picFileName, thumbListFileName[i], thumbSize.Width, thumbSize.Height, "Cut");
                                                        }
                                                        if (isThumbGenerated)
                                                        {
                                                            updateThumbStatus(collectOffline, myDB.LastInsertedId);
                                                        }
                                                        if (litpicUrl=="")
                                                        {
                                                            thumbPicID = myDB.LastInsertedId;
                                                            if (isThumbGenerated)
                                                            {
                                                                litpicUrl = thumbListUrl[i];
                                                            }
                                                            else
                                                            {
                                                                litpicUrl = imgUrl;
                                                            }
                                                        }
                                                    }
                                                }
                                                else   //如果数据库中没有配置生成多种规格缩略图参数则按默认缩略图规格参数来生成缩略图
                                                {
                                                    bool isThumbGenerated = ArcTool.MakeThumb(picFileName, thumbFileName, _cfgThumbWidthDefault,_cfgThumbHeightDefault, "Cut");
                                                    if (litpicUrl == "")
                                                    {
                                                        thumbPicID = myDB.LastInsertedId;
                                                        //如果正确生成图片缩略图，则将缩略图设置为缩略图URL，否则使用图片url作为缩略图
                                                        if (isThumbGenerated)
                                                        {
                                                            litpicUrl = thumbUrl;
                                                            updateThumbStatus(collectOffline, thumbPicID);
                                                        }
                                                        else
                                                        {
                                                            litpicUrl = imgUrl;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch (Exception ex) //如果复制图片过程中出错的话，保存出错异常，退出当前处理过程
                                        {
                                            List<Exception> coException = collectOffline.CoException;
                                            ex.Data.Add("文章ID", aid);
                                            ex.Data.Add("文章标题", arcTitle);
                                            ex.Data.Add("文章路径", arcUrl);
                                            ex.Data.Add("图片源路径", imgPath);
                                            ex.Data.Add("图片新路径", picFileName);
                                            coException.Add(ex);
                                            tboxErrorOutput.AppendText(string.Format("处理文章图片出错！请检查磁盘访问是否正常！文章ID：{0} 图片源路径：{1} 图片新路径：{2} 错误信息：{3}\n", aid, imgPath, picFileName, ex.Message));
                                            collectOffline.CoState = "采集错误";
                                            cancelAllTask();
                                            updateCoState(collectOffline);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        arcContent = arcContent.Replace(imgPath, _cfgPicNone);
                                    }
                                } //循环处理文章中的图片结束
                                bool isArcContentUpdated = updateArcContent(collectOffline, aid, arcContent, litpicUrl, isAllpicCopied, thumbPicID,picCount); //更新处理完毕后的文章内容和缩略图
                                if (!isArcContentUpdated)  //如果文章更新失败退出当前处理过程
                                {
                                    List<Exception> coException = collectOffline.CoException;
                                    Exception ex = new Exception("保存文章过程中，处理完文章内容中图片和缩略图后，更新文章内容出错！中断保存采集文章！");
                                    ex.Data.Add("文章ID", aid);
                                    ex.Data.Add("文章标题", arcTitle);
                                    ex.Data.Add("文章路径", arcUrl);
                                    coException.Add(ex);
                                    tboxErrorOutput.AppendText(string.Format("保存文章出错,请检查数据库连接是否正常！文章ID：{0} 文章标题：{1}  错误信息：{2}\n", aid, arcTitle, ex.Message));
                                    collectOffline.CoState = "采集错误";
                                    cancelAllTask();
                                    updateCoState(collectOffline);
                                    return;
                                }

                            }  //判断文章是否正确插入到数据库结束
                        }  //判断文章是否至少包含一张能正确打开的图片
                    }  //循环处理文章结束
                }//判断是否正确获取栏目ID和来源网站ID
                else
                {
                    List<Exception> coException = collectOffline.CoException;
                    Exception ex = new Exception("保存文章-获取采集分类ID（tid）来源网址ID错误！请检查数据库连接是否正常！");
                    ex.Data.Add("分类名称", typeName);
                    ex.Data.Add("来源网址", sourceSite);
                    coException.Add(ex);
                    tboxErrorOutput.AppendText(string.Format("获取采集分类ID（tid）来源网址ID错误！请检查数据库连接是否正常！分类名称: {0} 来源网址: {1}",typeName,sourceSite));
                    collectOffline.CoState = "采集错误";
                    cancelAllTask();
                    return;
                }
            }
            else
            {
                Exception ex = new Exception("获取系统设置参数失败，请确认sys_config表中对应的cfg_basepath，cfg_pic_num，cfg_img_baseurl变量初始值是否正确设置！");
                List<Exception> coException = collectOffline.CoException;
                coException.Add(ex);
                tboxErrorOutput.AppendText(string.Format("错误信息：{0} 中断保存采集文章！", ex.Message));
                collectOffline.CoState = "采集错误";
                cancelAllTask();
                return;
            }
            updateCoState(collectOffline);
            printErrors(collectOffline.CoException);
            collectOffline.CoState = "采集结束";
            Thread.Sleep(2000);   //延时2秒，等待监控状态最后一次更新完毕
            collectOffline.CoState = "采集完毕";
            Thread.Sleep(2000);

            removeOneCollection(cid);   //从监控列表中移除保存完毕的采集对象

            //保存文章结束后开始下一个采集任务
            ThreadPool.QueueUserWorkItem(startOneTask, null);
        }


        private delegate ArticleCollectOffline CollectProcess(ArticleCollectOffline collectOffline);

        //获得列表页清单
        private ArticleCollectOffline ProcessListPages(ArticleCollectOffline collectOffline)
        {
            collectOffline.ProcessListPages();
            return collectOffline;
        }
        //获得文章页清单
        private ArticleCollectOffline ProcessArticlePages(ArticleCollectOffline collectOffline)
        {
            collectOffline.ProcessArticlePages();
            return collectOffline;
        }
        //采集文章内容
        private ArticleCollectOffline ProcessCollectArticles(ArticleCollectOffline collectOffline)
        {
            collectOffline.ProcessCollectArticles();
            return collectOffline;
        }

        //异步执行获取列表文档结束
        private void ProcessListPagesComplete(IAsyncResult itfAR)
        {
            //异步执行获取列表文档完毕后，获得异步返回的结果，继续异步执行下一步（获取文章URL集合）
            CollectProcess collectProcessListPages = (CollectProcess)((AsyncResult)itfAR).AsyncDelegate;
            ArticleCollectOffline collectOffline = collectProcessListPages.EndInvoke(itfAR);
            if (collectOffline.CancelException == null)
            {
                CollectProcess collectProcessArticlePages = new CollectProcess(ProcessArticlePages);
                collectProcessArticlePages.BeginInvoke(collectOffline, ProcessArticlePagesComplete, null);
            }
            else
            {
                try
                {
                    tboxErrorOutput.AppendText(string.Format("终止获取列表页：{0} \n", collectOffline.CancelException.Message));
                    tboxErrorOutput.AppendText(string.Format("当前获取列表页位置：{0}\n", collectOffline.CurrentProcessedListPages));
                    tboxErrorOutput.AppendText(string.Format("总共需要处理列表页面数：{0}\n", collectOffline.CancelException.Data["TotalListPages"]));
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
            }
        }

        //异步执行获取文章URL集合结束
        private void ProcessArticlePagesComplete(IAsyncResult itfAR)
        {
            //异步执行获取文章URL集合完毕后，获得异步返回的结果，继续异步执行下一步（采集文档内容）
            CollectProcess collectProcessArticlePages = (CollectProcess)((AsyncResult)itfAR).AsyncDelegate;
            ArticleCollectOffline collectOffline = collectProcessArticlePages.EndInvoke(itfAR);
            if (collectOffline.CancelException == null)
            {
                //去除当前采集对象中已经采集过的文章URL
                removeDumpArcpages(collectOffline); 
                //执行下一步采集文章操作
                CollectProcess collectProcessCollectArticles = new CollectProcess(ProcessCollectArticles);
                collectProcessCollectArticles.BeginInvoke(collectOffline, ProcessCollectArticlesComplete, null);
            }
            else
            {
                try
                {
                    tboxErrorOutput.AppendText(string.Format("终止获取列表页：{0} \n", collectOffline.CancelException.Message));
                    tboxErrorOutput.AppendText(string.Format("当前处理列表页位置：{0}\n", collectOffline.CurrentProcessedListPages));
                    tboxErrorOutput.AppendText(string.Format("总共需要处理列表页面数：{0}\n", collectOffline.CancelException.Data["TotalListPages"]));
                    tboxErrorOutput.AppendText(string.Format("当前处理文章链接数：{0}\n", collectOffline.CurrentGetArticlePages));
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
            }
            /*
            //输出URL集合信息
            List<string> correctListArticles = collectOffline.CorrectArticlePages;
            List<string> wrongListArticles = collectOffline.WrongArticlePages;
            tboxErrorOutput.AppendText("待采集文章链接：\n");
            foreach (string item in correctListArticles)
            {
                tboxErrorOutput.AppendText(string.Format("{0}\n", item));
            }
            tboxErrorOutput.AppendText("-------------------------------------------------------------------------------\n");
            tboxErrorOutput.AppendText("未能正确匹配内容链接，请检查匹配XPATH规则： \n");
            foreach (string item in wrongListArticles)
            {
                tboxErrorOutput.AppendText(string.Format("{0}\n", item));
            }
            */
        }

        //异步执行采集文章结束
        private void ProcessCollectArticlesComplete(IAsyncResult itfAR)
        {
            //异步执行采集文章内容完成后
            CollectProcess collectProcessCollectArticles = (CollectProcess)((AsyncResult)itfAR).AsyncDelegate; 
            ArticleCollectOffline collectOffline = collectProcessCollectArticles.EndInvoke(itfAR);
            //输出采集文档信息
            if (collectOffline.CancelException == null)
            {
                /*
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
                */
                saveArticles(collectOffline);
            }
            else
            {
                try
                {
                    tboxErrorOutput.AppendText(string.Format("当前采集文章数：{0}\n", collectOffline.CurrentProcessedArticles));
                    tboxErrorOutput.AppendText(string.Format("此次总共需要采集文章数：{0}\n", collectOffline.CancelException.Data["TotalArticles"]));
                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000);
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
            }

            /*
            List<Exception> coException = collectOffline.CoException;
            printErrors(coException);
            List<Dictionary<string, string>> articles = collectOffline.Articles;

            tboxErrorOutput.AppendText(string.Format("采集文章总数：{0} \n", articles.Count));
            tboxErrorOutput.AppendText("-----------------------------------------------------------------------------------\n");
            var arcList = from d in articles
                          orderby d["title"]
                          ascending
                          select d;

            foreach (Dictionary<string, string> article in arcList)
            {
                foreach (KeyValuePair<string, string> kvp in article)
                {
                    tboxErrorOutput.AppendText(kvp.Key + ": \n");
                    tboxErrorOutput.AppendText(kvp.Value + "\n");
                }
                tboxErrorOutput.AppendText("---------------------------------------------\n");
            }
            */
        }


        public void StartCoTask()
        {
            initializeForm();
            tboxErrorOutput.AppendText(string.Format("System.Environment.ProcessorCount: {0}\n", System.Environment.ProcessorCount));
            _timerUpdateForm = new System.Threading.Timer(
                updateForm,   //TimerCallBack委托对象
                              //PrintTime,
                null,                 //想传入的参数 （null表示没有参数）
                1000,                    //在开始之前，等待多长时间（以毫秒为单位）
                1000               //每次调用的间隔时间（以毫秒为单位）
                );

            swGlobal.Start();
            //采集任务队列只采用单进程来完成！！切记，否则存储采集文章时会出错
            //同时因为核心采集类中已经使用多线程进行采集，所以此处采用多线程来完成采集任务队列也并不能加快速度
            ThreadPool.QueueUserWorkItem(startOneTask,null);
        }

        private void startOneTask(object state)
        {
            long cid = getOneCid();
            if (cid!=-1)
            {
                mySqlDB myDB = new mySqlDB(_connString);
                int counts = 0;
                string sResult = "";
                string sql = "select * from co_config where cid = '" + cid + "'";
                List<Dictionary<string, object>> coConfigRecords = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    Dictionary<string, object> dicConfig = coConfigRecords[0];
                    Dictionary<string, string> checkFields = new Dictionary<string, string>();
                    checkFields.Add("co_name", dicConfig["co_name"].ToString());
                    checkFields.Add("source_lang", dicConfig["source_lang"].ToString());
                    checkFields.Add("type_name", dicConfig["type_name"].ToString());
                    checkFields.Add("source_site", dicConfig["source_site"].ToString());
                    checkFields.Add("co_offline", dicConfig["co_offline"].ToString());
                    checkFields.Add("list_path", dicConfig["list_path"].ToString());
                    checkFields.Add("start_page_number", dicConfig["start_page_number"].ToString());
                    checkFields.Add("stop_page_number", dicConfig["stop_page_number"].ToString());
                    checkFields.Add("xpath_arcurl_node", dicConfig["xpath_arcurl_node"].ToString());
                    checkFields.Add("xpath_title_node", dicConfig["xpath_title_node"].ToString());
                    checkFields.Add("xpath_content_node", dicConfig["xpath_content_node"].ToString());
                    checkFields.Add("arc_subpage_symbol", dicConfig["arc_subpage_symbol"].ToString());
                    checkFields.Add("arc_subpage_startnum", dicConfig["arc_subpage_startnum"].ToString());
                    if (!validateCoConfig(checkFields))
                    {
                        tboxErrorOutput.AppendText(string.Format("采集规则: (ID:{0}) 配置检查错误，请重新编辑采集规则项，确认必填项数据都已正确填写！ \n", cid));
                    }
                    else
                    {
                        string listPath = dicConfig["list_path"].ToString();
                        int listStartPageNum = int.Parse(dicConfig["start_page_number"].ToString());
                        int listStopPageNum = int.Parse(dicConfig["stop_page_number"].ToString());
                        string xpathArcurlNode = dicConfig["xpath_arcurl_node"].ToString();
                        string xpathTitleNode = dicConfig["xpath_title_node"].ToString();
                        string xpathContentNode = dicConfig["xpath_content_node"].ToString();
                        string arcSubPageSymbol = dicConfig["arc_subpage_symbol"].ToString();
                        int arcSubPageStartNum = int.Parse(dicConfig["arc_subpage_startnum"].ToString());
                        List<string> moreListPages = new List<string>();
                        List<string> subNodeParams = new List<string>();
                        List<string> regexParams = new List<string>();
                        if (!string.IsNullOrWhiteSpace(dicConfig["more_list_pages"].ToString()))
                        {
                            moreListPages = getLines(dicConfig["more_list_pages"].ToString());
                        }
                        if (!string.IsNullOrWhiteSpace(dicConfig["sub_node_params"].ToString()))
                        {
                            subNodeParams = getLines(dicConfig["sub_node_params"].ToString());
                        }
                        if (!string.IsNullOrWhiteSpace(dicConfig["regex_params"].ToString()))
                        {
                            regexParams = getLines(dicConfig["regex_params"].ToString());
                        }
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        ArticleCollectOffline collectOffline = new ArticleCollectOffline(cid,listPath, listStartPageNum, listStopPageNum, xpathArcurlNode, xpathTitleNode, xpathContentNode, subNodeParams, regexParams, arcSubPageSymbol, arcSubPageStartNum);
                        if (moreListPages != null)
                        {
                            collectOffline.AddListPages(moreListPages);
                        }
                        collectOffline.CancelToken = cancelToken;
                        collectOffline.TypeName = dicConfig["type_name"].ToString();
                        collectOffline.SourceSite = dicConfig["source_site"].ToString();
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        CollectProcess collectProcessListPages = new CollectProcess(ProcessListPages);
                        collectProcessListPages.BeginInvoke(collectOffline, ProcessListPagesComplete, null);

                        //创建新的Dictionary集合，其中包括采集对象，包括用来监控耗时的Stopwatch对象
                        Dictionary<string, object> oneCollect = new Dictionary<string, object>();
                        oneCollect.Add("collect", collectOffline);
                        oneCollect.Add("watch", sw);

                        //将当前采集对象添加到全局用来监控采集进程的采集对象集合中。
                        bool addResult = false;
                        do
                        {
                            addResult=_articleCoCollections.TryAdd(cid, oneCollect);
                        } while (!addResult);
                    }
                }
                else
                {
                    tboxErrorOutput.AppendText(string.Format("采集规则(ID:{0}) 读取数据库采集配置错误！：{1} \n", cid, sResult));
                }
            }

        }  //END Of StartOneTask

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            cancelAllTask();
        }

        private void btnCancelSellect_Click(object sender, EventArgs e)
        {
            cancelCurrentTask();
        }
    }
}
