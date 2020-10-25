using SchoolModels;
using eVidyalaya.Views.Fee.Reports;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eVidyalaya
{
    public partial class AdmissionFeeForm : Form
    {
        long _studentID;
        long? Sequence_No_Student_Fee_Info;
        BindingSource bindingSource = new BindingSource();
        StringBuilder sbMessage;
        List<CheckBoxMonth> listMonthCkheckBoxList = new List<CheckBoxMonth>();
        private void Academic_Year_List()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();
            dicSession = Common.Get_Academic_Year_List();
            ddlAcademicYear.DataSource = dicSession.ToList();
            ddlAcademicYear.DisplayMember = "value";
            ddlAcademicYear.ValueMember = "key";
        }
        public AdmissionFeeForm(long StudentID, string Registration_Date)
        {
            InitializeComponent();
            _studentID = StudentID;
            ddlAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            gridAdmissionFeeType.AutoGenerateColumns = false;
            Academic_Year_List();
            Get_Admission_Fee_Details_By_Student_ID(_studentID);
            ddlAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            gridAdmissionFeeType.Columns["colTotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridAdmissionFeeType.Columns["colMonthNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridAdmissionFeeType.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            txtMaskedDate.Text = Registration_Date;
        }
        private void BindControls(long studentID, short monthValue, Int32 academicYear, string monthValuesDelimiterSeprated)
        {
            FeeType _feeType = new FeeType();
            AdmissionFee _admissionFee = new AdmissionFee();
            List<AdmissionFeeModel> _listAdmissionFee = _admissionFee.Get_Admission_Fee_List(studentID, monthValue, academicYear, monthValuesDelimiterSeprated);
            ConstructGrid(_listAdmissionFee.OrderBy(o => o.Fee_Type).ToList());
            // ConstructGrid(_listAdmissionFee);
        }
        private void ConstructGrid(List<AdmissionFeeModel> listAdmissionFee)
        {
            if (listAdmissionFee != null)
            {
                int index = 0;
                int totalAmount = 0;
                gridAdmissionFeeType.AutoGenerateColumns = false;
                bindingSource.DataSource = listAdmissionFee;
                gridAdmissionFeeType.DataSource = bindingSource;
                gridAdmissionFeeType.Refresh();
                long? sequenceID = listAdmissionFee.Select(x => x.Sequence_ID).FirstOrDefault();

                //if (sequenceID == null)
                //    gridAdmissionFeeType.Columns["colSelect"].Visible = false;

                foreach (AdmissionFeeModel item in listAdmissionFee)
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
                    colReceiptNo.Value = item.Admission_Receipt_No;
                    colSequenceID.Value = item.Sequence_ID;
                    colAmount.Style.BackColor = System.Drawing.Color.LightYellow;
                    colMonthNo.Style.BackColor = System.Drawing.Color.LightYellow;
                    //if (item.SequenceID == null)
                    //{
                    //}

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
        private void AdmissionFeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    Get_Admission_Fee_Details_By_Student_ID(_studentID);
                }));
            }
            catch (Exception ex)
            {
            }
        }
        private void ValidateGrid(string cellValue)
        {
            if (string.IsNullOrEmpty(cellValue))
            {

            }
            else
            {

            }
        }
        private void gridAdmissionFeeType_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(colFinePaidAmount_KeyPress);
            if (gridAdmissionFeeType.CurrentCell.ColumnIndex == 3 || gridAdmissionFeeType.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;

                if (gridAdmissionFeeType.CurrentCell.ColumnIndex == 3)
                    tb.MaxLength = 5;

                if (gridAdmissionFeeType.CurrentCell.ColumnIndex == 4)
                    tb.MaxLength = 2;

                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(colFinePaidAmount_KeyPress);
                }
            }
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

            //e.FormattedValue.ToString()
            // gridAdmissionFeeType.ClearSelection();
            //gridAdmissionFeeType.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            //gridAdmissionFeeType.CurrentCell = gridAdmissionFeeType["colAmount", e.RowIndex];
            // cellText.Focus();
        }
        private void gridAdmissionFeeType_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // gridAdmissionFeeType.Refresh();
            // colTotalAmount
            if (e.ColumnIndex == gridAdmissionFeeType.Columns["colAmount"].Index || e.ColumnIndex == gridAdmissionFeeType.Columns["colMonthNo"].Index)
            {
                int feeAmount = Convert.ToInt32(gridAdmissionFeeType.Rows[e.RowIndex].Cells["colAmount"].EditedFormattedValue);
                short numberofMonth = Convert.ToInt16(gridAdmissionFeeType.Rows[e.RowIndex].Cells["colMonthNo"].EditedFormattedValue);
                gridAdmissionFeeType.Rows[e.RowIndex].Cells["colTotalAmount"].Value = feeAmount * numberofMonth;

                UpdateTotalAmount();
            }
        }
        private void colFinePaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValidation(e);
        }
        private void UpdateTotalAmount()
        {
            lblTotalFeeAmountValue.Text = string.Empty;
            int checkedTotal = 0;
            List<AdmissionFeeModel> listAdmissionFeeModel = ConvertGridToList();
            checkedTotal = listAdmissionFeeModel.Where(w => w.Is_Selected == true).Select(s => s.Total_Amount).Sum();
            lblTotalFeeAmountValue.Text = Convert.ToString(checkedTotal);
        }
        private bool Validate_Controls()
        {
            sbMessage = new StringBuilder();
            int checkedMonthCount = listMonthCkheckBoxList.Where(x => x.CheckBox.Checked == true).Count();

            if (!txtMaskedDate.MaskFull)
                sbMessage.Append("\u2022 Date is required.\n");

            if (txtMaskedDate.MaskFull)
            {
                if (!Common.ValidateDate(txtMaskedDate.Text))
                    sbMessage.Append("\u2022 Date not in correct format. (DD.MM.YYYY)\n");
            }

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
                sbMessage.Append("\u2022 Academic year is required.\n");

            if (checkedMonthCount == 0)
                sbMessage.Append("\u2022 Please select month to calculate fee.");

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                MessageBox.Show(sbMessage.ToString(), "Admission Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                .Where(w => w.CheckBox.Checked == true)
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

                BindControls(_studentID, (short)monthValue, Convert.ToInt32(ddlAcademicYear.SelectedValue), monthValuesDelimiterSeprated);
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
            //if (DateTime.Today.Year > year)
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
        private void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_Control_On_DropDown_Change();

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) != 0)
            {
                panelMonths.Enabled = true;
                BindMonths(Convert.ToInt32(ddlAcademicYear.SelectedValue));
            }
            else
                panelMonths.Enabled = false;
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
        private List<AdmissionFeeModel> ConvertGridToList()
        {
            List<AdmissionFeeModel> listAdmissionFee = new List<AdmissionFeeModel>();
            try
            {
                foreach (DataGridViewRow rows in gridAdmissionFeeType.Rows)
                {
                    AdmissionFeeModel admissionFeeModel = new AdmissionFeeModel();
                    admissionFeeModel.Fee_Type_ID = Convert.ToInt16(rows.Cells["colFeeTypeID"].Value);
                    admissionFeeModel.Fee_Type = Convert.ToString(rows.Cells["colFeeType"].Value);
                    admissionFeeModel.Fee_Amount = Convert.ToInt32(rows.Cells["colAmount"].Value);
                    admissionFeeModel.Admission_Receipt_No = Convert.ToInt64(rows.Cells["colReceiptNo"].Value);
                    admissionFeeModel.Sequence_ID = Convert.ToInt64(rows.Cells["colSequenceID"].Value);

                    admissionFeeModel.Number_Of_Months = Convert.ToInt16(rows.Cells["colMonthNo"].EditedFormattedValue);
                    admissionFeeModel.Total_Amount = Convert.ToInt32(rows.Cells["colTotalAmount"].EditedFormattedValue);
                    admissionFeeModel.Is_Selected = Convert.ToBoolean(rows.Cells["colSelect"].EditedFormattedValue);

                    listAdmissionFee.Add(admissionFeeModel);
                }
            }
            catch (Exception ex)
            { }
            finally
            { }
            return listAdmissionFee;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate_Controls())
                {
                    List<AdmissionFeeModel> listGridData = ConvertGridToList();
                    //Update Student ID
                    listGridData.Select(x => { x.Student_ID = _studentID; return x; }).ToList();
                    string Admission_Fee_XML = ConvertGridToXML(listGridData);
                    AdmissionFee _admissionFee = new AdmissionFee();

                    short result = _admissionFee.Save_Admission_Fee(_studentID,
                        Sequence_No_Student_Fee_Info,
                        Admission_Fee_XML,
                        (Int32)ddlAcademicYear.SelectedValue,
                        Comma_Seprated_Months_Value(),
                        Common.Convert_String_To_Date(txtMaskedDate.Text));

                    Get_Admission_Fee_Details_By_Student_ID(_studentID);
                    if (result == 1)
                        MessageBox.Show("Record Successfully Saved.", "Admission Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error! Please contact to admin.", "Admission Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "Admission Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ConvertGridToXML(List<AdmissionFeeModel> ListAdmissionFee)
        {
            XElement xmlElements = new XElement("AdmissionFee", ListAdmissionFee.Where(x => x.Is_Selected == true)
            .Select(xmlchild => new XElement("Row",
                new XElement("StudentID", xmlchild.Student_ID),
                new XElement("SequenceID", xmlchild.Sequence_ID == 0 ? string.Empty : Convert.ToString(xmlchild.Sequence_ID)),
                new XElement("AdmissionReceiptNo", xmlchild.Admission_Receipt_No == 0 ? string.Empty : Convert.ToString(xmlchild.Admission_Receipt_No)),
                new XElement("FeeTypeID", xmlchild.Fee_Type_ID),
                new XElement("FeeType", xmlchild.Fee_Type),
                new XElement("FeeAmount", xmlchild.Fee_Amount),
                new XElement("Number_Of_Months", xmlchild.Number_Of_Months),
                new XElement("TotalAmount", xmlchild.Total_Amount))));
            return Convert.ToString(xmlElements);
        }
        private void Reset_Control_On_DropDown_Change()
        {
            #region Reset_CheckBox
            listMonthCkheckBoxList = ConvertPanelCheckBoxesToList();
            listMonthCkheckBoxList.Select(x => { x.CheckBox.Checked = false; return x; }).ToList();
            #endregion
            gridAdmissionFeeType.DataSource = null;
            lblTotalFeeAmount.Visible = false;
            lblTotalFeeAmountValue.Visible = false;
        }
        private void Get_Admission_Fee_Details_By_Student_ID(long Student_ID)
        {
            AdmissionFee _admissionFee = new AdmissionFee();
            Student_Admission_Fee_View_Model _model = _admissionFee.Get_Admission_Fee_Details_By_Student_ID(Student_ID);
            if (_model != null)
            {
                if (_model.List_Admission_Fee != null && _model.List_Admission_Fee.Count > 0)
                {
                    ConstructGrid(_model.List_Admission_Fee);
                }

                if (_model.Student_Fee_Info != null)
                {
                    if (_model.Student_Fee_Info.Academic_Year != null)
                    {
                        txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", _model.Student_Fee_Info.Updated_Date);
                        ddlAcademicYear.SelectedValue = _model.Student_Fee_Info.Academic_Year;
                    }

                    #region CheckBox
                    Sequence_No_Student_Fee_Info = _model.Student_Fee_Info.Sequence_No;
                    if (_model.Student_Fee_Info.April == 1) chkApril.Checked = true; else chkApril.Checked = false;
                    if (_model.Student_Fee_Info.May == 1) chkMay.Checked = true; else chkMay.Checked = false;
                    if (_model.Student_Fee_Info.June == 1) chkJune.Checked = true; else chkJune.Checked = false;
                    if (_model.Student_Fee_Info.July == 1) chkJuly.Checked = true; else chkJuly.Checked = false;
                    if (_model.Student_Fee_Info.August == 1) chkAugust.Checked = true; else chkAugust.Checked = false;
                    if (_model.Student_Fee_Info.September == 1) chkSeptember.Checked = true; else chkSeptember.Checked = false;
                    if (_model.Student_Fee_Info.October == 1) chkOctober.Checked = true; else chkOctober.Checked = false;
                    if (_model.Student_Fee_Info.November == 1) chkNovember.Checked = true; else chkNovember.Checked = false;
                    if (_model.Student_Fee_Info.December == 1) chkDecember.Checked = true; else chkDecember.Checked = false;
                    if (_model.Student_Fee_Info.January == 1) chkJanuary.Checked = true; else chkJanuary.Checked = false;
                    if (_model.Student_Fee_Info.February == 1) chkFebruary.Checked = true; else chkFebruary.Checked = false;
                    if (_model.Student_Fee_Info.March == 1) chkMarch.Checked = true; else chkMarch.Checked = false;
                    if (Sequence_No_Student_Fee_Info != null) btnPrint.Enabled = true; else btnPrint.Enabled = false;

                    panelMonths.Enabled = true;
                    BindMonths(Convert.ToInt32(ddlAcademicYear.SelectedValue));
                    #endregion
                }
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Admission_Report_Viewer_Form addFee = new Admission_Report_Viewer_Form(_studentID);
            addFee.StartPosition = FormStartPosition.CenterParent;
            addFee.ShowDialog(this);
        }
    }
    public class CheckBoxMonth
    {
        public CheckBox CheckBox { get; set; }
        public int Value { get; set; }
    }
}

/*
 * CellValidating
 * https://stackoverflow.com/questions/15918309/set-focus-to-data-grid-view-text-box-column-cell
 * 
 * https://stackoverflow.com/questions/183791/how-would-you-do-a-not-in-query-with-linq
 */
