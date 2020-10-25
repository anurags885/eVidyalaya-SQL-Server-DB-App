using System;
namespace SchoolModels
{
	public class StudentFineModel
	{
		public long? FineTransactionID
		{
			get;
			set;
		}
		public long? ReceiptNo
		{
			get;
			set;
		}
		public short? FineTypeID
		{
			get;
			set;
		}
		public string FineType
		{
			get;
			set;
		}
		public long? StudentID
		{
			get;
			set;
		}
		public string StudentName
		{
			get;
			set;
		}
		public DateTime? FineDate
		{
			get;
			set;
		}
		public int? FineAmount
		{
			get;
			set;
		}
		public bool? IsPaid
		{
			get;
			set;
		}
		public bool? IsOFF
		{
			get;
			set;
		}
		public int? DepositAmount
		{
			get;
			set;
		}
		public DateTime? DepositDate
		{
			get;
			set;
		}
	}
}
