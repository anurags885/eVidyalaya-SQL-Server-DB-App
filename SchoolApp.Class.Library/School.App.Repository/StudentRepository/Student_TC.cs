using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class Student_TC
	{
		public List<TC_Reason_Type> Get_TC_Reason_Type()
		{
			List<TC_Reason_Type> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_TC_Reason_Type"))
				{
					result = sqlDataReader.MapToList<TC_Reason_Type>();
				}
			}
			return result;
		}
		public Student_TC_Model_Info Get_Student_TC_Details(long? Student_ID)
		{
			Student_TC_Model_Info result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, Student_ID);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_TC_Details"))
				{
					result = sqlDataReader.MapToSingle<Student_TC_Model_Info>();
				}
			}
			return result;
		}
		public short Delete_TC_Details(long? Student_ID)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Student_ID", Student_ID);
					sqlService.AddOutputParameter("@Result_OUT", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Delete_TC_Details");
					result = (short)sqlService.Parameters["@Result_OUT"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public short USP_Save_Student_TC_Info(Student_TC_Model_Info model)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Sequence_No", model.Sequence_No);
					sqlService.AddParameter("@Student_ID", model.Student_ID);
					sqlService.AddParameter("@Reason_ID", model.Reason_ID);
					sqlService.AddParameter("@TC_Number", model.TC_Number);
					sqlService.AddParameter("@TC_Date", model.TC_Date);
					sqlService.AddParameter("@Academic_Year", model.Academic_Year);
					sqlService.AddParameter("@TC_Fee_Amount", model.TC_Fee_Amount);
					sqlService.AddOutputParameter("@Result_OUT", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Save_Student_TC_Info");
					result = (short)sqlService.Parameters["@Result_OUT"].Value;
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
