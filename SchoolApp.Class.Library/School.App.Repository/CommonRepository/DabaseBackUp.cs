using SqlServer.Service;
using System;
using System.Data;
namespace School.App.Repository
{
	public class DabaseBackUp
	{
		public short TakeBackUp(string filePath, string dbName)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@FilePath", filePath);
					sqlService.AddParameter("@DBName", dbName);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_DatabaseBackUp");
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
