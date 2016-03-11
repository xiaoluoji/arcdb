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
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Diagnostics;



namespace ArcDB
{
    public partial class MainForm : Form
    {
        private readonly string RootPath = Application.StartupPath + @"\";     //程序根目录
        private string _configFile;                                                                        //程序配置文件
        private Configuration _sysConfig;                                                           //保存配置的变量
        private string _coConnString;                                                                  //建立采集数据库连接的配置变量
        private string _pubConnString;                                                               //建立发布数据库连接的配置变量
        private string _pubTablePrename;                                                          //CMS数据库中的表前缀

        #region Main Form相关
        public MainForm()
        {
            InitializeComponent();
            _configFile = RootPath + "config.ini";
            CheckForIllegalCrossThreadCalls = false;
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

        //主窗口关闭后的处理
        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            updateSysconfig();
            _sysConfig.SaveToFile(_configFile);
        }

        //读取配置文件中的对应配置，并且更新到相应的控件中
        private void loadSysconfig()
        {
            //采集数据库
            tboxCoHostName.Text = _sysConfig["CoDatabase"]["Hostname"].StringValue;
            tboxCoUserName.Text = _sysConfig["CoDatabase"]["Username"].StringValue;
            tboxCoDbName.Text = _sysConfig["CoDatabase"]["Dbname"].StringValue;
            tboxCoPort.Text = _sysConfig["CoDatabase"]["Port"].StringValue;
            tboxCoPassword.Text = _sysConfig["CoDatabase"]["Password"].StringValue;
            cboxCoCharset.Text = _sysConfig["CoDatabase"]["Charset"].StringValue;
            //发布数据库
            tboxPubHostName.Text = _sysConfig["PubDatabase"]["Hostname"].StringValue;
            tboxPubUserName.Text = _sysConfig["PubDatabase"]["Username"].StringValue;
            tboxPubDbName.Text = _sysConfig["PubDatabase"]["Dbname"].StringValue;
            tboxPubPort.Text = _sysConfig["PubDatabase"]["Port"].StringValue;
            tboxPubPassword.Text = _sysConfig["PubDatabase"]["Password"].StringValue;
            cboxPubCharset.Text = _sysConfig["PubDatabase"]["Charset"].StringValue;
            tboxPubTablePrename.Text = _sysConfig["PubDatabase"]["TablePrename"].StringValue;
        }

        //更新sysConfig对象中的配置参数
        private void updateSysconfig()
        {
            //采集数据库
            _sysConfig["CoDatabase"]["Hostname"].SetValue(tboxCoHostName.Text);
            _sysConfig["CoDatabase"]["Username"].SetValue(tboxCoUserName.Text);
            _sysConfig["CoDatabase"]["Dbname"].SetValue(tboxCoDbName.Text);
            _sysConfig["CoDatabase"]["Port"].SetValue(tboxCoPort.Text);
            _sysConfig["CoDatabase"]["Password"].SetValue(tboxCoPassword.Text);
            _sysConfig["CoDatabase"]["Charset"].SetValue(cboxCoCharset.Text);
            //发布数据库
            _sysConfig["PubDatabase"]["Hostname"].SetValue(tboxPubHostName.Text);
            _sysConfig["PubDatabase"]["Username"].SetValue(tboxPubUserName.Text);
            _sysConfig["PubDatabase"]["Dbname"].SetValue(tboxPubDbName.Text);
            _sysConfig["PubDatabase"]["Port"].SetValue(tboxPubPort.Text);
            _sysConfig["PubDatabase"]["Password"].SetValue(tboxPubPassword.Text);
            _sysConfig["PubDatabase"]["Charset"].SetValue(cboxPubCharset.Text);
            _sysConfig["PubDatabase"]["TablePrename"].SetValue(tboxPubTablePrename.Text);
        }

        //通过mysql配置参数生成需要建立采集数据库mysql连接的配置字符串
        private string GetCoConnString()
        {
            updateSysconfig();
            if (tboxCoDbName.Text == "" || tboxCoHostName.Text == "" || tboxCoPort.Text == "" || tboxCoUserName.Text == "" || cboxCoCharset.Text == "" || tboxCoPort.Text == "")
            {
                MessageBox.Show("请将采集数据库配置信息填写完整！", "提示！", MessageBoxButtons.OK);
                return "";
            }
            return (@"Server=" + tboxCoHostName.Text + @";DataBase=" + tboxCoDbName.Text + @";Uid=" + tboxCoUserName.Text + @";Pwd=" + tboxCoPassword.Text + @";charset=" + cboxCoCharset.Text + @";port=" + tboxCoPort.Text);
        }

