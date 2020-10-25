using School.App.Repository;
using School.App.Repository.StudentViewModels;
using SchoolModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class StudentAdmissionForm : DockContent
    {
        #region Variables
        string _appPath = Application.StartupPath + "\\"; //.Substring(0, Application.StartupPath.LastIndexOf("bin"));
        Byte[] _tcFilebytes = null;
        Byte[] _tcStudentImagebytes = null;
        StudentRegistration _studentAdmission;
        StudentViewModel _studentViewModel;
        public static StudentAdmissionForm instanceFrmStudentRegistration;
        static ClassSection _classSection = new ClassSection();
        static List<ClassSectionModel> _listClassSectionModel = new List<ClassSectionModel>();
        string _dialogBoxFilter = "All Files|*.docx;*.doc;*.pdf;*.jpge*.jpg,*.png,*.gif|JPEG Images|*.jpge;*.jpg|Bitmap Files|*.bmp|PNG Image|*.png|GIF Images|*.gif|Document|*.docx;*.doc|Pdf|*.pdf";
        string TempFolder = "TempFolder\\";
        #endregion

        #region Private Constructor
        public StudentAdmissionForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            //Unbind the ddlCurrentClass_SelectedIndexChanged Event of ddlCurrentClass. Changing the default behaviour.
            //  ddlCurrentClass.SelectedIndexChanged -= new EventHandler(ddlCurrentClass_SelectedIndexChanged);
            LoadStudentDetails(null);
            HideError();
            //Bind the ddlCurrentClass_SelectedIndexChanged Event of ddlCurrentClass.
            // ddlCurrentClass.SelectedIndexChanged += new EventHandler(ddlCurrentClass_SelectedIndexChanged);
            StringBuilder sbShortCutKeys = new StringBuilder();
            sbShortCutKeys.Append("Use following shortcut keys :\n")
                .Append("\u2022 New: Ctrl + N \n")
                .Append("\u2022 Find: Ctrl + F \n")
                .Append("\u2022 Clear: Ctrl + D \n")
                .Append("\u2022 Save: Ctrl + S \n");
            lblShortCutKeys.Text = sbShortCutKeys.ToString();
        }
        #endregion

        #region Private Method
        public StudentAdmissionForm(long? RegistrationNumber)
        {
            LoadStudentDetails(RegistrationNumber);
        }
        private string ValidateControls()
        {
            StringBuilder messageBuilder = new StringBuilder();
            //  messageBuilder.Append("To continue, please select one of the actions below:");
            //messageBuilder.Append(Environment.NewLine);
            //messageBuilder.Append(Environment.NewLine);
            //messageBuilder.Append(" \u2022 Click Button A to do this action.");
            //messageBuilder.Append(Environment.NewLine);
            //messageBuilder.Append(" \u2022 Click Button B to do this action.");
            //  lblErrorList.Text = messageBuilder.ToString();
            // MessageBox.Show(messageBuilder.ToString());
            //sbyte s= Convert.ToSByte(ddlGender.SelectedValue);
            //sbyte selectedValue;
            //bool parseOK = sbyte.TryParse(ddlGender.SelectedValue.ToString(), out selectedValue);


            if (String.IsNullOrWhiteSpace(txtRegistrationNo.Text))
                messageBuilder.Append("\u2022 Registration number is required.\n");
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
                messageBuilder.Append("\u2022 First name is required.\n");
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
                messageBuilder.Append("\u2022 Last name is required.\n");
            if (String.IsNullOrWhiteSpace(txtFatherName.Text))
                messageBuilder.Append("\u2022 Father name is required.\n");
            if (String.IsNullOrWhiteSpace(txtMotherName.Text))
                messageBuilder.Append("\u2022 Mother name is required.\n");
            if (Convert.ToSByte(ddlGender.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Gender is required.\n");
            if (!txtMaskedBirthDate.MaskFull)
                messageBuilder.Append("\u2022 Birth date is required.\n");
            if (!txtMaskedRegistrationDate.MaskFull)
                messageBuilder.Append("\u2022 Registration date is required.\n");
            if (String.IsNullOrWhiteSpace(txtAddress.Text))
                messageBuilder.Append("\u2022 Address is required.\n");
            if (String.IsNullOrWhiteSpace(txtPincode.Text))
                messageBuilder.Append("\u2022 Pincode is required.\n");
            if (String.IsNullOrWhiteSpace(txtMobileNo1.Text))
                messageBuilder.Append("\u2022 Mobile1 is required.\n");
            if (Convert.ToSByte(ddlEnrollmentClass.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Enrollment class is required.\n");
            if (Convert.ToSByte(ddlCurrentClass.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Current class is required.\n");
            if (Convert.ToSByte(ddlCurrentSection.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Section is required.\n");
            if (Convert.ToSByte(ddlNationality.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Nationality is required.\n");
            if (Convert.ToSByte(ddlReligion.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Religion is required.\n");
            if (Convert.ToSByte(ddlCaste.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Caste is required.\n");
            if (Convert.ToSByte(ddlTransportArea.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Trasport detail is required.\n");

            if (txtMaskedBirthDate.MaskFull)
            {
                if (!Common.ValidateDate(txtMaskedBirthDate.Text))
                    messageBuilder.Append("\u2022 Birth date not in correct format. (DD.MM.YYYY)\n");
            }
            if (txtMaskedRegistrationDate.MaskFull)
            {
                if (!Common.ValidateDate(txtMaskedRegistrationDate.Text))
                    messageBuilder.Append("\u2022 Registration date not in correct format. (DD.MM.YYYY)\n");
            }

            

            if (chkTcAvailable.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtSchoolName.Text))
                    messageBuilder.Append("\u2022 School Name is required.\n");
                if (String.IsNullOrWhiteSpace(txtTCNumber.Text))
                    messageBuilder.Append("\u2022 TC number is required.\n");
                if (String.IsNullOrWhiteSpace(txtExSchoolContactNo.Text))
                    messageBuilder.Append("\u2022 School contact number is required.\n");
                if (String.IsNullOrWhiteSpace(lblExSchoolAddress.Text))
                    messageBuilder.Append("\u2022 School address is required.\n");
            }

            return messageBuilder.ToString();
        }
        private void LoadStudentDetails(long? RegistrationNumber)
        {
            //txtMaskedRegistrationDate.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToString("dd/MM/yyyy"));
            //chkISActive.Checked = true;
            //btnSave.Enabled = true;
            // ClearFileds();

            //RadWaitingBar radWaitingBar = new RadWaitingBar();
            //radWaitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            //radWaitingBar.WaitingDirection = ProgressOrientation.Left;
            //this.Controls.Add(radWaitingBar);

            // LoadingPanel.ShowPleaseWait();
            try
            {
                _studentAdmission = new StudentRegistration();
                _studentViewModel = new StudentViewModel();
                _studentViewModel = _studentAdmission.GetStudentDetails(RegistrationNumber);

                if (_studentViewModel.ListGender.Count > 0)
                {
                    ddlGender.DataSource = _studentViewModel.ListGender;
                    ddlGender.DisplayMember = "Type";
                    ddlGender.ValueMember = "GenderID";
                }

                if (_studentViewModel.ListCountry != null && _studentViewModel.ListCountry.Count > 0)
                {
                    List<CountryModel> listCountry = new List<CountryModel>(_studentViewModel.ListCountry);
                    listCountry.Add(new CountryModel { CountryID = 0, CountryName = "Select" });
                    ddlNationality.DataSource = listCountry.OrderBy(x => x.CountryID).ToList();
                    ddlNationality.DisplayMember = "CountryName";
                    ddlNationality.ValueMember = "CountryID";
                }

                if (_studentViewModel.ListReligionType != null && _studentViewModel.ListReligionType.Count > 0)
                {
                    List<ReligionTypeModel> listReligion = new List<ReligionTypeModel>(_studentViewModel.ListReligionType);
                    listReligion.Add(new ReligionTypeModel { ReligionID = 0, ReligionName = "Select" });
                    ddlReligion.DataSource = listReligion.OrderBy(x => x.ReligionID).ToList();
                    ddlReligion.DisplayMember = "ReligionName";
                    ddlReligion.ValueMember = "ReligionID";
                }

                if (_studentViewModel.ListCaste != null && _studentViewModel.ListCaste.Count > 0)
                {
                    List<CasteTypeModel> listCaste = new List<CasteTypeModel>(_studentViewModel.ListCaste);
                    listCaste.Add(new CasteTypeModel { CasteID = 0, CasteName = "Select" });
                    ddlCaste.DataSource = listCaste.OrderBy(x => x.CasteID).ToList();
                    ddlCaste.DisplayMember = "CasteName";
                    ddlCaste.ValueMember = "CasteID";
                }

                // List<TransportRouteModel> listTransport = new List<TransportRouteModel>()
                if (_studentViewModel.ListTrasport != null && _studentViewModel.ListTrasport.Count > 0)
                {
                    List<TransportRouteModel> listTransport = new List<TransportRouteModel>(_studentViewModel.ListTrasport);
                    listTransport.Add(new TransportRouteModel { RouteID = 0, RouteName = "Select" });
                    ddlTransportArea.DataSource = listTransport.OrderBy(x => x.RouteID).ToList();
                    ddlTransportArea.DisplayMember = "RouteName";
                    ddlTransportArea.ValueMember = "RouteID";
                }


                if (_studentViewModel.ListClass.Count > 0)
                {
                    List<ClassTypeModel> listClass = new List<ClassTypeModel>(_studentViewModel.ListClass);
                    ddlEnrollmentClass.DataSource = _studentViewModel.ListClass;
                    ddlEnrollmentClass.DisplayMember = "ClassName";
                    ddlEnrollmentClass.ValueMember = "ClassID";

                    //List<ClassModel> listCurrentClass = new List<ClassModel>(_studentViewModel.ListClass);
                    ddlCurrentClass.DataSource = listClass;
                    ddlCurrentClass.DisplayMember = "ClassName";
                    ddlCurrentClass.ValueMember = "ClassID";
                }

                if (_studentViewModel.ListClassSection.Count > 0)
                {
                    ddlCurrentSection.DataSource = _studentViewModel.ListClassSection;
                    ddlCurrentSection.DisplayMember = "SectionName";
                    ddlCurrentSection.ValueMember = "ClassSectionID";
                }

                //Checking for TC is Issued Or Not
                if (_studentViewModel.Student_TC_Info.Student_ID != null)
                {
                    chkISActive.Enabled = false;
                }
                else
                {
                    chkISActive.Enabled = true;
                }

                    if (_studentViewModel.StudentModel.StudentID != null)
                {
                    //Show Group Fee Setting
                    groupFeeSetting.Visible = true;

                    hdnStudentID.Text = Convert.ToString(_studentViewModel.StudentModel.StudentID);
                    //hdnRegistrationNo.Text = Convert.ToString(_studentViewModel.StudentModel.RegistrationNo);
                    txtRegistrationNo.Text = Convert.ToString(_studentViewModel.StudentModel.RegistrationNo);
                    hdnRegistrationNo.Text = Convert.ToString(_studentViewModel.StudentModel.RegistrationNo);
                    txtFirstName.Text = Convert.ToString(_studentViewModel.StudentModel.FirstName);
                    txtMiddleName.Text = Convert.ToString(_studentViewModel.StudentModel.MiddleName);
                    txtLastName.Text = Convert.ToString(_studentViewModel.StudentModel.LastName);
                    txtFatherName.Text = Convert.ToString(_studentViewModel.StudentModel.FatherName);
                    txtMotherName.Text = Convert.ToString(_studentViewModel.StudentModel.MotherName);

                    if (_studentViewModel.StudentModel.CountryID != null)
                        ddlNationality.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.CountryID);

                    if (_studentViewModel.StudentModel.ReligionID != null)
                        ddlReligion.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.ReligionID);

                    if (_studentViewModel.StudentModel.CasteID != null)
                        ddlCaste.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.CasteID);

                    if (_studentViewModel.StudentModel.TransportRouteID != null)
                        ddlTransportArea.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.TransportRouteID);

                    if (_studentViewModel.StudentModel.GenderID != null)
                        ddlGender.SelectedValue = Convert.ToByte(_studentViewModel.StudentModel.GenderID);

                    if (_studentViewModel.StudentModel.CurrentClass != null)
                        ddlCurrentClass.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.CurrentClass);

                    if (_studentViewModel.StudentModel.CurrentSection != null)
                        ddlCurrentSection.SelectedValue = Convert.ToInt16(_studentViewModel.StudentModel.CurrentSection);

                    if (_studentViewModel.StudentModel.BirthDate != null)
                        txtMaskedBirthDate.Text = String.Format("{0:dd.MM.yyyy}", _studentViewModel.StudentModel.BirthDate);

                    if (_studentViewModel.StudentModel.RegistrationDate != null)
                        txtMaskedRegistrationDate.Text = String.Format("{0:dd.MM.yyyy}", _studentViewModel.StudentModel.RegistrationDate);

                    if (_studentViewModel.StudentModel.IsTcSubmit == true)
                        chkTcAvailable.Checked = true;

                    if (_studentViewModel.StudentModel.IsStaffChild == true)
                        chkStaffChild.Checked = true;

                    if (_studentViewModel.StudentModel.IsActive == true)
                        chkISActive.Checked = true;
                    else
                        chkISActive.Checked = false;

                    if (_studentViewModel.StudentModel.Is_RTE_Student == true)
                        chkIsRTEStudent.Checked = true;
                    else
                        chkIsRTEStudent.Checked = false;

                    if (_studentViewModel.StudentModel.StudentImage != null)
                    {
                        MemoryStream memoryStream = new MemoryStream(_studentViewModel.StudentModel.StudentImage);
                        pictureStudent.Image = new Bitmap(memoryStream);
                        pictureStudent.SizeMode = PictureBoxSizeMode.Zoom;
                        lblStudentImage.Visible = true;
                        lblStudentImage.Text = "Image attached.";
                        linkDownloadStudentImage.Visible = true;
                        _tcStudentImagebytes = _studentViewModel.StudentModel.StudentImage;
                    }
                    else
                    {
                        lblStudentImage.Visible = true;
                        lblStudentImage.Text = "Image not attached.";
                    }

                    if (_studentViewModel.StudentModel.IsNewAdmission == true)
                    {
                        lblGenerateAdmissionFee.Visible = true;
                        btnGenerateFee.Visible = true;
                    }
                    else
                    {
                        lblGenerateAdmissionFee.Visible = false;
                        btnGenerateFee.Visible = false;
                    }

                    hdnAddressID.Text = Convert.ToString(_studentViewModel.AddressModel.AddressID);
                    txtAddress.Text = Convert.ToString(_studentViewModel.AddressModel.Address);
                    txtPincode.Text = Convert.ToString(_studentViewModel.AddressModel.Pincode);
                    txtLandlineNo.Text = Convert.ToString(_studentViewModel.AddressModel.LandlineNumber);
                    txtMobileNo1.Text = Convert.ToString(_studentViewModel.AddressModel.MobileNo1);
                    txtMobileNo2.Text = Convert.ToString(_studentViewModel.AddressModel.MobileNo2);

                    hdnExSchoolID.Text = Convert.ToString(_studentViewModel.ExSchoolModel.ExSchoolID);
                    hdnTCFileType.Text = _studentViewModel.ExSchoolModel.TCFileType;
                    txtSchoolName.Text = Convert.ToString(_studentViewModel.ExSchoolModel.SchoolName);
                    txtTCNumber.Text = Convert.ToString(_studentViewModel.ExSchoolModel.TCNumber);
                    txtExSchoolContactNo.Text = Convert.ToString(_studentViewModel.ExSchoolModel.ContactNo);
                    txtExSchoolAddress.Text = Convert.ToString(_studentViewModel.ExSchoolModel.Address).ToProper();


                    if (_studentViewModel.ExSchoolModel.EnrollmentClass != null)
                        ddlEnrollmentClass.SelectedValue = Convert.ToInt16(_studentViewModel.ExSchoolModel.EnrollmentClass);

                    if (_studentViewModel.StudentModel.TransportRouteID != null)
                    {
                        ddlTransportArea.SelectedValue = Convert.ToInt32(_studentViewModel.StudentModel.TransportRouteID);
                    }

                    if (_studentViewModel.ExSchoolModel.TCImage != null)
                    {
                        lblTCFile.Visible = true;
                        lblTCFile.Text = "File attached.";
                        linkDownloadTCFile.Visible = true;
                        _tcFilebytes = _studentViewModel.ExSchoolModel.TCImage;
                    }
                    else
                    {
                        lblTCFile.Visible = true;
                        lblTCFile.Text = "File not attached.";
                    }
                }
                else
                {
                    if (RegistrationNumber != null)
                    {
                        ClearFileds();
                        ShowError("\u2022 Sorry! No record found.\n Please enter correct Registration Number.");
                        txtRegistrationNo.Text = Convert.ToString(RegistrationNumber);
                    }

                    //Hide Group Fee Setting
                    groupFeeSetting.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ShowError("\u2022 Error! Please contact to admin.");
                btnSave.Enabled = false;
            }
            finally
            {
                // SetDefaultFocus();
                //  LoadingPanel.HidePleaseWait();

            }
        }
        private void SaveStudentDetails()
        {
            try
            {
                _studentViewModel = new StudentViewModel();
               // _studentViewModel.StudentModel.Academic_Year = Common.Get_Current_Academic_Year();
               //long? _changedRegistrationNo = string.IsNullOrWhiteSpace(hdnRegistrationNo.Text) ? null : (long?)Convert.ToInt64(hdnRegistrationNo.Text);
               _studentViewModel.StudentModel.StudentID = string.IsNullOrWhiteSpace(hdnStudentID.Text) ? null : (long?)Convert.ToInt64(hdnStudentID.Text);
                _studentViewModel.StudentModel.RegistrationNo = string.IsNullOrWhiteSpace(txtRegistrationNo.Text) ? null : (long?)Convert.ToInt64(txtRegistrationNo.Text);
                _studentViewModel.StudentModel.FirstName = txtFirstName.Text.ToProper();
                _studentViewModel.StudentModel.MiddleName = txtMiddleName.Text.ToProper();
                _studentViewModel.StudentModel.LastName = txtLastName.Text.ToProper();
                _studentViewModel.StudentModel.FatherName = txtFatherName.Text.ToProper();
                _studentViewModel.StudentModel.MotherName = txtMotherName.Text.ToProper();
                _studentViewModel.StudentModel.GenderID = Convert.ToByte(ddlGender.SelectedValue);
                //_studentViewModel.StudentModel.BirthDate = DateTime.ParseExact(txtMaskedBirthDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);//Convert.ToDateTime(txtMaskedBirthDate.Text);
                //_studentViewModel.StudentModel.RegistrationDate = DateTime.ParseExact(txtMaskedRegistrationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); //Convert.ToDateTime(txtMaskedRegistrationDate.Text);

                _studentViewModel.StudentModel.BirthDate = Common.Convert_String_To_Date(txtMaskedBirthDate.Text);
                _studentViewModel.StudentModel.RegistrationDate = Common.Convert_String_To_Date(txtMaskedRegistrationDate.Text);


                _studentViewModel.StudentModel.IsStaffChild = chkStaffChild.Checked == true ? true : false;
                _studentViewModel.StudentModel.IsTcSubmit = chkTcAvailable.Checked == true ? true : false;
                _studentViewModel.StudentModel.CurrentClass = Convert.ToInt16(ddlCurrentClass.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlCurrentClass.SelectedValue);
                _studentViewModel.StudentModel.CurrentSection = Convert.ToInt16(ddlCurrentSection.SelectedValue) == 0 ? null : (Int16?)Convert.ToInt16(ddlCurrentSection.SelectedValue);
                _studentViewModel.StudentModel.StudentImage = _tcStudentImagebytes;
                _studentViewModel.StudentModel.IsActive = chkISActive.Checked == true ? true : false;
                _studentViewModel.StudentModel.Is_RTE_Student = chkIsRTEStudent.Checked == true ? true : false;

                _studentViewModel.StudentModel.CountryID = Convert.ToInt16(ddlNationality.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlNationality.SelectedValue);
                _studentViewModel.StudentModel.ReligionID = Convert.ToInt16(ddlReligion.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlReligion.SelectedValue);
                _studentViewModel.StudentModel.CasteID = Convert.ToInt16(ddlCaste.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlCaste.SelectedValue);
                _studentViewModel.StudentModel.TransportRouteID = Convert.ToInt16(ddlTransportArea.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlTransportArea.SelectedValue);

                _studentViewModel.AddressModel.AddressID = string.IsNullOrWhiteSpace(hdnAddressID.Text) ? null : (long?)Convert.ToInt64(hdnAddressID.Text);
                _studentViewModel.AddressModel.Address = txtAddress.Text.ToProper();
                _studentViewModel.AddressModel.Pincode = txtPincode.Text;
                _studentViewModel.AddressModel.LandlineNumber = txtLandlineNo.Text;
                _studentViewModel.AddressModel.MobileNo1 = txtMobileNo1.Text;
                _studentViewModel.AddressModel.MobileNo2 = txtMobileNo2.Text;

                _studentViewModel.ExSchoolModel.ExSchoolID = string.IsNullOrWhiteSpace(hdnExSchoolID.Text) ? null : (long?)Convert.ToInt64(hdnExSchoolID.Text);
                _studentViewModel.ExSchoolModel.SchoolName = txtSchoolName.Text.ToProper();
                _studentViewModel.ExSchoolModel.Address = txtExSchoolAddress.Text.ToProper();
                _studentViewModel.ExSchoolModel.ContactNo = txtExSchoolContactNo.Text;
                _studentViewModel.ExSchoolModel.EnrollmentClass = Convert.ToInt16(ddlEnrollmentClass.SelectedValue);
                _studentViewModel.ExSchoolModel.TCImage = _tcFilebytes;
                _studentViewModel.ExSchoolModel.TCNumber = string.IsNullOrWhiteSpace(txtTCNumber.Text) ? null : (Int32?)Convert.ToInt32(txtTCNumber.Text);
                _studentViewModel.ExSchoolModel.TCFileType = string.IsNullOrWhiteSpace(hdnTCFileType.Text) ? null : hdnTCFileType.Text;

                _studentAdmission = new StudentRegistration();
                short result = _studentAdmission.SaveStudentDetails(_studentViewModel);
                switch (result)
                {
                    case 0:
                        ShowError("\u2022 Registration number already exit.\n");
                        break;
                    case 1:
                        MessageBox.Show("Record saved successfully.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case -1:
                        ShowError("\u2022 Error! Please try again,\n or contact to admin.\n");
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                SetDefaultFocus();
            }
        }
        private void ShowError(string ErrorMessage)
        {
            MessageBox.Show("Validation fail! To continue, please correct below error:\n\n" + ErrorMessage, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //lblErrorHead.Visible = true;
            // lblErrorList.Visible = true;
            //  lblErrorList.Text = ErrorMessage;
        }
        private void HideError()
        {
            // lblErrorHead.Visible = false;
            // lblErrorList.Visible = false;
            // lblErrorList.Text = String.Empty;
        }
        private void DownloadFile(byte[] FileBytes, string FileNameWithExtension)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = FileNameWithExtension;
            saveFile.Filter = _dialogBoxFilter; //"JPEG Images|*.jpge;*.jpg|Bitmap Files|*.bmp|PNG Image|*.png|GIF Images|*.gif|Document|*.docx;*.doc|Pdf|*.pdf|All Files|*.docx;*.doc;*.pdf;*.jpge*.jpg,*.png,*.gif";
            DialogResult result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                byte[] dbbyte;
                dbbyte = FileBytes;
                string filepath = saveFile.FileName;

                FileStream fileStream = new FileStream(filepath, FileMode.Create);
                fileStream.Write(dbbyte, 0, dbbyte.Length);
                fileStream.Close();
                Process Proc = new Process();
                Proc.StartInfo.FileName = filepath;
                Proc.Start();
            }
        }
        public void Text_KeyPressEvent()
        {
            txtRegistrationNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtPincode.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtLandlineNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtMobileNo1.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtMobileNo2.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtExSchoolContactNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtTCNumber.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };

            txtFirstName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtMiddleName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtLastName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtFatherName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtMotherName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtSchoolName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtAddress.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtExSchoolAddress.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
        }
        private void ClearFileds()
        {
            hdnStudentID.Text = String.Empty;
            txtRegistrationNo.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtMiddleName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtFatherName.Text = String.Empty;
            txtMotherName.Text = String.Empty;

            txtMaskedBirthDate.Text = String.Empty;
            txtMaskedRegistrationDate.Text = String.Format("{0:dd.MM.yyyy}", DateTime.Now.ToString("dd.MM.yyyy"));
            chkTcAvailable.Checked = false;
            chkStaffChild.Checked = false;
            chkISActive.Checked = true;
            chkIsRTEStudent.Checked = false;
            lblStudentImage.Text = String.Empty;
            linkDownloadStudentImage.Visible = false;
            pictureStudent.Image = null;
            hdnAddressID.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtPincode.Text = String.Empty;
            txtLandlineNo.Text = String.Empty;
            txtMobileNo1.Text = String.Empty;
            txtMobileNo2.Text = String.Empty;
            hdnExSchoolID.Text = String.Empty;
            hdnTCFileType.Text = String.Empty;
            txtSchoolName.Text = String.Empty;
            txtTCNumber.Text = String.Empty;
            txtExSchoolContactNo.Text = String.Empty;
            txtExSchoolAddress.Text = String.Empty;
            lblTCFile.Visible = false;
            lblTCFile.Text = String.Empty;
            linkDownloadTCFile.Visible = false;
            _tcFilebytes = null;
            _tcStudentImagebytes = null;
            LoadStudentDetails(null);
            HideError();
            btnSave.Enabled = true;
            SetDefaultFocus();
        }
        private void SetDefaultFocus()
        {
            txtRegistrationNo.Select();
            this.ActiveControl = txtRegistrationNo;
        }
        #endregion

        #region Events
        private void frmStudentRegistration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.N)
                ClearFileds();
            if (e.Control == true && e.KeyCode == Keys.D)
                ClearFileds();
            if (e.Control == true && e.KeyCode == Keys.F)
                linkSearchByRegistrationNo_LinkClicked(null, null);
            if (e.Control == true && e.KeyCode == Keys.S)
                btnSave_Click(null, null);
        }
        private void linkSearchByRegistrationNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRegistrationNo.Text))
            {
                ShowError("\u2022 Please enter registration number to search \n");
            }
            else
            {
                //loadingPanel.Show(this);
                //WaitingDialog.ShowDialog1();
                //varriable used to get registration number with ClearFileds method. ClearFileds already clear the txtRegistrationNo.
                long? _registrationNo = string.IsNullOrWhiteSpace(txtRegistrationNo.Text) ? null : (long?)Convert.ToInt64(txtRegistrationNo.Text);
                ClearFileds();
                HideError();
                LoadStudentDetails(_registrationNo);
            }
            //loadingPanel.Close();
            // WaitingDialog.CloseDialog();
        }
        private void linkDownloadTCFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadFile(_tcFilebytes, txtRegistrationNo.Text + hdnTCFileType.Text);
        }
        private void linkDownloadStudentImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadFile(_tcStudentImagebytes, txtRegistrationNo.Text + ".png");
        }
        private void frmStudentRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudentAdmissionForm.instanceFrmStudentRegistration = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openImage = new OpenFileDialog();
                openImage.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|Bitmap Files|*.bmp|PNG Image|*.png";
                openImage.Title = "Image";
                DialogResult result = openImage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pictureStudent.Load(openImage.FileName);
                    pictureStudent.SizeMode = PictureBoxSizeMode.Zoom;
                    //Set the folder name all tempory file in TempFolder;
                    string imagePath = _appPath + TempFolder;
                    _tcStudentImagebytes = Common.ResizeImage(pictureStudent.Width, pictureStudent.Height, openImage.FileName, imagePath, Path.GetFileName(openImage.FileName));
                    lblStudentImage.Text = "Image attached.";
                }
            }
            catch (Exception ex)
            {
                ShowError("Sorry! Error in uploading file");
                //MessageBox.Show(ex.ToString());
            }
        }
        private void btnTCBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = _dialogBoxFilter;//"JPEG Images|*.jpge;*.jpg|Bitmap Files|*.bmp|PNG Image|*.png|GIF Images|*.gif|Document|*.docx;*.doc|Pdf|*.pdf|All Files|*.docx;*.doc;*.pdf;*.jpge*.jpg,*.png,*.gif";
                openFile.Title = "File";
                openFile.Multiselect = false;
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtTCFilePath.Text = openFile.FileName;
                    FileStream fileStream = new FileStream(txtTCFilePath.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    _tcFilebytes = binaryReader.ReadBytes((Int32)fileStream.Length);
                    hdnTCFileType.Text = Path.GetExtension(openFile.FileName);
                    binaryReader.Close();
                    fileStream.Close();
                    lblTCFile.Text = "File attached.";
                }
            }
            catch (Exception ex)
            {
                txtTCFilePath.Text = string.Empty;
                ShowError("Soory! Error in uploading file");
                // MessageBox.Show("Soory! Error in uploading file", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(ValidateControls()))
            {
                ShowError(ValidateControls());
                return;
            }
            else
            {
                HideError();
                SaveStudentDetails();
            }
        }
        private void StudentAdmissionForm_Load(object sender, EventArgs e)
        {
            linkClearFileds.LinkClicked += delegate (object senderLink, LinkLabelLinkClickedEventArgs eLink) { ClearFileds(); };
            this.KeyPreview = true;
            Text_KeyPressEvent();
            //Delete all files in TempFolder;
            Array.ForEach(Directory.GetFiles(_appPath + TempFolder), File.Delete);
            ClearFileds();
            txtRegistrationNo.Select();
            this.ActiveControl = txtRegistrationNo;
        }
        //private void ddlCurrentClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //_listClassSectionModel.Clear();
        //if (Convert.ToInt16(ddlCurrentClass.SelectedValue) != 0)
        //{
        //    _listClassSectionModel = _classSection.GetSectionDetails(Convert.ToInt16(ddlCurrentClass.SelectedValue));

        //    if (_listClassSectionModel == null)
        //    {
        //        _listClassSectionModel = new List<ClassSectionModel>();
        //    }
        //}
        //_listClassSectionModel.Add(new ClassSectionModel
        //{
        //    ClassSectionID = 0,
        //    ClassTypeID = 0,
        //    Active = false,
        //    SectionName = "Select"
        //});
        //ddlCurrentSection.DataSource = _listClassSectionModel.OrderBy(x => x.ClassSectionID).ToList();
        //ddlCurrentSection.DisplayMember = "SectionName";
        //ddlCurrentSection.ValueMember = "ClassSectionID";
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPartialFee_Click(object sender, EventArgs e)
        {
            long? studentID = string.IsNullOrWhiteSpace(hdnStudentID.Text) ? null : (long?)Convert.ToInt64(hdnStudentID.Text);
            Student_Fee_Setting_Form student_Fee_Setting = new Student_Fee_Setting_Form(studentID);
            student_Fee_Setting.StartPosition = FormStartPosition.CenterParent;
            student_Fee_Setting.ShowDialog(UIParent.MDIForm);

            //PartialFeeSettingForm partialFeeSettingForm = new PartialFeeSettingForm(studentID);
            //partialFeeSettingForm.StartPosition = FormStartPosition.CenterParent;
            //partialFeeSettingForm.ShowDialog(UIParent.MDIForm);
        }
        private void btnGenerateFee_Click(object sender, EventArgs e)
        {
            long studentID = Convert.ToInt64(hdnStudentID.Text);
            AdmissionFeeForm admissionFeeForm = new AdmissionFeeForm(studentID,txtMaskedRegistrationDate.Text);
            admissionFeeForm.StartPosition = FormStartPosition.CenterParent;
            admissionFeeForm.ShowDialog(this);
        }

        #endregion
    }
}
