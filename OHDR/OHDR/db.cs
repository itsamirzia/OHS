using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace OHDR
{
    class db
    {
        public static MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["DBConnection"].ToString());
        public static MySqlConnection DBConnectionToCreateDB = new MySqlConnection(ConfigurationManager.AppSettings["DBConn"].ToString());
        //public static string username;



        #region        Mysql     Query And Execution

        public static bool SQLQuery(ref MySqlConnection MYSQL_connection, ref DataTable DTCombo, string querystr)
        {
            return SQLQuery(ref MYSQL_connection, ref DTCombo, querystr, false);
        }

        //INSTANT C# NOTE: Overloaded method(s) are created above to convert the following method having optional parameters:
        //ORIGINAL LINE: Public Function SQLQuery(ByRef MYSQL_connection As MySqlConnection, ByRef DTCombo As DataTable, ByVal querystr As String, Optional ByVal Throw_exception As Boolean = false) As Boolean
        public static bool SQLQuery(ref MySqlConnection MYSQL_connection, ref DataTable DTCombo, string querystr, bool Throw_exception)
        {
            DTCombo = new DataTable();
            MySqlDataAdapter ADAPTCombo = new MySqlDataAdapter();
            MySqlCommand mMySqlCommand = new MySqlCommand();
            mMySqlCommand.CommandTimeout = 600;
            //.CommandText = "SELECT * FROM escalation_table e where circle = 'ap' and nsn_site_id = 'aakc001' and level = 0" & _StrNSNSiteID & " and circle = '" & _StrCircleGenFrmReason & " '"
            mMySqlCommand.CommandText = querystr;
            mMySqlCommand.CommandType = CommandType.Text;
            mMySqlCommand.Connection = MYSQL_connection;

            //1st clear datatable
            DTCombo.Clear();

            //1st clear datatable
            if (MYSQL_connection.State != ConnectionState.Open)
            {
                if (!(MySql_Open(ref MYSQL_connection)))
                {
                    return false;
                }
            }

            ADAPTCombo.ReturnProviderSpecificTypes = true;
            ADAPTCombo.SelectCommand = mMySqlCommand;
            try
            {
                ADAPTCombo.Fill(DTCombo);
                return true;
            }
            catch (MySqlException ex)
            {
                if (Throw_exception)
                {
                    throw ex;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                MySql_Open(ref MYSQL_connection, Throw_exception);
                return false;
            }
        }

        // only for execution
        public static bool ExecuteSQLQuery(ref MySqlConnection MYSQL_connection, string querystr)
        {
            return ExecuteSQLQuery(ref MYSQL_connection, querystr, false);
        }

        //INSTANT C# NOTE: Overloaded method(s) are created above to convert the following method having optional parameters:
        //ORIGINAL LINE: Public Function ExecuteSQLQuery(ByRef MYSQL_connection As MySqlConnection, ByVal querystr As String, Optional ByVal Throw_exception As Boolean = false) As Boolean
        public static bool ExecuteSQLQuery(ref MySqlConnection MYSQL_connection, string querystr, bool Throw_exception)
        {
            MySqlCommand mMySqlCommand = new MySqlCommand();

            //.CommandText = "SELECT * FROM escalation_table e where circle = 'ap' and nsn_site_id = 'aakc001' and level = 0" & _StrNSNSiteID & " and circle = '" & _StrCircleGenFrmReason & " '"
            mMySqlCommand.CommandTimeout = 600;
            mMySqlCommand.CommandText = querystr;
            mMySqlCommand.CommandType = CommandType.Text;
            mMySqlCommand.Connection = MYSQL_connection;

            //1st clear datatable
            if (MYSQL_connection.State != ConnectionState.Open)
            {
                if (!(MySql_Open(ref MYSQL_connection)))
                {
                    return false;
                }
            }

            try
            {
                mMySqlCommand.Connection = MYSQL_connection;
                mMySqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                if (Throw_exception)
                {
                    throw ex;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                MySql_Open(ref MYSQL_connection, Throw_exception);
                return false;
            }
        }

        //mysql reconnect function
        public static bool MySql_Open(ref MySqlConnection conn)
        {
            return MySql_Open(ref conn, false);
        }

        //INSTANT C# NOTE: Overloaded method(s) are created above to convert the following method having optional parameters:
        //ORIGINAL LINE: Public Function MySql_Open(ByRef conn As MySqlConnection, Optional ByVal Throw_exception As Boolean = false) As Boolean
        public static bool MySql_Open(ref MySqlConnection conn, bool Throw_exception)
        {
            try
            {
                string constr = conn.ConnectionString;

                if (constr.Replace(" ", "").ToLower().IndexOf("password=") == -1)
                {
                    //here string do not have pass word so it can not be reinitialized  again 
                    //here we will only open connection
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (Throw_exception)
                        {
                            throw ex;
                        }
                        return false;
                    }
                }
                conn.Dispose();
                conn = new MySqlConnection(constr);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (conn.State == ConnectionState.Open)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (Throw_exception)
                {
                    throw ex;
                }
                return false;
            }
        }
        #endregion
    }
}
