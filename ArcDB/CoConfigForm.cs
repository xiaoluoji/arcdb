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

namespace ArcDB
{
    public partial class CoConfigForm : Form
    {
        private readonly string RootPath = Application.StartupPath + @"\";   /*程序根目录*/
        private string _connString;
        private long _cid;
        private string _coName;
        private string _sourceLang;
        private string _typeName;
        private string _sourceSite;
        private string _coOffline;
        private string _listPath;
        private string _startPageNumber;
        private string _stopPageNumber;
        private string _moreListPages;
        private string _xpathArcurlNode;
        private string _xpathTitleNode;
        private string _xpathContentNode;
        private string _arcSubPageSymbol;
        private string _arcSubPageStartNum;
        private string _subNodeParams;
        private string _regexParams;
        private Stopwatch swGlobal = new Stopwatch();
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        //构造函数
        public CoConfigForm(string connString,long cid)
        {
            _connString = connString;
            _cid = cid;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        //表单加载时候的执行的操作
        private void CoForm_Load(object sender, EventArgs e)
        {
            if (_cid!=-1)   // _cid 为-1 表示表单是执行添加采集规则的操作，否则就是修改现有采集规则
            {
                displayConfig();
            }
        }

        //表单关闭时候执行的操作
        private void CoForm_Closing(object sender, FormClosingEventArgs e)
        {
            string showMessage = "";
            if (_cid==-1)
            {
                showMessage = "放弃添加新规则？放弃请选择“是”";
            }
            else
            {
                showMessage = "将要推出采集规则编辑，请确认是否保存规则，是否退出编辑？";
            }
            if (MessageBox.Show(showMessage, "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TabctrCoform_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabctrCoform.SelectedTab = tabCoTest;
        }
        //将各项配置对应的变量更新为对应控件中的值
        private void setVarValue()
        {
            _coName = tboxCoName.Text;
            _sourceLang = cboxCoSource_Lang.Text;
            _typeName = cboxCoTypeName.Text;
            _sourceSite = cboxCoSource_Site.Text;
            if (rbtnCo_Offline_yes.Checked)
            {
                _coOffline = "yes";
            }
            else
            {
                _coOffline = "no";
            }
            _listPath = tboxCoListPath.Text;
            _startPageNumber = tboxCoStartPageNumber.Text;
            _stopPageNumber = tboxCoStopPageNumber.Text;
            _moreListPages = tboxMoreListPages.Text;
            _xpathArcurlNode = tboxXpathArcurlNode.Text;
            _xpathTitleNode = tboxXpathTitleNode.Text;
            _xpathContentNode = tboxXpathContentNode.Text;
            _arcSubPageSymbol = tboxArcSubpageSymbol.Text;
            _arcSubPageStartNum = tboxArcSubpageStartNum.Text;
            _subNodeParams = tboxSubNodeParams.Text;
            _regexParams = tboxRegexParams.Text;
        }

        //检查必填项是否正确填写，这里暂时只是用 string.IsNullOrWhiteSpace()判断是否为空值，未做进一步校验，以后完善
        private bool validateCoConfig()
        {
            List<string> testConfig = new List<string> { _coName, _sourceLang, _typeName , _sourceSite , _coOffline , _listPath , _startPageNumber ,_stopPageNumber, _xpathArcurlNode , _xpathTitleNode , _xpathContentNode, _arcSubPageSymbol, _arcSubPageStartNum };
            foreach (string item in testConfig)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return false;
                }
            }
            try
            {
                int startPageNumber = int.Parse(_startPageNumber);
                int stopPageNumber = int.Parse(_stopPageNumber);
                int subPageStartNum = int.Parse(_arcSubPageStartNum);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //从数据库中加载配置
        private void displayConfig()
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = @"select * from co_config where cid = '"+_cid.ToString()+"'";
            List<Dictionary<string, object>> coConfigRecords = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult==mySqlDB.SUCCESS)
            {
                Dictionary<string, object> coConfig = coConfigRecords[0];
                tboxCoName.Text = coConfig["co_name"].ToString();
                cboxCoSource_Lang.Text = coConfig["source_lang"].ToString();
                cboxCoSource_Site.Text = coConfig["source_site"].ToString();
                cboxCoTypeName.Text = coConfig["type_name"].ToString();
                if (coConfig["co_offline"].ToString() == "yes")
                {
                    rbtnCo_Offline_yes.Checked = true;
                }
                else
                {
                    rbtnCo_Offline_no.Checked = true;
                }
                tboxCoListPath.Text = coConfig["list_path"].ToString();
                tboxCoStartPageNumber.Text = coConfig["start_page_number"].ToString();
                tboxCoStopPageNumber.Text = coConfig["stop_page_number"].ToString();
                tboxMoreListPages.Text = coConfig["more_list_pages"].ToString();
                tboxXpathArcurlNode.Text = coConfig["xpath_arcurl_node"].ToString();
                tboxXpathTitleNode.Text = coConfig["xpath_title_node"].ToString();
                tboxXpathContentNode.Text = coConfig["xpath_content_node"].ToString();
                tboxArcSubpageSymbol.Text = coConfig["arc_subpage_symbol"].ToString();
                tboxArcSubpageStartNum.Text = coConfig["arc_subpage_startnum"].ToString();
                tboxSubNodeParams.Text = coConfig["sub_node_params"].ToString();
                tboxRegexParams.Text = coConfig["regex_params"].ToString();

                setVarValue();  //将控件中的值同步到对应的变量中
            }
            else
            {
                MessageBox.Show(string.Format("数据加载错误：{0}", sResult));
            }
        }

        //保存配置到数据库中
        private void saveConfig()
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = "";
            setVarValue();  //先将变量中的值更新成当前控件中的值
            bool validateResult = validateCoConfig();
            if (!validateResult)
            {
                MessageBox.Show("必填项未填写完整或未填写正确，请检查表达是否填写完整并正确填写！");
            }
            else
            {
                if (_cid != -1)  //如果传入cid不等于-1说明是更新配置
                {
                    sql = "update co_config set co_name = '" + _coName + "'";
                    sql = sql + ", type_name = '" + _typeName + "'";
                    sql = sql + ", source_lang = '" + _sourceLang + "'";
                    sql = sql + ", source_site = '" + mySqlDB.EscapeString(_sourceSite) + "'";
                    sql = sql + ", co_offline = '" + _coOffline + "'";
                    sql = sql + ", list_path = '" + mySqlDB.EscapeString(_listPath) + "'";
                    sql = sql + ", start_page_number = '" + _startPageNumber + "'";
                    sql = sql + ", stop_page_number = '" + _stopPageNumber + "'";
                    sql = sql + ", xpath_arcurl_node = '" + mySqlDB.EscapeString(_xpathArcurlNode) + "'";
                    sql = sql + ", xpath_title_node = '" + mySqlDB.EscapeString(_xpathTitleNode) + "'";
                    sql = sql + ", xpath_content_node = '" + mySqlDB.EscapeString(_xpathContentNode) + "'";
                    sql = sql + ",up_time=current_timestamp";
                    sql = sql + ", more_list_pages = '" + mySqlDB.EscapeString(_moreListPages) + "'";
                    sql = sql + ", sub_node_params = '" + mySqlDB.EscapeString(_subNodeParams) + "'";
                    sql = sql + ", regex_params = '" + mySqlDB.EscapeString(_regexParams) + "'";

                    if (_arcSubPageSymbol != "")
                    {
                        sql = sql + ", arc_subpage_symbol = '" + mySqlDB.EscapeString(_arcSubPageSymbol) + "'";
                    }
                    if (_arcSubPageStartNum != "")
                    {
                        sql = sql + ", arc_subpage_startnum = '" + _arcSubPageStartNum + "'";
                    }

                    sql = sql + " where cid = '" + _cid.ToString() + "'";

                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            MessageBox.Show("成功更新采集规则！");
                        }
                        else
                        {
                            MessageBox.Show(string.Format("更新采集规则失败！错误信息：{0}", sResult));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("修改规则出错！ 请检查数据格式是否正确！错误信息：", ex.Message));
                    }
                }
                else   //增加新配置
                {
                    sql = "insert into co_config (co_name,type_name,source_lang,source_site,co_offline,list_path,start_page_number,stop_page_number,xpath_arcurl_node,xpath_title_node,xpath_content_node";
                    string valueOption = "";
                    if (_arcSubPageSymbol != "")
                    {
                        sql = sql + ",arc_subpage_symbol" ;
                        valueOption =valueOption+ ",'" + mySqlDB.EscapeString(_arcSubPageSymbol) + "'";
                    }
                    if (_arcSubPageStartNum != "")
                    {
                        sql = sql + ", arc_subpage_startnum";
                        valueOption=valueOption+",'"+ _arcSubPageStartNum + "'";
                    }
                    if (_moreListPages != "")
                    {
                        sql = sql + ",more_list_pages";
                        valueOption=valueOption+ ",'"+mySqlDB.EscapeString(_moreListPages) + "'";
                    }
                    if (_subNodeParams != "")
                    {
                        sql = sql + ",sub_node_params";
                        valueOption=valueOption+ ",'"+mySqlDB.EscapeString(_subNodeParams) + "'";
                    }
                    if (_regexParams != "")
                    {
                        sql = sql + ",regex_params";
                        valueOption=valueOption+",'"+ mySqlDB.EscapeString(_regexParams) + "'";
                    }
                    sql = sql + ") values ('" + _coName + "'";
                    sql = sql + ",'" + _typeName + "'";
                    sql = sql + ",'" + _sourceLang + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(_sourceSite) + "'";
                    sql = sql + ",'" + _coOffline + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(_listPath) + "'";
                    sql = sql + ",'" + _startPageNumber + "'";
                    sql = sql + ",'" + _stopPageNumber + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(_xpathArcurlNode) + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(_xpathTitleNode) + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(_xpathContentNode) + "'";
                    sql = sql + valueOption + ")";
                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            _cid = myDB.LastInsertedId;
                            MessageBox.Show(string.Format("成功添加新采集规则！新规则ID：{0}",_cid));
                        }
                        else
                        {
                            MessageBox.Show(string.Format("添加采集规则失败！错误信息：{0}", sResult));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("添加新规则错误！ 请检查数据格式是否正确！错误信息：", ex.Message));
                    }


                } //添加规则结束

            }//判断表单数据是否填写完整结束


        }

        //以下是通过委托代理实现异步测试采集的过程

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
                tboxStatistics.AppendText(string.Format("终止获取列表页：{0} \n", collectOffline.CancelException.Message));
                tboxStatistics.AppendText(string.Format("当前获取列表页位置：{0}\n", collectOffline.CurrentProcessedListPages));
                tboxStatistics.AppendText(string.Format("总共需要处理列表页面数：{0}\n", collectOffline.CancelException.Data["TotalListPages"]));
            }

            //输出列表文档的信息

            List<string> listPages = collectOffline.ListPages;
            tboxStatistics.AppendText(string.Format("获取列表文档所花时间：{0}\n", swGlobal.ElapsedMilliseconds));
            tboxStatistics.AppendText(string.Format("本次获取列表页面数：{0}\n", listPages.Count));

        }

        //异步执行获取文章URL集合结束
        private void ProcessArticlePagesComplete(IAsyncResult itfAR)
        {
            //异步执行获取文章URL集合完毕后，获得异步返回的结果，继续异步执行下一步（采集文档内容）
            CollectProcess collectProcessArticlePages = (CollectProcess)((AsyncResult)itfAR).AsyncDelegate;
            ArticleCollectOffline collectOffline = collectProcessArticlePages.EndInvoke(itfAR);
            if (collectOffline.CancelException == null)
            {
                CollectProcess collectProcessCollectArticles = new CollectProcess(ProcessCollectArticles);
                collectProcessCollectArticles.BeginInvoke(collectOffline, ProcessCollectArticlesComplete, null);
            }
            else
            {
                tboxStatistics.AppendText(string.Format("终止获取列表页：{0} \n", collectOffline.CancelException.Message));
                tboxStatistics.AppendText(string.Format("当前处理列表页位置：{0}\n", collectOffline.CurrentProcessedListPages));
                tboxStatistics.AppendText(string.Format("总共需要处理列表页面数：{0}\n", collectOffline.CancelException.Data["TotalListPages"]));
                tboxStatistics.AppendText(string.Format("当前处理文章链接数：{0}\n", collectOffline.CurrentGetArticlePages));
            }
            //输出URL集合信息
            List<string> correctListArticles = new List<string>();
            foreach (Dictionary<string,string> item in collectOffline.CorrectArticlePages)
            {
                correctListArticles.Add(item["arcpath"]);
            }
            List<string> wrongListArticles = new List<string>();
            foreach (Dictionary<string,string> item in collectOffline.WrongArticlePages)
            {
                wrongListArticles.Add(item["arcpath"]);
            }
            tboxStatistics.AppendText(string.Format("获取文章URL集合所花时间： {0}\n", swGlobal.ElapsedMilliseconds));
            tboxArticlesPages.AppendText("待采集文章链接：\n");
            foreach (string item in correctListArticles)
            {
                tboxArticlesPages.AppendText(string.Format("{0}\n", item));
            }
            tboxArticlesPages.AppendText("-------------------------------------------------------------------------------\n");
            tboxArticlesPages.AppendText("未能正确匹配内容链接，请检查匹配XPATH规则： \n");
            foreach (string item in wrongListArticles)
            {
                tboxArticlesPages.AppendText(string.Format("{0}\n", item));
            }
        }

        //异步执行采集文章结束
        private void ProcessCollectArticlesComplete(IAsyncResult itfAR)
        {
            //异步执行采集文章内容完成后
            CollectProcess collectProcessCollectArticles = (CollectProcess)((AsyncResult)itfAR).AsyncDelegate;
            ArticleCollectOffline collectOffline = collectProcessCollectArticles.EndInvoke(itfAR);
            swGlobal.Stop();
            tboxStatistics.AppendText(string.Format("swGlobal ElapsedMilliseconds: {0} \n", swGlobal.ElapsedMilliseconds));
            //输出采集文档信息
            if (collectOffline.CancelException != null)
            {
                tboxStatistics.AppendText(string.Format("当前采集文章数：{0}\n", collectOffline.CurrentProcessedArticles));
                tboxStatistics.AppendText(string.Format("此次总共需要采集文章数：{0}\n", collectOffline.CancelException.Data["TotalArticles"]));
            }
            List<Dictionary<string, string>> articles = collectOffline.Articles;
            List<Exception> coException = collectOffline.CoException;
            printErrors(coException);

            tboxStatistics.AppendText(string.Format("采集文章总数：{0} \n", articles.Count));
            tboxStatistics.AppendText(string.Format("采集所耗时间 ：{0} \n", swGlobal.ElapsedMilliseconds));
            tboxStatistics.AppendText("-----------------------------------------------------------------------------------\n");
            var arcList = from d in articles
                          orderby d["title"]
                          ascending
                          select d;

            foreach (Dictionary<string, string> article in arcList)
            {
                foreach (KeyValuePair<string, string> kvp in article)
                {
                    tboxArticlesContent.AppendText(kvp.Key + ": \n");
                    tboxArticlesContent.AppendText(kvp.Value + "\n");
                }
                tboxArticlesContent.AppendText("---------------------------------------------\n");
            }

            //恢复表单可操作
            try
            {
                btnSaveCoConfig.Enabled = true;
                btnCoTest.Enabled = true;
                tabctrCoform.SelectedIndexChanged -= TabctrCoform_SelectedIndexChanged;
            }
            catch (Exception ex)
            {

            }
        }

        private void printErrors(List<Exception> coExption)
        {
            int count = 0;
            foreach (Exception item in coExption)
            {
                count = count + 1;
                tboxStatistics.AppendText(string.Format("Error {0}: --------------------------\n", count));
                tboxStatistics.AppendText(string.Format("From: {0}   Message:{1}\n", item.TargetSite, item.Message));
                if (item.Data != null)
                {
                    foreach (DictionaryEntry de in item.Data)
                    {
                        tboxStatistics.AppendText(string.Format("{0} : {1} \n", de.Key, de.Value));
                    }
                }

            }
        }

        private void btnSaveCoConfig_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        private void btnCoTest_Click(object sender, EventArgs e)
        {
            tabctrCoform.SelectedTab = tabCoTest;
            bool validateResult = validateCoConfig();
            if (!validateResult)
            { 
                MessageBox.Show("采集规则未填写完整或未正确填写，请重新填写并保存！");
            }
            else
            {
                //int listStartPageNum = int.Parse(_startPageNumber);
                //int listStopPageNum = int.Parse(_stopPageNumber);
                int listStartPageNum = 2;               
                int listStopPageNum = 5;            //因为这里是测试，所以默认只采集到第5页，提升测试速度
                int arcSubPageStartNum = int.Parse(_arcSubPageStartNum);
                List<string> moreListPages=new List<string>();
                List<string> subNodeParams=new List<string>();
                List<string> regexParams=new List<string>();
                cancelToken = new CancellationTokenSource();
                swGlobal.Start();

                if (!string.IsNullOrWhiteSpace(_moreListPages))
                {
                    string[] moreListPagesArr = tboxMoreListPages.Lines;
                    moreListPages = moreListPagesArr.ToList<string>();
                }
                if (!string.IsNullOrWhiteSpace(_subNodeParams))
                {
                    string[] subNodeParamsArr = tboxSubNodeParams.Lines;
                    subNodeParams = subNodeParamsArr.ToList<string>();
                }
                if (!string.IsNullOrWhiteSpace(_regexParams))
                {
                    string[] regexParamsArr = tboxRegexParams.Lines;
                    regexParams = regexParamsArr.ToList<string>();
                }

                ArticleCollectOffline collectOffline = new ArticleCollectOffline(_cid,_listPath, listStartPageNum, listStopPageNum, _xpathArcurlNode, _xpathTitleNode, _xpathContentNode, subNodeParams, regexParams, _arcSubPageSymbol, arcSubPageStartNum);
                if (moreListPages!= null)
                {
                    collectOffline.AddListPages(moreListPages);
                }
                collectOffline.CancelToken = cancelToken;
                CollectProcess collectProcessListPages = new CollectProcess(ProcessListPages);
                collectProcessListPages.BeginInvoke(collectOffline, ProcessListPagesComplete, null);

                //禁用表单，测试采集期间不能操作表单
                tabctrCoform.SelectedIndexChanged += TabctrCoform_SelectedIndexChanged;
                btnCoTest.Enabled = false;
                btnSaveCoConfig.Enabled = false;
            }
        }



        private void btnCancelCoTest_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
            try
            {
                btnSaveCoConfig.Enabled = true;
                btnCoTest.Enabled = true;
                tabctrCoform.SelectedIndexChanged -= TabctrCoform_SelectedIndexChanged;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
