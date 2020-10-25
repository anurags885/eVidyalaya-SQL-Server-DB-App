using SchoolModels.Fee;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eVidyalaya
{
    public partial class Deposit_Fee_Multiple_Receipt : Form
    {
        long _registration_No;
        int _totalDues = 0;
        long _bill_No = 0;
        public Deposit_Fee_Multiple_Receipt(long Registration_No)
        {
            InitializeComponent();
            _registration_No = Registration_No;
            gridPreviousDues.AutoGenerateColumns = false;
            txtDepositAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";
        }
        private void Bind_Previous_Dues_Grid(long Registration_No)
        {
            try
            {
                FeeDeposit feeDeposit = new FeeDeposit();
                List<MonthlyFeeGenerateModel> listPreviousDues = new List<MonthlyFeeGenerateModel>();
                listPreviousDues = feeDeposit.Get_Student_Previous_Dues_List(Registration_No);
                int index = 0;
                if (listPreviousDues != null)
                {
                    //listPreviousDues = listPreviousDues.OrderBy(x => x.FeeReceiptNo).ToList();
                    gridPreviousDues.DataSource = listPreviousDues;
                    foreach (MonthlyFeeGenerateModel feeDues in listPreviousDues)
                    {
                        DataGridViewTextBoxCell colBillNo = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["colGridDuesBillNo"]);
                        DataGridViewTextBoxCell colDuesAmount = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["colGridDuesDuesAmount"]);
                        DataGridViewTextBoxCell colFeeDate = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["colGridDuesFeeDate"]);
                        DataGridViewTextBoxCell col_Student_ID = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["col_Student_ID"]);

                        colBillNo.Value = feeDues.FeeReceiptNo;
                        colDuesAmount.Value = feeDues.PreviousDues;
                        colFeeDate.Value = String.Format("{0:dd-MMM-yyyy}", feeDues.FeeDate);
                        col_Student_ID.Value = feeDues.StudentID;
                        index++;
                    }
                    _totalDues = (int)listPreviousDues.Sum(x => x.PreviousDues);
                    lblTotalDues.Text = String.Empty;
                    lblTotalDues.Text = "Total Dues : " + Convert.ToString(_totalDues);
                }
                else
                {
                    gridPreviousDues.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridPreviousDues.Refresh();
                gridPreviousDues.ClearSelection();
            }
        }
        private void Search_Previous_Dues_Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    Bind_Previous_Dues_Grid(_registration_No);
                }));
            }
            catch (Exception ex)
            {
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (Amount_Validation())
            {
                int deposited_Amount = Convert.ToInt32(txtDepositAmount.Text);
                int dues_Amount = 0;

                foreach (DataGridViewRow rows in gridPreviousDues.Rows)
                {
                    rows.Cells["col_Paid_Amount"].Value = string.Empty;
                    rows.Cells["col_Dues"].Value = string.Empty;
                    dues_Amount = Convert.ToInt32(rows.Cells["colGridDuesDuesAmount"].Value);

                    if (deposited_Amount > 0)
                    {
                        if (deposited_Amount > dues_Amount)
                        {
                            rows.Cells["col_Paid_Amount"].Value = dues_Amount;
                            deposited_Amount = deposited_Amount - dues_Amount;
                        }
                        else
                        {
                            rows.Cells["col_Paid_Amount"].Value = deposited_Amount;
                            deposited_Amount = deposited_Amount - dues_Amount;
                        }

                        rows.Cells["col_Dues"].Value = dues_Amount - Convert.ToInt32(rows.Cells["col_Paid_Amount"].Value);
                        _bill_No = Convert.ToInt64(rows.Cells["colGridDuesBillNo"].Value);
                    }
                }
            }
        }
        private bool Amount_Validation()
        {
            bool returnValue = true;

            if (String.IsNullOrWhiteSpace(txtDepositAmount.Text))
            {
                Set_Error_Message("Amount is Required.");
                returnValue = false;
            }

            if (!String.IsNullOrEmpty(txtDepositAmount.Text))
            {
                if (Convert.ToInt32(txtDepositAmount.Text) <= 0)
                {
                    Set_Error_Message("Amount Should Be Greater Than Zero.");
                    returnValue = false;
                }

                if (Convert.ToInt32(txtDepositAmount.Text) > _totalDues)
                {
                    Set_Error_Message("Amount Should Be Greater Than Total Dues.");
                    returnValue = false;
                }
            }

            if (returnValue == false)
            {
                txtDepositAmount.Focus();
                return false;
            }
            return returnValue;
        }
        private void Deposit_Fee_Multiple_Receipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FeeDepositForm.instanceFrm != null && _bill_No > 0)
            {
                Control textBillNo = FeeDepositForm.instanceFrm.Controls.Find("txtBillNo", true).FirstOrDefault();
                textBillNo.Text = Convert.ToString(_bill_No);
                FeeDepositForm.instanceFrm.GetFeeDetailsByReceiptNo(_bill_No);
                FeeDepositForm.instanceFrm.Set_Control_Visibility(true);
            }
        }
        private void Set_Error_Message(string message)
        {
            MessageBox.Show(message, "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int deposited_Amount = 0;
            foreach (DataGridViewRow rows in gridPreviousDues.Rows)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(rows.Cells["col_Paid_Amount"].Value)))
                {
                    deposited_Amount += Convert.ToInt32(rows.Cells["col_Paid_Amount"].Value);
                }
            }

            if (deposited_Amount == 0)
            {
                Set_Error_Message("There is no data to save.");
                return;
            }

            if (deposited_Amount > 0)
            {
                string Fee_Details_xml = Grid_To_Xml_Data();
                Save_Fee_Details(Fee_Details_xml);
            }
        }
        private string Grid_To_Xml_Data()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Fee_Receipt>");
            foreach (DataGridViewRow rows in gridPreviousDues.Rows)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(rows.Cells["col_Paid_Amount"].Value)))
                {
                    sb.Append("<Row>")
                   .Append("<Receipt_No>").Append(Convert.ToInt64(rows.Cells["colGridDuesBillNo"].Value)).Append("</Receipt_No>")
                   .Append("<Paid_Amount>").Append(Convert.ToInt32(rows.Cells["col_Paid_Amount"].Value)).Append("</Paid_Amount>")
                   .Append("<Dues_Amount>").Append(Convert.ToInt32(rows.Cells["col_Dues"].Value)).Append("</Dues_Amount>")
                   .Append("<Student_ID>").Append(Convert.ToInt64(rows.Cells["col_Student_ID"].Value)).Append("</Student_ID>")
                   .Append("<Paid_Date>").Append(String.Format("{0:dd-MMM-yyyy}", dtpDate.Value)).Append("</Paid_Date>")
                   .Append("</Row>");
                }
            }
            sb.Append("</Fee_Receipt>");
            return Convert.ToString(sb);
        }
        private void Save_Fee_Details(string Fee_Details_xml)
        {
            FeeDeposit feeDeposit = new FeeDeposit();
            try
            {
                short result = feeDeposit.Multiple_Receipt_Fee_Paid(Fee_Details_xml);
                if (result == 1)
                {
                    Set_Error_Message("Records has been saved.");
                    Bind_Previous_Dues_Grid(_registration_No);

                    txtDepositAmount.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Set_Error_Message("Error! Please Contact To Support Team.");
            }
        }
    }
}

