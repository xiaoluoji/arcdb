using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;

namespace SharpMysql
{
    public class mySqlDB
    {
        //private string  connString  = "Server=127.0.0.1;Database=test;Uid=test;Pwd=test;charset=utf8"
        public static readonly string SUCCESS = "SUCCESS";
        private readonly string SERROR = "ERROR";
        private string connString;
        private MySqlConnection conn;
        public mySqlDB(string dbinfo)
        {
            connString = dbinfo;
        }

        /*GetRecords 直接返回一个类型为 List<Dictionary<string,object>>的list，如果有多行返回结果，则list记录着每一行记录*/
        public List<Dictionary<string, object>> GetRecords(string sSql, ref string sResult, ref int counts)
        {
            DataTable dt = new DataTable();
            List<Dictionary<string, object>> Records = new List<Dictionary<string, object>>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand sComm = new MySqlCommand();
                sComm.CommandText = sSql;
                sComm.Connection = conn;
                da.SelectCommand = sComm;
                da.Fill(dt);
                conn.Close();
                sResult = SUCCESS;
                counts = 0;
                foreach (DataRow row in dt.Rows)
                {
                    Dictionary<string, object> findResult = new Dictionary<string, object>();
                    foreach (DataColumn column in dt.Columns)
                    {
                        findResult.Add(column.Caption, row[column]);
                    }
                    counts = counts + 1;
                    Records.Add(findResult);
                }
            }
            catch (Exception ex)
            {
                sResult = SERROR + ": " + ex.Message;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            conn.Dispose();
            return Records;
        }

        /*executeDMLSQL 只是用来返回执行SQL命令后影响到的数据记录数，比如delete、insert操作所影响到的结果，以及成功状态通过引用变量返回*/

        public int executeDMLSQL(string sSql, ref string sResult)
        {
            int irows = 0;
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand sComm = new MySqlCommand();
                sComm.CommandText = sSql;
                sComm.Connection = conn;
                irows = sComm.ExecuteNonQuery();
                conn.Close();
                sResult = SUCCESS;
            }
            catch (Exception ex)
            {
                sResult = SERROR + ": " + ex.Message;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            conn.Dispose();
            return irows;
        }

        /*executeSQL 用来返回保存查寻结果的DataTable表，以及成功状态通过引用变量返回，由用户自行处理DataTable中的数据*/
        public DataTable executeSQL(string sSql, ref string sResult)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand sComm = new MySqlCommand();
                sComm.CommandText = sSql;
                sComm.Connection = conn;
                da.SelectCommand = sComm;
                da.Fill(dt);
                conn.Close();
                sResult = SUCCESS;
            }
            catch (Exception ex)
            {
                sResult = SERROR + ": " + ex.Message;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            conn.Dispose();
            return dt;
        }

        public static string EscapeString(string stringVar)
        {
            return MySqlHelper.EscapeString(stringVar);
        }
    }

}
