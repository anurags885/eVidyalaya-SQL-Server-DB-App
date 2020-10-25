using SchoolModels;
using SqlServer.Service;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class AdmissionFee
	{
		public List<AdmissionFeeModel> Get_Admission_Fee_List(long StudentID, short MonthValue, int AcademicYear, string MonthValuesDelimiterSeprated)
		{
			List<AdmissionFeeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@StudentID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@MaximumMonthValue", SqlDbType.SmallInt, MonthValue);
				sqlService.AddParameter("@AcademicYear", SqlDbType.Int, AcademicYear);
				sqlService.AddParameter("@MonthValuesDelimiterSeprated", SqlDbType.VarChar, MonthValuesDelimiterSeprated);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetCalculateAdmissionTimeFee"))
				{
					result = sqlDataReader.MapToList<AdmissionFeeModel>();
				}
			}
			return result;
		}
		public short Save_Admission_Fee(long Student_ID, long? Sequence_No_Student_Fee_Info, string Fee_Details_XML, int Academic_Year, string MonthValuesDelimiterSeprated, DateTime Admission_Fee_Date)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Student_ID", Student_ID);
					sqlService.AddParameter("@Sequence_No_Student_Fee_Info", Sequence_No_Student_Fee_Info);
					sqlService.AddParameter("@Fee_Details_XML", Fee_Details_XML);
					sqlService.AddParameter("@Months_Comma_Seprated", MonthValuesDelimiterSeprated);
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddParameter("@Admission_Fee_Date", Admission_Fee_Date);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Save_Admission_Fee");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public Student_Admission_Fee_View_Model Get_Admission_Fee_Details_By_Student_ID(long Student_ID)
		{
			Student_Admission_Fee_View_Model result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, Student_ID);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Admission_Fee_Details_By_Student_ID"))
				{
					Student_Admission_Fee_View_Model student_Admission_Fee_View_Model = new Student_Admission_Fee_View_Model();
					student_Admission_Fee_View_Model.List_Admission_Fee = sqlDataReader.MapToList<AdmissionFeeModel>();
					sqlDataReader.NextResult();
					student_Admission_Fee_View_Model.Student_Fee_Info = sqlDataReader.MapToSingle<Student_Fee_Info_Model>();
					sqlDataReader.NextResult();
					result = student_Admission_Fee_View_Model;
				}
			}
			return result;
		}
		public DataSet Get_Admission_Fee_Report(long Student_ID)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Student_ID", SqlDbType.BigInt, Student_ID);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_Get_Admission_Fee_Report"))
				{
					result = dataSet;
				}
			}
			return result;
		}
	}
}
