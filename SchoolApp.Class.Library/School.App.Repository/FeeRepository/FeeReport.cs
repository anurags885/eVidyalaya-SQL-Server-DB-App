using SchoolModels.Report;
using SqlServer.Service;
using System;
using System.Data;
namespace School.App.Repository
{
	public class FeeReport
	{
		public DataSet GetFeeReportByMonth(FeeMonthlyReportModel feeMonthlyReportModel)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", feeMonthlyReportModel.ClassID);
				sqlService.AddParameter("@Year", feeMonthlyReportModel.Year);
				sqlService.AddParameter("@Month", feeMonthlyReportModel.Month);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_Report_Monthly_Fee_By_Class_Multiple_Months"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public DataSet GetFeeDepositReportByReceiptNo(long receiptNo)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ReceiptNo", receiptNo);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_GetFeeDepositReceiptReport"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public DataSet GetDailyFeeCollection(DateTime collectionDate)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@CollectionDate", collectionDate);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_GetDailyFeeCollection"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public DataSet GetStudentDuesDetailsByClass(FeeMonthlyReportModel model)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", model.ClassID);
				sqlService.AddParameter("@SectionID", model.SectionID);
				sqlService.AddParameter("@Month", model.Month);
				sqlService.AddParameter("@Year", model.Year);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_StudentDuesDetailsByClass"))
				{
					result = dataSet;
				}
			}
			return result;
		}
		public DataSet GetPurchasesFeeReport(long ReceiptNo, long RegistrationNo)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ReceiptNo", ReceiptNo);
				sqlService.AddParameter("@RegistrationNo", RegistrationNo);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_ReportPurchasesFeeReceipt"))
				{
					result = dataSet;
				}
			}
			return result;
		}
	}
}
