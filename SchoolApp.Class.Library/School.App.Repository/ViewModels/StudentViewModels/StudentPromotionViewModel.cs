using SchoolModels;
using System;
using System.Collections.Generic;
namespace School.App.Repository.StudentViewModels
{
	public class StudentPromotionViewModel : StudentPromotionModel
	{
		private List<StudentPromotionViewModel> _listStudent = new List<StudentPromotionViewModel>();
		private List<StudentPromotionViewModel> _listStudentPromotion = new List<StudentPromotionViewModel>();
		public long? RegistrationNo
		{
			get;
			set;
		}
		public string StudentName
		{
			get;
			set;
		}
		public string FromClassName
		{
			get;
			set;
		}
		public string FromSectionName
		{
			get;
			set;
		}
		public bool? IsSelected
		{
			get;
			set;
		}
		public bool? IsDeleted
		{
			get;
			set;
		}
		public List<StudentPromotionViewModel> ListStudent
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
		public List<StudentPromotionViewModel> ListStudentPromotion
		{
			get
			{
				return this._listStudentPromotion;
			}
			set
			{
				this._listStudentPromotion = value;
			}
		}
	}
}
