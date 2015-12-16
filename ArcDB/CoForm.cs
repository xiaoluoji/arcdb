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
        private int _cid;

        

        public CoForm(string connString,int cid)
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
        /*
        private List<string>splitConfig(string config)
        {
            List<string> templistConfig = new List<string>();
            
        }
        */
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
            if (_cid!=-1)
            {
                sql = "update co_config set co_name = '" + coName + "'";
                sql = sql + ", type_name = '" + typeName + "'";
                sql = sql + ", source_lang = '" + sourceLang + "'";
                sql = sql + ", source_site = '" + sourceSite + "'";
                sql = sql + ", co_offline = '" + coOffline + "'";
                sql = sql + ", list_path = '" + listPath + "'";
                sql = sql + ", start_page_number = '" + startPageNumber + "'";
                sql = sql + ", stop_page_number = '" + stopPageNumber + "'";
                sql = sql + ", more_list_pages = '" + moreListPages + "'";
                sql = sql + ", xpath_arcurl_node = '" + xpathArcurlNode + "'";
                sql = sql + ", xpath_title_node = '" + xpathTitleNode + "'";
                sql = sql + ", xpath_content_node = '" + xpathContentNode + "'";
                sql = sql + ", arc_subpage_symbol = '" + arcSubPageSymbol + "'";
                sql = sql + ", arc_subpage_startnum = '" + arcSubPageStartNum + "'";
                sql = sql + ", sub_node_params = '" + subNodeParams + "'";
                sql = sql + ", regex_params = '" + regexParams + "'";
                sql = sql + " where cid = '" + _cid.ToString() + "'";
                try
                {
                    counts = myDB.executeDMLSQL(sql, ref sResult);
                    if (counts==1 && sResult==mySqlDB.SUCCESS)
                    {
                        MessageBox.Show("成功更新采集规则！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("保存数据出错！ 请检查数据格式是否正确！错误信息：", ex.Message));
                }
            }

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
