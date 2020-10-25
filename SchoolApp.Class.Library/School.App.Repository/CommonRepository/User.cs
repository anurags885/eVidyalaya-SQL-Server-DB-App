using SchoolModels;
using SqlServer.Service;
using System;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class User
	{
		public User_Model Get_User_Login_Details(string User_ID, string Password)
		{
			User_Model result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@User_ID", User_ID);
				sqlService.AddParameter("@Password", Password);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_User_Login"))
				{
					result = sqlDataReader.MapToSingle<User_Model>();
				}
			}
			return result;
		}
	}
}
