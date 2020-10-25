using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class FeeType
	{
		public List<FeeTypeModel> GetFeeType()
		{
			List<FeeTypeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetFeeType"))
				{
					result = sqlDataReader.MapToList<FeeTypeModel>();
				}
			}
			return result;
		}
		public List<FeeTypeModel> GetLostableFeeType()
		{
			List<FeeTypeModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetPurchasableFeeType"))
				{
					result = sqlDataReader.MapToList<FeeTypeModel>();
				}
			}
			return result;
		}
		public short SaveFeeType(FeeTypeModel feeTypeModel)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@FeeTypeID", feeTypeModel.FeeTypeID);
					sqlService.AddParameter("@FeeType", feeTypeModel.FeeType);
					sqlService.AddParameter("@Active", feeTypeModel.Active);
					sqlService.AddParameter("@IsPurchasable", feeTypeModel.IsPurchasable);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveFeeType");
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
