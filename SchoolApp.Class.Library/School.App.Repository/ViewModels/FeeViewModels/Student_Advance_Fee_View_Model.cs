using SchoolModels;
using System;
using System.Collections.Generic;
namespace School.App.Repository.FeeViewModels
{
	public class Student_Advance_Fee_View_Model
	{
		private List<Advance_Pay_Model> list_Advance_Pay = new List<Advance_Pay_Model>();
		private List<Student_Fee_Info_Months_Model> list_Student_Fee_Info_Months = new List<Student_Fee_Info_Months_Model>();
		public List<Advance_Pay_Model> List_Advance_Pay
		{
			get
			{
				return this.list_Advance_Pay;
			}
			set
			{
				this.list_Advance_Pay = value;
			}
		}
		public List<Student_Fee_Info_Months_Model> List_Student_Fee_Info_Months
		{
			get
			{
				return this.list_Student_Fee_Info_Months;
			}
			set
			{
				this.list_Student_Fee_Info_Months = value;
			}
		}
	}
}
