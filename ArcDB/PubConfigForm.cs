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
    public partial class PubConfigForm : Form
    {
        private int _pubID;
        private string _coConnString;
        private string _pubConnString;
        private string _pubTablePrename;
        private string _pubName;
        private string _coTypeid;
        private string _coTypename;
        private string _pubTypeid;
        private string _pubTypename;
        private string _pubNums;
        private string _randomDateStart;
        private string _randomDateStop;
        private CancellationTokenSource cancelTokenSource;

        //构造方法
        public PubConfigForm(string coConnString,string pubConnString,int pubID,string pubTablePrename)
        {
            _pubID = pubID;
            _coConnString = coConnString;
            _pubConnString = pubConnString;
            _pubTablePrename = pubTablePrename;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region 事件区域
        //表单加载时执行的方法
        private void PubConfigForm_Load(object sender, EventArgs e)
        {
            if (_pubID!=-1)
            {
                displayConfig();
            }
            loadCoTypeInfo();  //加载采集分类信息
            loadPubTypeInfo(); //加载CMS分类信息
        }
        
        //表单关闭前的提示
        private void PubConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string showMessage = "";
            if (_pubID == -1)
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

        //RandomDateStart 日期选择器的值变更时，修改配置值为新的值
        private void dtpRandomDateStart_ValueChanged(object sender, EventArgs e)
        {
            string randomDateStart = dtpRandomDateStart.Value.ToShortDateString();
            tboxRandomDateStart.Text = randomDateStart;
        }

        //RandomDateStop 日期选择器的值变更时，修改配置值为新的值
        private void dtpRandomDateStop_ValueChanged(object sender, EventArgs e)
        {
            string randomDateStop = dtpRandomDateStop.Value.ToShortDateString();
            tboxRandomDateStop.Text = randomDateStop;
        }

        //当选中listViewCoTypeinfo中的分类项的时候，讲表单中采集分类ID和采集分类名称更新为选中的值
        private void listViewCoTypeinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewCoTypeinfo.FocusedItem != null)
                {
                    ListViewItem selectedItem = listViewCoTypeinfo.SelectedItems[0];
                    tboxCoTypeid.Text = selectedItem.SubItems[0].Text;
                    tboxCoTypename.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //当选中listViewPubTypeinfo中的分类项的时候，讲表单中CMS分类ID和CMS分类名称更新为选中的值
        private void listViewPubTypeinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewPubTypeinfo.FocusedItem!=null)
                {
                    ListViewItem selectedItem = listViewPubTypeinfo.SelectedItems[0];
                    tboxPubTypeid.Text = selectedItem.SubItems[0].Text;
                    tboxPubTypename.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        #endregion 事件区域


        #region 配置发布规则
        //加载采集分类信息
        private void loadCoTypeInfo(string searchCondition="")
        {
            listViewCoTypeinfo.Items.Clear();
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql = "select tid,type_name from arc_type";
            if (searchCondition!="")
            {
                sql = sql + " where type_name like '%" + searchCondition + "%'";
            }
            List<Dictionary<string, object>> listCoTypeinfo = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                listViewCoTypeinfo.BeginUpdate();
                foreach (Dictionary<string,object> item in listCoTypeinfo)
                {
                    List<string> subItems = new List<string>();
                    foreach (KeyValuePair<string, object>kvp in item)
                    {
                        subItems.Add(kvp.Value.ToString());
                    }
                    ListViewItem listItem = new ListViewItem(subItems.ToArray());
                    listViewCoTypeinfo.Items.Add(listItem);
                }
                listViewCoTypeinfo.EndUpdate();
                listViewCoTypeinfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            else
            {
                if (counts==0)
                {
                    MessageBox.Show(string.Format("未找到搜索的分类!"));

                }
                else
                {
                    MessageBox.Show(string.Format("加载采集分类数据出错!：{0}", sResult));
                }
            }
        }

        //加载发布分类信息
        private void loadPubTypeInfo(string searchCondition="")
        {
            listViewPubTypeinfo.Items.Clear();
            mySqlDB myDB = new mySqlDB(_pubConnString);
            string sResult = "";
            int counts = 0;
            string sql = "select catid,catname from "+_pubTablePrename+"_category where parentid <> 0 and modelid=1";
            if (searchCondition!="")
            {
                sql = sql + " and catname like '%" + searchCondition + "%'";
            }
            List<Dictionary<string, object>> listPubTypeinfo = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult==mySqlDB.SUCCESS && counts>0)
            {
                listViewPubTypeinfo.BeginUpdate();
                foreach (Dictionary<string,object> item in listPubTypeinfo)
                {
                    List<string> subItems = new List<string>();
                    foreach (KeyValuePair<string,object> kvp in item)
                    {
                        subItems.Add(kvp.Value.ToString());
                    }
                    ListViewItem listItem = new ListViewItem(subItems.ToArray());
                    listViewPubTypeinfo.Items.Add(listItem);
                }
                listViewPubTypeinfo.EndUpdate();
                listViewPubTypeinfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                if (counts == 0)
                {
                    MessageBox.Show(string.Format("未找到搜索的分类!"));

                }
                else
                {
                    MessageBox.Show(string.Format("加载采集分类数据出错!：{0}", sResult));
                }
            }

        }

        //检验表单数据是否正确填写
        private bool validatePubConfig()
        {
            List<string> testConfig = new List<string> { _pubName, _coTypeid, _coTypename, _pubNums, _pubTypeid, _pubTypename, _randomDateStart, _randomDateStop };
            foreach (string item in testConfig)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return false;
                }
            }
            try
            {
                int coTypeID = int.Parse(_coTypeid);
                int pubTypeID = int.Parse(_pubTypeid);
                int pubNums = int.Parse(_pubNums);
                DateTime randomDateStart = DateTime.Parse(_randomDateStart);
                DateTime randomDateStop = DateTime.Parse(_randomDateStop);
                TimeSpan ts = randomDateStop - randomDateStart;
                if (ts.TotalDays<0)
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

        //将相关变量的值设置为表单中的数据
        private void setVarValue()
        {
            _pubName = tboxPubName.Text;
            _coTypeid = tboxCoTypeid.Text;
            _coTypename = tboxCoTypename.Text;
            _pubNums = tboxPubNums.Text;
            _pubTypeid = tboxPubTypeid.Text;
            _pubTypename = tboxPubTypename.Text;
            _randomDateStart = tboxRandomDateStart.Text;
            _randomDateStop = tboxRandomDateStop.Text;
        }

        //显示需要修改的发布规则的配置信息
        private void displayConfig()
        {
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql = @"select * from pub_config where id='" + _pubID.ToString() + "'";
            List<Dictionary<string, object>> pubConfigRecords = myDB.GetRecords(sql, ref sResult, ref counts);
            if (sResult == mySqlDB.SUCCESS)
            {
                Dictionary<string, object> pubConfig = pubConfigRecords[0];
                tboxPubName.Text = pubConfig["pub_name"].ToString();
                tboxPubNums.Text = pubConfig["pub_nums"].ToString();
                tboxCoTypeid.Text = pubConfig["co_typeid"].ToString();
                tboxCoTypename.Text = pubConfig["co_typename"].ToString();
                tboxPubTypeid.Text = pubConfig["pub_typeid"].ToString();
                tboxPubTypename.Text = pubConfig["pub_typename"].ToString();
                tboxRandomDateStart.Text = pubConfig["random_date_start"].ToString();
                tboxRandomDateStop.Text = pubConfig["random_date_stop"].ToString();
                setVarValue();  //将控件中的值同步到对应的变量中
            }
            else
            {
                MessageBox.Show(string.Format("数据加载错误：{0}", sResult));
            }
        }

        //保存配置 或者 新增配置
        private void saveConfig()
        {
            mySqlDB myDB = new mySqlDB(_coConnString);
            string sResult = "";
            int counts = 0;
            string sql = "";
            setVarValue();  //先将变量中的值更新成当前控件中的值
            bool validateResult = validatePubConfig();
            if (!validateResult)
            {
                MessageBox.Show("必填项未填写完整或未填写正确，请检查表达是否填写完整并正确填写！");
            }
            else
            {
                if (_pubID!=-1)
                {
                    sql = "update pub_config set pub_name = '" + _pubName + "'";
                    sql = sql + ", co_typeid = '" + _coTypeid + "'";
                    sql = sql + ", co_typename = '" + _coTypename + "'";
                    sql = sql + ", pub_typeid = '" + _pubTypeid + "'";
                    sql = sql + ", pub_typename = '" + _pubTypename + "'";
                    sql = sql + ", pub_nums = '" + _pubNums + "'";
                    sql = sql + ", random_date_start = '" + _randomDateStart + "'";
                    sql = sql + ", random_date_stop = '" + _randomDateStop + "'";
                    sql = sql + ",pub_add_date=current_timestamp";
                    sql = sql + " where id = '" + _pubID.ToString() + "'";
                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            MessageBox.Show("成功更新发布规则！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("修改规则出错！ 请检查数据格式是否正确！错误信息：", ex.Message));
                    }
                }
                else
                {
                    sql = "insert into pub_config(pub_name,co_typeid,co_typename,pub_typeid,pub_typename,pub_nums,random_date_start,random_date_stop)";
                    sql = sql + " values ('" + _pubName + "'";
                    sql = sql + ",'" + _coTypeid + "'";
                    sql = sql + ",'" + _coTypename + "'";
                    sql = sql + ",'" + _pubTypeid + "'";
                    sql = sql + ",'" + _pubTypename + "'";
                    sql = sql + ",'" + _pubNums + "'";
                    sql = sql + ",'" + _randomDateStart + "'";
                    sql = sql + ",'" + _randomDateStop + "')";
                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            _pubID = (int)myDB.LastInsertedId;
                            MessageBox.Show(string.Format("成功添加新发布规则！新规则ID：{0}", _pubID));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("添加新规则错误！ 请检查数据格式是否正确！错误信息：", ex.Message));
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
            sql = sql + ",pub_export_date = CURRENT_TIMESTAMP";
            sql = sql + " where id = '" + pubID.ToString() + "'";
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

        //输出发布过程中的错误信息
        private void printErrors(ArticlePublish articlePublish)
        {
            //输出错误信息
            Exception cancelException = articlePublish.CancelException;
            if (cancelException != null)
            {
                tboxPubTestResult.AppendText(cancelException.Message + "\n");
                if (cancelException.Data != null)
                {
                    foreach (DictionaryEntry de in cancelException.Data)
                    {
                        tboxPubTestResult.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                    }
                }
            }
            List<Exception> listException = articlePublish.PubException;
            if (listException.Count > 0)
            {
                foreach (Exception item in listException)
                {
                    tboxPubTestResult.AppendText(item.Message + "\n");
                    if (item.Data != null)
                    {
                        foreach (DictionaryEntry de in item.Data)
                        {
                            tboxPubTestResult.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                        }
                    }
                }
            }
        }



        //点击 保存按钮后的操作
        private void btnSavePubConfig_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        //点击 采集分类搜索按钮
        private void btnSearchCoTypename_Click(object sender, EventArgs e)
        {
            loadCoTypeInfo(tboxSearchCoTypename.Text);
        }

        //点击 发布分类搜索按钮
        private void btnSearchPubTypename_Click(object sender, EventArgs e)
        {
            loadPubTypeInfo(tboxSearchPubTypename.Text);
        }


        #endregion 配置发布规则


        // 点击 测试发布按钮
        private void btnPubTest_Click(object sender, EventArgs e)
        {
            tabctrPubform.SelectedTab = tabPubTest;
            setVarValue();  //先将变量中的值更新成当前控件中的值
            bool validateResult = validatePubConfig();
            if (!validateResult)
            {
                MessageBox.Show("必填项未填写完整或未填写正确，请检查表达是否填写完整并正确填写！");
            }
            else
            {
                int coTypeid = int.Parse(_coTypeid);
                int pubTypeid = int.Parse(_pubTypeid);
                //测试发布一篇文章
                ArticlePublish articlePublishTest = new ArticlePublish(_pubID, _coConnString, _pubConnString, _pubTablePrename, coTypeid,pubTypeid,1, _randomDateStart, _randomDateStop);
                cancelTokenSource = new CancellationTokenSource();
                articlePublishTest.CancelTokenSource = cancelTokenSource;
                articlePublishTest.ProcessPublishArticles();
                long aid = articlePublishTest.LastExportedCoid;
                long cmsAid = articlePublishTest.LastExportedCmsid;
                int exportedNums = articlePublishTest.CurrentExportedArticles;
                if (aid == -1 || cmsAid==-1)
                {
                    Exception cancelException = articlePublishTest.CancelException;
                    if (cancelException!=null)
                    {
                        tboxPubTestResult.AppendText(cancelException.Message + "\n");
                        if (cancelException.Data!=null)
                        {
                            foreach (DictionaryEntry de in cancelException.Data)
                            {
                                tboxPubTestResult.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                            }
                        }
                    }
                    List<Exception> listException = articlePublishTest.PubException;
                    if (listException.Count>0)
                    {
                        foreach (Exception item in listException)
                        {
                            tboxPubTestResult.AppendText(item.Message + "\n");
                            if (item.Data!=null)
                            {
                                foreach (DictionaryEntry de  in item.Data)
                                {
                                    tboxPubTestResult.AppendText(string.Format("{0} :  {1} \n", de.Key, de.Value));
                                }
                            }
                        }
                    }
                }
                else
                {
                    tboxPubTestResult.AppendText(string.Format("发布文章成功！ 采集文章ID是：{0}  CMS文章ID是：{1} \n",aid,cmsAid));
                    tboxPubTestResult.AppendText(string.Format("此次发布数量：{0}\n", exportedNums));
                    updatePublishState(articlePublishTest);
                    printErrors(articlePublishTest);
                }
            }
        }

    }
}
