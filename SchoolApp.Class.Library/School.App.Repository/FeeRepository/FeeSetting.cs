using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class FeeSetting
	{
		public List<FeeSettingModel> GetFeeSetting(int AcademicYear)
		{
			List<FeeSettingModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@AcademicYear", SqlDbType.Int, AcademicYear);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetFeeSetting"))
				{
					result = sqlDataReader.MapToList<FeeSettingModel>();
				}
			}
			return result;
		}
		public short SaveFeeSetting(string xmlFeeSetting, int Academic_Year)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@FeeSettingXML", xmlFeeSetting);
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveFeeSetting");
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
