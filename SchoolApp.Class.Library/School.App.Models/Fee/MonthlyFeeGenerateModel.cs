using System;
namespace SchoolModels.Fee
{
	public class MonthlyFeeGenerateModel
	{
		public long? FeeReceiptNo
		{
			get;
			set;
		}
		public long? StudentID
		{
			get;
			set;
		}
		public int? FeeAmount
		{
			get;
			set;
		}
		public int? TransportAmount
		{
			get;
			set;
		}
		public int? PreviousDues
		{
			get;
			set;
		}
		public int? ReAdmission
		{
			get;
			set;
		}
		public DateTime? FeeDate
		{
			get;
			set;
		}
	}
}
