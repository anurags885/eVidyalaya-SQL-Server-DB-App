using System;
namespace SchoolModels.Fee
{
	public class MonthlyFeeDepositModel
	{
		public long? FeeTransactionID
		{
			get;
			set;
		}
		public long? FeeReceiptNo
		{
			get;
			set;
		}
		public int? AmountDeposit
		{
			get;
			set;
		}
		public int? AmountDues
		{
			get;
			set;
		}
		public DateTime? FeeDepositDate
		{
			get;
			set;
		}
		public string FineDetailsXML
		{
			get;
			set;
		}
		public long Student_ID
		{
			get;
			set;
		}
		public long Days_Count
		{
			get;
			set;
		}
	}
}
