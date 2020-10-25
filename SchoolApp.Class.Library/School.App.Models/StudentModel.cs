using System;
namespace SchoolModels
{
	public class StudentModel
	{
		public long? StudentID
		{
			get;
			set;
		}
		public long? RegistrationNo
		{
			get;
			set;
		}
		public string FirstName
		{
			get;
			set;
		}
		public string MiddleName
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
		public DateTime? BirthDate
		{
			get;
			set;
		}
		public DateTime? RegistrationDate
		{
			get;
			set;
		}
		public byte? GenderID
		{
			get;
			set;
		}
		public string FatherName
		{
			get;
			set;
		}
		public string MotherName
		{
			get;
			set;
		}
		public byte[] StudentImage
		{
			get;
			set;
		}
		public bool? IsTcSubmit
		{
			get;
			set;
		}
		public bool? IsStaffChild
		{
			get;
			set;
		}
		public bool? IsActive
		{
			get;
			set;
		}
		public short? CurrentClass
		{
			get;
			set;
		}
		public short? CurrentSection
		{
			get;
			set;
		}
		public short? CountryID
		{
			get;
			set;
		}
		public short? ReligionID
		{
			get;
			set;
		}
		public short? CasteID
		{
			get;
			set;
		}
		public int? TransportRouteID
		{
			get;
			set;
		}
		public bool? IsNewAdmission
		{
			get;
			set;
		}
		public int? Academic_Year
		{
			get;
			set;
		}
		public bool Is_RTE_Student
		{
			get;
			set;
		}
	}
}
