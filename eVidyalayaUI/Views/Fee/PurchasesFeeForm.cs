using SchoolModels;
using School.App.Repository;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using System;
using School.App.Repository;
using System.Text;
using School.App.Repository.FeeViewModels;
using System.Xml.Linq;

namespace eVidyalaya
{
    public partial class FeePurchasesItem : DockContent
    {
        BindingSource bindingSource = new BindingSource();
        public static FeePurchasesItem instanceFrm;
        private RegistrationModel _registrationModel;
        private FeeDeposit _feeDeposit;
        private FeeType _feeType;
        private Int16? classID;
        private long? studentID;
        public FeePurchasesItem()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            txtRegistrationNo.Select();
            this.ActiveControl = txtRegistrationNo;

            txtRegistrationNo.Leave -= new EventHandler(txtRegistrationNo_Leave);
            txtRegistrationNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };

            gridFeeType.AutoGenerateColumns = false;
            gridPurchasesItem.AutoGenerateColumns = false;

            dateReport.Format = DateTimePickerFormat.Custom;
            dateReport.Value = DateTime.Now;
            dateReport.CustomFormat = "dd.MM.yyyy";

            dtpPurchasesDate.Format = DateTimePickerFormat.Custom;
            dtpPurchasesDate.Value = DateTime.Now;
            dtpPurchasesDate.CustomFormat = "dd.MM.yyyy";
            GetFeeType();
            txtRegistrationNo.Leave += new EventHandler(txtRegistrationNo_Leave);
        }
        public void GetFeeType()
        {
            _feeType = new FeeType();
            List<FeeTypeModel> _listFeeType = _feeType.GetLostableFeeType();
            if (_listFeeType != null && _listFeeType.Count > 0)
            {
                _listFeeType.Add(new FeeTypeModel { FeeTypeID = 0, FeeType = "Select" });
                ddlFeeType.DataSource = _listFeeType.OrderBy(x => x.FeeTypeID).ThenBy(x => x.FixedName).ToList();

                ddlFeeType.ValueMember = "FeeTypeID";
                ddlFeeType.DisplayMember = "FeeType";
            }
            else
            {
                _listFeeType = new List<FeeTypeModel>();
                _listFeeType.Add(new FeeTypeModel { FeeTypeID = 0, FeeType = "Select" });
            }
        }
        private void FeeForLostableFeeTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeePurchasesItem.instanceFrm = null;
        }
        private void SearchRegistrationDetails()
        {
            if (string.IsNullOrEmpty(txtRegistrationNo.Text))
            {
                MessageBox.Show("Registration Number is required.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControls();
            }
            else
            {
                StudentRegistration registration = new StudentRegistration();
                _registrationModel = new RegistrationModel();
                _registrationModel = registration.Get_Student_Detail(Convert.ToInt64(txtRegistrationNo.Text));
                if (_registrationModel.RegistrationNo != null)
                {
                    lblStudentNameValue.Text = _registrationModel.FullName;
                    lblClassValue.Text = _registrationModel.ClassSection;
                    lblStudentNameValue.Visible = true;
                    lblClassValue.Visible = true;
                    classID = _registrationModel.CurrentClass;
                    studentID = _registrationModel.StudentID;
                }
                else
                {
                    MessageBox.Show("Invalid Registration Number.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetControls();
                }
            }
        }
        private void ResetControls()
        {
            txtRegistrationNo.Text = string.Empty;
            txtRegistrationNo.Focus();
            lblStudentNameValue.Visible = false;
            lblClassValue.Visible = false;
        }
        private void FeePurchasesItem_Load(object sender, EventArgs e)
        {
            BindPurchasesListGrid();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ISDuplicateItemInDB())
            {
                MessageBox.Show("This entry already exists in DB.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsDuplicateItem(Convert.ToInt16(ddlFeeType.SelectedValue)) != 0)
                return;

            List<Class_Fee_Setting_Model> listPurchasesItem = new List<Class_Fee_Setting_Model>();
            if (ValidateControl())
            {
                Int16 feeType = Convert.ToInt16(ddlFeeType.SelectedValue);
                listPurchasesItem.Add(new Class_Fee_Setting_Model
                {
                    FeeTypeID = Convert.ToInt16(ddlFeeType.SelectedValue),
                    FeeType = Convert.ToString(ddlFeeType.Text),
                    FeeAmount = GetFeeAmount(classID, Convert.ToInt16(ddlFeeType.SelectedValue))
                });
                BindFeeTypeGrid(listPurchasesItem);
            }
        }
        public bool ValidateControl()
        {
            bool isValid = false;
            StringBuilder messageBuilder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(txtRegistrationNo.Text))
                messageBuilder.Append("\u2022 Registration number is required.\n");
            if (Convert.ToInt16(ddlFeeType.SelectedValue) == 0)
                messageBuilder.Append("\u2022 Fee Type is required.\n");

            if (!string.IsNullOrEmpty(messageBuilder.ToString()))
            {
                isValid = false;
                MessageBox.Show(messageBuilder.ToString(), "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                isValid = true;
            return isValid;

            //GetPurchasableFeeTypeAmount()
        }
        private int? GetFeeAmount(short? classID, short feeType)
        {
            ClassFeeSetting classFeeSetting = new ClassFeeSetting();
            List<ClassFeeSettingViewModel> listClassFee = classFeeSetting.GetPurchasableFeeTypeAmount(classID, feeType);
            if (listClassFee != null)
                return listClassFee.Select(x => x.FeeAmount).SingleOrDefault();
            else
                return 0;
        }
        private void BindFeeTypeGrid(List<Class_Fee_Setting_Model> listClassFee)
        {
            if (listClassFee != null)
            {
                int index = 0;
                btnSave.Enabled = true;

                if (gridFeeType.Rows.Count > 0)
                {
                    bindingSource = (BindingSource)gridFeeType.DataSource;
                    listClassFee.AddRange((List<Class_Fee_Setting_Model>)bindingSource.DataSource);
                }

                bindingSource.DataSource = listClassFee;
                gridFeeType.DataSource = bindingSource;

                foreach (Class_Fee_Setting_Model item in listClassFee)
                {
                    DataGridViewTextBoxCell colFeeTypeID = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colFeeTypeID"]);
                    DataGridViewTextBoxCell colFeeType = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colFeeType"]);
                    DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colAmount"]);
                    DataGridViewLinkCell colDelete = (DataGridViewLinkCell)(gridFeeType.Rows[index].Cells["colDelete"]);
                    colFeeTypeID.Value = item.FeeTypeID;
                    colFeeType.Value = item.FeeType;
                    colDelete.Value = "Delete";
                    colAmount.Value = item.FeeAmount == null ? 0 : item.FeeAmount;

                    if (item.FeeAmount == 0)
                    {
                        colAmount.Style.BackColor = System.Drawing.Color.Yellow;
                        colAmount.Style.ForeColor = System.Drawing.Color.Red;
                    }
                    index++;
                }
            }
        }
        private int IsDuplicateItem(short feeType)
        {
            int duplicatesRecords = 0;
            if (gridFeeType.Rows.Count > 0)
            {
                bindingSource = (BindingSource)gridFeeType.DataSource;
                List<Class_Fee_Setting_Model> listItems = (List<Class_Fee_Setting_Model>)bindingSource.DataSource;
                //Checking for duplicate records
                duplicatesRecords = listItems.Where(x => x.FeeTypeID == feeType).Count();

                if (duplicatesRecords > 0)
                    MessageBox.Show("This fee type already added.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return duplicatesRecords;
        }
        private bool ISDuplicateItemInDB()
        {
            _feeDeposit = new FeeDeposit();
            return _feeDeposit.CheckDuplicatePurchasesFee(
                 studentID,
                Convert.ToInt16(ddlFeeType.SelectedValue),
                Common.Convert_String_To_Date(dtpPurchasesDate.Text)
                );
        }
        private void gridFeeType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 3)
            {
                try
                {
                    short? feeTypeID = Convert.ToInt16(gridFeeType.Rows[rowIndex].Cells["colFeeTypeID"].Value);
                    gridFeeType.Rows.RemoveAt(rowIndex);
                    //List<ClassFeeSettingModel> listItems = (List<ClassFeeSettingModel>)gridFeeType.DataSource;
                    // listItems.RemoveAll(x => x.FeeTypeID == feeTypeID);
                    // gridFeeType.DataSource = null;
                    // BindFeeTypeGrid(listItems);
                    gridFeeType.ClearSelection();
                }
                catch
                { }
                finally
                { }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateControl())
                {
                    return;
                }
                if (gridFeeType.Rows.Count > 0)
                {
                    _feeDeposit = new FeeDeposit();
                    short result = _feeDeposit.SavePurchasesFee(ConvertGridToXML());
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Record successfully saved. ", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtRegistrationNo.Text = string.Empty;
                            ddlFeeType.SelectedIndex = 0;
                            gridFeeType.DataSource = null;
                            lblStudentNameValue.Text = string.Empty;
                            lblClassValue.Text = string.Empty;
                            break;
                        case -1:
                            MessageBox.Show("Error in saving records.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                    MessageBox.Show("There is no record in below table. Please add items.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                BindPurchasesListGrid();
            }
        }
        private void BindPurchasesListGrid()
        {
            int index = 0;
            _feeDeposit = new FeeDeposit();
            List<PurchasesFeeModel> listPurchasesFee = _feeDeposit.GetPurchasesFeeList(Common.Convert_String_To_Date(dateReport.Text));
            if (listPurchasesFee != null)
            {
                gridPurchasesItem.DataSource = listPurchasesFee;
                foreach (PurchasesFeeModel item in listPurchasesFee)
                {
                    DataGridViewTextBoxCell colRegistrationNo = (DataGridViewTextBoxCell)(gridPurchasesItem.Rows[index].Cells["colRegistrationNo"]);
                    DataGridViewTextBoxCell colReceiptNo = (DataGridViewTextBoxCell)(gridPurchasesItem.Rows[index].Cells["colReceiptNo"]);
                    DataGridViewLinkCell colPrint = (DataGridViewLinkCell)(gridPurchasesItem.Rows[index].Cells["colPrint"]);
                    colRegistrationNo.Value = item.RegistrationNo;
                    colReceiptNo.Value = item.ReceiptNo;
                    colPrint.Value = "Print";
                    index++;
                }
                gridPurchasesItem.ClearSelection();
            }
            else
                gridPurchasesItem.DataSource = null;
        }
        private string ConvertGridToXML()
        {
            bindingSource = (BindingSource)gridFeeType.DataSource;
            List<Class_Fee_Setting_Model> gridList = (List<Class_Fee_Setting_Model>)bindingSource.DataSource;
            XElement xmlElements = new XElement("PurchasesItems", gridList.Where(x => x.FeeAmount != 0)
            .Select(xmlchild =>
            new XElement("Row",
            new XElement("StudentID", studentID),
            new XElement("RegistrationNo", txtRegistrationNo.Text),
            new XElement("PurchasesDate", Common.Convert_String_To_Date(dtpPurchasesDate.Text)),
            new XElement("Amount", xmlchild.FeeAmount),
            new XElement("FeeTypeID", xmlchild.FeeTypeID))));
            return Convert.ToString(xmlElements);
        }
        private void linkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BindPurchasesListGrid();
            if (gridPurchasesItem.Rows.Count == 0)
                MessageBox.Show("No Record Found.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gridPurchasesItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 2)
            {
                try
                {
                    long registrationNo = Convert.ToInt64(gridPurchasesItem.Rows[rowIndex].Cells["colRegistrationNo"].Value);
                    long receiptNo = Convert.ToInt64(gridPurchasesItem.Rows[rowIndex].Cells["colReceiptNo"].Value);

                    //if (PurchasesFeeReportForm.instanceFrm == null)
                    //{
                    PurchasesFeeReportForm.instanceFrm = new PurchasesFeeReportForm(receiptNo, registrationNo);
                    PurchasesFeeReportForm.instanceFrm.Show(UIParent.MDIForm.dockPanel);
                    //}
                    //else
                    //    PurchasesFeeReportForm.instanceFrm.Focus();

                    gridPurchasesItem.ClearSelection();
                }
                catch
                { }
                finally
                { }
            }
        }
        private void txtRegistrationNo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegistrationNo.Text))
                SearchRegistrationDetails();
        }
    }
}