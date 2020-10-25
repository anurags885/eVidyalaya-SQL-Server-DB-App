using School.App.Models.Fee;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace School.App.Repository
{
	public class FeeGenerate
	{
		public string IsMonthlyFeeGenerated(int CrrentAcademicYear, out int LastMonthNo)
		{
			string text = string.Empty;
			string result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Academic_Year", CrrentAcademicYear);
				sqlService.AddOutputParameter("@Last_Month_No", SqlDbType.SmallInt);
				text = sqlService.ExecuteSPScalar("dbo.USP_IsMonthlyFeeGenerated");
				LastMonthNo = (int)((short)sqlService.Parameters["@Last_Month_No"].Value);
				result = text;
			}
			return result;
		}
		public short GenerateMonthlyFee(string Months, int AcademicYear)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@MonthValuesDelimiterSeprated", Months);
					sqlService.AddParameter("@AcademicYear", AcademicYear);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_GenerateMonthlyFee_Multiple_Months");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public string Get_Fee_Generated_Current_Month(int Academic_Year)
		{
			string text = string.Empty;
			string result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Academic_Year", Academic_Year);
				text = sqlService.ExecuteSPScalar("dbo.USP_Get_Fee_Generated_Month");
				result = text;
			}
			return result;
		}
		public List<Month_Model> GetPurchasesFeeList(int Academic_Year)
		{
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Academic_Year", Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.usp_fee_generated_month_list"))
				{
					return sqlDataReader.MapToList<Month_Model>();
				}
			}
		}
	}
}
