using SchoolModels;
using SqlServer.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace School.App.Repository
{
	public class TransportFeeSetting
	{
		public List<TransportRouteModel> GetTransportRoute()
		{
			List<TransportRouteModel> result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				using (SqlDataReader sqlDataReader = sqlService.ExecuteSPReader("dbo.USP_GetTransportRoute"))
				{
					result = sqlDataReader.MapToList<TransportRouteModel>();
				}
			}
			return result;
		}
		public short SaveTransportRoute(TransportRouteModel transportModel)
		{
			short result;
			try
			{
				using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
				{
					sqlService.AddParameter("@RouteID", transportModel.RouteID);
					sqlService.AddParameter("@RouteName", transportModel.RouteName);
					sqlService.AddParameter("@Amount", transportModel.Amount);
					sqlService.AddOutputParameter("@Result", SqlDbType.SmallInt);
					sqlService.ExecuteSPNonQuery("dbo.USP_SaveTransportRoute");
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
