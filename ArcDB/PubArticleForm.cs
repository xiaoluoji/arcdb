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
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections;
using System.Collections.Concurrent;

namespace ArcDB
{
    public partial class PubArticleForm : Form
    {
        private List<string> _ListPubID;                                                                                             //需要发布的发布规则ID列表
        private string _coConnString;                                                                                                //采集数据库连接配置
        private string _pubConnString;                                                                                             //发布数据库连接配置
        private string _pubTablePrename;                                                                                        //发布数据库表前缀
        private ConcurrentDictionary<int, Dictionary<string, object>> _articlePubCollections;   //发布对象集合，每一个集合中包括一个ArticlePublish发布对象， 一个监控耗时的stopwatch对象
        private Queue<int> _queuePubID;                                                                                    //发布规则ID队列
        private Stopwatch swGlobal = new Stopwatch();                                                                 //监控总任务时间
        private List<Exception> _listException;                                                                                 //保存错误异常信息
        System.Threading.Timer _timerUpdateForm;                                                                    //listViewCoArticles状态更新定时器



        public PubArticleForm(List<string> listPubID, string coConnString, string pubConnString, string pubTablePrename)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            _ListPubID = listPubID;
            _coConnString = coConnString;
            _pubConnString = pubConnString;
            _pubTablePrename = pubTablePrename;
            _articlePubCollections = new ConcurrentDictionary<int, Dictionary<string, object>>();
            _queuePubID = new Queue<int>();
            _listException = new List<Exception>();
        }

