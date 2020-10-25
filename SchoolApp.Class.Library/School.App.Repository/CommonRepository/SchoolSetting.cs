using SchoolModels;
using SqlServer.Service;
using System;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class SchoolSetting
	{
		public SchoolModel GetSchoolDetail(long schoolID)
		{
			SchoolModel result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@SchoolID", SqlDbType.BigInt, schoolID);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetSchoolDetail"))
				{
					result = sqlDataReader.MapToSingle<SchoolModel>();
				}
			}
			return result;
		}
		public short SaveSchoolDetails(SchoolModel schoolModel)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@SchoolID", schoolModel.SchoolID);
					sqlService.AddParameter("@SchoolName", schoolModel.SchoolName);
					sqlService.AddParameter("@Address", schoolModel.Address);
					sqlService.AddParameter("@PhoneNo", schoolModel.PhoneNo);
					sqlService.AddParameter("@ESTD", schoolModel.ESTD);
					sqlService.AddParameter("@AffiliationNo", schoolModel.AffiliationNo);
					sqlService.AddParameter("@SchoolNo", schoolModel.SchoolNo);
					sqlService.AddParameter("@SchoolLogo", schoolModel.SchoolLogo);
					sqlService.AddParameter("@IsReAdmission", schoolModel.IsReAdmission);
					sqlService.AddParameter("@ReAdmissionAmount", schoolModel.ReAdmissionAmount);
					sqlService.AddParameter("@FormTextLine1", schoolModel.FormTextLine1);
					sqlService.AddParameter("@FormTextLine2", schoolModel.FormTextLine2);
					sqlService.AddParameter("@FormTextLine3", schoolModel.FormTextLine3);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveSchoolDetails");
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
