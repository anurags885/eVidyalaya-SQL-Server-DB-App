using SchoolModels;
using eVidyalaya.Views.Fee.Reports;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya.Views.Fee
{
    public partial class Advance_Fee_Paid_Form : DockContent
    {
        public static Advance_Fee_Paid_Form instanceFrm;
        private RegistrationModel _registrationModel;
        private Int16? _classID;
        private long _studentID;
        StringBuilder sbMessage;
        List<CheckBoxMonth> listMonthCkheckBoxList = new List<CheckBoxMonth>();
        BindingSource bindingSource = new BindingSource();
        FeeGenerate fee_Generate = new FeeGenerate();

        public Advance_Fee_Paid_Form()
        {
            InitializeComponent();
            this.KeyPreview = true;
            AutoScaleMode = AutoScaleMode.Dpi;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";

            ddlAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            gridAdmissionFeeType.AutoGenerateColumns = false;
            Bind_Academic_Year_Drop_Down();
            ddlAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            gridAdmissionFeeType.Columns["colTotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridAdmissionFeeType.Columns["colMonthNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridAdmissionFeeType.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            txtRegistrationNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Clear_Control();
            Search_Student_Details();
            lblReceiptNoLabel.Visible = false;
            lblReceiptNo.Visible = false;
            lblReceiptNo.Text = String.Empty;
        }
        private void Search_Student_Details()
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
                    lblStudentName.Visible = true;
                    lblClass.Visible = true;
                    panelAdvanceFee.Visible = true;
                    _classID = _registrationModel.CurrentClass;
                    _studentID = (long)_registrationModel.StudentID;
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
            panelAdvanceFee.Visible = false;
        }
        private bool Validate_Controls()
        {
            sbMessage = new StringBuilder();
            int checkedMonthCount = listMonthCkheckBoxList.Where(x => x.CheckBox.Checked == true && x.CheckBox.Enabled == true).Count();
            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
                sbMessage.Append("\u2022 Academic year is required.\n");

            if (checkedMonthCount == 0)
                sbMessage.Append("\u2022 Please select month to calculate fee.");

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                MessageBox.Show(sbMessage.ToString(), "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
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
        private void Get_Advance_Pay_Receipt_No()
        {
            gridAdvancePay.AutoGenerateColumns = false;
            BindingSource bindingSourceAP = new BindingSource();
            Advance_Deposit_Fee _advance_Pay = new Advance_Deposit_Fee();
            List<Student_Fee_Info_Receipt_Model> listAdvancePay_Receipt = _advance_Pay.Get_Advance_Pay_Receipt_No(_studentID, Convert.ToInt32(ddlAcademicYear.SelectedValue));
            bindingSourceAP.DataSource = listAdvancePay_Receipt;
            gridAdvancePay.DataSource = bindingSourceAP;

            if (listAdvancePay_Receipt != null)
            {
                int index = 0;

                foreach (Student_Fee_Info_Receipt_Model item in listAdvancePay_Receipt)
                {
                    DataGridViewLinkCell col_AP_Receipt_No = (DataGridViewLinkCell)(gridAdvancePay.Rows[index].Cells["col_AP_Receipt_No"]);
                    DataGridViewTextBoxCell col_AP_Date = (DataGridViewTextBoxCell)(gridAdvancePay.Rows[index].Cells["col_AP_Date"]);
                    DataGridViewLinkCell col_AP_Print = (DataGridViewLinkCell)(gridAdvancePay.Rows[index].Cells["col_AP_Print"]);
                    DataGridViewLinkCell col_AP_Delete = (DataGridViewLinkCell)(gridAdvancePay.Rows[index].Cells["col_AP_Delete"]);
                    DataGridViewTextBoxCell col_Days_Count = (DataGridViewTextBoxCell)(gridAdvancePay.Rows[index].Cells["col_Days_Count"]);

                    col_Days_Count.Value = item.Days_Count;
                    col_AP_Receipt_No.Value = item.Receipt_No;
                    col_AP_Date.Value = item.Updated_Date;
                    col_AP_Print.Value = "Print";
                    if (Convert.ToInt32(col_Days_Count.Value) <= 31)
                        col_AP_Delete.Value = "Delete";
                    index++;
                }
                gridAdvancePay.ClearSelection();
            }
        }
        private void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Control_On_DropDown_Change();
            groupBoxFee.Visible = true;
            lblReceiptNoLabel.Visible = false;
            lblReceiptNo.Visible = false;

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) != 0)
            {
                panelMonths.Enabled = true;
                BindMonths(Convert.ToInt32(ddlAcademicYear.SelectedValue));

                Get_All_Appllicable_Months();

                Check_Is_Fee_Generated_For_Current_Month();

                Get_Advance_Pay_Receipt_No();
            }
            else
                panelMonths.Enabled = false;
        }
        private void BindMonths(Int32 AcademicYear)
        {
            listMonthCkheckBoxList = ConvertPanelCheckBoxesToList();
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
        public List<CheckBoxMonth> ConvertPanelCheckBoxesToList()
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
        private string Comma_Seprated_Months_Value()
        {
            return string.Join(",", listMonthCkheckBoxList
                .Where(w => w.CheckBox.Checked == true && w.CheckBox.Enabled == true)
                .OrderBy(o => o.Value)
                .Select(s => s.Value));
        }
        private void btnCalculateFee_Click(object sender, EventArgs e)
        {
            gridAdmissionFeeType.DataSource = null;
            listMonthCkheckBoxList = ConvertPanelCheckBoxesToList();

            //Validate Controls
            if (Validate_Controls())
            {
                int monthValue = listMonthCkheckBoxList
                    .Where(w => w.CheckBox.Checked == true)
                    .Select(s => s.Value)
                    .Max();

                string monthValuesDelimiterSeprated = Comma_Seprated_Months_Value();
                int academic_Year = Convert.ToInt32(ddlAcademicYear.SelectedValue);

                BindControls(_studentID, monthValuesDelimiterSeprated, academic_Year);
            }
        }
        private void BindControls(long? studentID, string monthValuesDelimiterSeprated, int Academic_Year)
        {
            FeeType _feeType = new FeeType();
            Advance_Deposit_Fee _advancePay = new Advance_Deposit_Fee();
            List<Advance_Pay_Model> _listAdmissionFee = _advancePay.Calculate_Advance_Pay(studentID, monthValuesDelimiterSeprated, Academic_Year);
            ConstructGrid(_listAdmissionFee.OrderBy(o => o.Fee_Type).ToList());
            ConstructGrid(_listAdmissionFee);
        }
        private void ConstructGrid(List<Advance_Pay_Model> list_Advance_Pay)
        {
            if (list_Advance_Pay != null)
            {
                int index = 0;
                int totalAmount = 0;
                gridAdmissionFeeType.AutoGenerateColumns = false;
                bindingSource.DataSource = list_Advance_Pay;
                gridAdmissionFeeType.DataSource = bindingSource;
                gridAdmissionFeeType.Refresh();
                long? sequenceID = list_Advance_Pay.Select(x => x.Sequence_ID).FirstOrDefault();

                foreach (Advance_Pay_Model item in list_Advance_Pay)
                {
                    DataGridViewCheckBoxCell colSelect = (DataGridViewCheckBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colSelect"]);
                    DataGridViewTextBoxCell colFeeTypeID = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colFeeTypeID"]);
                    DataGridViewTextBoxCell colFeeType = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colFeeType"]);
                    DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colAmount"]);
                    DataGridViewTextBoxCell colMonthNo = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colMonthNo"]);
                    DataGridViewTextBoxCell colTotalAmount = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colTotalAmount"]);
                    DataGridViewTextBoxCell colReceiptNo = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colReceiptNo"]);
                    DataGridViewTextBoxCell colSequenceID = (DataGridViewTextBoxCell)(gridAdmissionFeeType.Rows[index].Cells["colSequenceID"]);

                    colSelect.Value = true;
                    colFeeTypeID.Value = item.Fee_Type_ID;
                    colFeeType.Value = Convert.ToString(item.Fee_Type);
                    colAmount.Value = item.Fee_Amount;
                    colMonthNo.Value = item.Number_Of_Months;
                    colTotalAmount.Value = item.Total_Amount;
                    colReceiptNo.Value = item.Advance_Pay_Receipt_No;
                    colSequenceID.Value = item.Sequence_ID;
                    colAmount.Style.BackColor = System.Drawing.Color.LightYellow;
                    colMonthNo.Style.BackColor = System.Drawing.Color.LightYellow;

                    if (item.Fee_Amount == 0)
                        colAmount.Style.BackColor = System.Drawing.Color.Yellow;

                    totalAmount = totalAmount + item.Total_Amount;

                    index++;
                }
                gridAdmissionFeeType.ClearSelection();
                lblTotalFeeAmount.Visible = true;
                lblTotalFeeAmountValue.Visible = true;
                lblTotalFeeAmountValue.Text = Convert.ToString(totalAmount);
            }
            else
            {
                lblTotalFeeAmount.Visible = false;
                lblTotalFeeAmountValue.Visible = false;
            }
        }
        private void Reset_Control_On_DropDown_Change()
        {
            #region Reset_CheckBox
            listMonthCkheckBoxList = ConvertPanelCheckBoxesToList();
            listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();
            listMonthCkheckBoxList.Select(x => { x.CheckBox.Enabled = true; return x; }).ToList();
            #endregion
            gridAdmissionFeeType.DataSource = null;
            lblTotalFeeAmount.Visible = false;
            lblTotalFeeAmountValue.Visible = false;
        }
        private List<Advance_Pay_Model> ConvertGridToList()
        {
            List<Advance_Pay_Model> listAdmissionFee = new List<Advance_Pay_Model>();
            try
            {
                foreach (DataGridViewRow rows in gridAdmissionFeeType.Rows)
                {
                    Advance_Pay_Model advance_Pay = new Advance_Pay_Model();
                    advance_Pay.Fee_Type_ID = Convert.ToInt16(rows.Cells["colFeeTypeID"].Value);
                    advance_Pay.Fee_Type = Convert.ToString(rows.Cells["colFeeType"].Value);
                    advance_Pay.Fee_Amount = Convert.ToInt32(rows.Cells["colAmount"].Value);
                    advance_Pay.Advance_Pay_Receipt_No = Convert.ToInt64(rows.Cells["colReceiptNo"].Value);
                    advance_Pay.Sequence_ID = Convert.ToInt64(rows.Cells["colSequenceID"].Value);

                    advance_Pay.Number_Of_Months = Convert.ToInt16(rows.Cells["colMonthNo"].EditedFormattedValue);
                    advance_Pay.Total_Amount = Convert.ToInt32(rows.Cells["colTotalAmount"].EditedFormattedValue);
                    advance_Pay.Is_Selected = Convert.ToBoolean(rows.Cells["colSelect"].EditedFormattedValue);

                    listAdmissionFee.Add(advance_Pay);
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
            return listAdmissionFee;
        }
        private string ConvertGridToXML(List<Advance_Pay_Model> ListAdmissionFee)
        {
            XElement xmlElements = new XElement("AdvancePay", ListAdmissionFee.Where(x => x.Is_Selected == true)
            .Select(xmlchild => new XElement("Row",
                new XElement("StudentID", xmlchild.Student_ID),
                new XElement("SequenceID", xmlchild.Sequence_ID == 0 ? string.Empty : Convert.ToString(xmlchild.Sequence_ID)),
                new XElement("Advance_Pay_Receipt_No", xmlchild.Advance_Pay_Receipt_No == 0 ? string.Empty : Convert.ToString(xmlchild.Advance_Pay_Receipt_No)),
                new XElement("FeeTypeID", xmlchild.Fee_Type_ID),
                new XElement("FeeType", xmlchild.Fee_Type),
                new XElement("FeeAmount", xmlchild.Fee_Amount),
                new XElement("Number_Of_Months", xmlchild.Number_Of_Months),
                new XElement("TotalAmount", xmlchild.Total_Amount))));
            return Convert.ToString(xmlElements);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                #region Check Validation For Calculate Fee
                if (gridAdvancePay.Rows.Count >= 1 && lblReceiptNo.Visible == false)
                {
                    MessageBox.Show("Please Click On Receipt No Link To Modify.", "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int checkedMonthCount = listMonthCkheckBoxList.Where(x => x.CheckBox.Checked == true && x.CheckBox.Enabled == true).Count();
                if (checkedMonthCount >= 1)
                {
                    if (gridAdmissionFeeType.Rows.Count == 0)
                    {
                        MessageBox.Show("\u2022 Please click on calculate button to calculate advance fee.\n", "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                #endregion

                if (Validate_Controls())
                {
                    long? _receipt_No = null;
                    if (lblReceiptNo.Visible == true && !string.IsNullOrEmpty(lblReceiptNo.Text))
                    {
                        _receipt_No = Convert.ToInt64(lblReceiptNo.Text);
                    }

                    List<Advance_Pay_Model> listGridData = ConvertGridToList();

                    //Update Student ID
                    listGridData.Select(x => { x.Student_ID = _studentID; return x; }).ToList();
                    string Addvance_Fee_XML = ConvertGridToXML(listGridData);
                    Advance_Deposit_Fee _advance_Pay = new Advance_Deposit_Fee();

                    short result = _advance_Pay.Save_Advance_Pay_Fee(_studentID, _receipt_No, Addvance_Fee_XML,
                        (Int32)ddlAcademicYear.SelectedValue,
                        Comma_Seprated_Months_Value(),
                        Common.Convert_String_To_Date(dtpDate.Text));

                    if (result == 1)
                        MessageBox.Show("Record Successfully Saved.", "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error! Please contact to admin.", "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "Advance Pay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Get_All_Appllicable_Months();
                Get_Advance_Pay_Receipt_No();
            }
        }
        private void Advance_Fee_Paid_Form_Load(object sender, EventArgs e)
        {
        }
        private void Get_All_Appllicable_Months()
        {
            Advance_Deposit_Fee _advance_Pay = new Advance_Deposit_Fee();
            List<Student_Fee_Info_Months_Model> listCheckedMonths =
                _advance_Pay.Get_Student_Fee_Setting_Months(_studentID, Convert.ToInt32(ddlAcademicYear.SelectedValue));

            if (listCheckedMonths != null)
            {
                foreach (Student_Fee_Info_Months_Model item in listCheckedMonths)
                {
                    listMonthCkheckBoxList.Where(x => x.Value == item.MonthValue)
                  .Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
                }
            }
        }
        private void Advance_Fee_Paid_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Advance_Fee_Paid_Form.instanceFrm = null;
        }
        private void gridAdmissionFeeType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    UpdateTotalAmount();
                }
                catch (Exception ex)
                { }
                finally
                { }
            }
        }
        private void UpdateTotalAmount()
        {
            lblTotalFeeAmountValue.Text = string.Empty;
            int checkedTotal = 0;
            List<Advance_Pay_Model> listAdmissionFeeModel = ConvertGridToList();
            checkedTotal = listAdmissionFeeModel.Where(w => w.Is_Selected == true).Select(s => s.Total_Amount).Sum();
            lblTotalFeeAmountValue.Text = Convert.ToString(checkedTotal);
        }
        private void gridAdmissionFeeType_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridAdmissionFeeType.EndEdit();
            if (e.ColumnIndex == gridAdmissionFeeType.Columns["colAmount"].Index || e.ColumnIndex == gridAdmissionFeeType.Columns["colMonthNo"].Index)
            {
                gridAdmissionFeeType.BeginEdit(true);
                gridAdmissionFeeType.ClearSelection();

                if (gridAdmissionFeeType.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
                    ((TextBox)gridAdmissionFeeType.EditingControl).SelectionStart = ((TextBox)gridAdmissionFeeType.EditingControl).TextLength;
            }
        }
        private void gridAdmissionFeeType_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridAdmissionFeeType.Columns["colAmount"].Index || e.ColumnIndex == gridAdmissionFeeType.Columns["colMonthNo"].Index)
            {
                int feeAmount = Convert.ToInt32(gridAdmissionFeeType.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
                short numberofMonth = Convert.ToInt16(gridAdmissionFeeType.Rows[e.RowIndex].Cells["colMonthNo"].EditedFormattedValue);
                gridAdmissionFeeType.Rows[e.RowIndex].Cells["colTotalAmount"].Value = feeAmount * numberofMonth;

                UpdateTotalAmount();
            }
        }
        private void gridAdmissionFeeType_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == gridAdmissionFeeType.Columns["colAmount"].Index || e.ColumnIndex == gridAdmissionFeeType.Columns["colMonthNo"].Index)
            {
                TextBox cellText = ((TextBox)gridAdmissionFeeType.EditingControl);

                if (cellText != null)
                {
                    string cellValue = cellText.Text;

                    if (e.ColumnIndex == 3)
                    {
                        if (string.IsNullOrEmpty(cellValue))
                        {
                            MessageBox.Show("Amount is required.");
                            e.Cancel = true;
                        }
                    }

                    if (e.ColumnIndex == 4)
                    {
                        if (string.IsNullOrEmpty(cellValue))
                        {
                            MessageBox.Show("Month is required.");
                            e.Cancel = true;
                        }
                        else if (Convert.ToInt32(cellValue) > 12 || Convert.ToInt32(cellValue) < 1)
                        {
                            MessageBox.Show("Month should be between 1 to 12.");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        private void gridAdvancePay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            try
            {
                if (e.ColumnIndex == 0)
                {
                    long receipt_No = Convert.ToInt64(gridAdvancePay.Rows[rowIndex].Cells["col_AP_Receipt_No"].Value);
                    Student_Advance_Fee_View_Model model = Get_Advance_Pay_Details_By_Receipt_No(receipt_No);
                    if (model != null)
                    {
                        ConstructGrid(model.List_Advance_Pay);
                        Advance_Pay_Receipt_Months(model.List_Student_Fee_Info_Months);
                        lblReceiptNoLabel.Visible = true;
                        lblReceiptNo.Visible = true;
                        lblReceiptNo.Text = Convert.ToString(gridAdvancePay.Rows[rowIndex].Cells["col_AP_Receipt_No"].Value);
                        dtpDate.Value = Convert.ToDateTime(gridAdvancePay.Rows[rowIndex].Cells["col_AP_Date"].Value);
                    }
                }
                if (e.ColumnIndex == 2)
                {
                    long receipt_No = Convert.ToInt64(gridAdvancePay.Rows[rowIndex].Cells["col_AP_Receipt_No"].Value);
                    Advance_Pay_Report_Viewer_Form report = new Advance_Pay_Report_Viewer_Form(_studentID, receipt_No);
                    report.StartPosition = FormStartPosition.CenterParent;
                    report.ShowDialog(this);
                }

                if (e.ColumnIndex == 3)
                {
                    long receipt_No = Convert.ToInt64(gridAdvancePay.Rows[rowIndex].Cells["col_AP_Receipt_No"].Value);
                    Delete_Records(receipt_No);
                }

                gridAdvancePay.ClearSelection();
            }
            catch (Exception ex)
            { }
            finally
            { }
        }
        private Student_Advance_Fee_View_Model Get_Advance_Pay_Details_By_Receipt_No(long Receipt_No)
        {
            Advance_Deposit_Fee advance_Deposit_Fee = new Advance_Deposit_Fee();
            Student_Advance_Fee_View_Model model = advance_Deposit_Fee.Get_Advance_Pay_Details_By_Receipt_No(Receipt_No);
            return model;
        }
        private void Advance_Pay_Receipt_Months(List<Student_Fee_Info_Months_Model> list_Student_Fee_Info_Months_Model)
        {
            foreach (Student_Fee_Info_Months_Model item in list_Student_Fee_Info_Months_Model)
            {
                switch (item.MonthValue)
                {
                    case 4:
                        chkApril.Checked = true;
                        chkApril.Enabled = true;
                        break;
                    case 5:
                        chkMay.Checked = true;
                        chkMay.Enabled = true;
                        break;
                    case 6:
                        chkJune.Checked = true;
                        chkJune.Enabled = true;
                        break;
                    case 7:
                        chkJuly.Checked = true;
                        chkJuly.Enabled = true;
                        break;
                    case 8:
                        chkAugust.Checked = true;
                        chkAugust.Enabled = true;
                        break;
                    case 9:
                        chkSeptember.Checked = true;
                        chkSeptember.Enabled = true;
                        break;
                    case 10:
                        chkOctober.Checked = true;
                        chkOctober.Enabled = true;
                        break;
                    case 11:
                        chkNovember.Checked = true;
                        chkNovember.Enabled = true;
                        break;
                    case 12:
                        chkDecember.Checked = true;
                        chkDecember.Enabled = true;
                        break;
                    case 13:
                        chkJanuary.Checked = true;
                        chkJanuary.Enabled = true;
                        break;
                    case 14:
                        chkFebruary.Checked = true;
                        chkFebruary.Enabled = true;
                        break;
                    case 15:
                        chkMarch.Checked = true;
                        chkMarch.Enabled = true;
                        break;
                }
            }
        }
        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetControls();
            Clear_Control();
            txtRegistrationNo.Text = String.Empty;
        }
        private void Clear_Control()
        {
            lblReceiptNoLabel.Visible = false;
            lblReceiptNo.Visible = false;
            lblReceiptNo.Text = String.Empty;
            gridAdmissionFeeType.DataSource = null;
            gridAdvancePay.DataSource = null;
            panelAdvanceFee.Visible = false;
            //txtRegistrationNo.Text = String.Empty;
            ddlAcademicYear.SelectedIndex = 0;
            txtRegistrationNo.Focus();
            lblStudentName.Visible = false;
            lblStudentNameValue.Visible = false;
            lblClass.Visible = false;
            lblClassValue.Visible = false;
            lblStudentNameValue.Text = String.Empty;
            lblClassValue.Text = String.Empty;
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
            groupBoxFee.Visible = false;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";
        }
        private void Advance_Fee_Paid_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.N)
            {
                Clear_Control();
                txtRegistrationNo.Text = String.Empty;
            }
        }
        private void Delete_Records(long receipt_No)
        {
            try
            {
                Advance_Deposit_Fee advance_Deposit_Fee = new Advance_Deposit_Fee();
                short output = advance_Deposit_Fee.Delete_Advance_Pay(receipt_No);
                if (output == 1)
                {
                    MessageBox.Show("Record Deleted.", "Advance Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "Advance Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtRegistrationNo.Text = String.Empty;
                Reset_Control_On_DropDown_Change();
                Clear_Control();
            }
        }
        private void Check_Is_Fee_Generated_For_Current_Month()
        {
            #region Check Fee Already Generated Or Not

            string month_Of_Fee_Generated = fee_Generate.Get_Fee_Generated_Current_Month(Convert.ToInt32(ddlAcademicYear.SelectedValue));

            if (!string.IsNullOrEmpty(month_Of_Fee_Generated))
            {
                listMonthCkheckBoxList.Where(x => x.Value <= Convert.ToInt16(month_Of_Fee_Generated))
                    .Select(x => { x.CheckBox.Enabled = false; return x; }).ToList();
            }
            #endregion
        }
    }
}
