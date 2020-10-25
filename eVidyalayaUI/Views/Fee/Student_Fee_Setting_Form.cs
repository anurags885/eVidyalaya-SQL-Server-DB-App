using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace eVidyalaya
{
    public partial class Student_Fee_Setting_Form : Form
    {
        long? _student_Id;
        long? _receipt_No = null;
        FeeGenerate fee_Generate = new FeeGenerate();
        Student_Fee_Setting _repository_Object;
        StringBuilder sbMessage;
        List<CheckBoxMonth> listMonthCkheckBoxList = new List<CheckBoxMonth>();
        Student_Fee_Setting student_Fee_Setting = new Student_Fee_Setting();

        public Student_Fee_Setting_Form(long? StudentID)
        {
            InitializeComponent();
            _student_Id = StudentID;
            //  gridStudentSetting.AutoGenerateColumns = false;

            txtAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };

            ddlAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            Bind_Academic_Year_Drop_Down();
            ddlAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);

            ddlSettingType.SelectedIndexChanged -= new EventHandler(ddlSettingType_SelectedIndexChanged);
            Bind_Student_Fee_Info_Type_Drop_Down();
            ddlSettingType.SelectedIndexChanged += new EventHandler(ddlSettingType_SelectedIndexChanged);
        }
        private void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Control_On_DropDown_Change();
            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) != 0)
            {
                Bind_Check_Box_Months(Convert.ToInt32(ddlAcademicYear.SelectedValue));
                panelMonths.Enabled = true;
                // Get_Student_Fee_Setting_Months();
                Check_Is_Fee_Generated_For_Current_Month();
            }
            else
            {
                Clear_Control();
            }
        }
        private void ddlSettingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlSettingType.SelectedValue).ToUpper() == "HTF")
            {
                txtAmount.Visible = true;
                lblTutionFeeAmount.Visible = true;
            }
            else
            {
                txtAmount.Text = String.Empty;
                txtAmount.Visible = false;
                lblTutionFeeAmount.Visible = false;
            }

            if (Convert.ToString(ddlSettingType.SelectedValue) != "0")
            {
                //SET RECEIPT NUMBER
                Get_Student_Fee_Info_Receipt_No();

                //Disable Applicable Fee Month Check Boxs
                Get_All_Appllicable_Months();

                // Enable Check Box For Edit BY Receipt No
                Get_Applicable_Months_Details_By_Receipt_No();
            }
            else
            {
                listMonthCkheckBoxList.Select(x => { x.CheckBox.Enabled = true; return x; }).ToList();
                listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();
                lblReceipt_No.Text = string.Empty;
                _receipt_No = null;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate_Controls())
                {
                    string setting_Code = Convert.ToString(ddlSettingType.SelectedValue);
                    Int32 academic_Year = Convert.ToInt32(ddlAcademicYear.SelectedValue);
                    Int32? Half_Tution_Fee = null;

                    if (!String.IsNullOrEmpty(txtAmount.Text))
                        Half_Tution_Fee = Convert.ToInt32(txtAmount.Text);

                    _repository_Object = new Student_Fee_Setting();
                    short result = _repository_Object.Save_Student_Fee_Info((long)_student_Id, _receipt_No, setting_Code, academic_Year,
                        Comma_Seprated_Months_Value(), Half_Tution_Fee);

                    if (result == 1)
                    {
                        MessageBox.Show("Student setting has been saved.", "Student Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear_Control();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Please contact to support team.", "Student Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }
        }

        #region Private Functions
        private void Bind_Academic_Year_Drop_Down()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();
            dicSession = Common.Get_Academic_Year_List();
            ddlAcademicYear.DataSource = dicSession.ToList();
            ddlAcademicYear.DisplayMember = "value";
            ddlAcademicYear.ValueMember = "key";
        }
        private void Bind_Check_Box_Months(Int32 AcademicYear)
        {
            listMonthCkheckBoxList = Convert_Panel_Check_Boxes_To_List();
            int monthValue = DateTime.Today.Month;
            switch (monthValue)
            {
                case 1:
                    monthValue = 13;
                    break;
                case 2:
                    monthValue = 14;
                    break;
                case 3:
                    monthValue = 15;
                    break;
            }
            if (AcademicYear == Common.Get_Current_Academic_Year())
            {
                listMonthCkheckBoxList.Where(x => x.Value < monthValue).Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
            }
            if (AcademicYear > Common.Get_Current_Academic_Year())
            {
                listMonthCkheckBoxList.Select(x => { x.CheckBox.Enabled = true; return x; }).ToList();
                monthValue = DateTime.Today.Month;
                listMonthCkheckBoxList.Where(x => x.Value < monthValue).Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
            }
        }
        public List<CheckBoxMonth> Convert_Panel_Check_Boxes_To_List()
        {
            List<CheckBoxMonth> checkBoxesList = new List<CheckBoxMonth>();

            int month = 4;
            foreach (Control ctrl in panelMonths.Controls)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    checkBoxesList.Add(new CheckBoxMonth { CheckBox = ctrl as CheckBox, Value = Common.GetMonthValue(ctrl.Text) });
                }
                month++;
            }
            return checkBoxesList;
        }
        private void Reset_Control_On_DropDown_Change()
        {
            #region Reset_CheckBox
            listMonthCkheckBoxList = Convert_Panel_Check_Boxes_To_List();
            listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();
            #endregion
            lblReceipt_No.Text = string.Empty;
            ddlSettingType.SelectedIndex = 0;
        }
        private bool Validate_Controls()
        {
            sbMessage = new StringBuilder();

            int checkedMonthCount = listMonthCkheckBoxList.Where(x => x.CheckBox.Checked == true && x.CheckBox.Enabled == true).Count();
            int checked_Disable_Month_Count = listMonthCkheckBoxList.Where(x => x.CheckBox.Checked == true && x.CheckBox.Enabled == false).Count();

            if (checked_Disable_Month_Count == 12)
            {
                sbMessage.Append("\u2022 Sorry not allowed.\n");
            }
            else
            {
                if (checkedMonthCount == 0)
                    sbMessage.Append("\u2022 Please select month to calculate fee.\n");
            }

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
                sbMessage.Append("\u2022 Academic year is required.\n");

            if (Convert.ToString(ddlSettingType.SelectedValue) == "0")
                sbMessage.Append("\u2022 Setting Type is required.\n");


            if (Convert.ToString(ddlSettingType.SelectedValue) == "HTF")
            {
                if (string.IsNullOrEmpty(txtAmount.Text))
                    sbMessage.Append("\u2022 Tution Fee Amount is required.\n");

                if (!string.IsNullOrEmpty(txtAmount.Text))
                    if (Convert.ToInt32(txtAmount.Text) <= 0)
                    {
                        sbMessage.Append("\u2022 Tution Fee Amount should be greater than zero.");
                        txtAmount.Focus();
                    }
            }

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                MessageBox.Show(sbMessage.ToString(), "Student Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private string Comma_Seprated_Months_Value()
        {
            return string.Join(",", listMonthCkheckBoxList
                .Where(w => w.CheckBox.Checked == true && w.CheckBox.Enabled == true)
                .OrderBy(o => o.Value)
                .Select(s => s.Value));
        }

        /// <summary>
        /// Checking IS Current Month Fee is Generated
        /// </summary>
        private void Check_Is_Fee_Generated_For_Current_Month()
        {
            #region Check Fee Already Generated Or Not

            string month_Of_Fee_Generated = fee_Generate.Get_Fee_Generated_Current_Month(Convert.ToInt32(ddlAcademicYear.SelectedValue));

            if (!string.IsNullOrEmpty(month_Of_Fee_Generated))
            {
                //listMonthCkheckBoxList.Select(x => { x.CheckBox.Enabled = true; return x; }).ToList();
                listMonthCkheckBoxList.Where(x => x.Value <= Convert.ToInt16(month_Of_Fee_Generated))
                    .Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
            }
            #endregion
        }

        /// <summary>
        /// Clear Controls
        /// </summary>
        private void Clear_Control()
        {
            panelMonths.Enabled = false;
            txtAmount.Text = String.Empty;
            ddlAcademicYear.SelectedIndex = 0;
            ddlSettingType.SelectedIndex = 0;
            txtAmount.Focus();
            lblReceipt_No.Text = string.Empty;
            chkApril.Checked = false;
            chkMay.Checked = false;
            chkJune.Checked = false;
            chkJuly.Checked = false;
            chkAugust.Checked = false;
            chkSeptember.Checked = false;
            chkOctober.Checked = false;
            chkNovember.Checked = false;
            chkDecember.Checked = false;
            chkJanuary.Checked = false;
            chkFebruary.Checked = false;
            chkMarch.Checked = false;
        }

        /// <summary>
        /// Bind Fee Info Type Drrop Down
        /// </summary>
        private void Bind_Student_Fee_Info_Type_Drop_Down()
        {
            List<Student_Fee_Info_Type> list_Student_Info = new List<Student_Fee_Info_Type>();
            list_Student_Info.Add(new Student_Fee_Info_Type { Fee_Info_Code = "0", Fee_Info_Type = "Select" });
            _repository_Object = new Student_Fee_Setting();

            List<Student_Fee_Info_Type> list_Student_Info_Output = _repository_Object.Get_Student_Fee_Info_Type(false);
            if (list_Student_Info_Output != null)
            {
                list_Student_Info.AddRange(list_Student_Info_Output);
            }

            ddlSettingType.DataSource = list_Student_Info;
            ddlSettingType.DisplayMember = "Fee_Info_Type";
            ddlSettingType.ValueMember = "Fee_Info_Code";
        }

        /// <summary>
        /// Get Receipt No By Setting Type If Already Saved
        /// </summary>
        private void Get_Student_Fee_Info_Receipt_No()
        {
            Int32 academic_Year = Convert.ToInt32(ddlAcademicYear.SelectedValue);
            string setting_Code = Convert.ToString(ddlSettingType.SelectedValue);
            _repository_Object = new Student_Fee_Setting();

            Student_Fee_Info_Receipt_Model model = _repository_Object.Get_Student_Fee_Info_Receipt_No((long)_student_Id, academic_Year, setting_Code);
            if (model != null)
            {
                _receipt_No = model.Receipt_No;
                lblReceipt_No.Text = Convert.ToString(_receipt_No);
                txtAmount.Text = model.Half_Tution_Fee == null ? string.Empty : Convert.ToString(model.Half_Tution_Fee);
            }
            else
            {
                _receipt_No = null;
                lblReceipt_No.Text = String.Empty;
            }
        }

        /// <summary>
        /// Get All Applicable Months From DB & Disable CheckBox
        /// </summary>
        private void Get_All_Appllicable_Months()
        {
            _repository_Object = new Student_Fee_Setting();
            List<Student_Fee_Info_Months_Model> listCheckedMonths = _repository_Object.Get_Student_Fee_Setting_Months((long)_student_Id, Convert.ToInt32(ddlAcademicYear.SelectedValue));

            if (listCheckedMonths != null)
            {
                foreach (Student_Fee_Info_Months_Model item in listCheckedMonths)
                {
                    listMonthCkheckBoxList.Where(x => x.Value == item.MonthValue)
                   .Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
                }
            }
            Check_Is_Fee_Generated_For_Current_Month();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Get_Applicable_Months_Details_By_Receipt_No()
        {
            string setting_Code = Convert.ToString(ddlSettingType.SelectedValue);
            int academic_Year = Convert.ToInt32(ddlAcademicYear.SelectedValue);
            long? receipt_No = null;

            listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();

            if (!string.IsNullOrEmpty(lblReceipt_No.Text))
                receipt_No = Convert.ToInt64(lblReceipt_No.Text);

            List<Student_Fee_Info_Months_Model> list = student_Fee_Setting.Get_Student_Fee_Setting_Details_By_Receipt_No(
                receipt_No, setting_Code, academic_Year);

            if (list != null)
            {
                #region Enable CheckBox
                foreach (Student_Fee_Info_Months_Model item in list)
                {
                    listMonthCkheckBoxList.Where(x => x.Value == item.MonthValue)
                        .Select(x => { x.CheckBox.Enabled = true; return x; }).ToList();

                    listMonthCkheckBoxList.Where(x => x.Value == item.MonthValue)
                        .Select(x => { x.CheckBox.Checked = true; return x; }).ToList();
                }
                #endregion

                #region Disable CheckBox If Fee is all ready generated
                //   Check_Is_Fee_Generated_For_Current_Month();
                #endregion
            }
            else
            {
                //UnCheck Months If any months is applicable
                listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();
            }
        }
        #endregion
    }
}