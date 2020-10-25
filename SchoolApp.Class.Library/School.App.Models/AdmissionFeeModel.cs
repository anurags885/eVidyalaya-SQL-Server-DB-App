using System;
namespace SchoolModels
{
	public class AdmissionFeeModel
	{
		public long? Sequence_ID
		{
			get;
			set;
		}
		public long? Admission_Receipt_No
		{
			get;
			set;
		}
		public long Student_ID
		{
			get;
			set;
		}
		public int Fee_Type_ID
		{
			get;
			set;
		}
		public string Fee_Type
		{
			get;
			set;
		}
		public int Fee_Amount
		{
			get;
			set;
		}
		public int Number_Of_Months
		{
			get;
			set;
		}
		public int Total_Amount
		{
			get;
			set;
		}
		public DateTime Deposit_Date
		{
			get;
			set;
		}
		public bool Is_Selected
		{
			get;
			set;
		}
	}
}
