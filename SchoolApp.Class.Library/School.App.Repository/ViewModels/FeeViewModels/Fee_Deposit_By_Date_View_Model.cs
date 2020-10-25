using SchoolModels.Fee;
using System;
namespace School.App.Repository.FeeViewModels
{
	public class Fee_Deposit_By_Date_View_Model : MonthlyFeeDepositModel
	{
		public string Student_Name
		{
			get;
			set;
		}
		public string Class_Name
		{
			get;
			set;
		}
		public string Fee_Deposit_Code
		{
			get;
			set;
		}
		public string Fee_Deposit_Type
		{
			get;
			set;
		}
		public long Registration_No
		{
			get;
			set;
		}
	}
}
