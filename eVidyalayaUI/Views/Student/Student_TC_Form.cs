using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class Student_TC_Form : DockContent
    {
        public Student_TC _student_TC;
        Student_TC_Model_Info _student_TC_Model;
        public static Student_TC_Form instanceFrm;
        private Int16? _class_ID;
        private Int16? _section_ID;
        private long? _student_ID;
        private long? _sequence_No;
        public Student_TC_Form()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            Get_TC_Reason_Type();
            txtRegistrationNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtTCNumber.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtTCAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            this.ActiveControl = txtRegistrationNo;
            txtRegistrationNo.Focus();
        }
        private void Student_TC_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Student_TC_Form.instanceFrm = null;
        }
        private void Search_Student_Details()
        {
            Reset_Controls();
            if (string.IsNullOrEmpty(txtRegistrationNo.Text))
            {
                MessageBox.Show("Registration Number is required.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StudentRegistration registration = new StudentRegistration();
                RegistrationModel _registrationModel = new RegistrationModel();
                _registrationModel = registration.Get_Student_Detail(Convert.ToInt64(txtRegistrationNo.Text));

                if (_registrationModel.RegistrationNo == null)
                {
                    _registrationModel = registration.Get_InActive_Student_Detail(Convert.ToInt64(txtRegistrationNo.Text));
                }

                if (_registrationModel.RegistrationNo != null)
                {
                    lblStudentNameValue.Text = _registrationModel.FullName;
                    lblClassValue.Text = _registrationModel.ClassSection;
                    lblStudentNameValue.Visible = true;
                    lblClassValue.Visible = true;
                    lblStudentName.Visible = true;
                    lblClass.Visible = true;
                    panelInfo.Visible = true;
                    _class_ID = _registrationModel.CurrentClass;
                    _section_ID = _registrationModel.CurrentSection;
                    _student_ID = (long)_registrationModel.StudentID;
                    Get_Student_TC_Details();
                }
                else
                {
                    MessageBox.Show("Invalid Registration Number.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_Controls();
                    txtRegistrationNo.Text = string.Empty;
                }
            }
        }
        private void Reset_Controls()
        {
            txtRegistrationNo.Focus();
            lblStudentNameValue.Visible = false;
            lblClassValue.Visible = false;
            panelInfo.Visible = false;
            txtMaskedAcademicYear.Text = string.Empty;
            txtMaskedDate.Text = string.Empty;
            txtTCNumber.Text = string.Empty;
            ddlTCReason.Text = string.Empty;
            lblClassValue.Text = string.Empty;
            lblStudentNameValue.Text = string.Empty;
            _sequence_No = null;
            _student_ID = null;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search_Student_Details();
        }
        private void Get_Student_TC_Details()
        {
            string Academic_Year = string.Empty;
            string Academic_Year_Format = string.Empty;

            _student_TC = new Student_TC();
            _student_TC_Model = _student_TC.Get_Student_TC_Details(_student_ID);

            if (_student_TC_Model.Sequence_No != null)
            {
                txtTCNumber.Text = Convert.ToString(_student_TC_Model.TC_Number);
                ddlTCReason.SelectedValue = _student_TC_Model.Reason_ID;
                txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", _student_TC_Model.TC_Date);

                Academic_Year = Convert.ToString(_student_TC_Model.Academic_Year);
                Academic_Year_Format = Academic_Year.Left(4) + "-" + Academic_Year.Right(4);
                txtMaskedAcademicYear.Text = Academic_Year_Format;
                btnDelete.Visible = true;
                _sequence_No = _student_TC_Model.Sequence_No;
                txtTCAmount.Text = Convert.ToString(_student_TC_Model.TC_Fee_Amount);
            }
            else
            {
                Academic_Year = Convert.ToString(Common.Get_Current_Academic_Year());
                Academic_Year_Format = Academic_Year.Left(4) + "-" + Academic_Year.Right(4);
                txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", DateTime.Today);
                txtMaskedAcademicYear.Text = Academic_Year_Format;
                btnDelete.Visible = false;
            }
        }
        private bool Validate_Controls()
        {
            StringBuilder sbMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtRegistrationNo.Text))
            {
                sbMessage.Append("\u2022 Registration Number is required.\n");
            }

            if (!txtMaskedAcademicYear.MaskFull)
                sbMessage.Append("\u2022 Academic Year is required.\n");

            if (!txtMaskedDate.MaskFull)
                sbMessage.Append("\u2022 TC Date is required.\n");

            if (txtMaskedDate.MaskFull)
            {
                if (!Common.ValidateDate(txtMaskedDate.Text))
                    sbMessage.Append("\u2022 TC Date not in correct format. (DD.MM.YYYY)\n");
            }

            if (string.IsNullOrEmpty(txtTCNumber.Text))
                sbMessage.Append("\u2022 TC Number is required.\n");

            if (Convert.ToInt16(ddlTCReason.SelectedValue) == 0)
            {
                sbMessage.Append("\u2022 Reasons is required.\n");
            }

            if (string.IsNullOrEmpty(txtTCAmount.Text))
                sbMessage.Append("\u2022 Amount is required.\n");

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                MessageBox.Show(sbMessage.ToString(), "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           // Search_Student_Details();
            if (Validate_Controls())
            {
                _student_TC = new Student_TC();
                _student_TC_Model = new Student_TC_Model_Info()
                {
                    Academic_Year = Convert.ToInt32(txtMaskedAcademicYear.Text.Replace("-", "")),
                    Sequence_No = _sequence_No,
                    Student_ID = _student_ID,
                    TC_Date = Common.Convert_String_To_Date(txtMaskedDate.Text),
                    Reason_ID = Convert.ToInt32(ddlTCReason.SelectedValue),
                    TC_Number = Convert.ToInt32(txtTCNumber.Text),
                    TC_Fee_Amount= Convert.ToInt32(txtTCAmount.Text),
                };
                short result = _student_TC.USP_Save_Student_TC_Info(_student_TC_Model);

                switch (result)
                {
                    case 1:
                        MessageBox.Show("Record saved successfully.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset_Controls();
                        txtRegistrationNo.Text = string.Empty;
                        break;
                    case -1:
                        MessageBox.Show("Error in saving record.\n Please contact support team.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0:
                        MessageBox.Show("TC Number already exists.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        public void Get_TC_Reason_Type()
        {
            List<TC_Reason_Type> list = new List<TC_Reason_Type>();
            list.Add(new TC_Reason_Type { TC_Reason_ID = 0, TC_Reason = "Select" });

            List<TC_Reason_Type> list_TC_Reason_Type = new List<TC_Reason_Type>();
            _student_TC = new Student_TC();
            list_TC_Reason_Type = _student_TC.Get_TC_Reason_Type();

            if (list_TC_Reason_Type != null)
            {
                list.AddRange(list_TC_Reason_Type);
            }
            ddlTCReason.DataSource = list;
            ddlTCReason.DisplayMember = "TC_Reason";
            ddlTCReason.ValueMember = "TC_Reason_ID";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Search_Student_Details();

            if (Validate_Controls())
            {
                try
                {
                    DialogResult dResult = MessageBox.Show("Are you sure to delete this record?", "Student TC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        _student_TC = new Student_TC();
                        short output = _student_TC.Delete_TC_Details(_student_ID);

                        switch (output)
                        {
                            case 1:
                                MessageBox.Show("Record deleted successfully.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case -1:
                                MessageBox.Show("Error in deleting record.\n Please contact support team.", "Student TC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error: Please contact support team.", "Student TC", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                finally
                {
                    Reset_Controls();
                    txtRegistrationNo.Text = string.Empty;
                }
            }
        }

        private void Student_TC_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnPrintTCReceipt_Click(object sender, EventArgs e)
        {

        }
    }
}
