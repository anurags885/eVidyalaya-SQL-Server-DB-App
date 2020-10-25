using SchoolModels;
using SqlServer.Service;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class Advance_Deposit_Fee
	{
		public List<Advance_Pay_Model> Calculate_Advance_Pay(long? StudentID, string MonthValuesDelimiterSeprated, int Academic_Year)
		{
			List<Advance_Pay_Model> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@StudentID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@MonthValuesDelimiterSeprated", SqlDbType.VarChar, MonthValuesDelimiterSeprated);
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Calculate_Advance_Pay"))
				{
					result = sqlDataReader.MapToList<Advance_Pay_Model>();
				}
			}
			return result;
		}
		public short Save_Advance_Pay_Fee(long Student_ID, long? Receipt_No, string Fee_Details_XML, int Academic_Year, string MonthValuesDelimiterSeprated, DateTime Deposit_Date)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Student_ID", Student_ID);
					sqlService.AddParameter("@Receipt_No", Receipt_No);
					sqlService.AddParameter("@Fee_Details_XML", Fee_Details_XML);
					sqlService.AddParameter("@Months_Comma_Seprated", MonthValuesDelimiterSeprated);
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddParameter("@Deposit_Date", Deposit_Date);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Save_Advance_Pay_Fee");
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
		public List<Student_Fee_Info_Receipt_Model> Get_Advance_Pay_Receipt_No(long StudentID, int Academic_Year)
		{
			List<Student_Fee_Info_Receipt_Model> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@Academic_Year", SqlDbType.Int, Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GET_Advance_Pay_Receipt_No"))
				{
					result = sqlDataReader.MapToList<Student_Fee_Info_Receipt_Model>();
				}
			}
			return result;
		}
		public Student_Advance_Fee_View_Model Get_Advance_Pay_Details_By_Receipt_No(long Receipt_No)
		{
			Student_Advance_Fee_View_Model result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Receipt_No", SqlDbType.BigInt, Receipt_No);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GET_Advance_Pay_Details_By_Receipt_No"))
				{
					Student_Advance_Fee_View_Model student_Advance_Fee_View_Model = new Student_Advance_Fee_View_Model();
					student_Advance_Fee_View_Model.List_Student_Fee_Info_Months = sqlDataReader.MapToList<Student_Fee_Info_Months_Model>();
					sqlDataReader.NextResult();
					student_Advance_Fee_View_Model.List_Advance_Pay = sqlDataReader.MapToList<Advance_Pay_Model>();
					result = student_Advance_Fee_View_Model;
				}
			}
			return result;
		}
		public DataSet Get_Advance_Fee_Pay_Report(long Student_ID, long Receipt_No)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_Id", SqlDbType.BigInt, Student_ID);
				sqlService.AddParameter("@Receipt_No", SqlDbType.BigInt, Receipt_No);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_Get_Advance_Pay_Report"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public short Delete_Advance_Pay(long Receipt_No)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Receipt_No", Receipt_No);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Delete_Advance_Pay");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
