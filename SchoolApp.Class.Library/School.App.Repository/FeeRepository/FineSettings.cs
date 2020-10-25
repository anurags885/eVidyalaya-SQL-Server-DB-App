using SchoolModels;
using SqlServer.Service;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class FineSettings
	{
		private StudentFineViewModel _studentFineViewModel;
		public List<FineTypeModel> GetFineType()
		{
			List<FineTypeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetFineType"))
				{
					result = sqlDataReader.MapToList<FineTypeModel>();
				}
			}
			return result;
		}
		public StudentFineViewModel GetStudentFineDetails(StudentFineViewModel studentFine, out short isBillPaid)
		{
			StudentFineViewModel studentFineViewModel;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", SqlDbType.SmallInt, studentFine.ClassID);
				sqlService.AddParameter("@SectionID", SqlDbType.SmallInt, studentFine.SectionID);
				sqlService.AddParameter("@FineDate", SqlDbType.Date, studentFine.FineDate);
				sqlService.AddParameter("@FineTypeID", SqlDbType.SmallInt, studentFine.FineTypeID);
				sqlService.AddOutputParameter("@ISBillPaid", SqlDbType.SmallInt);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetStudentFineDetails"))
				{
					this._studentFineViewModel = new StudentFineViewModel();
					this._studentFineViewModel.ListStudent = sqlDataReader.MapToList<StudentFineViewModel>();
					sqlDataReader.NextResult();
					this._studentFineViewModel.ListStudentFine = sqlDataReader.MapToList<StudentFineViewModel>();
					sqlDataReader.NextResult();
					isBillPaid = (short)sqlService.Parameters["@ISBillPaid"].Value;
					studentFineViewModel = this._studentFineViewModel;
				}
			}
			return studentFineViewModel;
		}
		public short SaveStudentFine(string studentFineXML)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@StudentFineXML", studentFineXML);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveStudentFine");
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
