using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class Student_Fee_Setting
	{
		public short Save_Student_Fee_Info(long Student_ID, long? Receipt_No, string Student_Fee_Info_Type_Code, int Academic_Year, string MonthValuesDelimiterSeprated, int? Half_Tution_Fee_Amount)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Student_ID", Student_ID);
					sqlService.AddParameter("@Months_Comma_Seprated", MonthValuesDelimiterSeprated);
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddParameter("@Receipt_No", Receipt_No);
					sqlService.AddParameter("@Student_Fee_Info_Type_Code", Student_Fee_Info_Type_Code);
					sqlService.AddParameter("@Half_Tution_Fee_Amount", Half_Tution_Fee_Amount);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Save_Student_Fee_Info");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public List<Student_Fee_Info_Months_Model> Get_Student_Fee_Setting_Months(long StudentID, int Academic_Year)
		{
			List<Student_Fee_Info_Months_Model> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Fee_Setting_Months"))
				{
					result = sqlDataReader.MapToList<Student_Fee_Info_Months_Model>();
				}
			}
			return result;
		}
		public Student_Fee_Info_Receipt_Model Get_Student_Fee_Info_Receipt_No(long StudentID, int Academic_Year, string Fee_Info_Code)
		{
			Student_Fee_Info_Receipt_Model result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				sqlService.AddParameter("@Fee_Info_Code", SqlDbType.VarChar, Fee_Info_Code);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Fee_Info_Receipt_No"))
				{
					result = sqlDataReader.MapToSingle<Student_Fee_Info_Receipt_Model>();
				}
			}
			return result;
		}
		public List<Student_Fee_Info_Months_Model> Get_Student_Fee_Setting_Details_By_Receipt_No(long? Receipt_No, string Fee_Info_Code, int Academic_Year)
		{
			List<Student_Fee_Info_Months_Model> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Receipt_No", SqlDbType.BigInt, Receipt_No);
				sqlService.AddParameter("@Fee_Info_Code", SqlDbType.VarChar, Fee_Info_Code);
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Fee_Info_By_Receipt_No"))
				{
					result = sqlDataReader.MapToList<Student_Fee_Info_Months_Model>();
				}
			}
			return result;
		}
		public List<Student_Fee_Info_Type> Get_Student_Fee_Info_Type(bool Is_Display_All)
		{
			List<Student_Fee_Info_Type> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Is_Display_All", SqlDbType.Bit, Is_Display_All);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Fee_Info_Type"))
				{
					result = sqlDataReader.MapToList<Student_Fee_Info_Type>();
				}
			}
			return result;
		}
		public DataSet Get_Student_Fee_Info_Report(int Academic_Year, string Fee_Info_Type)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				sqlService.AddParameter("@Fee_Info_Type", SqlDbType.VarChar, Fee_Info_Type);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_Student_Fee_Info_Report"))
				{
					result = dataSet;
				}
			}
			return result;
		}
	}
}
