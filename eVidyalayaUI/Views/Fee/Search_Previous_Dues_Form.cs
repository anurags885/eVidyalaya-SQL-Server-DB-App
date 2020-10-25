using SchoolModels.Fee;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace eVidyalaya
{
    public partial class Search_Previous_Dues_Form : Form
    {
        long _studentID;
        public Search_Previous_Dues_Form(long Registration_No)
        {
            InitializeComponent();
            _studentID = Registration_No;
            gridPreviousDues.AutoGenerateColumns = false;
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
                    gridPreviousDues.DataSource = listPreviousDues;
                    foreach (MonthlyFeeGenerateModel feeDues in listPreviousDues)
                    {
                        DataGridViewLinkCell colBillNo = (DataGridViewLinkCell)(gridPreviousDues.Rows[index].Cells["colGridDuesBillNo"]);
                        DataGridViewTextBoxCell colDuesAmount = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["colGridDuesDuesAmount"]);
                        DataGridViewTextBoxCell colFeeDate = (DataGridViewTextBoxCell)(gridPreviousDues.Rows[index].Cells["colGridDuesFeeDate"]);
                        colBillNo.Value = feeDues.FeeReceiptNo;
                        colDuesAmount.Value = feeDues.PreviousDues;
                        colFeeDate.Value = String.Format("{0:dd-MMM-yyyy}", feeDues.FeeDate);
                        index++;
                    }
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
                    Bind_Previous_Dues_Grid(_studentID);
                }));
            }
            catch (Exception ex)
            {
            }
        }
        private void gridPreviousDues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridPreviousDues.ClearSelection();
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    long receiptNo = Convert.ToInt64(gridPreviousDues.Rows[rowIndex].Cells["colGridDuesBillNo"].Value);
                    if (FeeDepositForm.instanceFrm != null)
                    {
                        Control textBillNo = FeeDepositForm.instanceFrm.Controls.Find("txtBillNo", true).FirstOrDefault();
                        textBillNo.Text = Convert.ToString(receiptNo);
                        FeeDepositForm.instanceFrm.GetFeeDetailsByReceiptNo(receiptNo);
                        FeeDepositForm.instanceFrm.Set_Control_Visibility(true);
                        this.Close();
                    }
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
    }
}

