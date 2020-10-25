using System;
namespace SchoolModels
{
	public class StudentPromotionModel
	{
		public long? PromotionID
		{
			get;
			set;
		}
		public long? StudentID
		{
			get;
			set;
		}
		public short? FromClassID
		{
			get;
			set;
		}
		public short? FromSectionID
		{
			get;
			set;
		}
		public short? ToClassID
		{
			get;
			set;
		}
		public short? ToSectionID
		{
			get;
			set;
		}
		public DateTime? PromotionDate
		{
			get;
			set;
		}
		public int From_Academic_Year
		{
			get;
			set;
		}
		public int To_Academic_Year
		{
			get;
			set;
		}
	}
}
