using SchoolModels;
using SchoolModels.Fee;
using SqlServer.Service;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class FeeDeposit
	{
		private FeeDepositViewModel _feeDepositViewModel;
		public FeeDepositViewModel GetFeeDetailsByReceiptNo(long? ReceiptNo)
		{
			this._feeDepositViewModel = new FeeDepositViewModel();
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@ReceiptNo", SqlDbType.BigInt, ReceiptNo);
					using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetFeeDetailsByReceiptNo"))
					{
						this._feeDepositViewModel.FeeDepositModel = sqlDataReader.MapToSingle<FeeDepositModel>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.ListFeeApplicable = sqlDataReader.MapToList<Class_Fee_Setting_Model>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.ListFeeDues = sqlDataReader.MapToList<MonthlyFeeGenerateModel>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.ListMonthlyTransaction = sqlDataReader.MapToList<MonthlyFeeDepositModel>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.ListStudentFine = sqlDataReader.MapToList<StudentFineModel>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.ListStudentFinePaid = sqlDataReader.MapToList<StudentFineModel>();
						sqlDataReader.NextResult();
						this._feeDepositViewModel.List_Fee_Deposited = sqlDataReader.MapToList<MonthlyFeeDepositModel>();
						sqlDataReader.NextResult();
					}
				}
			}
			catch (Exception var_2_107)
			{
			}
			return this._feeDepositViewModel;
		}
		public short DepositMonthlyFee(MonthlyFeeDepositModel monthlyFeeDeposit)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@ReceiptNo", monthlyFeeDeposit.FeeReceiptNo);
					sqlService.AddParameter("@AmountDeposit", monthlyFeeDeposit.AmountDeposit);
					sqlService.AddParameter("@AmountDues", monthlyFeeDeposit.AmountDues);
					sqlService.AddParameter("@FeeDepositDate", monthlyFeeDeposit.FeeDepositDate);
					sqlService.AddParameter("@FineDetailsXML", monthlyFeeDeposit.FineDetailsXML);
					sqlService.AddParameter("@Student_ID", monthlyFeeDeposit.Student_ID);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_DepositFee");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public short SavePurchasesFee(string purchasesFeeXML)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@PurchasesFeeXML", purchasesFeeXML);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SavePurchasesFee");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public short Update_Deposit_Date(long Fee_Transaction_ID_IN, DateTime New_Deposit_Date_IN)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Fee_Transaction_ID_IN", Fee_Transaction_ID_IN);
					sqlService.AddParameter("@New_Deposit_Date_IN", New_Deposit_Date_IN);
					sqlService.AddOutputParameter("@Result_OUT", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Update_Deposit_Date");
					result = (short)sqlService.Parameters["@Result_OUT"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public short Delete_Deposit_Entry(long Fee_Transaction_ID_IN, long Fee_Receipt_No_IN)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Fee_Transaction_ID_IN", Fee_Transaction_ID_IN);
					sqlService.AddParameter("@Fee_Receipt_No_IN", Fee_Receipt_No_IN);
					sqlService.AddOutputParameter("@Result_OUT", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Delete_Deposit_Entry");
					result = (short)sqlService.Parameters["@Result_OUT"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public bool CheckDuplicatePurchasesFee(long? StudentID, short FeeTypeID, DateTime PurchasesDate)
		{
			this._feeDepositViewModel = new FeeDepositViewModel();
			bool result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@StudentID", SqlDbType.BigInt, StudentID);
				sqlService.AddParameter("@FeeTypeID", SqlDbType.SmallInt, FeeTypeID);
				sqlService.AddParameter("@PurchasesDate", SqlDbType.Date, PurchasesDate);
				string value = sqlService.ExecuteSPScalar("dbo.USP_CheckDuplicatePurchasesFee");
				result = (Convert.ToInt16(value) == 0);
			}
			return result;
		}
		public List<PurchasesFeeModel> GetPurchasesFeeList(DateTime PurchasesDate)
		{
			this._feeDepositViewModel = new FeeDepositViewModel();
			List<PurchasesFeeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@PurchasesDate", SqlDbType.Date, PurchasesDate);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetPurchasesFeeList"))
				{
					result = sqlDataReader.MapToList<PurchasesFeeModel>();
				}
			}
			return result;
		}
		public List<MonthlyFeeGenerateModel> Get_Student_Previous_Dues_List(long Registration_No)
		{
			List<MonthlyFeeGenerateModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Registration_No", SqlDbType.BigInt, Registration_No);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Previous_Dues_List"))
				{
					result = sqlDataReader.MapToList<MonthlyFeeGenerateModel>();
				}
			}
			return result;
		}
		public List<MonthlyFeeDepositModel> Get_Student_Deposited_List(long Student_Id)
		{
			List<MonthlyFeeDepositModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Registration_No", SqlDbType.BigInt, Student_Id);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Student_Fee_Deposited_List"))
				{
					result = sqlDataReader.MapToList<MonthlyFeeDepositModel>();
				}
			}
			return result;
		}
		public string Is_Valid_Fee_Receipt_No(long Fee_Receipt_No_IN)
		{
			string result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Fee_Receipt_No_IN", Fee_Receipt_No_IN);
					sqlService.AddOutputParameter("@Return_OUT", SqlDbType.Char, DBNull.Value, 1);
					sqlService.ExecuteSPNonQuery("dbo.USP_Is_Valid_Fee_Receipt_No");
					result = (string)sqlService.Parameters["@Return_OUT"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public List<Fee_Deposit_By_Date_View_Model> Get_Fee_Deposit_By_Date(DateTime Fee_Deposit_Date)
		{
			List<Fee_Deposit_By_Date_View_Model> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@Fee_Deposit_Date", SqlDbType.Date, Fee_Deposit_Date);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_Get_Fee_Deposit_By_Date"))
				{
					result = sqlDataReader.MapToList<Fee_Deposit_By_Date_View_Model>();
				}
			}
			return result;
		}
		public short Multiple_Receipt_Fee_Paid(string Fee_Details_xml)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Fee_Details_xml_IN", Fee_Details_xml);
					sqlService.AddOutputParameter("@Result_OUT", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_Multiple_Receipt_Fee_Paid");
					result = (short)sqlService.Parameters["@Result_OUT"].Value;
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
