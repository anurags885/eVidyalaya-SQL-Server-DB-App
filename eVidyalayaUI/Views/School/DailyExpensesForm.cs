using School.App.Repository;
using SchoolModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class DailyExpensesForm : DockContent
    {
        SchoolExpenses _schoolExpenses;
        ExpensesModel model;
        public static DailyExpensesForm instanceFrm;
        string outMessage = string.Empty;
        public DailyExpensesForm()
        {
            InitializeComponent();
            hdnExpensesID.Text = null;
            txtQuantity.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtBillNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtParticulars.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };
            txtShopName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidationWithSymbol(e); };

            var font = new Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            gridExpenses.ColumnHeadersDefaultCellStyle.Font = font;
            gridExpenses.DefaultCellStyle.Font = font;
            gridExpenses.AutoGenerateColumns = false;

            //dtpDate.Format = DateTimePickerFormat.Custom;
            //dtpDate.Value = DateTime.Now;
            //dtpDate.CustomFormat = "dd/MM/yyyy";
            txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", DateTime.Now.ToString("dd.MM.yyyy"));
        }
        private void DailyExpensesForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dicPaymentMode = new Dictionary<string, string>();
            dicPaymentMode.Add("0", "Select");
            dicPaymentMode.Add("1", "Cash");
            dicPaymentMode.Add("2", "Check");
            dicPaymentMode.Add("3", "Net Banking");
            ddlPaymentMode.DataSource = dicPaymentMode.ToList();
            ddlPaymentMode.ValueMember = "Key";
            ddlPaymentMode.DisplayMember = "Value";
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    BindExpensesGrid();
                }));
            }
            catch { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveExpenses();
        }
        private bool ValidateControls()
        {
            StringBuilder messageBuilder = new StringBuilder();
            bool isValid = true;

            if (!isValidDate(out outMessage))
                isValid = false;

            //if (string.IsNullOrEmpty(txtBillNo.Text))
            //{
            //    messageBuilder.Append("\u2022 Bill Number is required.\n");
            //    isValid = false;
            //}

            if (string.IsNullOrEmpty(txtShopName.Text))
            {
                messageBuilder.Append("\u2022 Shop/Person name is required.\n");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtParticulars.Text))
            {
                messageBuilder.Append("\u2022 Particulars is required.\n");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                messageBuilder.Append("\u2022 Quantity is required.\n");
                isValid = false;
            }

            if (!string.IsNullOrEmpty(txtQuantity.Text))
            {
                if (txtQuantity.Text == "0")
                {
                    messageBuilder.Append("\u2022 Quantity should be greater than zero.\n");
                    isValid = false;
                }
            }

            if (Convert.ToInt16(ddlPaymentMode.SelectedValue) == 0)
            {
                messageBuilder.Append("\u2022 Payment type is required.\n");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                messageBuilder.Append("\u2022 Amount is required.\n");
                isValid = false;
            }

            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                if (txtAmount.Text == "0")
                {
                    messageBuilder.Append("\u2022 Amount should be greater than zero.\n");
                    isValid = false;
                }
            }

            if (!isValid)
            {
                MessageBox.Show(outMessage + messageBuilder.ToString(), "Daily Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isValid;
        }
        private void SaveExpenses()
        {
            try
            {
                if (ValidateControls())
                {
                    model = new ExpensesModel();
                    model.AutoExpensesID = string.IsNullOrEmpty(hdnExpensesID.Text) ? null : (long?)Convert.ToInt64(hdnExpensesID.Text);
                    model.ExpensesBillNo = string.IsNullOrEmpty(txtBillNo.Text) ? null : txtBillNo.Text;
                    model.Particulars = txtParticulars.Text;
                    model.PaymentMode = Convert.ToString(ddlPaymentMode.Text);
                    model.ShopName = txtShopName.Text;
                    model.Quantity = Convert.ToInt32(txtQuantity.Text);
                    model.Amount = Convert.ToInt32(txtAmount.Text);
                    model.PurchasesDate = Common.Convert_String_To_Date(txtMaskedDate.Text);
                    //DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _schoolExpenses = new SchoolExpenses();
                    int result = _schoolExpenses.SaveExpenses(model);
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Record Successfully Saved.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                            //case -1:
                            //    MessageBox.Show("Error in saving records.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    break;
                    }
                    BindExpensesGrid();
                    ClearControls();

                    /*=================================================================*/
                    //Show Hide Delete Control, Based on Date.
                    if (gridExpenses.Rows.Count == 0)
                        gridExpenses.Columns["ColDelete"].Visible = true;
                    else
                        Grid_ShowDeleteContol();
                    /*=================================================================*/
                }
            }
            catch
            {
                MessageBox.Show("Error in saving records.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BindExpensesGrid()
        {
            _schoolExpenses = new SchoolExpenses();
            List<ExpensesModel> expenseslist = new List<ExpensesModel>();
            expenseslist = _schoolExpenses.GetExpensesList(Common.Convert_String_To_Date(txtMaskedDate.Text));
            gridExpenses.DataSource = expenseslist;

            if (expenseslist != null)
            {
                int index = 0;
                foreach (ExpensesModel model in expenseslist)
                {
                    DataGridViewTextBoxCell colSLNo = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColSLNo"]);
                    DataGridViewTextBoxCell colBillNo = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColBillNo"]);
                    DataGridViewTextBoxCell colShopName = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColShopName"]);
                    DataGridViewTextBoxCell colParticulars = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColParticulars"]);
                    DataGridViewTextBoxCell colPaymentMode = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColPaymentMode"]);
                    DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColAmount"]);
                    DataGridViewTextBoxCell colExpensesID = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColExpensesID"]);
                    DataGridViewTextBoxCell colQuantity = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColQuantity"]);
                    DataGridViewTextBoxCell colDate = (DataGridViewTextBoxCell)(gridExpenses.Rows[index].Cells["ColDate"]);
                    DataGridViewLinkCell colEdit = (DataGridViewLinkCell)(gridExpenses.Rows[index].Cells["ColEdit"]);
                    DataGridViewLinkCell colDelete = (DataGridViewLinkCell)(gridExpenses.Rows[index].Cells["ColDelete"]);

                    colSLNo.Value = index + 1;
                    colBillNo.Value = model.ExpensesBillNo;
                    colShopName.Value = model.ShopName;
                    colParticulars.Value = model.Particulars;
                    colPaymentMode.Value = model.PaymentMode;
                    colAmount.Value = model.Amount;
                    colExpensesID.Value = model.AutoExpensesID;
                    colQuantity.Value = model.Quantity;
                    colDate.Value = model.PurchasesDate;
                    colEdit.Value = "Edit";
                    colDelete.Value = "Delete";
                    index++;
                }
                gridExpenses.Refresh();
                gridExpenses.ClearSelection();
            }
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (!isValidDate(out outMessage))
                MessageBox.Show(outMessage, "Daily Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DateTime reportDate = Common.Convert_String_To_Date(txtMaskedDate.Text);
                if (ExpensesReportForm.instanceFrm == null)
                {
                    ExpensesReportForm.instanceFrm = new ExpensesReportForm(reportDate);
                    ExpensesReportForm.instanceFrm.Show(UIParent.MDIForm.dockPanel);
                }
                else
                    ExpensesReportForm.instanceFrm.Focus();
            }
        }
        private void gridExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            try
            {
                if (e.ColumnIndex == 8)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete record?", "Expenses", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        long ExpensesID = Convert.ToInt64(gridExpenses.Rows[rowIndex].Cells["ColExpensesID"].Value);
                        _schoolExpenses = new SchoolExpenses();
                        DeleteRecord(ExpensesID);
                    }
                }
                if (e.ColumnIndex == 7)
                {
                    hdnExpensesID.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColExpensesID"].Value);
                    txtBillNo.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColBillNo"].Value);
                    txtShopName.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColShopName"].Value);
                    txtParticulars.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColParticulars"].Value);
                    ddlPaymentMode.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColPaymentMode"].Value);
                    txtQuantity.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["colQuantity"].Value);
                    txtAmount.Text = Convert.ToString(gridExpenses.Rows[rowIndex].Cells["ColAmount"].Value);
                    txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(gridExpenses.Rows[rowIndex].Cells["ColDate"].Value));

                    // Convert.ToDateTime(gridExpenses.Rows[rowIndex].Cells["ColDate"].Value);
                    //  string dateAndTime =Convert.ToDateTime(gridExpenses.Rows[rowIndex].Cells["ColDate"].Value).ToString("dd/MM/yyyy");
                    //DateTime.ParseExact("", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    // dtpDate.CustomFormat = "dd/MM/yyyy";
                }
                gridExpenses.ClearSelection();
            }
            catch { }
        }
        private void ClearControls()
        {
            hdnExpensesID.Text = null;
            txtBillNo.Text = String.Empty;
            txtShopName.Text = String.Empty;
            txtParticulars.Text = String.Empty;
            ddlPaymentMode.SelectedValue = "0";
            txtQuantity.Text = String.Empty;
            txtAmount.Text = String.Empty;
            //txtMaskedDate.Text = String.Format("{0:dd.MM.yyyy}", DateTime.Now.ToString("dd.MM.yyyy"));
            txtMaskedDate.Focus();
        }
        private void DeleteRecord(long ExpensesID)
        {
            try
            {
                int delResult = _schoolExpenses.DeleteExpenses(ExpensesID);

                switch (delResult)
                {
                    case 1:
                        MessageBox.Show("Record deleted successfully.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error in deleting records.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                ClearControls();
                BindExpensesGrid();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!isValidDate(out outMessage))
                MessageBox.Show(outMessage, "Daily Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                SearchRecords();
        }
        private void SearchRecords()
        {
            BindExpensesGrid();
            if (gridExpenses.Rows.Count == 0)
            {
                MessageBox.Show("No record found.\nPlease select another date.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
            }
            else
                Grid_ShowDeleteContol();
        }
        private void Grid_ShowDeleteContol()
        {
            DateTime previousDate = Convert.ToDateTime(gridExpenses.Rows[0].Cells["ColDate"].Value);
            previousDate = previousDate.Date;
            DateTime todayDate = DateTime.Today.Date;

            if (previousDate < todayDate)
                gridExpenses.Columns["ColDelete"].Visible = false;
            else
                gridExpenses.Columns["ColDelete"].Visible = true;
        }
        private bool isValidDate(out string message)
        {
            StringBuilder messageBuilder = new StringBuilder();
            bool isValid = true;
            if (!txtMaskedDate.MaskFull)
            {
                messageBuilder.Append("\u2022 Date enter valid date.\n");
                isValid = false;
            }

            if (txtMaskedDate.MaskFull)
            {
                if (!Common.ValidateDate(txtMaskedDate.Text))
                {
                    messageBuilder.Append("\u2022 Date is not in correct format. (DD.MM.YYYY)\n");
                    isValid = false;
                }
            }
            message = messageBuilder.ToString();
            return isValid;
        }
        private void DailyExpensesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DailyExpensesForm.instanceFrm = null;
        }
    }
}

