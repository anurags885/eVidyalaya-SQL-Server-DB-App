using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class ClassSection
	{
		public List<ClassSectionModel> GetSectionDetails()
		{
			List<ClassSectionModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetSectionDetails"))
				{
					result = sqlDataReader.MapToList<ClassSectionModel>();
				}
			}
			return result;
		}
	}
}
