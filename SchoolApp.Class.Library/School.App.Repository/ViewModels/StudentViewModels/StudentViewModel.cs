using SchoolModels;
using System;
using System.Collections.Generic;
namespace School.App.Repository.StudentViewModels
{
	public class StudentViewModel
	{
		private List<GenderModel> _listGender = new List<GenderModel>();
		private List<ClassTypeModel> _listClass = new List<ClassTypeModel>();
		private List<ClassSectionModel> _listClassSection = new List<ClassSectionModel>();
		private List<CountryModel> _listCountry = new List<CountryModel>();
		private List<ReligionTypeModel> _listReligion = new List<ReligionTypeModel>();
		private List<CasteTypeModel> _listCaste = new List<CasteTypeModel>();
		private List<TransportRouteModel> _listTransport = new List<TransportRouteModel>();
		private StudentModel _student = new StudentModel();
		private AddressModel _address = new AddressModel();
		private ExSchoolModel _exSchool = new ExSchoolModel();
		private Student_TC_Model_Info _studentTCInfo = new Student_TC_Model_Info();
		public List<GenderModel> ListGender
		{
			get
			{
				return this._listGender;
			}
			set
			{
				this._listGender = value;
			}
		}
		public List<ClassTypeModel> ListClass
		{
			get
			{
				return this._listClass;
			}
			set
			{
				this._listClass = value;
			}
		}
		public List<ClassSectionModel> ListClassSection
		{
			get
			{
				return this._listClassSection;
			}
			set
			{
				this._listClassSection = value;
			}
		}
		public StudentModel StudentModel
		{
			get
			{
				return this._student;
			}
			set
			{
				this._student = value;
			}
		}
		public AddressModel AddressModel
		{
			get
			{
				return this._address;
			}
			set
			{
				this._address = value;
			}
		}
		public ExSchoolModel ExSchoolModel
		{
			get
			{
				return this._exSchool;
			}
			set
			{
				this._exSchool = value;
			}
		}
		public List<ReligionTypeModel> ListReligionType
		{
			get
			{
				return this._listReligion;
			}
			set
			{
				this._listReligion = value;
			}
		}
		public List<CountryModel> ListCountry
		{
			get
			{
				return this._listCountry;
			}
			set
			{
				this._listCountry = value;
			}
		}
		public List<CasteTypeModel> ListCaste
		{
			get
			{
				return this._listCaste;
			}
			set
			{
				this._listCaste = value;
			}
		}
		public List<TransportRouteModel> ListTrasport
		{
			get
			{
				return this._listTransport;
			}
			set
			{
				this._listTransport = value;
			}
		}
		public Student_TC_Model_Info Student_TC_Info
		{
			get
			{
				return this._studentTCInfo;
			}
			set
			{
				this._studentTCInfo = value;
			}
		}
	}
}
