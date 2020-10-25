using SchoolModels;
using SchoolModels.Fee;
using System;
using System.Collections.Generic;
namespace School.App.Repository.FeeViewModels
{
	public class FeeDepositViewModel
	{
		private FeeDepositModel _feeDepositModel = new FeeDepositModel();
		private List<Class_Fee_Setting_Model> _listClassFeeApplicable = new List<Class_Fee_Setting_Model>();
		private List<MonthlyFeeGenerateModel> _listFeeDues = new List<MonthlyFeeGenerateModel>();
		private List<MonthlyFeeDepositModel> _listFeeTransaction = new List<MonthlyFeeDepositModel>();
		private List<StudentFineModel> _listStudentFine = new List<StudentFineModel>();
		private List<StudentFineModel> _listStudentFinePaid = new List<StudentFineModel>();
		private List<MonthlyFeeDepositModel> _listMonthlyFeeDeposit = new List<MonthlyFeeDepositModel>();
		public FeeDepositModel FeeDepositModel
		{
			get
			{
				return this._feeDepositModel;
			}
			set
			{
				this._feeDepositModel = value;
			}
		}
		public List<Class_Fee_Setting_Model> ListFeeApplicable
		{
			get
			{
				return this._listClassFeeApplicable;
			}
			set
			{
				this._listClassFeeApplicable = value;
			}
		}
		public List<MonthlyFeeGenerateModel> ListFeeDues
		{
			get
			{
				return this._listFeeDues;
			}
			set
			{
				this._listFeeDues = value;
			}
		}
		public List<MonthlyFeeDepositModel> ListMonthlyTransaction
		{
			get
			{
				return this._listFeeTransaction;
			}
			set
			{
				this._listFeeTransaction = value;
			}
		}
		public List<StudentFineModel> ListStudentFine
		{
			get
			{
				return this._listStudentFine;
			}
			set
			{
				this._listStudentFine = value;
			}
		}
		public List<StudentFineModel> ListStudentFinePaid
		{
			get
			{
				return this._listStudentFinePaid;
			}
			set
			{
				this._listStudentFinePaid = value;
			}
		}
		public List<MonthlyFeeDepositModel> List_Fee_Deposited
		{
			get
			{
				return this._listMonthlyFeeDeposit;
			}
			set
			{
				this._listMonthlyFeeDeposit = value;
			}
		}
	}
}
