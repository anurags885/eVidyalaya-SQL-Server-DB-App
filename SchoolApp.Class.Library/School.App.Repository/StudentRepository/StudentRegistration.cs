using SchoolModels;
using SqlServer.Service;
using School.App.Repository.StudentViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace School.App.Repository
{
	public class StudentRegistration
	{
		private StudentViewModel _studentViewModel;
		private RegistrationModel _registrationModel;
		public short SaveStudentDetails(StudentViewModel studentViewModel)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@StudentID", studentViewModel.StudentModel.StudentID);
					sqlService.AddParameter("@AddressID", studentViewModel.AddressModel.AddressID);
					sqlService.AddParameter("@ExSchoolID", studentViewModel.ExSchoolModel.ExSchoolID);
					sqlService.AddParameter("@RegistrationNo", studentViewModel.StudentModel.RegistrationNo);
					sqlService.AddParameter("@FirstName", studentViewModel.StudentModel.FirstName);
					sqlService.AddParameter("@MiddleName", studentViewModel.StudentModel.MiddleName);
					sqlService.AddParameter("@LastName", studentViewModel.StudentModel.LastName);
					sqlService.AddParameter("@BirthDate", studentViewModel.StudentModel.BirthDate);
					sqlService.AddParameter("@RegistrationDate", studentViewModel.StudentModel.RegistrationDate);
					sqlService.AddParameter("@GenderID", studentViewModel.StudentModel.GenderID);
					sqlService.AddParameter("@FatherName", studentViewModel.StudentModel.FatherName);
					sqlService.AddParameter("@MotherName", studentViewModel.StudentModel.MotherName);
					sqlService.AddParameter("@IsTcSubmit", studentViewModel.StudentModel.IsTcSubmit);
					sqlService.AddParameter("@IsStaffChild", studentViewModel.StudentModel.IsStaffChild);
					sqlService.AddParameter("@IsActive", studentViewModel.StudentModel.IsActive);
					sqlService.AddParameter("@Address", studentViewModel.AddressModel.Address);
					sqlService.AddParameter("@Pincode", studentViewModel.AddressModel.Pincode);
					sqlService.AddParameter("@LandlineNumber", studentViewModel.AddressModel.LandlineNumber);
					sqlService.AddParameter("@MobileNo1", studentViewModel.AddressModel.MobileNo1);
					sqlService.AddParameter("@MobileNo2", studentViewModel.AddressModel.MobileNo2);
					sqlService.AddParameter("@ExSchoolName", studentViewModel.ExSchoolModel.SchoolName);
					sqlService.AddParameter("@ExSchoolTCNumber", studentViewModel.ExSchoolModel.TCNumber);
					sqlService.AddParameter("@EnrollmentClassID", studentViewModel.ExSchoolModel.EnrollmentClass);
					sqlService.AddParameter("@ExSchoolAddress", studentViewModel.ExSchoolModel.Address);
					sqlService.AddParameter("@ExSchoolContactNo", studentViewModel.ExSchoolModel.ContactNo);
					sqlService.AddParameter("@CurrentClass", studentViewModel.StudentModel.CurrentClass);
					sqlService.AddParameter("@CurrentSection", studentViewModel.StudentModel.CurrentSection);
					sqlService.AddParameter("@ExSchoolTCImage", (studentViewModel.ExSchoolModel.TCImage == null) ? SqlBinary.Null : studentViewModel.ExSchoolModel.TCImage);
					sqlService.AddParameter("@StudentImage", (studentViewModel.StudentModel.StudentImage == null) ? SqlBinary.Null : studentViewModel.StudentModel.StudentImage);
					sqlService.AddParameter("@TCFileType", studentViewModel.ExSchoolModel.TCFileType);
					sqlService.AddParameter("@CountryID", studentViewModel.StudentModel.CountryID);
					sqlService.AddParameter("@ReligionID", studentViewModel.StudentModel.ReligionID);
					sqlService.AddParameter("@CasteID", studentViewModel.StudentModel.CasteID);
					sqlService.AddParameter("@TransportRouteID", studentViewModel.StudentModel.TransportRouteID);
					sqlService.AddParameter("@Is_RTE_Student", studentViewModel.StudentModel.Is_RTE_Student);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Save_Registration_Details");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public StudentViewModel GetStudentDetails(long? RegistrationNo)
		{
			this._studentViewModel = new StudentViewModel();
			StudentViewModel studentViewModel;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@RegistrationNo", SqlDbType.BigInt, RegistrationNo);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Registration_Details"))
				{
					this._studentViewModel.ListGender = sqlDataReader.MapToList<GenderModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListClass = sqlDataReader.MapToList<ClassTypeModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.StudentModel = sqlDataReader.MapToSingle<StudentModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.AddressModel = sqlDataReader.MapToSingle<AddressModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ExSchoolModel = sqlDataReader.MapToSingle<ExSchoolModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListClassSection = sqlDataReader.MapToList<ClassSectionModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListCountry = sqlDataReader.MapToList<CountryModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListReligionType = sqlDataReader.MapToList<ReligionTypeModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListCaste = sqlDataReader.MapToList<CasteTypeModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.ListTrasport = sqlDataReader.MapToList<TransportRouteModel>();
					sqlDataReader.NextResult();
					this._studentViewModel.Student_TC_Info = sqlDataReader.MapToSingle<Student_TC_Model_Info>();
					studentViewModel = this._studentViewModel;
				}
			}
			return studentViewModel;
		}
		public RegistrationModel Get_Student_Detail(long? RegistrationNo)
		{
			this._registrationModel = new RegistrationModel();
			RegistrationModel registrationModel;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@RegistrationNo", SqlDbType.BigInt, RegistrationNo);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Detail"))
				{
					this._registrationModel = sqlDataReader.MapToSingle<RegistrationModel>();
					sqlDataReader.NextResult();
					registrationModel = this._registrationModel;
				}
			}
			return registrationModel;
		}
		public RegistrationModel Get_InActive_Student_Detail(long? RegistrationNo)
		{
			this._registrationModel = new RegistrationModel();
			RegistrationModel registrationModel;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@RegistrationNo", SqlDbType.BigInt, RegistrationNo);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_InActive_Student_Detail"))
				{
					this._registrationModel = sqlDataReader.MapToSingle<RegistrationModel>();
					sqlDataReader.NextResult();
					registrationModel = this._registrationModel;
				}
			}
			return registrationModel;
		}
	}
}