        private void initializeForm()
        {
            mySqlDB coMyDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql;
            listViewPubArticles.BeginUpdate();
            foreach (string item in _ListPubID)
            {
                int pubID = int.Parse(item);
                sql = "select * from pub_config where id='" + item + "'";
                List<Dictionary<string, object>> pubConfigRecords = coMyDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult==mySqlDB.SUCCESS && counts>0)
                {
                    _queuePubID.Enqueue(pubID);
                    string pubName = pubConfigRecords[0]["pub_name"].ToString();
                    string coTypename = pubConfigRecords[0]["co_typename"].ToString();
                    string pubTypename = pubConfigRecords[0]["pub_typename"].ToString();
                    string pubNums = pubConfigRecords[0]["pub_nums"].ToString();
                    string[] subItems = new string[] {"待发布",item,pubName,coTypename,pubTypename,pubNums,"0","0"};
                    ListViewItem listItem = new ListViewItem(subItems);
                    listViewPubArticles.Items.Add(listItem);
                }
            }
            listViewPubArticles.EndUpdate();
            listViewPubArticles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewPubArticles.GridLines = true;
        }
        private void PubArticleForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void PubArticleForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        //用来监控当前并行采集中的各个进程的进度状态
        private void updateForm(object state)
        {
            foreach (var collectItem in _articlePubCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    int currentPubID = collectItem.Key;
                    ArticlePublish currentCollectWork = (ArticlePublish)dic["publish"];
                    if (currentCollectWork.PubState != "发布完毕"  && dic != null)
                    {
                        Stopwatch currentWatch = (Stopwatch)dic["watch"];
                        ListViewItem currentItem = listViewPubArticles.Items.Cast<ListViewItem>().First(item => item.SubItems[1].Text == currentPubID.ToString());
                        listViewPubArticles.BeginUpdate();
                        if (currentCollectWork.PubState != "")
                        {
                            currentItem.SubItems[0].Text = currentCollectWork.PubState;
                        }
                        currentItem.SubItems[6].Text = currentCollectWork.CurrentExportedArticles.ToString();
                        string timeUsed = currentWatch.Elapsed.ToString();
                        currentItem.SubItems[7].Text = timeUsed.Remove(8, 8);
                        listViewPubArticles.EndUpdate();
                    }
                    else if (dic == null)
                    {
                        tboxErrorOutput.AppendText(string.Format("ID: {0} NULL \n", currentPubID));
                    }
                    if (_articlePubCollections.Count > 0)
                    {
                        labTime.Text = string.Format("总共耗时： {0}\n", swGlobal.Elapsed.ToString());
                    }
                    else
                    {
                        swGlobal.Stop();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        //从_articlePubCollections监控采集状态集合中移出一条已经完成采集的记录
        private void removeOneCollection(int pubID)
        {
            Dictionary<string, object> oneCollection = null;
            bool removed = false;
            do
            {
                removed = _articlePubCollections.TryRemove(pubID, out oneCollection);
            } while (!removed);
        }

        //从需要执行的采集Cid队列中获取一条CID记录
        private object queueLock = new object();
        private int getOnePubID()
        {
            int pubID = -1;
            lock (queueLock)
            {
                if (_queuePubID.Count > 0)
                {
                    pubID = _queuePubID.Dequeue();
                }
            }
            return pubID;
        }
        //检查当前需要发布的发布规则中的配置是否正确
        private bool validatePubConfig(Dictionary<string,string>testConfig)
        {
            foreach (KeyValuePair<string,string> kvp in testConfig)
            {
                if (string.IsNullOrWhiteSpace(kvp.Value))
                {
                    return false;
                }
            }
            try
            {
                int coTypeID = int.Parse(testConfig["co_typeid"]);
                int pubTypeID = int.Parse(testConfig["pub_typeid"]);
                int pubNums = int.Parse(testConfig["pub_nums"]);
                DateTime randomDateStart = DateTime.Parse(testConfig["random_date_start"]);
                DateTime randomDateStop = DateTime.Parse(testConfig["random_date_stop"]);
                TimeSpan ts = randomDateStop - randomDateStart;
                if (ts.TotalDays < 0)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //输出发布过程中的错误信息
        private void printErrors(ArticlePublish articlePublish)
        {
            //输出错误信息
            Exception cancelException = articlePublish.CancelException;
            if (cancelException != null)
            {
                tboxErrorOutput.AppendText(cancelException.Message + "\n");
                if (cancelException.Data != null)
                {
                    foreach (DictionaryEntry de in cancelException.Data)
                    {
                        tboxErrorOutput.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                    }
                }
            }
            List<Exception> listException = articlePublish.PubException;
            if (listException.Count > 0)
            {
                foreach (Exception item in listException)
                {
                    tboxErrorOutput.AppendText(item.Message + "\n");
                    if (item.Data != null)
                    {
                        foreach (DictionaryEntry de in item.Data)
                        {
                            tboxErrorOutput.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                        }
                    }
                }
            }
        }

        //完成发布任务后更新发布表中对应发布规则的已发布数量
        private void updatePublishState(ArticlePublish articlePublish)
        {
            int pubID = articlePublish.PubID;
            int coTypeID = articlePublish.CoTypeID;
            int publishedNums = articlePublish.CurrentExportedArticles;
            mySqlDB coMyDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            //更新发布配置表中的信息
            string sql = "update pub_config set published_nums=published_nums+'" + publishedNums.ToString() + "'";
            sql = sql + ",pub_export_date = CURRENT_TIMESTAMP where id = '" + pubID.ToString() + "'";
            sql =sql+" where id = '" + pubID.ToString() + "'";
            counts = coMyDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS)
            {
                List<Exception> pubException = articlePublish.PubException;
                Exception mysqlError = new Exception(sResult);
                pubException.Add(mysqlError);
            }
            //更新分类表中的统计信息，发不完以后对应的分类中的可发布数量应该减去当前的数量
            sql = "update arc_type set unused_nums=unused_nums-'" + publishedNums.ToString() + "'";
            sql = sql + " where tid='" + coTypeID.ToString() + "'";
            counts = coMyDB.executeDMLSQL(sql, ref sResult);
            if (sResult != mySqlDB.SUCCESS)
            {
                List<Exception> pubException = articlePublish.PubException;
                Exception mysqlError = new Exception(sResult);
                pubException.Add(mysqlError);
            }
        }

        private delegate ArticlePublish PublishProcess(ArticlePublish articlePublish);

        private ArticlePublish ProcessPublishArticles(ArticlePublish articlePublish)
        {
            articlePublish.ProcessPublishArticles();
            return articlePublish;
        }

        private void ProcessPublishArticlesComplete(IAsyncResult itfAR)
        {
            PublishProcess publishProcesArticles = (PublishProcess)((AsyncResult)itfAR).AsyncDelegate;
            ArticlePublish articlePublish = publishProcesArticles.EndInvoke(itfAR);
            long aid = articlePublish.LastExportedCoid;
            long cmsAid = articlePublish.LastExportedCmsid;
            int pubID = articlePublish.PubID;

            //输出错误信息
            printErrors(articlePublish);
            //更新对应发布规则的已发布数量
            updatePublishState(articlePublish);

            articlePublish.PubState = "发布结束";
            Thread.Sleep(2000);   //延时2秒，等待监控状态最后一次更新完毕
            articlePublish.PubState = "发布完毕";
            Thread.Sleep(2000);   //延时2秒，等待监控状态最后一次更新完毕

            //移除当前正在监控的发布任务
            removeOneCollection(pubID);

            //继续执行下一个发布任务
            ThreadPool.QueueUserWorkItem(startOneTask, null);

        }

        //开始执行发布任务
        public void StartPubTask()
        {
            initializeForm();
            _timerUpdateForm = new System.Threading.Timer(
                updateForm,   //TimerCallBack委托对象
                              //PrintTime,
                null,                 //想传入的参数 （null表示没有参数）
                1000,                    //在开始之前，等待多长时间（以毫秒为单位）
                1000               //每次调用的间隔时间（以毫秒为单位）
                );
            swGlobal.Start();
            ThreadPool.QueueUserWorkItem(startOneTask, null);

        }

        private void startOneTask(object state)
        {
            int pubID = getOnePubID();
            if (pubID != -1)
            {
                mySqlDB coMyDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string sql = "select * from pub_config where id='" + pubID.ToString() + "'";
                List<Dictionary<string, object>> pubConfigRecords = coMyDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    Dictionary<string, object> dicConfig = pubConfigRecords[0];
                    Dictionary<string, string> checkFields = new Dictionary<string, string>();
                    checkFields.Add("id",dicConfig["id"].ToString());
                    checkFields.Add("pub_name", dicConfig["pub_name"].ToString());
                    checkFields.Add("co_typeid", dicConfig["co_typeid"].ToString());
                    checkFields.Add("co_typename", dicConfig["co_typename"].ToString());
                    checkFields.Add("pub_typeid", dicConfig["pub_typeid"].ToString());
                    checkFields.Add("pub_typename", dicConfig["pub_typename"].ToString());
                    checkFields.Add("pub_nums", dicConfig["pub_nums"].ToString());
                    checkFields.Add("random_date_start", dicConfig["random_date_start"].ToString());
                    checkFields.Add("random_date_stop", dicConfig["random_date_stop"].ToString());
                    if (!validatePubConfig(checkFields))
                    {
                        tboxErrorOutput.AppendText(string.Format("采集规则: (ID:{0}) 配置检查错误，请重新编辑采集规则项，确认必填项数据都已正确填写！ \n", pubID));
                    }
                    else
                    {
                        int coTypeid = int.Parse(dicConfig["co_typeid"].ToString());
                        int pubTypeid = int.Parse(dicConfig["pub_typeid"].ToString());
                        int pubNums = int.Parse(dicConfig["pub_nums"].ToString());
                        string randomDateStart = dicConfig["random_date_start"].ToString();
                        string randomDateStop = dicConfig["random_date_stop"].ToString();
                        ArticlePublish articlePublish = new ArticlePublish(pubID, _coConnString, _pubConnString, _pubTablePrename, coTypeid, pubTypeid, pubNums, randomDateStart, randomDateStop);
                        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                        articlePublish.CancelTokenSource = cancelTokenSource;
                        //articlePublish.ProcessPublishArticles();
                        //创建发布任务的监控时钟，并且开始记时
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        //通过委托代理异步执行发布任务
                        PublishProcess publishProcesArticles = new PublishProcess(ProcessPublishArticles);
                        publishProcesArticles.BeginInvoke(articlePublish, ProcessPublishArticlesComplete, null);


                        //创建新的Dictionary集合，其中包括采集对象，包括用来监控耗时的Stopwatch对象
                        Dictionary<string, object> oneCollect = new Dictionary<string, object>();
                        oneCollect.Add("publish", articlePublish);
                        oneCollect.Add("watch", sw);

                        //将当前采集对象添加到全局用来监控采集进程的采集对象集合中。
                        bool addResult = false;
                        do
                        {
                            addResult = _articlePubCollections.TryAdd(pubID, oneCollect);
                        } while (!addResult);
                    }

                }
                else
                {
                    tboxErrorOutput.AppendText(string.Format("发布规则(ID:{0}) 读取数据库采集配置错误！：{1} \n", pubID, sResult));
                }
            }
        }
    }
}
