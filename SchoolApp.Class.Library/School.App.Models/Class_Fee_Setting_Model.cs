using System;
namespace SchoolModels
{
	public class Class_Fee_Setting_Model
	{
		public long? ClassFeeID
		{
			get;
			set;
		}
		public short? ClassID
		{
			get;
			set;
		}
		public short? FeeTypeID
		{
			get;
			set;
		}
		public string FeeType
		{
			get;
			set;
		}
		public int? FeeAmount
		{
			get;
			set;
		}
		public int? AmountForStaffChild
		{
			get;
			set;
		}
		public bool? IsApplicableOnStaffChild
		{
			get;
			set;
		}
		public bool? Active
		{
			get;
			set;
		}
		public int AcademicYear
		{
			get;
			set;
		}
		public string Month_Name
		{
			get;
			set;
		}
	}
}
