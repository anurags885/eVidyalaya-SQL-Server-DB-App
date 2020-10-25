using System;
namespace SchoolModels
{
	public class ExpensesModel
	{
		public long? AutoExpensesID
		{
			get;
			set;
		}
		public string Particulars
		{
			get;
			set;
		}
		public string ExpensesBillNo
		{
			get;
			set;
		}
		public string ShopName
		{
			get;
			set;
		}
		public int? Quantity
		{
			get;
			set;
		}
		public int? Amount
		{
			get;
			set;
		}
		public string PaymentMode
		{
			get;
			set;
		}
		public DateTime PurchasesDate
		{
			get;
			set;
		}
	}
}
