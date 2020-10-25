using SchoolModels;
using System;
namespace School.App.Repository.FeeViewModels
{
	public class ClassFeeSettingViewModel : Class_Fee_Setting_Model
	{
		public string ClassName
		{
			get;
			set;
		}
		public new string FeeType
		{
			get;
			set;
		}
	}
}