        //通过mysql配置参数生成需要建立发布数据库mysql连接的配置字符串
        private string GetPubConnString()
        {
            updateSysconfig();
            _pubTablePrename = tboxPubTablePrename.Text;
            if (tboxPubDbName.Text == "" || tboxPubHostName.Text == "" || tboxPubPort.Text == "" || tboxPubUserName.Text == "" || cboxPubCharset.Text == "" || tboxPubPort.Text == "")
            {
                MessageBox.Show("请将发布数据库配置信息填写完整！", "提示！", MessageBoxButtons.OK);
                return "";
            }
            return (@"Server=" + tboxPubHostName.Text + @";DataBase=" + tboxPubDbName.Text + @";Uid=" + tboxPubUserName.Text + @";Pwd=" + tboxPubPassword.Text + @";charset=" + cboxPubCharset.Text + @";port=" + tboxPubPort.Text);
        }

        //保存配置信息到配置文件中
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            updateSysconfig();
            try
            {
                _sysConfig.SaveToFile(_configFile);
                MessageBox.Show("保存配置成功！");
            }
            catch (Exception)
            {
                MessageBox.Show("保存配置失败！");
            }
        }

        #endregion   Main Form 相关方法结束


        #region 采集规则功能块（增删改查）
        private void CoFormModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadCoConfig();
        }
        private void CoArticleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadCoConfig();
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

        //获取采集过滤器
        private string getCoFilter()
        {
            string filter = "";
            if (cboxCoFilterCo_name.Text!="" && tboxCoFilterCo_name.Text!="")
            {
                filter += " where co_name " + cboxCoFilterCo_name.Text + " '"+tboxCoFilterCo_name.Text+"' ";
            }

            if (cboxCoFilterType_name.Text!="" && tboxCoFilterType_name.Text!="")
            {
                if (filter!="")
                {
                    filter+= " and  type_name " + cboxCoFilterType_name.Text + " '" + tboxCoFilterType_name.Text + "' ";
                }
                else
                {
                    filter += " where type_name " + cboxCoFilterType_name.Text + " '" + tboxCoFilterType_name.Text + "' ";
                }
            }
            if (cboxCoFilterSource_site.Text != "" && tboxCoFilterSource_site.Text != "")
            {
                if (filter != "")
                {
                    filter += " and  source_site " + cboxCoFilterSource_site.Text + " '" + tboxCoFilterSource_site.Text + "' ";
                }
                else
                {
                    filter += " where source_site " + cboxCoFilterSource_site.Text + " '" + tboxCoFilterSource_site.Text + "' ";
                }
            }
            if (cboxCoFilterCo_nums.Text != "" && tboxCoFilterCo_nums.Text != "")
            {
                try
                {
                    int nums = int.Parse(tboxCoFilterCo_nums.Text);
                    if (filter != "")
                    {
                        filter += " and  co_nums " + cboxCoFilterCo_nums.Text + " '" + tboxCoFilterCo_nums.Text + "' ";
                    }
                    else
                    {
                        filter += " where co_nums " + cboxCoFilterCo_nums.Text + " '" + tboxCoFilterCo_nums.Text + "' ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("采集数量过滤器输入错误，请检查是否为纯数字！");
                }
            }
            return filter;
        }
        //加载采集规则
        private void loadCoConfig()
        {
            _coConnString = GetCoConnString();
            if (_coConnString != "")
            {
                listViewCollect.Items.Clear();
                mySqlDB myDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string filter = getCoFilter();
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
                            if (kvp.Key == "up_time" || kvp.Key == "co_time")
                            {
                                string fullDate = kvp.Value.ToString();
                                try  //尝试将完整时间格式转换成短日期格式
                                {
                                    if (fullDate=="")
                                    {
                                        subItems.Add(fullDate);
                                    }
                                    else
                                    {
                                        DateTime dt = DateTime.Parse(fullDate);
                                        string shortDate = dt.ToShortDateString();
                                        subItems.Add(shortDate);
                                    }

                                }
                                catch (Exception)   //如果转换失败，则继续用完整日期格式
                                {
                                    subItems.Add(fullDate);
                                }
                            }
                            else
                            {
                                subItems.Add(kvp.Value.ToString());
                            }
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
        //加载采集规则
        private void btnLoadCoconfig_Click(object sender, EventArgs e)
        {
            loadCoConfig();
        } //end of btnLoadCoconfig_Click

        //修改采集规则
        private void btnModifyCoconfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewCollect.CheckedItems[0];
                long cid = long.Parse(checkedItem.SubItems[0].Text);
                CoConfigForm coFormModify = new CoConfigForm(_coConnString, cid,this);
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
        //增加采集规则
        private void btnAddCoconfig_Click(object sender, EventArgs e)
        {
            CoConfigForm coFormAdd = new CoConfigForm(_coConnString, -1,this);
            coFormAdd.Text = "添加新采集规则";
            coFormAdd.Show();
            this.Enabled = false;
            coFormAdd.FormClosed += CoFormModify_FormClosed;

        }
        //删除采集规则
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
                    string showMessage = "确认删除以下" + checkedItems.Count.ToString() + "项采集规则项？: " + cidString.TrimEnd(',', ' ');
                    if (MessageBox.Show(showMessage, "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mySqlDB myDB = new mySqlDB(_coConnString);
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
        //复制采集规则
        private void btnCopyCoconfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewCollect.CheckedItems[0];
                long cid = long.Parse(checkedItem.SubItems[0].Text);
                string coName = checkedItem.SubItems[1].Text;
                mySqlDB myDB = new mySqlDB(_coConnString);
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
        //清空采集过滤器
        private void btnClearCoFilter_Click(object sender, EventArgs e)
        {
            cboxCoFilterCo_name.SelectedIndex = -1;
            cboxCoFilterCo_nums.SelectedIndex = -1;
            cboxCoFilterSource_site.SelectedIndex = -1;
            cboxCoFilterType_name.SelectedIndex = -1;
            tboxCoFilterCo_name.Text = "";
            tboxCoFilterCo_nums.Text = "";
            tboxCoFilterSource_site.Text = "";
            tboxCoFilterType_name.Text = "";
            loadCoConfig();
        }
        //执行选中采集规则项的采集工作
        private void btnCoArticles_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewCollect.CheckedItems;
            if (checkedItems.Count>0)
            {
                Dictionary<long, string> dicCids = new Dictionary<long, string>();
                foreach (ListViewItem item in checkedItems)
                {
                    long cid = long.Parse(item.SubItems[0].Text);
                    dicCids.Add(cid, item.SubItems[1].Text);
                }
                CoArticleForm coArticleForm = new CoArticleForm(_coConnString, dicCids);
                coArticleForm.Show();
                coArticleForm.StartCoTask();
                this.Enabled = false;
                coArticleForm.FormClosed += CoArticleForm_FormClosed;
            }
            else
            {
                MessageBox.Show("未选中任何采集项，请至少选择一项采集规则！");
            }

        }
        //全选采集规则
        private void btnCoSelectAll_Click(object sender, EventArgs e)
        {
            ListView.ListViewItemCollection items = listViewCollect.Items;
            foreach (ListViewItem item in items)
            {
                item.Checked = true;
            }
        }
        //取消全选采集规则
        private void btnCoUnselectAll_Click(object sender, EventArgs e)
        {
            ListView.ListViewItemCollection items = listViewCollect.Items;
            foreach (ListViewItem item in items)
            {
                item.Checked = false;
            }
        }
        #endregion   采集规则功能块结束



        //以下是发布功能模块的相关方法
        #region 发布规则功能块（增删改查）


        //全选发布规则
        private void btnPubSelectAll_Click(object sender, EventArgs e)
        {
            ListView.ListViewItemCollection items = listViewPublish.Items;
            foreach (ListViewItem item in items)
            {
                item.Checked = true;
            }
        }
        //取消全选发布规则
        private void btnPubUnselectAll_Click(object sender, EventArgs e)
        {
            ListView.ListViewItemCollection items = listViewPublish.Items;
            foreach (ListViewItem item in items)
            {
                item.Checked = false;
            }
        }
        //获取采集过滤器
        private string getPubFilter()
        {
            string filter = "";
            if (cboxPubFilterPub_name.Text != "" && tboxPubFilterPub_name.Text != "")
            {
                filter += " where pub_name " + cboxPubFilterPub_name.Text + " '" + tboxPubFilterPub_name.Text + "' ";
            }

            if (cboxPubFilterCo_typename.Text != "" && tboxPubFilterCo_typename.Text != "")
            {
                if (filter != "")
                {
                    filter += " and  co_typename " + cboxPubFilterCo_typename.Text + " '" + tboxPubFilterCo_typename.Text + "' ";
                }
                else
                {
                    filter += " where co_typename " + cboxPubFilterCo_typename.Text + " '" + tboxPubFilterCo_typename.Text + "' ";
                }
            }
            if (cboxPubFilterPub_typename.Text != "" && tboxPubFilterPub_typename.Text != "")
            {
                if (filter != "")
                {
                    filter += " and  pub_typename " + cboxPubFilterPub_typename.Text + " '" + tboxPubFilterPub_typename.Text + "' ";
                }
                else
                {
                    filter += " where pub_typename " + cboxPubFilterPub_typename.Text + " '" + tboxPubFilterPub_typename.Text + "' ";
                }
            }
            return filter;
        }
        //加载采集规则方法
        private void loadPubConfig()
        {
            _coConnString = GetCoConnString();
            _pubConnString = GetPubConnString();
            if (_coConnString != "" && _pubConnString!="")
            {
                listViewPublish.Items.Clear();
                mySqlDB myDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string filter = getPubFilter();
                string sql = @"select id,pub_name,co_typename,arc_type.unused_nums,pub_typename,pub_nums,published_nums,pub_add_date,pub_export_date from pub_config left join arc_type on pub_config.co_typeid=arc_type.tid";
                if (filter != "")
                {
                    sql += filter;
                }
                List<Dictionary<string, object>> pubConfigRecords = myDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS)
                {
                    listViewPublish.GridLines = true;
                    listViewPublish.BeginUpdate();
                    foreach (Dictionary<string, object> item in pubConfigRecords)
                    {
                        List<string> subItems = new List<string>();
                        foreach (KeyValuePair<string, object> kvp in item)
                        {
                            if (kvp.Key=="pub_add_date" || kvp.Key=="pub_export_date")
                            {
                                string fullDate = kvp.Value.ToString();
                                try  //尝试将完整时间格式转换成短日期格式
                                {
                                    if (fullDate=="")
                                    {
                                        subItems.Add(fullDate);
                                    }
                                    else
                                    {
                                        DateTime dt = DateTime.Parse(fullDate);
                                        string shortDate = dt.ToShortDateString();
                                        subItems.Add(shortDate);
                                    }

                                }
                                catch (Exception)   //如果转换失败，则继续用完整日期格式
                                {
                                    subItems.Add(fullDate);
                                }
                            }
                            else
                            {
                                if (kvp.Key== "unused_nums")
                                {
                                    string unUsedNums = kvp.Value.ToString();
                                    if (unUsedNums == "")
                                        unUsedNums = "0";
                                    subItems.Add(unUsedNums);
                                }
                                else
                                {
                                    subItems.Add(kvp.Value.ToString());
                                }
                            }
                        }
                        ListViewItem listItem = new ListViewItem(subItems.ToArray());
                        listViewPublish.Items.Add(listItem);
                    }
                    listViewPublish.EndUpdate();
                    listViewPublish.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                }
                else
                {
                    MessageBox.Show(string.Format("加载数据出错!：{0}", sResult));
                }
            }
            else
            {
                MessageBox.Show("请正确填写采集数据库和发布数据库配置信息！");
            }
        }
        //点击加载发布规则按钮
        private void btnLoadPubConfig_Click(object sender, EventArgs e)
        {
            loadPubConfig();
        }
        //点击修改发布规则按钮
        private void btnModifyPubConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewPublish.CheckedItems[0];
                int pubID = int.Parse(checkedItem.SubItems[0].Text);
                PubConfigForm pubFormModify = new PubConfigForm(_coConnString,_pubConnString, pubID,_pubTablePrename,this);
                pubFormModify.Text = "修改发布规则";
                pubFormModify.Show();
                this.Enabled = false;
                pubFormModify.FormClosed += PubFormModify_FormClosed;

            }
            catch (Exception ex)
            {
                MessageBox.Show("未选中任何采集规则，请选择需要修改的采集规则！");
            }
        }

        private void PubFormModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadPubConfig();
        }

        //点击增加发布规则按钮
        private void btnAddPubConfig_Click(object sender, EventArgs e)
        {
            PubConfigForm pubFormAdd = new PubConfigForm(_coConnString, _pubConnString, -1,_pubTablePrename,this);
            pubFormAdd.Text = "新增发布规则";
            pubFormAdd.Show();
            this.Enabled = false;
            pubFormAdd.FormClosed += PubFormAdd_FormClosed;

        }

        private void PubFormAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadPubConfig();
        }

        //点击复制发布规则按钮
        private void btnCopyPubConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem checkedItem = listViewPublish.CheckedItems[0];
                long pubID = long.Parse(checkedItem.SubItems[0].Text);
                string pubName = checkedItem.SubItems[1].Text;
                mySqlDB myDB = new mySqlDB(_coConnString);
                string sResult = "";
                int count = 0;
                long LastInsertedId;
                string sql = "insert into pub_config(pub_name,co_typeid,co_typename,pub_typeid,pub_typename,pub_nums,random_date_start,random_date_stop)";
                sql = sql + " select pub_name,co_typeid,co_typename,pub_typeid,pub_typename,pub_nums,random_date_start,random_date_stop";
                sql = sql + " from pub_config where id = '" + pubID.ToString() + "'";
                count = myDB.executeDMLSQL(sql, ref sResult);
                if (sResult == mySqlDB.SUCCESS && count == 1)
                {
                    LastInsertedId = myDB.LastInsertedId;
                    MessageBox.Show(string.Format("复制成功！复制的发布规则ID为：{0}", LastInsertedId));
                    string sqlRename = "update pub_config set pub_name = '" + pubName + "复件'" + " where id ='" + LastInsertedId.ToString() + "'";
                    count = myDB.executeDMLSQL(sqlRename, ref sResult);
                    loadPubConfig();
                }
                else
                {
                    MessageBox.Show(string.Format("复制失败：{0}", sResult));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请选择需要复制的发布规则项！");
            }
        }
        //点击删除发布规则按钮
        private void btnDelPubConfig_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.CheckedListViewItemCollection checkedItems = listViewPublish.CheckedItems;
                if (checkedItems.Count > 0)
                {
                    List<long> pubIDList = new List<long>();
                    string pubIDString = "";
                    foreach (ListViewItem item in checkedItems)
                    {
                        long pubID = long.Parse(item.SubItems[0].Text);
                        pubIDList.Add(pubID);
                        pubIDString = pubIDString + pubID.ToString() + ", ";
                    }
                    string showMessage = "确认删除以下" + checkedItems.Count.ToString() + "项发布规则项？: " + pubIDString.TrimEnd(',', ' ');
                    if (MessageBox.Show(showMessage, "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mySqlDB myDB = new mySqlDB(_coConnString);
                        string sResult = "";
                        int counts = 0;
                        string deletedItems = "";
                        string unDeletedItems = "";
                        string errorMessage = "";
                        string messageAfterDelete = "";
                        foreach (long id in pubIDList)
                        {
                            string sql = "delete from pub_config where id = '" + id.ToString() + "'";
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
                                errorMessage = errorMessage + exDb.Message + "\n";
                                unDeletedItems = unDeletedItems + ", ";
                            }
                        }
                        if (deletedItems != "")
                        {
                            messageAfterDelete = "成功删除以下规则：" + deletedItems.TrimEnd(',', ' ') + "\n";
                            if (unDeletedItems != "")
                                messageAfterDelete = messageAfterDelete + "未成功删除项：" + unDeletedItems.TrimEnd(',', ' ') + "\n";
                            messageAfterDelete = messageAfterDelete + errorMessage;
                        }
                        else if (unDeletedItems != "")
                        {
                            messageAfterDelete = messageAfterDelete + "未成功删除项：" + unDeletedItems.TrimEnd(',', ' ') + "\n" + errorMessage;
                        }
                        MessageBox.Show(messageAfterDelete);
                        loadPubConfig();
                    }
                }
                else
                {
                    MessageBox.Show("未选中任何采集规则，请选择要删除的规则项！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("删除出错！{0}", ex.Message));
            }
        }
        //点击清空发布过滤器按钮
        private void btnClearPubFilter_Click(object sender, EventArgs e)
        {
            cboxPubFilterCo_typename.SelectedIndex = -1;
            cboxPubFilterPub_name.SelectedIndex = -1;
            cboxPubFilterPub_typename.SelectedIndex = -1;
            tboxPubFilterCo_typename.Text = "";
            tboxPubFilterPub_name.Text = "";
            tboxPubFilterPub_typename.Text = "";
            loadPubConfig();
        }

        //点击开始发布按钮
        private void btnPubArticles_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listViewPublish.CheckedItems;
            if (checkedItems.Count > 0)
            {
                List<string> listPubID = new List<string>();
                foreach (ListViewItem item in checkedItems)
                {
                    string pubID = item.SubItems[0].Text;
                    listPubID.Add(pubID);
                }
                PubArticleForm pubArticleForm = new PubArticleForm(listPubID,_coConnString,_pubConnString,_pubTablePrename);
                pubArticleForm.Show();
                pubArticleForm.StartPubTask();
                this.Enabled = false;
                pubArticleForm.FormClosed += PubArticleForm_FormClosed;
            }
            else
            {
                MessageBox.Show("未选中任何采集项，请至少选择一项采集规则！");
            }
        }

        private void PubArticleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            loadPubConfig();
        }

        #endregion   发布规则功能块结束

        #region 文章相关工具模块
        //重新生成采集数据库的文章概要
        private void btnGetCoArcDesc_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(getCoArticleDescription,null);
        }
        //重新生成发布数据库文章的概要
        private void btnGetPubArcDesc_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(setPubArticleDescription, null);
        }
        //生成文章点击数数据
        private void btnCreateHitsRecords_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(createHitsRecords, null);
        } 
        //重新生成所有图片的缩略图
        private void btnRegenerateAllthumbs_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(reGenarateAllthumbs, null);
        }
        private void getCoArticleDescription(object state)
        {
            _coConnString = GetCoConnString();
            int descriptionLength=120;
            int finishedArticles = 0;
            if (int.TryParse(tboxCoArcDescLength.Text,out descriptionLength))
            {
                descriptionLength = int.Parse(tboxCoArcDescLength.Text);
            }
            else
            {
                MessageBox.Show("文章概要长度值不是整数，使用默认长度120！");
            }
            if (_coConnString!="")
            {
                System.Threading.Timer timer = new System.Threading.Timer(
                    //timeCB,
                    //PrintTime,      //TimerCallBack委托对象
                    delegate {
                        this.Invoke((Action)delegate { lblFinishedGetCoArcDescCounts.Text = string.Format("{0}", finishedArticles); });
                    },
                    //(object state)=>labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()),
                    null,           //想传入的参数 （null表示没有参数）
                    0,              //在开始之前，等待多长时间（以毫秒为单位）
                    1000);       //每次调用的间隔时间（以毫秒为单位）
                mySqlDB coMyDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string sql = "select aid,title,content from arc_contents where description is null limit 1";
                List<Dictionary<string, object>> articleRecord=new List<Dictionary<string, object>>();
                articleRecord = coMyDB.GetRecords(sql, ref sResult, ref counts);
                while (sResult==mySqlDB.SUCCESS && counts>0)
                {
                    string aid = articleRecord[0]["aid"].ToString();
                    string title= articleRecord[0]["title"].ToString();
                    string arcContent = articleRecord[0]["content"].ToString();
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
                        if (arcContentPiece.Length>200)
                        {
                            arcContentPiece = arcContentPiece.Substring(0, 200);
                        }
                        string description = ArcTool.GetDescription(arcContentPiece, descriptionLength);
                        string updateSql = "update arc_contents set description='" + description + "' where aid='" + aid+"'";
                        counts=coMyDB.executeDMLSQL(updateSql,ref sResult);
                        if (sResult==mySqlDB.SUCCESS && counts>0)
                        {
                            finishedArticles += 1;
                        }
                        else
                        {
                            tboxArctoolOutput.AppendText(string.Format("错误信息：{0}\n", sResult));
                        }
                    }
                    catch (Exception ex)
                    {
                        tboxArctoolOutput.AppendText(string.Format("错误信息：{0}: {1} : {2} \n", aid,title,ex.Message));
                    }
                    //再次从数据里获取一篇文章
                    articleRecord = coMyDB.GetRecords(sql, ref sResult, ref counts);
                }

            }
            else
            {
                MessageBox.Show("请正确配置采集数据库参数！");
            }

        }
        private void setPubArticleDescription(object state)
        {
            _coConnString = GetCoConnString();
            _pubConnString = GetPubConnString();
            int finishedArticles = 0;
            if (_pubConnString != "" && _coConnString != "")
            {
                System.Threading.Timer timer = new System.Threading.Timer(
                    //timeCB,
                    //PrintTime,      //TimerCallBack委托对象
                    delegate {
                        this.Invoke((Action)delegate { lblFinishedGetPubArcDescCount.Text = string.Format("{0}", finishedArticles); });
                    },
                    //(object state)=>labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()),
                    null,           //想传入的参数 （null表示没有参数）
                    0,              //在开始之前，等待多长时间（以毫秒为单位）
                    1000);       //每次调用的间隔时间（以毫秒为单位）

                mySqlDB coMyDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string sql = "select aid,cms_aid,description from arc_contents where description is not null and cms_aid is not null";
                List<Dictionary<string, object>> coRecords = coMyDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult == mySqlDB.SUCCESS && counts > 0)
                {
                    foreach (Dictionary<string, object> item in coRecords)
                    {
                        string cms_aid = item["cms_aid"].ToString();
                        string description = item["description"].ToString();
                        mySqlDB pubMyDB = new mySqlDB(_pubConnString);
                        sql = "update " + _pubTablePrename + "_news set description='" + description + "' where id='" + cms_aid + "'";
                        counts = pubMyDB.executeDMLSQL(sql, ref sResult);
                        if (counts > 0 && sResult == mySqlDB.SUCCESS)
                        {
                            finishedArticles += 1;
                        }
                        else
                        {
                            tboxArctoolOutput.AppendText(string.Format("错误信息：{0}\n", sResult));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请正确配置发布数据库参数！");
            }
        }
        //生成文章点击数数据
        private void createHitsRecords(object state)
        {
            _pubConnString = GetPubConnString();
            int finishedArticles = 0;
            if (_pubConnString != "")
            {
                System.Threading.Timer timer = new System.Threading.Timer(
                    //timeCB,
                    //PrintTime,      //TimerCallBack委托对象
                    delegate
                    {
                        this.Invoke((Action)delegate { lblFinishedCreateHitsRecordsCount.Text = string.Format("{0}", finishedArticles); });
                    },
                    //(object state)=>labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()),
                    null,           //想传入的参数 （null表示没有参数）
                    0,              //在开始之前，等待多长时间（以毫秒为单位）
                    1000);       //每次调用的间隔时间（以毫秒为单位）            }
                mySqlDB pubMydb = new mySqlDB(_pubConnString);
                string sResult = "";
                int counts = 0;
                string sql = "select count(id) from " + _pubTablePrename + "_news";
                List<Dictionary<string, object>> dbResult = new List<Dictionary<string, object>>();
                dbResult=pubMydb.GetRecords(sql, ref sResult, ref counts);
                if (sResult==mySqlDB.SUCCESS && counts>0)
                {
                    int articleCounts = int.Parse(dbResult[0]["count(id)"].ToString());
                    tboxArctoolOutput.AppendText(string.Format("文章总数：{0}\n", articleCounts));
                    int startPosition = 0;
                    int onceNums = 1000;
                    if (articleCounts>0)
                    {
                        while (startPosition<articleCounts)
                        {
                            sql="select id,catid from " + _pubTablePrename + "_news limit "+startPosition.ToString()+","+onceNums.ToString();
                            dbResult = pubMydb.GetRecords(sql, ref sResult, ref counts);
                            if (sResult==mySqlDB.SUCCESS && counts>0)
                            {
                                foreach (Dictionary<string,object> item in dbResult)
                                {
                                    string id = item["id"].ToString();
                                    string catid = item["catid"].ToString();
                                    string hitsid = "c-1-" + id.ToString();
                                    sql = "INSERT IGNORE INTO " + _pubTablePrename + "_hits(hitsid,catid) Values('" + hitsid + "','" + catid + "')";
                                    counts = pubMydb.executeDMLSQL(sql, ref sResult);
                                    if (sResult==mySqlDB.SUCCESS && counts>0)
                                    {
                                        finishedArticles += 1;
                                    }
                                    else
                                    {
                                        tboxArctoolOutput.AppendText(string.Format("插入hits表数据出错或记录已存在！sql语句：{0}  错误信息：{1}\n",sql,sResult));
                                    }
                                }
                                startPosition += onceNums;
                            }
                            else
                            {
                                tboxArctoolOutput.AppendText("CMS数据库获取文章ID和分类ID出错！终止\n");
                                break;
                            }
                        }
                    }
                }
            }

        }

        //重新生成所有图片的缩略图
        private void reGenarateAllthumbs(object state)
        {
            _coConnString = GetCoConnString();
            int thumbWidth = 158;
            int thumbHeight = 140;
            int finishedThumbs = 0;

            if (_coConnString != "")
            {
                System.Threading.Timer timer = new System.Threading.Timer(
                    //timeCB,
                    //PrintTime,      //TimerCallBack委托对象
                    delegate {
                        this.Invoke((Action)delegate { lblRegenerateThumbsCount.Text = string.Format("{0}", finishedThumbs); });
                    },
                    //(object state)=>labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()),
                    null,           //想传入的参数 （null表示没有参数）
                    0,              //在开始之前，等待多长时间（以毫秒为单位）
                    1000);       //每次调用的间隔时间（以毫秒为单位）
                mySqlDB coMyDB = new mySqlDB(_coConnString);
                string sResult = "";
                int counts = 0;
                string picBasepath = "";
                string sql = "select value from sys_config where varname='cfg_basepath'";
                List<Dictionary<string, object>> dbResult = coMyDB.GetRecords(sql, ref sResult, ref counts);
                if (sResult==mySqlDB.SUCCESS && counts>0)
                {
                    picBasepath = dbResult[0]["value"].ToString();
                }
                if (picBasepath!="")
                {
                    sql = "select pid,pic_path,is_thumb_maked from arc_pics where is_thumb_maked='no' limit 1";
                    List<Dictionary<string, object>> picRecord = new List<Dictionary<string, object>>();
                    picRecord = coMyDB.GetRecords(sql, ref sResult, ref counts);
                    string picRootpath = picBasepath + "src";
                    string thumbRootPath = picBasepath + "thumb";
                    while (sResult == mySqlDB.SUCCESS && counts > 0)
                    {
                        string pid = picRecord[0]["pid"].ToString();
                        string picPath = picRecord[0]["pic_path"].ToString();
                        string thumbPath = picPath.Replace(picRootpath, thumbRootPath);
                        string thumbDirpath = Path.GetDirectoryName(thumbPath);
                        string picFilename = Path.GetFileNameWithoutExtension(picPath);
                        string picExtenstion = Path.GetExtension(picPath);
                        string thumbFilename = thumbDirpath +@"\"+ picFilename + "." + thumbWidth.ToString() + picExtenstion;
                        if (!Directory.Exists(thumbDirpath))
                        {
                            Directory.CreateDirectory(thumbDirpath);
                        }
                        if (ArcTool.MakeThumb(picPath,thumbFilename,thumbWidth,thumbHeight,"Cut"))
                        {
                            sql = "update arc_pics set is_thumb_maked='yes' where pid='" + pid + "'";
                            counts = coMyDB.executeDMLSQL(sql, ref sResult);
                            if (sResult==mySqlDB.SUCCESS && counts>0)
                            {
                                finishedThumbs++;
                            }
                            else
                            {
                                tboxArctoolOutput.AppendText(string.Format("错误信息：更新arc_pics表错误 PID：{0}:  error:{1}  \n", pid,sResult));
                            }
                        }
                        else
                        {
                            tboxArctoolOutput.AppendText(string.Format("错误信息：生成缩略图错误: pid:{0} ！\n",pid));
                        }
                        //再次从数据里获取一篇文章
                        sql = "select pid,pic_path,is_thumb_maked from arc_pics where is_thumb_maked='no' limit 1";
                        picRecord = coMyDB.GetRecords(sql, ref sResult, ref counts);
                    }

                }

            }
            else
            {
                MessageBox.Show("请正确配置采集数据库参数！");
            }

        }


        #endregion 文章相关工具模块结束


    }
}
