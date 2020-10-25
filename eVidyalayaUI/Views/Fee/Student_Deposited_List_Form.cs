using SchoolModels.Fee;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace eVidyalaya
{
    public partial class Student_Deposited_List_Form : Form
    {
        long _registration_No;
        public Student_Deposited_List_Form(long Registration_No)
        {
            InitializeComponent();
            _registration_No = Registration_No;
            gridDepositedFee.AutoGenerateColumns = false;
        }
        private void Bind_Previous_Dues_Grid(long Registration_No)
        {
            try
            {
                FeeDeposit feeDeposit = new FeeDeposit();
                List<MonthlyFeeDepositModel> listDepositedDues = new List<MonthlyFeeDepositModel>();
                listDepositedDues = feeDeposit.Get_Student_Deposited_List(Registration_No);
                int index = 0;
                if (listDepositedDues != null)
                {
                    gridDepositedFee.DataSource = listDepositedDues;
                    foreach (MonthlyFeeDepositModel feeDues in listDepositedDues)
                    {
                        DataGridViewLinkCell colBillNo = (DataGridViewLinkCell)(gridDepositedFee.Rows[index].Cells["colGridDuesBillNo"]);
                        DataGridViewTextBoxCell colDuesAmount = (DataGridViewTextBoxCell)(gridDepositedFee.Rows[index].Cells["colGridDuesDuesAmount"]);
                        DataGridViewTextBoxCell colFeeDate = (DataGridViewTextBoxCell)(gridDepositedFee.Rows[index].Cells["colGridDuesFeeDate"]);
                        colBillNo.Value = feeDues.FeeReceiptNo;
                        colDuesAmount.Value = feeDues.AmountDeposit;
                        colFeeDate.Value = String.Format("{0:dd-MMM-yyyy}", feeDues.FeeDepositDate);
                        index++;
                    }
                }
                else
                {
                    gridDepositedFee.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridDepositedFee.Refresh();
                gridDepositedFee.ClearSelection();
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
        private void gridPreviousDues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridDepositedFee.ClearSelection();
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    long receiptNo = Convert.ToInt64(gridDepositedFee.Rows[rowIndex].Cells["colGridDuesBillNo"].Value);
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

