using System;
namespace SchoolModels.Fee
{
	public class FeeDepositModel
	{
		public long? FeeReceiptNo
		{
			get;
			set;
		}
		public long? RegistrationNo
		{
			get;
			set;
		}
		public long? StudentID
		{
			get;
			set;
		}
		public string FullName
		{
			get;
			set;
		}
		public string ClassName
		{
			get;
			set;
		}
		public short ClassID
		{
			get;
			set;
		}
		public bool IsStaffChild
		{
			get;
			set;
		}
		public DateTime FeeDate
		{
			get;
			set;
		}
		public int? Amount_Paid_On_Bill
		{
			get;
			set;
		}
		public int? Amount_Dues_On_Bill
		{
			get;
			set;
		}
		public int? TotalFine
		{
			get;
			set;
		}
		public int? TotalFinePaid
		{
			get;
			set;
		}
		public int? TotalFineOff
		{
			get;
			set;
		}
		public int? Total_Fee_Amount
		{
			get;
			set;
		}
		public int? Total_Dues
		{
			get;
			set;
		}
	}
}
