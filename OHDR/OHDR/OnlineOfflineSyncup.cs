﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OHDR
{
    static class OnlineOfflineSyncup
    {
        private static int requestCounter = 1; //counter for pulling request in forward direction
        private static int requestPrintCounter = 1;//Counter for pulling print request
        public static int reverseRequestCounter = 10000;//counter for pulling request in reverse direction
        /// <summary>
        /// Update print status to online database when badge printing is successful.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="printedtime"></param>
        /// <param name="printstatus"></param>
        /// <returns>returns boolean</returns>
        public static bool UpdateOnlinePrintStatus(string userid, string printedtime, string printstatus)
        {
            try
            {
                string key = "9pFb5qoOIa0z7ztevOa1zMe38LklAnQZEa5MxLfhiWs=";
                string iv = "Wd9tszXf6y8Ua483d7XQGVNvu2bgj1zrUEZEZ4oFbiM=";
                string eventid = Properties.Settings.Default.EventID.ToString();
                string tokan = Encrypt(userid + "|" + eventid + "|" + printstatus + "|" + printedtime, key, iv);

                WebServicePuller.WebServicePortTypeClient client = new WebServicePuller.WebServicePortTypeClient();
                string response = JsonConvert.SerializeObject(client.update_print_status(tokan));
                response = response.TrimStart('\"');
                response = response.TrimEnd('\"');
                response = response.Replace("\\", "");
                if (response.Contains("Success"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        /// <summary>
        /// retry updating print status to online databse if failed in updating on badge printing success.
        /// </summary>
        public static void UpdateFailedPrintStatus()
        {
            DataTable dt = new DataTable();
            string query = "Select * from retry_print_status";
            db.SQLQuery(ref db.conn, ref dt, query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (UpdateOnlinePrintStatus(dr["user_id"].ToString(), dr["print_datetime"].ToString(), dr["print_status"].ToString()))
                    {
                        db.ExecuteSQLQuery(ref db.conn, "delete from retry_print_status where user_id='" + dr["user_id"].ToString() + "' and event_id='" + dr["event_id"].ToString() + "'");
                    }
                }
            }
        }
        /// <summary>
        /// Get registered data or total registered count(Depend on input)
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="rowcountRequest"></param>
        /// <param name="reverseRequest"></param>
        /// <returns>response string</returns>
        public static string GetOnlineData(int counter, bool rowcountRequest = false, string reverseRequest="no")
        {
            try
            {
                string key = "9pFb5qoOIa0z7ztevOa1zMe38LklAnQZEa5MxLfhiWs=";
                string iv = "Wd9tszXf6y8Ua483d7XQGVNvu2bgj1zrUEZEZ4oFbiM=";
                string eventid = Properties.Settings.Default.EventID.ToString();
                string tokan = string.Empty;
                if(!rowcountRequest)
                        tokan = Encrypt("@1m213R4|" + eventid + "|" + counter + "|no|"+reverseRequest, key, iv);
                else
                    tokan = Encrypt("@1m213R4|" + eventid + "|" + counter + "|yes|" + reverseRequest, key, iv);

                WebServicePuller.WebServicePortTypeClient client = new WebServicePuller.WebServicePortTypeClient();
                string response = JsonConvert.SerializeObject(client.get_message(tokan));
                response = response.TrimStart('\"');
                response = response.TrimEnd('\"');
                response = response.Replace("\\", "");
                return response;
            }
            catch(Exception) 
            { 
                return ""; 
            }
        }
        /// <summary>
        /// Get print status from online database to sync all environments
        /// </summary>
        /// <param name="counter"></param>
        /// <returns>returns response string</returns>
        public static string GetPrintStatus(int counter)
        {
            try
            {
                string key = "9pFb5qoOIa0z7ztevOa1zMe38LklAnQZEa5MxLfhiWs=";
                string iv = "Wd9tszXf6y8Ua483d7XQGVNvu2bgj1zrUEZEZ4oFbiM=";
                string eventid = Properties.Settings.Default.EventID.ToString();
                string tokan = string.Empty;
                tokan = Encrypt(eventid + "|" + counter, key, iv);

                WebServicePuller.WebServicePortTypeClient client = new WebServicePuller.WebServicePortTypeClient();
                string response = JsonConvert.SerializeObject(client.get_print_status(tokan));
                response = response.TrimStart('\"');
                response = response.TrimEnd('\"');
                response = response.Replace("\\", "");
                return response;
            }
            catch { return ""; }
        }
        /// <summary>
        /// update latest records if comes in online database.
        /// </summary>
        public static void UpdateLatestRecords()
        {
            string rows = GetOnlineData(1, true);
            if(!string.IsNullOrEmpty(rows))
            {
                int totalRows = Convert.ToInt32(rows);
                string response = GetOnlineData(totalRows, false, "yes");
                if (!string.IsNullOrEmpty(response))
                {
                    InsertRecordsInDB(response);
                }
            }
        }
        /// <summary>
        /// reset or increase counters 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="isPrintCounter"></param>
        /// <returns>boolean</returns>
        private static bool ResetOrIncreaseCounter(string response, bool isPrintCounter = false)
        {
            if (response.Contains("Info: DB Updated"))
            {
                if (isPrintCounter)
                    requestPrintCounter = 1;
                else
                    requestCounter = 1;
                return true;
            }
            else
            {
                if (isPrintCounter)
                    requestPrintCounter++;
                else
                    requestCounter++;
                return false;
            }
        }
        /// <summary>
        /// update offline database after successfully fetching records from online database
        /// </summary>
        public static void UpdateOfflineDatabase()
        {
            try
            {
                string response = GetOnlineData(requestCounter);
                if (!string.IsNullOrEmpty(response))
                {
                    if (ResetOrIncreaseCounter(response))
                        return;
                    InsertRecordsInDB(response);
                }
           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// insert records in offline database
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static bool InsertRecordsInDB(string response)
        {
            try
            {
                List<RegisterationDetail> Data = JsonConvert.DeserializeObject<List<RegisterationDetail>>(response);
                string queryData = string.Empty;
                foreach (RegisterationDetail rd in Data)
                {
                    queryData += "('" + rd.first_name + "','" + rd.last_name + "','" + rd.designation + "','" + rd.organization + "','" + rd.mobile_no + "','" + rd.email + "','" + rd.RDate + "','VISITOR','" + rd.id + "','" + rd.print_status + "'),";
                }


                string query = "replace into register values " + queryData.TrimEnd(',');
                if (db.ExecuteSQLQuery(ref db.conn, query))
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        /// <summary>
        /// Encryption
        /// </summary>
        /// <param name="prm_text_to_encrypt"></param>
        /// <param name="prm_key"></param>
        /// <param name="prm_iv"></param>
        /// <returns>encrypted string</returns>
        private static string Encrypt(string prm_text_to_encrypt, string prm_key, string prm_iv)
        {
            var sToEncrypt = prm_text_to_encrypt;

            var rj = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 256,
            };

            var key = Convert.FromBase64String(prm_key);
            var IV = Convert.FromBase64String(prm_iv);

            var encryptor = rj.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            var encrypted = msEncrypt.ToArray();

            return (Convert.ToBase64String(encrypted));
        }
        /// <summary>
        /// update offline database after pulling records from online database in reverse direction
        /// through reverse filling we can reduce half of the total time in pulling from online database
        /// </summary>
        public static void ReverseUpdateOfflineDatabase()
        {
            string response = GetOnlineData(reverseRequestCounter,false,"yes");
            if (!string.IsNullOrEmpty(response))
            {
                reverseRequestCounter -= 5;
                InsertRecordsInDB(response);
            }
        }
        /// <summary>
        /// update offline database after pulling print status from online database
        /// </summary>
        public static void UpdatePrintStatus()
        {
            try
            {
                string response = GetPrintStatus(requestPrintCounter);
                ResetOrIncreaseCounter(response, true);
                if(!string.IsNullOrEmpty(response))
                    UpdateDBRecords(response);
            }
            catch { }

        }
        /// <summary>
        /// update db records after pulling print status from online database
        /// </summary>
        /// <param name="response"></param>
        private static void UpdateDBRecords(string response)
        {
            try
            {
                List<Print_Status> Data = JsonConvert.DeserializeObject<List<Print_Status>>(response);
                string queryData = string.Empty;
                foreach (Print_Status rd in Data)
                {
                    db.ExecuteSQLQuery(ref db.conn, "update register set Registered_Time='" + rd.print_datetime + "', IsPrinted='" + rd.print_status + "' where EmpCode='"+rd.user_id+"'");
                }
            }
            catch { }
        }
    }
}
