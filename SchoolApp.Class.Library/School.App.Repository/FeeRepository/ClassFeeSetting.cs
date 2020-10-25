using SchoolModels;
using SqlServer.Service;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class ClassFeeSetting
	{
		public List<ClassFeeSettingViewModel> GetClassFeeSetting(short? ClassID, short? FeeTypeID, int AcademicYear)
		{
			List<ClassFeeSettingViewModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", SqlDbType.TinyInt, ClassID);
				sqlService.AddParameter("@FeeTypeID", SqlDbType.TinyInt, FeeTypeID);
				sqlService.AddParameter("@AcademicYear", SqlDbType.Int, AcademicYear);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetClassFeeSetting"))
				{
					result = sqlDataReader.MapToList<ClassFeeSettingViewModel>();
				}
			}
			return result;
		}
		public short SaveClassFeeSetting(Class_Fee_Setting_Model classFeeSettingModels)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@ClassFeeID", classFeeSettingModels.ClassFeeID);
					sqlService.AddParameter("@ClassID", classFeeSettingModels.ClassID);
					sqlService.AddParameter("@FeeTypeID", classFeeSettingModels.FeeTypeID);
					sqlService.AddParameter("@FeeAmount", classFeeSettingModels.FeeAmount);
					sqlService.AddParameter("@Active", classFeeSettingModels.Active);
					sqlService.AddParameter("@IsApplicableOnStaffChild", classFeeSettingModels.IsApplicableOnStaffChild);
					sqlService.AddParameter("@AmountForStaffChild", classFeeSettingModels.AmountForStaffChild);
					sqlService.AddParameter("@Academic_Year", classFeeSettingModels.AcademicYear);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveClassFeeSetting");
					result = (short)sqlService.Parameters["@Result"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public List<ClassFeeSettingViewModel> GetPurchasableFeeTypeAmount(short? ClassID, short FeeTypeID)
		{
			List<ClassFeeSettingViewModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", SqlDbType.TinyInt, ClassID);
				sqlService.AddParameter("@FeeTypeID", SqlDbType.TinyInt, FeeTypeID);
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetPurchasableFeeTypeAmount"))
				{
					result = sqlDataReader.MapToList<ClassFeeSettingViewModel>();
				}
			}
			return result;
		}
		public void Check_Is_Fee_Setting_Is_Saved(int Academic_Year, out string Is_Fee_Setting_Saved, out string Is_Class_Fee_Setting_Saved)
		{
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddOutputParameter("@Is_Fee_Setting_Saved", SqlDbType.Char, DBNull.Value, 1);
					sqlService.AddOutputParameter("@Is_Class_Fee_Setting_Saved", SqlDbType.Char, DBNull.Value, 1);
					sqlService.ExecuteSPNonQuery("dbo.USP_Check_Is_Fee_Setting_Is_Saved");
					Is_Fee_Setting_Saved = (string)sqlService.Parameters["@Is_Fee_Setting_Saved"].Value;
					Is_Class_Fee_Setting_Saved = (string)sqlService.Parameters["@Is_Class_Fee_Setting_Saved"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void Check_Class_Fee_Setting_For_Previous_Academic_Year(int Academic_Year, out string Is_Record_Exists_Out)
		{
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddOutputParameter("@Is_Record_Exists_OUT", SqlDbType.Char, DBNull.Value, 1);
					sqlService.ExecuteSPNonQuery("dbo.USP_CHECK_CLASS_FEE_SETTING_FOR_PREVIOUS_ACADEMIC_YEAR");
					Is_Record_Exists_Out = (string)sqlService.Parameters["@Is_Record_Exists_OUT"].Value;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public short Copy_Class_Fee_Setting(int Academic_Year)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@Academic_Year", Academic_Year);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.Usp_Copy_Class_Fee_Setting");
					result = (short)sqlService.Parameters["@Result"].Value;
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
