using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class SchoolExpenses
	{
		public int SaveExpenses(ExpensesModel model)
		{
			int result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@AutoExpensesID", model.AutoExpensesID);
					sqlService.AddParameter("@Particulars", model.Particulars);
					sqlService.AddParameter("@ExpensesBillNo", model.ExpensesBillNo);
					sqlService.AddParameter("@ShopName", model.ShopName);
					sqlService.AddParameter("@Quantity", model.Quantity);
					sqlService.AddParameter("@Amount", model.Amount);
					sqlService.AddParameter("@PaymentMode", model.PaymentMode);
					sqlService.AddParameter("@PurchasesDate", model.PurchasesDate);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveExpenses");
					result = (int)((short)sqlService.Parameters["@Result"].Value);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public List<ExpensesModel> GetExpensesList(DateTime? purchasesDate)
		{
			List<ExpensesModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@PurchasesDate", SqlDbType.Date, purchasesDate);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetExpensesDetails"))
				{
					result = sqlDataReader.MapToList<ExpensesModel>();
				}
			}
			return result;
		}
		public DataSet ExpensesReport(DateTime? purchasesDate)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@PurchasesDate", SqlDbType.Date, purchasesDate);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_ExpensesReport"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public int DeleteExpenses(long ExpensesID)
		{
			int result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@AutoExpensesID", ExpensesID);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_DeleteExpenses");
					result = (int)((short)sqlService.Parameters["@Result"].Value);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
