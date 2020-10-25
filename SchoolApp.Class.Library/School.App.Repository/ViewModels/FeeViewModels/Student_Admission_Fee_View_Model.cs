using SchoolModels;
using System;
using System.Collections.Generic;


namespace School.App.Repository.FeeViewModels
{
	public class Student_Admission_Fee_View_Model
	{
		private List<AdmissionFeeModel> _list_Admission_Fee_Model = new List<AdmissionFeeModel>();
		public List<AdmissionFeeModel> List_Admission_Fee
		{
			get
			{
				return this._list_Admission_Fee_Model;
			}
			set
			{
				this._list_Admission_Fee_Model = value;
			}
		}
		public Student_Fee_Info_Model Student_Fee_Info
		{
			get;
			set;
		}
	}
}
