using System;
using System.IO;
using System.Windows.Forms;
using SchoolModels;
using School.App.Repository;
using System.Drawing;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class SchoolDetailsForm : DockContent
    {
        // string _appPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
        string _appPath = Application.StartupPath + "\\";
        string TempFolder = "TempFolder\\";
        Byte[] _schoolLogoBytes = null;
        SchoolSetting schoolSetting;
        SchoolModel schoolModel;
        public static SchoolDetailsForm instanceFrm = null;
        public SchoolDetailsForm()
        {
            InitializeComponent();
            Array.ForEach(Directory.GetFiles(_appPath + TempFolder), File.Delete);
            hdnSchoolID.Text = string.Empty;
            KeyPressValidation();
            GetSchoolDetails();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //Delete all files in TempFolder;

                OpenFileDialog openImage = new OpenFileDialog();
                openImage.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|Bitmap Files|*.bmp|PNG Image|*.png";
                openImage.Title = "Image";
                DialogResult result = openImage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pictureSchoolLogo.Load(openImage.FileName);
                    pictureSchoolLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    _appPath = _appPath + TempFolder;
                    _schoolLogoBytes = Common.ResizeImage(pictureSchoolLogo.Width, pictureSchoolLogo.Height, openImage.FileName, _appPath, Path.GetFileName(openImage.FileName));
                }
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                ShowError("Soory! Error in uploading file");
            }
        }
        private void GetSchoolDetails()
        {
            try
            {
                schoolSetting = new SchoolSetting();
                schoolModel = schoolSetting.GetSchoolDetail(1);
                if (schoolModel != null)
                {
                    hdnSchoolID.Text = Convert.ToString(schoolModel.SchoolID);
                    txtSchoolName.Text = schoolModel.SchoolName;
                    txtAddress.Text = schoolModel.Address;
                    txtPhoneNo.Text = schoolModel.PhoneNo;
                    txtESTD.Text = schoolModel.ESTD;
                    txtAffiliationNo.Text = schoolModel.AffiliationNo;
                    txtSchoolNo.Text = schoolModel.SchoolNo;
                    chkReAdmission.Checked = schoolModel.IsReAdmission;
                    txtReAdmissionAmount.Enabled = schoolModel.IsReAdmission;
                    txtReAdmissionAmount.Text = Convert.ToString(schoolModel.ReAdmissionAmount);
                    txtline1.Text = schoolModel.FormTextLine1;
                    txtline2.Text = schoolModel.FormTextLine2;
                    txtline3.Text = schoolModel.FormTextLine3;

                    if (schoolModel.SchoolLogo != null)
                    {
                        MemoryStream memoryStream = new MemoryStream(schoolModel.SchoolLogo);
                        pictureSchoolLogo.Image = new Bitmap(memoryStream);
                        pictureSchoolLogo.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureSchoolLogo.Visible = true;
                        _schoolLogoBytes = schoolModel.SchoolLogo;
                    }
                    lblError.Visible = false;
                }
                else
                {
                    ShowError("Error: Please Contact To Admin.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Error: Please Contact To Admin.");
            }
            txtSchoolName.Focus();
            txtSchoolName.SelectionStart = txtSchoolName.Text.Length;
        }
        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = message;
        }
        private void chkReAdmission_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReAdmission.Checked == false)
            {
                txtReAdmissionAmount.Enabled = false;
            }
            else
            {
                txtReAdmissionAmount.Enabled = true;
            }
        }
        private void KeyPressValidation()
        {
            txtReAdmissionAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtSchoolNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtESTD.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtAffiliationNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtPhoneNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.AlphaNumericValidation(e); };
            txtSchoolName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtAddress.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtline1.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtline2.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtline3.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
        }
        private void SaveSchoolDetail()
        {
            schoolModel = new SchoolModel
            {
                SchoolID = string.IsNullOrWhiteSpace(hdnSchoolID.Text) ? null : (long?)Convert.ToInt64(hdnSchoolID.Text),
                SchoolName = txtSchoolName.Text,
                Address = txtAddress.Text,
                PhoneNo = txtPhoneNo.Text,
                ESTD = string.IsNullOrWhiteSpace(txtESTD.Text) ? null : txtESTD.Text,
                AffiliationNo = string.IsNullOrWhiteSpace(txtAffiliationNo.Text) ? null : txtAffiliationNo.Text,
                SchoolNo = string.IsNullOrWhiteSpace(txtSchoolNo.Text) ? null : txtSchoolNo.Text,
                IsReAdmission = chkReAdmission.Checked == true ? true : false,
                ReAdmissionAmount = string.IsNullOrWhiteSpace(txtReAdmissionAmount.Text) ? null : (Int32?)Convert.ToInt32(txtReAdmissionAmount.Text),
                SchoolLogo = _schoolLogoBytes,
                FormTextLine1 = string.IsNullOrWhiteSpace(txtline1.Text) ? null : txtline1.Text,
                FormTextLine2 = string.IsNullOrWhiteSpace(txtline2.Text) ? null : txtline2.Text,
                FormTextLine3 = string.IsNullOrWhiteSpace(txtline3.Text) ? null : txtline3.Text
            };
            schoolSetting = new SchoolSetting();
            short result = schoolSetting.SaveSchoolDetails(schoolModel);
            switch (result)
            {
                case 1:
                    MessageBox.Show("Record Successfully Saved.", "School Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case -1:
                    MessageBox.Show("Error: Please Contact To Admin.", "School Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ControlValidation())
            {
                SaveSchoolDetail();
                GetSchoolDetails();
            }
        }
        private bool ControlValidation()
        {
            bool isValid = false;
            StringBuilder messageBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtSchoolName.Text))
                messageBuilder.Append("\u2022 School Name is required.\n");
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                messageBuilder.Append("\u2022 Address is required.\n");
            if (string.IsNullOrWhiteSpace(txtPhoneNo.Text))
                messageBuilder.Append("\u2022 Phone Number is required.\n");
            if (pictureSchoolLogo.Image == null)
                messageBuilder.Append("\u2022 School's Logo is required.\n");
            if (chkReAdmission.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txtReAdmissionAmount.Text))
                    messageBuilder.Append("\u2022 Re-Admission Amount is required.\n");
            }
            if (!string.IsNullOrWhiteSpace(Convert.ToString(messageBuilder)))
            {
                MessageBox.Show(Convert.ToString(messageBuilder), "School Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = false;
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
        private void SchoolDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SchoolDetailsForm.instanceFrm = null;
        }
    }
}