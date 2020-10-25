using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class ClassType
	{
		public List<ClassTypeModel> GetClassDetails()
		{
			List<ClassTypeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetClassType"))
				{
					result = sqlDataReader.MapToList<ClassTypeModel>();
				}
			}
			return result;
		}
	}
}
