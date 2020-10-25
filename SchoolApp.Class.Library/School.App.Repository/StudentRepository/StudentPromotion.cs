using SqlServer.Service;
using School.App.Repository.StudentViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class StudentPromotion
	{
		private StudentPromotionViewModel _studentPromotionViewModel;
		public StudentPromotionViewModel GetStudentPromotionDetails(short ClassID, short SectionID, int Academic_Year)
		{
			this._studentPromotionViewModel = new StudentPromotionViewModel();
			StudentPromotionViewModel studentPromotionViewModel;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", SqlDbType.SmallInt, ClassID);
				sqlService.AddParameter("@SectionID", SqlDbType.SmallInt, SectionID);
				sqlService.AddParameter("@From_Academic_Year", SqlDbType.Int, Academic_Year);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetStudentPromotionDetails"))
				{
					this._studentPromotionViewModel.ListStudent = sqlDataReader.MapToList<StudentPromotionViewModel>();
					sqlDataReader.NextResult();
					this._studentPromotionViewModel.ListStudentPromotion = sqlDataReader.MapToList<StudentPromotionViewModel>();
					sqlDataReader.NextResult();
					studentPromotionViewModel = this._studentPromotionViewModel;
				}
			}
			return studentPromotionViewModel;
		}
		public short SavePromotionStudent(string promoteStudentXML)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@XMLData", promoteStudentXML);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SavePromotionStudent");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public DataSet GetStudentPromotionReport(short ClassID, short SectionID, int From_Academic_Year)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", ClassID);
				sqlService.AddParameter("@SectionID", SectionID);
				sqlService.AddParameter("@From_Academic_Year", From_Academic_Year);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_GetStudentPromotionReport"))
				{
					result = dataSet;
				}
			}
			return result;
		}
	}
}
