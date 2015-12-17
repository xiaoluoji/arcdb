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
    public partial class MainForm : Form
    {
        private readonly string RootPath = Application.StartupPath + @"\";   /*程序根目录*/
        private string _configFile;                                                                        /*程序配置文件*/
        private Configuration _sysConfig;                                                            /*保存配置的变量*/
        private string _connString;                                                                       /*建立mysql连接的配置变量*/

        public MainForm()
        {
            InitializeComponent();
            _configFile = RootPath + "config.ini";
        }

        //主窗口加载时的处理
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(_configFile))
            {
                _sysConfig = Configuration.LoadFromFile(_configFile);
                loadSysconfig();
            }
            else
            {
                _sysConfig = new Configuration();
                updateSysconfig();
            }
        }

        //当主窗口要关闭时的处理
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("将要关闭程序，是否继续？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void CoFormModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadCoConfig();
        }

        //主窗口关闭后的处理
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            updateSysconfig();
            _sysConfig.SaveToFile(_configFile);
        }

        //读取配置文件中的对应配置，并且更新到相应的控件中
        private void loadSysconfig()
        {
            tboxHostName.Text = _sysConfig["Database"]["Hostname"].StringValue;
            tboxUserName.Text = _sysConfig["Database"]["Username"].StringValue;
            tboxDbName.Text = _sysConfig["Database"]["Dbname"].StringValue;
            tboxPort.Text = _sysConfig["Database"]["Port"].StringValue;
            tboxPassword.Text = _sysConfig["Database"]["Password"].StringValue;
            cboxCharset.Text = _sysConfig["Database"]["Charset"].StringValue;
        }

        //更新sysConfig对象中的配置参数
        private void updateSysconfig()
        {
            _sysConfig["Database"]["Hostname"].SetValue(tboxHostName.Text);
            _sysConfig["Database"]["Username"].SetValue(tboxUserName.Text);
            _sysConfig["Database"]["Dbname"].SetValue(tboxDbName.Text);
            _sysConfig["Database"]["Port"].SetValue(tboxPort.Text);
            _sysConfig["Database"]["Password"].SetValue(tboxPassword.Text);
            _sysConfig["Database"]["Charset"].SetValue(cboxCharset.Text);
        }

        //通过mysql配置参数生成需要建立mysql连接的配置字符串
        private string GetConnString()
        {
            updateSysconfig();
            if (tboxDbName.Text == "" || tboxHostName.Text == "" || tboxPort.Text == "" || tboxUserName.Text == "" || cboxCharset.Text == "")
            {
                MessageBox.Show("请将数据库配置信息填写完整！", "提示！", MessageBoxButtons.OK);
                return "";
            }
            return (@"Server=" + tboxHostName.Text + @";DataBase=" + tboxDbName.Text + @";Uid=" + tboxUserName.Text + @";Pwd=" + tboxPassword.Text + @";charset=" + cboxCharset.Text);
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

        private string getFilter()
        {
            string filter = "";
            if (cboxFilterCo_name.Text!="" && tboxFilterCo_name.Text!="")
            {
                filter += " where co_name " + cboxFilterCo_name.Text + " '"+tboxFilterCo_name.Text+"' ";
            }

            if (cboxFilterType_name.Text!="" && tboxFilterType_name.Text!="")
            {
                if (filter!="")
                {
                    filter+= " and  type_name " + cboxFilterType_name.Text + " '" + tboxFilterType_name.Text + "' ";
                }
                else
                {
                    filter += " where type_name " + cboxFilterType_name.Text + " '" + tboxFilterType_name.Text + "' ";
                }
            }
            if (cboxFilterSource_site.Text != "" && tboxFilterSource_site.Text != "")
            {
                if (filter != "")
                {
                    filter += " and  source_site " + cboxFilterSource_site.Text + " '" + tboxFilterSource_site.Text + "' ";
                }
                else
                {
                    filter += " where source_site " + cboxFilterSource_site.Text + " '" + tboxFilterSource_site.Text + "' ";
                }
            }
            if (cboxFilterCo_nums.Text != "" && tboxFilterCo_nums.Text != "")
            {
                try
                {
                    int nums = int.Parse(tboxFilterCo_nums.Text);
                    if (filter != "")
                    {
                        filter += " and  co_nums " + cboxFilterCo_nums.Text + " '" + tboxFilterCo_nums.Text + "' ";
                    }
                    else
                    {
                        filter += " where co_nums " + cboxFilterCo_nums.Text + " '" + tboxFilterCo_nums.Text + "' ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("采集数量过滤器输入错误，请检查是否为纯数字！");
                }
            }
            return filter;
        }

        private void loadCoConfig()
        {
            _connString = GetConnString();
            if (_connString != "")
            {
                listViewCollect.Items.Clear();
                mySqlDB myDB = new mySqlDB(_connString);
                string sResult = "";
                int counts = 0;
                string filter = getFilter();
                string sql = @"select cid,co_name,type_name,source_lang,source_site,up_time,co_time,co_nums from co_config";
                if (filter != "")
                {
                    sql += filter;
                }
                List<Dictionary<string, object>> coConfigRecords = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS)
                {
                    listViewCollect.GridLines = true;
                    listViewCollect.BeginUpdate();
                    foreach (Dictionary<string, object> item in coConfigRecords)
                    {
                        List<string> subItems = new List<string>();
                        foreach (KeyValuePair<string, object> kvp in item)
                        {
                            subItems.Add(kvp.Value.ToString());
                        }
                        ListViewItem listItem = new ListViewItem(subItems.ToArray());
                        listViewCollect.Items.Add(listItem);
                    }
                    listViewCollect.EndUpdate();
                    listViewCollect.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                }
                else
                {
                    MessageBox.Show(string.Format("加载数据出错!：{0}", sResult));
                }
            }
        }

        //保存配置信息到配置文件中
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            updateSysconfig();
            _sysConfig.SaveToFile(_configFile);
        }

        private void btnLoadCoconfig_Click(object sender, EventArgs e)
        {
            loadCoConfig();
        } //end of btnLoadCoconfig_Click

        private void btnModifyCoconfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewCollect.CheckedItems[0];
                long cid = long.Parse(checkedItem.SubItems[0].Text);
                CoForm coFormModify = new CoForm(_connString, cid);
                coFormModify.Text = "修改采集规则";
                coFormModify.Show();
                this.Enabled = false;
                coFormModify.FormClosed += CoFormModify_FormClosed;

            }
            catch (Exception ex)
            {
                MessageBox.Show("未选中任何采集规则，请选择需要修改的采集规则！");
            }
        }

        private void btnAddCoconfig_Click(object sender, EventArgs e)
        {
            CoForm coFormAdd = new CoForm(_connString, -1);
            coFormAdd.Text = "添加新采集规则";
            coFormAdd.Show();
            this.Enabled = false;
            coFormAdd.FormClosed += CoFormModify_FormClosed;

        }

        private void btnDeleteCoconfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.CheckedListViewItemCollection checkedItems= listViewCollect.CheckedItems;
                if (checkedItems.Count>0)
                {
                    List<long> cidList = new List<long>();
                    string cidString = "";
                    foreach (ListViewItem item in checkedItems)
                    {
                        long cid = long.Parse(item.SubItems[0].Text);
                        cidList.Add(cid);
                        cidString = cidString + cid.ToString() + ", ";
                    }
                    string showMessage = "确认删除采集以下" + checkedItems.Count.ToString() + "项采集规则项？: " + cidString.TrimEnd(',', ' ');
                    if (MessageBox.Show(showMessage, "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mySqlDB myDB = new mySqlDB(_connString);
                        string sResult = "";
                        int counts = 0;
                        string deletedItems = "";
                        string unDeletedItems = "";
                        string errorMessage = "";
                        string messageAfterDelete = "";
                        foreach (long id in cidList)
                        {
                            string sql = "delete from co_config where cid = '" + id.ToString() + "'";
                            try
                            {
                                counts = myDB.executeDMLSQL(sql, ref sResult);
                                if (sResult == mySqlDB.SUCCESS && counts == 1)
                                    deletedItems = deletedItems + id.ToString() + ", ";
                                else
                                    unDeletedItems = unDeletedItems + id.ToString() + ", ";
                            }
                            catch (Exception exDb)
                            {
                                errorMessage = errorMessage + exDb.Message+"\n";
                                unDeletedItems = unDeletedItems + ", ";
                            }
                        }
                        if (deletedItems!="")
                        {
                            messageAfterDelete = "成功删除以下规则：" + deletedItems.TrimEnd(',', ' ')+"\n";
                            if (unDeletedItems != "")
                                messageAfterDelete = messageAfterDelete + "未成功删除项：" + unDeletedItems.TrimEnd(',', ' ') + "\n";
                            messageAfterDelete = messageAfterDelete + errorMessage;
                        }
                        else if (unDeletedItems!="")
                        {
                            messageAfterDelete = messageAfterDelete + "未成功删除项：" + unDeletedItems.TrimEnd(',', ' ') + "\n"+errorMessage;
                        }
                        MessageBox.Show(messageAfterDelete);
                        loadCoConfig();
                    }
                }
                else
                {
                    MessageBox.Show("未选中任何采集规则，请选择要删除的规则项！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("删除出错！{0}",ex.Message));
            }

        }

        private void btnCopyCoconfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewCollect.CheckedItems[0];
                long cid = long.Parse(checkedItem.SubItems[0].Text);
                string coName = checkedItem.SubItems[1].Text;
                mySqlDB myDB = new mySqlDB(_connString);
                string sResult = "";
                int count = 0;
                long LastInsertedId;
                string sql = "insert into co_config(co_name,type_name,source_lang,source_site,co_offline,list_path,more_list_pages,xpath_arcurl_node,";
                sql=sql+ " xpath_title_node,xpath_content_node,arc_subpage_symbol,arc_subpage_startnum,sub_node_params,regex_params) ";
                sql = sql + " select co_name,type_name,source_lang,source_site,co_offline,list_path,more_list_pages,xpath_arcurl_node,";
                sql = sql + "xpath_title_node,xpath_content_node,arc_subpage_symbol,arc_subpage_startnum,sub_node_params,regex_params";
                sql =sql+" from co_config where cid = '" + cid.ToString() + "'";
                count = myDB.executeDMLSQL(sql, ref sResult);
                if (sResult == mySqlDB.SUCCESS && count == 1)
                {
                    LastInsertedId = myDB.LastInsertedId;
                    MessageBox.Show(string.Format("复制成功！复制的采集规则ID为：{0}", LastInsertedId));
                    string sqlRename = "update co_config set co_name = '" + coName + "复件'" + " where cid ='" + LastInsertedId.ToString() + "'";
                    count = myDB.executeDMLSQL(sqlRename, ref sResult);
                    loadCoConfig();
                }
                else
                {
                    MessageBox.Show(string.Format("复制失败：{0}",sResult));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请选择需要复制的采集规则项！");
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cboxFilterCo_name.SelectedIndex = -1;
            cboxFilterCo_nums.SelectedIndex = -1;
            cboxFilterSource_site.SelectedIndex = -1;
            cboxFilterType_name.SelectedIndex = -1;
            tboxFilterCo_name.Text = "";
            tboxFilterCo_nums.Text = "";
            tboxFilterSource_site.Text = "";
            tboxFilterType_name.Text = "";
            loadCoConfig();
        }


    }
}
