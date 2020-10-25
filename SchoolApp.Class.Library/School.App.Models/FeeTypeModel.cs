using System;
namespace SchoolModels
{
	public class FeeTypeModel
	{
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
		public string FixedName
		{
			get;
			set;
		}
		public bool Active
		{
			get;
			set;
		}
		public bool IsPurchasable
		{
			get;
			set;
		}
	}
}
