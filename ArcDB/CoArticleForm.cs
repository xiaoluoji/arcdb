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
using SharpConfig;
using Murmur;
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
        private ConcurrentDictionary<long, Dictionary<string, object>> _articleCollections; //采集对象集合，每一个集合中包括一个ArticleCollectOffline采集对象， 一个监控耗时的stopwatch对象
        private Dictionary<long, string> _dicCids;                                                       //采集规则ID和采集名称集合，
        private string _connString;                                                                               //数据库连接字符串
        System.Threading.Timer _timerUpdateForm;                                                  //listViewCoArticles状态更新定时器
        private Queue<long> _queueCids;                                                                  //采集规则ID队列
        Stopwatch swGlobal = new Stopwatch();

        public CoArticleForm(string connString,Dictionary<long,string>dicCids)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            _articleCollections = new ConcurrentDictionary<long, Dictionary<string, object>>();
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
            foreach (var collectItem in _articleCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    if (currentCollectWork.CoState != "采集结束" && currentCollectWork.CancelException == null && dic != null)
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
                        string timeUsed = currentWatch.Elapsed.ToString();
                        currentItem.SubItems[7].Text = timeUsed.Remove(8, 8);
                        listViewCoArticles.EndUpdate();
                    }
                    else if (dic == null)
                    {
                        tboxErrorOutput.AppendText(string.Format("ID: {0} NULL \n", currentCid));
                    }
                    if (_articleCollections.Count > 0)
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

        //取消所有采集任务
        private void cancelAllTask()
        {
            _queueCids.Clear();
            foreach (var collectItem in _articleCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    currentCollectWork.CancelToken.Cancel();
                }
                catch (Exception)
                {

                }
            }
        }
        //取消当前采集任务
        private void cancelCurrentTask()
        {
            foreach (var collectItem in _articleCollections)
            {
                try
                {
                    Dictionary<string, object> dic = collectItem.Value;
                    long currentCid = collectItem.Key;
                    ArticleCollectOffline currentCollectWork = (ArticleCollectOffline)dic["collect"];
                    currentCollectWork.CancelToken.Cancel();
                }
                catch (Exception)
                {

                }
            }
        }

        //检查必填项是否正确填写，这里暂时只是用 string.IsNullOrWhiteSpace()判断是否为空值，未做进一步校验，以后完善
        private bool validateCoConfig(Dictionary<string,string> coConfigs)
        {
            foreach (KeyValuePair<string,string> kvp in coConfigs)
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
            foreach (KeyValuePair<long,string> kvp in _dicCids)
            {
                string[] subItems = new string[] { "待采集",kvp.Key.ToString(), kvp.Value,"0","0","0","0","0"};
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
        private long getOneCid() 
        {
            long cid = -1;
            lock (_queueCids)
            {
                if (_queueCids.Count>0)
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
                removed = _articleCollections.TryRemove(cid, out oneCollection);
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
        private void removeDumpArcpages(ArticleCollectOffline collectOffline)
        {
            List<string> articlePages = collectOffline.CorrectArticlePages;
            //collectOffline.CorrectArticlePages = null;
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

                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);

            }

            //输出列表文档的信息
            /*
            List<string> listPages = collectOffline.ListPages;
            tboxErrorOutput.AppendText(string.Format("本次获取列表页面数：{0}\n", listPages.Count));
            */
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
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
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
                long cid = collectOffline.Cid;
                removeOneCollection(cid);
                ThreadPool.QueueUserWorkItem(startOneTask, null);
            }


            //startOneTask(new object());
            /*
            printErrors(coException);
            List<Dictionary<string, string>> articles = collectOffline.Articles;
            List<Exception> coException = collectOffline.CoException;

            
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
                            addResult=_articleCollections.TryAdd(cid, oneCollect);
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
