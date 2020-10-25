using SchoolModels;
using System;
using System.Collections.Generic;
namespace School.App.Repository.FeeViewModels
{
	public class StudentFineViewModel : StudentFineModel
	{
		private List<StudentFineViewModel> _listStudent = new List<StudentFineViewModel>();
		private List<StudentFineViewModel> _listStudentFine = new List<StudentFineViewModel>();
		public short? ClassID
		{
			get;
			set;
		}
		public short? SectionID
		{
			get;
			set;
		}
		public long? RegistrationNo
		{
			get;
			set;
		}
		public bool? IsSelected
		{
			get;
			set;
		}
		public List<StudentFineViewModel> ListStudent
		{
			get
			{
				return this._listStudent;
			}
			set
			{
				this._listStudent = value;
			}
		}
		public List<StudentFineViewModel> ListStudentFine
		{
			get
			{
				return this._listStudentFine;
			}
			set
			{
				this._listStudentFine = value;
			}
		}
	}
}
