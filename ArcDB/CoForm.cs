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


namespace ArcDB
{
    public partial class CoForm : Form
    {
        private readonly string RootPath = Application.StartupPath + @"\";   /*程序根目录*/
        private string _connString;
        private long _cid;

        

        public CoForm(string connString,long cid)
        {
            _connString = connString;
            _cid = cid;
            InitializeComponent();
        }
        private void CoForm_Load(object sender, EventArgs e)
        {
            if (_cid!=-1)   // _cid 为-1 表示表单是执行添加采集规则的操作，否则就是修改现有采集规则
            {
                displayConfig();
            }
        }

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
            }
            else
            {
                MessageBox.Show(string.Format("数据加载错误：{0}", sResult));
            }
        }

        private void saveConfig()
        {
            mySqlDB myDB = new mySqlDB(_connString);
            string sResult = "";
            int counts = 0;
            string sql = "";
            string coName = tboxCoName.Text;
            string sourceLang = cboxCoSource_Lang.Text;
            string typeName = cboxCoTypeName.Text;
            string sourceSite = cboxCoSource_Site.Text;
            string coOffline = "yes";
            if (rbtnCo_Offline_yes.Checked)
            {
                coOffline = "yes";
            }
            else
            {
                coOffline = "no";
            }
            string listPath = tboxCoListPath.Text;
            string startPageNumber = tboxCoStartPageNumber.Text;
            string stopPageNumber = tboxCoStopPageNumber.Text;
            string moreListPages = tboxMoreListPages.Text;
            string xpathArcurlNode = tboxXpathArcurlNode.Text;
            string xpathTitleNode = tboxXpathTitleNode.Text;
            string xpathContentNode = tboxXpathContentNode.Text;
            string arcSubPageSymbol = tboxArcSubpageSymbol.Text;
            string arcSubPageStartNum = tboxArcSubpageStartNum.Text;
            string subNodeParams = tboxSubNodeParams.Text;
            string regexParams = tboxRegexParams.Text;
            if (coName=="" || sourceLang=="" || typeName=="" || sourceSite=="" || coOffline=="" || listPath=="" || startPageNumber=="" || stopPageNumber=="" || xpathArcurlNode=="" || xpathTitleNode=="" || xpathContentNode=="")
            {
                MessageBox.Show("必填项未填写完整，请检查表达是否填写完整！");
            }
            else
            {
                if (_cid != -1)
                {
                    sql = "update co_config set co_name = '" + coName + "'";
                    sql = sql + ", type_name = '" + typeName + "'";
                    sql = sql + ", source_lang = '" + sourceLang + "'";
                    sql = sql + ", source_site = '" + mySqlDB.EscapeString(sourceSite) + "'";
                    sql = sql + ", co_offline = '" + coOffline + "'";
                    sql = sql + ", list_path = '" + mySqlDB.EscapeString(listPath) + "'";
                    sql = sql + ", start_page_number = '" + startPageNumber + "'";
                    sql = sql + ", stop_page_number = '" + stopPageNumber + "'";
                    sql = sql + ", xpath_arcurl_node = '" + mySqlDB.EscapeString(xpathArcurlNode) + "'";
                    sql = sql + ", xpath_title_node = '" + mySqlDB.EscapeString(xpathTitleNode) + "'";
                    sql = sql + ", xpath_content_node = '" + mySqlDB.EscapeString(xpathContentNode) + "'";
                    if (arcSubPageSymbol != "")
                    {
                        sql = sql + ", arc_subpage_symbol = '" + mySqlDB.EscapeString(arcSubPageSymbol) + "'";
                    }
                    if (arcSubPageStartNum != "")
                    {
                        sql = sql + ", arc_subpage_startnum = '" + arcSubPageStartNum + "'";
                    }
                    if (moreListPages != "")
                    {
                        sql = sql + ", more_list_pages = '" + mySqlDB.EscapeString(moreListPages) + "'";
                    }
                    if (subNodeParams != "")
                    {
                        sql = sql + ", sub_node_params = '" + mySqlDB.EscapeString(subNodeParams) + "'";
                    }
                    if (regexParams != "")
                    {
                        sql = sql + ", regex_params = '" + mySqlDB.EscapeString(regexParams) + "'";
                    }
                    sql = sql + " where cid = '" + _cid.ToString() + "'";

                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            MessageBox.Show("成功更新采集规则！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("修改规则出错！ 请检查数据格式是否正确！错误信息：", ex.Message));
                    }
                }
                else
                {
                    sql = "insert into co_config (co_name,type_name,source_lang,source_site,co_offline,list_path,start_page_number,stop_page_number,xpath_arcurl_node,xpath_title_node,xpath_content_node";
                    string valueOption = "";
                    if (arcSubPageSymbol != "")
                    {
                        sql = sql + ",arc_subpage_symbol" ;
                        valueOption =valueOption+ ",'" + mySqlDB.EscapeString(arcSubPageSymbol) + "'";
                    }
                    if (arcSubPageStartNum != "")
                    {
                        sql = sql + ", arc_subpage_startnum";
                        valueOption=valueOption+",'"+ arcSubPageStartNum + "'";
                    }
                    if (moreListPages != "")
                    {
                        sql = sql + ",more_list_pages";
                        valueOption=valueOption+ ",'"+mySqlDB.EscapeString(moreListPages) + "'";
                    }
                    if (subNodeParams != "")
                    {
                        sql = sql + ",sub_node_params";
                        valueOption=valueOption+ ",'"+mySqlDB.EscapeString(subNodeParams) + "'";
                    }
                    if (regexParams != "")
                    {
                        sql = sql + ",regex_params";
                        valueOption=valueOption+",'"+ mySqlDB.EscapeString(regexParams) + "'";
                    }
                    sql = sql + ") values ('" + coName + "'";
                    sql = sql + ",'" + typeName + "'";
                    sql = sql + ",'" + sourceLang + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(sourceSite) + "'";
                    sql = sql + ",'" + coOffline + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(listPath) + "'";
                    sql = sql + ",'" + startPageNumber + "'";
                    sql = sql + ",'" + stopPageNumber + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(xpathArcurlNode) + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(xpathTitleNode) + "'";
                    sql = sql + ",'" + mySqlDB.EscapeString(xpathContentNode) + "'";
                    sql = sql + valueOption + ")";
                    try
                    {
                        counts = myDB.executeDMLSQL(sql, ref sResult);
                        if (counts == 1 && sResult == mySqlDB.SUCCESS)
                        {
                            _cid = myDB.LastInsertedId;
                            MessageBox.Show(string.Format("成功添加新采集规则！新规则ID：{0}",_cid));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("添加新规则错误！ 请检查数据格式是否正确！错误信息：", ex.Message));
                    }


                } //添加规则结束

            }//判断表单数据是否填写完整结束


        }

        private void btnSaveCoConfig_Click(object sender, EventArgs e)
        {
            saveConfig();
        }
        private void btnCoTest_Click(object sender, EventArgs e)
        {

        }


    }
}
