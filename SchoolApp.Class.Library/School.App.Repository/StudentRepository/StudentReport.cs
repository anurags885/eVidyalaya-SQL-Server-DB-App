using SqlServer.Service;
using System;
using System.Data;
namespace School.App.Repository
{
	public class StudentReport
	{
		public DataSet GetStudentDetailsByClass(short? ClassID, short? SectionID)
		{
			DataSet result;
			using (SqlService sqlService = new SqlService(ConnectionString.ConnectionStrings))
			{
				sqlService.AddParameter("@ClassID", ClassID);
				sqlService.AddParameter("@SectionID", SectionID);
				using (DataSet dataSet = sqlService.ExecuteSPDataSet("dbo.USP_GetStudentDetailsByClass"))
				{
					result = dataSet;
				}
			}
			return result;
		}
	}
}
