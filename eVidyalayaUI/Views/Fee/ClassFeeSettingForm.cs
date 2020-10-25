using School.App.Repository;
using SchoolModels;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class ClassFeeSettingForm : DockContent
    {
        FeeType _feeType;
        ClassType _classType;
        ClassFeeSetting _classFeeSetting;
        Class_Fee_Setting_Model _classFeeSettingModel;
        bool isSearchByFeeType = false; //Drop down value changes when saving data in case of search by fee type.
        public static ClassFeeSettingForm instanceFrm;
        public ClassFeeSettingForm()
        {
            InitializeComponent();
            gridFeeSetting.AutoGenerateColumns = false;
            chkApplicable.Checked = true;
            txtFeeAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtAmountForStaffChild.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            hdnClassFeeID.Text = string.Empty;
            this.KeyPreview = true;
            #region Shortcut Keys Description
            StringBuilder sbShortCutKeys = new StringBuilder();
            sbShortCutKeys.Append("Use following shortcut keys :\n")
                .Append("\t\u2022 Find: Ctrl + F \n")
                .Append("\t\u2022 Clear: Ctrl + D \n")
                .Append("\t\u2022 Save: Ctrl + S \n");
            lblShortCutKeys.Text = sbShortCutKeys.ToString();
            #endregion

            ddlAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            Bind_Academic_Year_Drop_Down();
            ddlAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);
        }
        private void ClassFeeSettingForm_Load(object sender, EventArgs e)
        {
            ////Unbind the ddlClass_SelectedIndexChanged Event of ddlCurrentClass. Changing the default behaviour.
            //ddlClass.SelectedIndexChanged -= new EventHandler(ddlClass_SelectedIndexChanged);
            //BindFeeTypeDropDownList();
            //BindClassTypeDropDownList();
            ////Bind the ddlClass_SelectedIndexChanged Event of ddlCurrentClass. Changing the default behaviour.
            //ddlClass.SelectedIndexChanged += new EventHandler(ddlClass_SelectedIndexChanged);
        }
        private void BindFeeTypeDropDownList()
        {
            _feeType = new FeeType();
            List<FeeTypeModel> _listFeeList = _feeType.GetFeeType();

            /*----Display only those fee type those are map in fee seeting form----------------------------------------------------------*/
            FeeSetting _feeSetting = new FeeSetting();
            List<FeeSettingModel> _listFeeSetting = _feeSetting.GetFeeSetting(Convert.ToInt32(ddlAcademicYear.SelectedValue));
            if (_listFeeList != null && _listFeeSetting != null)
                _listFeeList = _listFeeList.Where(p => _listFeeSetting.Any(p2 => p2.FeeTypeID == p.FeeTypeID)).ToList();
            /*--------------------------------------------------------------------------------------------------------------------------*/

            if (_listFeeList != null)
            {
                _listFeeList.Add(new FeeTypeModel { FeeTypeID = 0, FeeType = "Select" });
                ddlFeeType.DataSource = _listFeeList.OrderBy(x => x.FeeTypeID).ToList();
                ddlFeeType.DisplayMember = "FeeType";
                ddlFeeType.ValueMember = "FeeTypeID";
            }
        }
        private void BindClassTypeDropDownList()
        {
            _classType = new ClassType();
            List<ClassTypeModel> _listClassTypeList = _classType.GetClassDetails();
            if (_listClassTypeList != null)
            {
                _listClassTypeList.Add(new ClassTypeModel { ClassID = null, ClassName = "Select", Active = true });
                _listClassTypeList.Add(new ClassTypeModel { ClassID = 0, ClassName = "All Class", Active = true });
                ddlClass.DataSource = _listClassTypeList.OrderBy(x => x.ClassID).ToList();
                ddlClass.DisplayMember = "ClassName";
                ddlClass.ValueMember = "ClassID";
            }
        }
        private void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridFeeSetting.DataSource = null;
            isSearchByFeeType = false;
            if (ddlClass.SelectedValue != null)
            {
                _classFeeSetting = new ClassFeeSetting();
                short? classValue = Convert.ToInt16(ddlClass.SelectedValue) != 0 ? Convert.ToInt16(ddlClass.SelectedValue) : (short?)null;
                List<ClassFeeSettingViewModel> _listClassFee = _classFeeSetting.GetClassFeeSetting(classValue, null, Convert.ToInt32(ddlAcademicYear.SelectedValue));
                BindGrid(_listClassFee);
                gridFeeSetting.ClearSelection();
                ClearClontrols();
            }
        }
        private void BindGridContols(List<ClassFeeSettingViewModel> listClassFeeSettingmodel)
        {
            try
            {
                int index = 0;
                foreach (ClassFeeSettingViewModel classFeeSettingModel in listClassFeeSettingmodel)
                {
                    DataGridViewLinkCell colEdit = (DataGridViewLinkCell)(gridFeeSetting.Rows[index].Cells["colEdit"]);
                    DataGridViewTextBoxCell colFeeSettingID = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colFeeSettingID"]);
                    DataGridViewTextBoxCell colClassID = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colClassID"]);
                    DataGridViewTextBoxCell colFeeTypeID = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colFeeTypeID"]);
                    DataGridViewTextBoxCell colClass = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colClass"]);
                    DataGridViewTextBoxCell colFeeType = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colFeeType"]);
                    DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colAmount"]);
                    DataGridViewCheckBoxCell colActive = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colActive"]);
                    DataGridViewCheckBoxCell colIsApplicableOnStaffChild = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colIsApplicableOnStaffChild"]);
                    DataGridViewTextBoxCell colAmountForStaffChild = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colAmountForStaffChild"]);

                    colEdit.Value = "Edit";
                    colFeeSettingID.Value = classFeeSettingModel.ClassFeeID;
                    colClassID.Value = classFeeSettingModel.ClassID == null ? 0 : classFeeSettingModel.ClassID;
                    colFeeTypeID.Value = classFeeSettingModel.FeeTypeID;
                    colClass.Value = classFeeSettingModel.ClassName;
                    colFeeType.Value = classFeeSettingModel.FeeType;
                    colAmount.Value = classFeeSettingModel.FeeAmount;
                    colActive.Value = classFeeSettingModel.Active;
                    colIsApplicableOnStaffChild.Value = classFeeSettingModel.IsApplicableOnStaffChild;
                    colAmountForStaffChild.Value = classFeeSettingModel.AmountForStaffChild;
                    index++;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void BindGrid(List<ClassFeeSettingViewModel> listClassFeeSetting)
        {
            if (listClassFeeSetting != null && listClassFeeSetting.Count > 0)
            {
                gridFeeSetting.DataSource = listClassFeeSetting;
                BindGridContols(listClassFeeSetting);
                lblNoRecordFound.Visible = false;
            }
            else
            {
                gridFeeSetting.DataSource = null;
                lblNoRecordFound.Visible = true;
            }
        }
        private void linkSearchByFeeType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isSearchByFeeType = true;
            if (Convert.ToInt16(ddlFeeType.SelectedValue) != 0)
            {
                _classFeeSetting = new ClassFeeSetting();
                short? feeTypeValue = Convert.ToInt16(ddlFeeType.SelectedValue) != 0 ? Convert.ToInt16(ddlFeeType.SelectedValue) : (Int16?)null;
                List<ClassFeeSettingViewModel> _listClassFee = _classFeeSetting.GetClassFeeSetting(null, feeTypeValue, Common.Get_Current_Academic_Year());
                gridFeeSetting.DataSource = null;
                gridFeeSetting.Refresh();
                BindGrid(_listClassFee);
                lblError.Visible = false;
            }
            else
            {
                MessageBox.Show("Please Select Fee Type.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblError.Text = "Please Select Fee Type.";
                //lblError.Visible = true;
            }
        }
        private void ClassFeeSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassFeeSettingForm.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                _classFeeSettingModel = new Class_Fee_Setting_Model();
                _classFeeSettingModel.ClassFeeID = string.IsNullOrWhiteSpace(hdnClassFeeID.Text) ? null : (long?)Convert.ToInt64(hdnClassFeeID.Text);
                _classFeeSettingModel.ClassID = Convert.ToInt16(ddlClass.SelectedValue) != 0 ? Convert.ToInt16(ddlClass.SelectedValue) : (Int16?)null;
                _classFeeSettingModel.FeeTypeID = Convert.ToInt16(ddlFeeType.SelectedValue);
                _classFeeSettingModel.FeeAmount = Convert.ToInt32(txtFeeAmount.Text);
                _classFeeSettingModel.Active = chkApplicable.Checked == true ? true : false;
                _classFeeSettingModel.IsApplicableOnStaffChild = chkIsApplicapleOnStaffChild.Checked == true ? true : false;
                _classFeeSettingModel.AmountForStaffChild = chkIsApplicapleOnStaffChild.Checked == true ? (short?)Convert.ToInt16(txtAmountForStaffChild.Text) : null;
                _classFeeSettingModel.AcademicYear = Convert.ToInt32(ddlAcademicYear.SelectedValue);
                SaveDetails(_classFeeSettingModel);
            }
        }
        private bool ValidateControls()
        {
            bool _isValid = false;
            StringBuilder messageBuilder = new StringBuilder();

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
                messageBuilder.Append("\t\u2022 Please Selct Academic Year.\n");

            if (ddlClass.SelectedValue == null)
                messageBuilder.Append("\t\u2022 Please Selct Class.\n");

            if (Convert.ToInt16(ddlFeeType.SelectedValue) == 0)
                messageBuilder.Append("\t\u2022 Please Select Fee Type\n");

            if (String.IsNullOrWhiteSpace(txtFeeAmount.Text))
                messageBuilder.Append("\t\u2022 Amount Is Required\n");

            if (chkIsApplicapleOnStaffChild.Checked == true && String.IsNullOrWhiteSpace(txtAmountForStaffChild.Text))
            {
                messageBuilder.Append("\t\u2022 Amount For Staff Child Is Required\n");
            }

            if (!string.IsNullOrWhiteSpace(messageBuilder.ToString()))
            {
                MessageBox.Show(messageBuilder.ToString(), "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblError.Visible = true;
                //lblError.Text = messageBuilder.ToString();
                _isValid = false;
            }
            else
            {
                //  lblError.Visible = false;
                _isValid = true;
            }
            return _isValid;
        }
        private void SaveDetails(Class_Fee_Setting_Model classFeeSettingModel)
        {
            try
            {
                _classFeeSetting = new ClassFeeSetting();
                short output = _classFeeSetting.SaveClassFeeSetting(classFeeSettingModel);
                switch (output)
                {
                    case 1:
                        lblError.Visible = false;
                        MessageBox.Show("Record Successfully Saved.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridFeeSetting.Refresh();
                        //bind Grid on Insert And Update.
                        if (isSearchByFeeType == false) //IF Search by Class Type DropDownList
                            ddlClass_SelectedIndexChanged(null, null);
                        if (isSearchByFeeType == true)//IF Search by Fee Type DropDownList
                            linkSearchByFeeType_LinkClicked(null, null);
                        //ClearClontrol();
                        break;
                    case -1:
                        // lblError.Visible = true;
                        //  lblError.Text = "Error! Please contact to admin.";
                        MessageBox.Show("Error! Please contact to support team.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 0:
                        // lblError.Visible = true;
                        // lblError.Text = "Record already Exit.";
                        MessageBox.Show("Record already Exit.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to support team.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearClontrols()
        {
            ddlFeeType.SelectedValue = Convert.ToInt16(0);
            txtFeeAmount.Text = string.Empty;
            chkApplicable.Checked = true;
            lblError.Visible = false;
            hdnClassFeeID.Text = string.Empty;
            chkIsApplicapleOnStaffChild.Checked = false;
            txtAmountForStaffChild.Text = string.Empty;
        }
        private void ClassFeeSettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.F)
            {
                linkSearchByFeeType_LinkClicked(null, null);
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                ClearClontrols();
                ddlClass.SelectedIndex = 0;
                gridFeeSetting.DataSource = null;
                //gridFeeSetting.DataSource = null;
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                btnSave_Click(null, null);
            }
        }
        private void gridFeeSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ddlClass.SelectedIndexChanged -= new EventHandler(ddlClass_SelectedIndexChanged);
            gridFeeSetting.Refresh();
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    hdnClassFeeID.Text = Convert.ToString(gridFeeSetting.Rows[rowIndex].Cells["colFeeSettingID"].Value);
                    ddlClass.SelectedValue = Convert.ToInt16(gridFeeSetting.Rows[rowIndex].Cells["colClassID"].Value);
                    ddlFeeType.SelectedValue = Convert.ToInt16(gridFeeSetting.Rows[rowIndex].Cells["colFeeTypeID"].Value);
                    txtFeeAmount.Text = Convert.ToString(gridFeeSetting.Rows[rowIndex].Cells["colAmount"].Value);
                    chkApplicable.Checked = Convert.ToBoolean(gridFeeSetting.Rows[rowIndex].Cells["colActive"].Value);
                    chkIsApplicapleOnStaffChild.Checked = Convert.ToBoolean(gridFeeSetting.Rows[rowIndex].Cells["colIsApplicableOnStaffChild"].Value);
                    txtAmountForStaffChild.Text = Convert.ToString(gridFeeSetting.Rows[rowIndex].Cells["colAmountForStaffChild"].Value);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    ddlClass.SelectedIndexChanged += new EventHandler(ddlClass_SelectedIndexChanged);
                }
            }
        }
        private void chkIaApplicapleOnStaffChild_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsApplicapleOnStaffChild.Checked == true)
            {
                lblAmountForStaffChild.Enabled = true;
                txtAmountForStaffChild.Enabled = true;
                txtAmountForStaffChild.Focus();
            }
            else
            {
                lblAmountForStaffChild.Enabled = false;
                txtAmountForStaffChild.Enabled = false;
            }
        }
        private void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) != 0)
            {
                groupFee.Enabled = true;
                groupFeeList.Enabled = true;
                gridFeeSetting.DataSource = null;
                lblNoRecordFound.Visible = false;
                lblError.Visible = false;

                //Checking Is Fee Type Is Save For Academic Year Or Not.
                Check_Is_Fee_Setting_Is_Saved();

                //Unbind the ddlClass_SelectedIndexChanged Event of ddlCurrentClass. Changing the default behaviour.
                ddlClass.SelectedIndexChanged -= new EventHandler(ddlClass_SelectedIndexChanged);
                BindFeeTypeDropDownList();
                BindClassTypeDropDownList();
                //Bind the ddlClass_SelectedIndexChanged Event of ddlCurrentClass. Changing the default behaviour.
                ddlClass.SelectedIndexChanged += new EventHandler(ddlClass_SelectedIndexChanged);
            }
            else
            {
                groupFee.Enabled = false;
                groupFeeList.Enabled = false;
            }
        }
        private void Bind_Academic_Year_Drop_Down()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();
            dicSession = Common.Get_Academic_Year_List();
            ddlAcademicYear.DataSource = dicSession.ToList();
            ddlAcademicYear.DisplayMember = "value";
            ddlAcademicYear.ValueMember = "key";
        }
        private void Check_Is_Fee_Setting_Is_Saved()
        {
            string Is_Fee_Setting_Saved;
            string Is_Class_Fee_Setting_Saved;
            string Is_Record_Exists_Out;
            ClassFeeSetting classFeeSetting = new ClassFeeSetting();

            classFeeSetting.Check_Is_Fee_Setting_Is_Saved(
                Convert.ToInt32(ddlAcademicYear.SelectedValue),
                out Is_Fee_Setting_Saved,
                out Is_Class_Fee_Setting_Saved);

            if (Is_Fee_Setting_Saved.ToUpper() == "N")
            {
                MessageBox.Show("Fee Setting For This Academic Year Is Not Found.\nPlease Copy/Add New Fee Setting For This Academic Year.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlAcademicYear.SelectedIndex = 0;

                FeeSettingForm feeSettingForm = new FeeSettingForm();
                feeSettingForm.MaximizeBox = false;
                feeSettingForm.MinimizeBox = false;
                feeSettingForm.StartPosition = FormStartPosition.CenterParent;
                feeSettingForm.ShowDialog(this);

                return;
            }

            if (Is_Class_Fee_Setting_Saved.ToUpper() == "N")
            {
                DialogResult dResult = MessageBox.Show("Class Fee Setting For This Academic Year Is Not Found.\nPlease Add New/Copy Previous Academic Year's Class Fee Setting.\nDo You Want To Copy Previous Academic Year's Data?", "Class Fee Setting", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dResult == DialogResult.Yes)
                {
                    classFeeSetting.Check_Class_Fee_Setting_For_Previous_Academic_Year(
                        Convert.ToInt32(ddlAcademicYear.SelectedValue),
                        out Is_Record_Exists_Out);
                    //IF Record of Previous Year is available then copy.
                    if (Is_Record_Exists_Out.ToUpper() == "Y")
                    {
                        Copy_Class_Fee_Setting();
                    }
                    else
                    {
                        MessageBox.Show("No Record Found For Previous Year.\n Please Add New Record.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Copy_Class_Fee_Setting()
        {
            try
            {
                ClassFeeSetting classFeeSetting = new ClassFeeSetting();
                short result = classFeeSetting.Copy_Class_Fee_Setting(Convert.ToInt32(ddlAcademicYear.SelectedValue));
                if (result == 1)
                {
                    MessageBox.Show("Data has been copied.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (result == -1)
                {
                    MessageBox.Show("Error in copied data.Please contact to support team.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error: Please contact to support team.", "Class Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ddlAcademicYear.SelectedIndex = 0;
            }
        }
    }
}
