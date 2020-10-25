using School.App.Models;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace School.App.Repository.CommonRepository
{
    public class SMS_Repository
    {
        public string Construct_SMS_All_Class(string SMS_Text)
        {
            try
            {
                using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
                {
                    sqlService.AddParameter("@SMS_Text", SMS_Text);
                    sqlService.AddOutputParameter("@Result_OUT", SqlDbType.VarChar, 10);
                    sqlService.ExecuteSPNonQuery("dbo.USP_Construct_SMS_All_Class");
                    return (string)sqlService.Parameters["@Result_OUT"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SMS_Model> Get_SMS_Recipient_All_Class()
        {
            using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
            {
                using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_SMS_Recipient_All_Class"))
                {
                    return sqlDataReader.MapToList<SMS_Model>();
                }
            }
        }

        public List<SMS_Model> Get_SMS_Report(string Sent_Date, string SMS_Category)
        {
            using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
            {
                sqlService.AddParameter("@Sent_Date", SqlDbType.VarChar, Sent_Date);
                sqlService.AddParameter("@SMS_Category", SqlDbType.VarChar, SMS_Category);

                using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_SMS_Report"))
                {
                    return sqlDataReader.MapToList<SMS_Model>();
                }
            }
        }

        public string Update_SMS_Status_All_Class(string SMS_ID)
        {
            try
            {
                using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
                {
                    sqlService.AddParameter("@SMS_ID", SMS_ID);
                    sqlService.AddOutputParameter("@Result_OUT", SqlDbType.VarChar, 10);
                    sqlService.ExecuteSPNonQuery("dbo.USP_Update_SMS_Status_All_Class");
                    return (string)sqlService.Parameters["@Result_OUT"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Log_SMS_Individual(string Mobile_Number, string SMS_Text)
        {
            try
            {
                using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
                {
                    sqlService.AddParameter("@SMS_Text", SMS_Text);
                    sqlService.AddParameter("@Mobile_Number", Mobile_Number);
                    sqlService.AddOutputParameter("@Result_OUT", SqlDbType.VarChar, 10);
                    sqlService.ExecuteSPNonQuery("dbo.USP_Log_SMS_Individual");
                    return (string)sqlService.Parameters["@Result_OUT"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
