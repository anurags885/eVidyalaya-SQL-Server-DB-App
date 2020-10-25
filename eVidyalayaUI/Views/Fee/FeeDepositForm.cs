using SchoolModels;
using SchoolModels.Fee;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class FeeDepositForm : DockContent
    {
        public static FeeDepositForm instanceFrm;
        FeeDepositViewModel feeDepositViewModel;
        FeeDeposit feeDeposit;
        MonthlyFeeDepositModel monthlyFeeDepositModel;
        DateTimePicker dtp_Change_Date = new DateTimePicker();
        int index = 0;
        int grid_Amount_Paid_Current_Index = 0;
        //Only Basic Amount And Transport Amount. Without Fine and ReAdmission 
        int? basicFeeAmount = 0;
        DateTime fee_generated_date;

        const int days_Count = 31;
        public FeeDepositForm()
        {
            InitializeComponent();

            //txtBillNo.ContextMenu = null;
            // txtBillNo.ShortcutsEnabled = false;
            // txtRegistrationSearch.ShortcutsEnabled = false;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";

            dtp_Change_Date.Format = DateTimePickerFormat.Custom;
            dtp_Change_Date.Value = DateTime.Now;
            dtp_Change_Date.CustomFormat = "dd-MMM-yyyy";
            dtp_Change_Date.Visible = false;
            dtp_Change_Date.Width = 90;
            // dtpDate.Font = new Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            dtp_Change_Date.ValueChanged += new EventHandler(dtp_Chage_Date_ValueChange);
            gridAmountPaid.Controls.Add(dtp_Change_Date);

            txtBillNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtDepositAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            txtRegistrationSearch.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };

            //On_Enter_Bill_No
            txtBillNo.KeyPress += delegate (object sender, KeyPressEventArgs e) { btn_Bill_No_Enter(e); };

            //  txtDate.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.DateKeyPressValidation(e); };

            var font = new Font("Segoe UI Semibold", 8.2F, System.Drawing.FontStyle.Bold);

            gridDeposited.Columns[0].HeaderCell.Style.Font = font;
            gridDeposited.Columns[1].HeaderCell.Style.Font = font;
            gridDeposited.Columns[2].HeaderCell.Style.Font = font;

            gridDeposited.DefaultCellStyle.Font = font;
            gridFine.DefaultCellStyle.Font = font;
            gridFeeType.DefaultCellStyle.Font = font;
            gridPreviousDues.DefaultCellStyle.Font = font;
            gridAmountPaid.DefaultCellStyle.Font = font;
            gridFinePaid.DefaultCellStyle.Font = font;

            gridFine.AutoGenerateColumns = false;
            gridFeeType.AutoGenerateColumns = false;
            gridFeeType.Columns["colGridApplicableFeeType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridFeeType.Columns["colGridApplicableAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridFeeType.Columns["colMonths"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridDeposited.Columns["colAmount_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridDeposited.Columns["colDate_Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            /*To Do: Grid header Alignment*/
            // gridFeeType.Columns["colTotalAmount"].HeaderCell.Al

            gridPreviousDues.AutoGenerateColumns = false;
            gridAmountPaid.AutoGenerateColumns = false;
            gridDeposited.AutoGenerateColumns = false;
            gridFinePaid.AutoGenerateColumns = false;

            Set_Control_Visibility(false);

            this.gridAmountPaid.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAmountPaid_CellEnter);
        }
        public void btn_Bill_No_Enter(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if (ascii == 13)
            {
                btnSearch_Click(null, null);
                txtDepositAmount.Focus();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                txtRegistrationSearch.Text = string.Empty;
                Set_Control_Visibility(false);
                // lblError.Visible = false;
                if (!string.IsNullOrWhiteSpace(txtBillNo.Text))
                {
                    GetFeeDetailsByReceiptNo(Convert.ToInt64(txtBillNo.Text));
                }
                else
                {
                    Set_Control_Visibility(false);
                    // lblError.Visible = true;
                    SetErrorMessage("Invalid Bill No. Please Enter Valid Bill No.");
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage("Error! Please Contact To Admin.");
            }
        }
        public void GetFeeDetailsByReceiptNo(long? receiptNo)
        {
            feeDeposit = new FeeDeposit();
            feeDepositViewModel = new FeeDepositViewModel();
            feeDepositViewModel = feeDeposit.GetFeeDetailsByReceiptNo(receiptNo);
            if (feeDepositViewModel.FeeDepositModel.FeeReceiptNo == null)
            {
                Set_Control_Visibility(false);
                // lblError.Visible = true;
                // lblError.Text = "Invalid Bill No. Please Enter Correct Bill No.";
                SetErrorMessage("Invalid Bill No. Please Enter Correct Bill No.");
            }
            else
            {
                Set_Control_Visibility(true);
                ResetGridControls();
                BindControl(feeDepositViewModel);
            }
        }
        private void BindControl(FeeDepositViewModel feeDepositViewModel)
        {
            txtBillNo.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.FeeReceiptNo);
            lblBillNoValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.FeeReceiptNo);

            lblFeeDateValue.Text = String.Format("{0:dd-MMMM-yyyy}", feeDepositViewModel.FeeDepositModel.FeeDate);
            fee_generated_date = feeDepositViewModel.FeeDepositModel.FeeDate;

            lblHdnFeeDate.Text = String.Format("{0:dd-MM-yyyy}", feeDepositViewModel.FeeDepositModel.FeeDate);
            lblRegistrationValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.RegistrationNo);
            lblNameValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.FullName);
            lblClassValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.ClassName);
            lbBillTotalValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.Total_Fee_Amount);
            // lblReAdmissionValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.ReAdmission);
            lblPreviousDuesValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.Total_Dues);
            // lblTransportAmountValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.TransportAmount);
            //groupBillTransaction.Text = string.Empty;
            groupBillTransaction.Text = "AMOUNT PAID ON BILL NO : " + lblBillNoValue.Text;
            lblAmountPaid.Text = "Amount Paid On Bill No " + lblBillNoValue.Text + " :";
            lblDuesLeftOnBill.Text = "Dues On Bill No " + lblBillNoValue.Text + " :";
            lblDuesLeftOnBillValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.Amount_Dues_On_Bill);
            lblAmountPaidOnBillValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.Amount_Paid_On_Bill);
            lblTotalFineValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.TotalFine);
            lblFinePaidValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.TotalFinePaid);
            lblFineOFFValue.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.TotalFineOff);
            lblHdnStudentID.Text = Convert.ToString(feeDepositViewModel.FeeDepositModel.StudentID);

            /*====================================================================================================================*/
            //Only Basic Amount And Transport Amount. Without Fine and ReAdmission 
            //  basicFeeAmount = feeDepositViewModel.FeeDepositModel.FeeAmount + feeDepositViewModel.FeeDepositModel.TransportAmount;

            /*====================================================================================================================*/
            // txtDepositAmount.Text= Convert.ToString(feeDepositViewModel.FeeDepositModel.DuesOnReceiptNo);
            BindFeeCategoryGrid(feeDepositViewModel.ListFeeApplicable, Convert.ToBoolean(feeDepositViewModel.FeeDepositModel.IsStaffChild));
            Bind_Previous_Dues_Grid(feeDepositViewModel.ListFeeDues);
            BindAmountPaidGrid(feeDepositViewModel.ListMonthlyTransaction);
            Bind_Diposited_List(feeDepositViewModel.List_Fee_Deposited);

            gridPreviousDues.ClearSelection();
            gridAmountPaid.ClearSelection();
            gridDeposited.ClearSelection();
            gridFinePaid.ClearSelection();
            /*=====================================================================================================================*/
            //This Grid Should Be First Before Grid Fine Order=1 Beacuse We are adding Re-Admission Chargers at Fine Grid
            BindGridFinePaid(feeDepositViewModel.ListStudentFinePaid);
            //This Grid Should Be After The Grid Paid Fine Order=2 Beacuse We are adding Re-Admission Chargers at Fine Grid
            BindFineGrid(feeDepositViewModel.ListStudentFine);
            /*=====================================================================================================================*/

            //Disable Save Button When Dues on Bill Is ZERO
            if (feeDepositViewModel.FeeDepositModel.Amount_Dues_On_Bill == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            /*=====================================================================================================================*/

            //Amount After Fine And ReAdmission
            if (gridFine.Rows.Count > 0)
            {
                lblAmountAfterFineValue.Visible = true;
                lblAmountAfterFine.Visible = true;
                lblAmountAfterFineValue.Text = Convert.ToString(basicFeeAmount);
            }
            else
            {
                lblAmountAfterFineValue.Visible = false;
                lblAmountAfterFine.Visible = false;
            }
        }
        private void BindFeeCategoryGrid(List<Class_Fee_Setting_Model> listFeeApplicable, bool isStaffChild)
        {
            try
            {
                index = 0;
                if (listFeeApplicable != null)
                {
                    gridFeeType.DataSource = listFeeApplicable;
                    foreach (Class_Fee_Setting_Model feeApplicable in listFeeApplicable)
                    {
                        DataGridViewTextBoxCell colFeeType = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colGridApplicableFeeType"]);
                        DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colGridApplicableAmount"]);
                        DataGridViewTextBoxCell colMonths = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colMonths"]);
                        // DataGridViewTextBoxCell colTotalAmount = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colTotalAmount"]);

                        //if (feeApplicable.Calculation_Symbol == "+")
                        //{
                        //    gridFeeType.Columns["colGridApplicableAmount"].Visible = false;
                        //    gridFeeType.Columns["colNumberOfMonths"].Visible = false;
                        //}
                        //else
                        //{
                        //    gridFeeType.Columns["colGridApplicableAmount"].Visible = true;
                        //    gridFeeType.Columns["colNumberOfMonths"].Visible = true;
                        //}
                        colMonths.Value = feeApplicable.Month_Name;
                        colAmount.Value = feeApplicable.FeeAmount;
                        //   colNumberOfMonths.Value = feeApplicable.Calculation_Symbol + " " + Convert.ToString(feeApplicable.NUMBER_OF_MONTH);

                        colFeeType.Value = feeApplicable.FeeType;
                        //  colTotalAmount.Value = isStaffChild == false ? feeApplicable.TOTAL_FEE_AMOUNT_NORMAL_STUDENT : feeApplicable.TOTAL_FEE_AMOUNT_STAFF_CHILD;
                        index++;
                    }
                }
                else
                {
                    gridFeeType.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridFeeType.Refresh();
                gridFeeType.ClearSelection();
            }
        }
        private void Bind_Previous_Dues_Grid(List<MonthlyFeeGenerateModel> listPreviousDues)
        {
            try
            {
                index = 0;
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
                    //int? totalDues = listPreviousDues.Where(x => x.FeeReceiptNo == Convert.ToInt64(lblBillNoValue.Text))
                    //    .Select(x => x.PreviousDues).SingleOrDefault();

                    //totalDues = totalDues == null ? 0 : totalDues + Convert.ToInt16(lblReAdmissionValue.Text);

                    //lblDuesLeftOnBillValue.Text = Convert.ToString(totalDues);
                    linkPaidFee.Visible = true;
                }
                else
                {
                    gridPreviousDues.DataSource = null;
                    linkPaidFee.Visible = false;
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
        private void BindAmountPaidGrid(List<MonthlyFeeDepositModel> listFeeTransaction)
        {
            try
            {
                index = 0;
                if (listFeeTransaction != null)
                {
                    gridAmountPaid.DataSource = listFeeTransaction;
                    foreach (MonthlyFeeDepositModel amountPaid in listFeeTransaction)
                    {
                        DataGridViewTextBoxCell colPaidAmount = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["colPaidAmount"]);
                        DataGridViewTextBoxCell colPaidDate = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["colPaidDate"]);
                        DataGridViewLinkCell colPrint = (DataGridViewLinkCell)(gridAmountPaid.Rows[index].Cells["colPrint"]);
                        DataGridViewLinkCell colSave = (DataGridViewLinkCell)(gridAmountPaid.Rows[index].Cells["colSave"]);
                        DataGridViewLinkCell colDelete = (DataGridViewLinkCell)(gridAmountPaid.Rows[index].Cells["colDelete"]);
                        DataGridViewTextBoxCell colFeeTransactionID = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["colFeeTransactionID"]);
                        DataGridViewTextBoxCell colFeeReceiptNo = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["colFeeReceiptNo"]);
                        DataGridViewTextBoxCell colPaidDateHidden = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["colPaidDateHidden"]);
                        DataGridViewTextBoxCell col_Days_Count = (DataGridViewTextBoxCell)(gridAmountPaid.Rows[index].Cells["col_Days_Count"]);

                        //Used for compair Date
                        colPaidDateHidden.Value = String.Format("{0:dd-MMM-yyyy}", amountPaid.FeeDepositDate);
                        colPaidDate.Value = String.Format("{0:dd-MMM-yyyy}", amountPaid.FeeDepositDate);

                        col_Days_Count.Value = amountPaid.Days_Count;
                        colPaidAmount.Value = amountPaid.AmountDeposit;
                        colPrint.Value = "Print";
                        colSave.Value = string.Empty;

                        if (Convert.ToInt32(col_Days_Count.Value) <= days_Count)
                            colDelete.Value = "Delete";
                        else
                            colDelete.Value = string.Empty;

                        colFeeTransactionID.Value = amountPaid.FeeTransactionID;
                        colFeeReceiptNo.Value = amountPaid.FeeReceiptNo;
                        index++;
                    }

                    this.gridAmountPaid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAmountPaid_CellEnter);
                    //  this.gridAmountPaid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAmountPaid_CellContentClick);

                    /*==Calculate Bill Dues Amount===========================================================================*/
                    //int? totalDues = listFeeTransaction.Select(x => x.AmountDeposit).Sum();

                    //totalDues = totalDues == null ? 0 : totalDues + Convert.ToInt16(lblReAdmissionValue.Text);

                    //totalDues = Convert.ToInt16(lblMonthlyFeeValue.Text) - totalDues;

                    //lblDuesLeftValue.Text = Convert.ToString(totalDues);
                    /*========================================================================================================*/
                }
                else
                {
                    gridAmountPaid.DataSource = null;
                    // lblDuesLeftValue.Text = "0";
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridAmountPaid.Refresh();
                gridAmountPaid.ClearSelection();
            }
        }
        private void BindGridFinePaid(List<StudentFineModel> listStudentFinePaid)
        {
            try
            {
                index = 0;
                if (listStudentFinePaid != null)
                {
                    groupFinePaid.Visible = true;
                    groupFinePaid.Location = new System.Drawing.Point(12, 247);
                    gridFinePaid.DataSource = listStudentFinePaid;

                    foreach (StudentFineModel finePaid in listStudentFinePaid)
                    {
                        DataGridViewTextBoxCell colFineBillNo = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFineBillNoFinePaid"]);
                        DataGridViewTextBoxCell colFineType = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFineTypeFinePaid"]);
                        DataGridViewTextBoxCell colFineAmount = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFineAmountFinePaid"]);
                        DataGridViewTextBoxCell colFineDate = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFineDateFinePaid"]);
                        DataGridViewTextBoxCell colFineTransactionID = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFineTransactionIDFinePaid"]);
                        DataGridViewCheckBoxCell colIsPaidFinePaid = (DataGridViewCheckBoxCell)(gridFinePaid.Rows[index].Cells["colIsPaidFinePaid"]);
                        DataGridViewTextBoxCell colFinePaidAmountFinePaid = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colFinePaidAmountFinePaid"]);
                        DataGridViewCheckBoxCell colIsOffFinePaid = (DataGridViewCheckBoxCell)(gridFinePaid.Rows[index].Cells["colIsOffFinePaid"]);
                        DataGridViewTextBoxCell colStudentIDFinePaid = (DataGridViewTextBoxCell)(gridFinePaid.Rows[index].Cells["colStudentIDFinePaid"]);

                        colFineBillNo.Value = finePaid.ReceiptNo;
                        colFineType.Value = finePaid.FineType;
                        colFineAmount.Value = finePaid.FineAmount;
                        colFineDate.Value = String.Format("{0:dd-MMM-yyyy}", finePaid.FineDate);
                        colFineTransactionID.Value = finePaid.FineTransactionID;
                        colIsPaidFinePaid.Value = finePaid.IsPaid;
                        colFinePaidAmountFinePaid.Value = finePaid.DepositAmount;
                        colIsOffFinePaid.Value = finePaid.IsOFF;
                        colStudentIDFinePaid.Value = finePaid.StudentID;
                        index++;
                    }
                }
                else
                {
                    groupFinePaid.Visible = false;
                    gridFinePaid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridFinePaid.Refresh();
                gridFinePaid.ClearSelection();
            }
        }
        private void BindFineGrid(List<StudentFineModel> listStudentFine)
        {
            try
            {
                #region Add Re-Admission In Fine Grid
                //if (Convert.ToInt32(lblReAdmissionValue.Text) != 0 && gridFinePaid.Rows.Count == 0)
                //{
                //    listStudentFine = listStudentFine == null ? new List<StudentFineModel>() : listStudentFine;
                //    listStudentFine.Add(new StudentFineModel
                //    {
                //        FineTransactionID = 0,
                //        IsOFF = false,
                //        IsPaid = false,
                //        FineAmount = Convert.ToInt32(lblReAdmissionValue.Text),
                //        FineDate = Convert.ToDateTime(lblHdnFeeDate.Text),
                //        FineType = "Re Admission",
                //        FineTypeID = null,
                //        ReceiptNo = Convert.ToInt32(lblBillNoValue.Text),
                //        StudentID = Convert.ToInt64(lblHdnStudentID.Text),

                //    });
                //}
                #endregion

                index = 0;
                if (listStudentFine != null)
                {
                    groupFine.Visible = true;
                    gridFine.DataSource = listStudentFine;

                    foreach (StudentFineModel fine in listStudentFine)
                    {
                        DataGridViewTextBoxCell colFineType = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineType"]);
                        DataGridViewTextBoxCell colFineAmount = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineAmount"]);
                        DataGridViewTextBoxCell colFineDate = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineDate"]);
                        DataGridViewTextBoxCell colFineTransactionID = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineTransactionID"]);
                        DataGridViewTextBoxCell colFineBillNo = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineBillNo"]);
                        DataGridViewTextBoxCell colStudentID = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colStudentID"]);

                        colFineBillNo.Value = fine.ReceiptNo;
                        colFineType.Value = fine.FineType;
                        colFineAmount.Value = fine.FineAmount;
                        colFineDate.Value = String.Format("{0:dd-MMM-yyyy}", fine.FineDate);
                        colFineTransactionID.Value = fine.FineTransactionID;
                        colStudentID.Value = fine.StudentID;
                        index++;
                    }
                }
                else
                {
                    groupFine.Visible = false;
                    gridFine.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                gridFine.Refresh();
                gridFine.ClearSelection();
            }
        }
        private void Bind_Diposited_List(List<MonthlyFeeDepositModel> listFeeDeposited)
        {
            try
            {
                index = 0;
                if (listFeeDeposited != null)
                {
                    gridDeposited.DataSource = listFeeDeposited;
                    foreach (MonthlyFeeDepositModel feeDues in listFeeDeposited)
                    {
                        DataGridViewLinkCell colBillNo = (DataGridViewLinkCell)(gridDeposited.Rows[index].Cells["colBillNo_Paid"]);
                        DataGridViewTextBoxCell colDuesAmount = (DataGridViewTextBoxCell)(gridDeposited.Rows[index].Cells["colAmount_Paid"]);
                        DataGridViewTextBoxCell colFeeDate = (DataGridViewTextBoxCell)(gridDeposited.Rows[index].Cells["colDate_Paid"]);
                        colBillNo.Value = feeDues.FeeReceiptNo;
                        colDuesAmount.Value = feeDues.AmountDeposit;
                        colFeeDate.Value = String.Format("{0:dd-MMM-yyyy}", feeDues.FeeDepositDate);
                        index++;
                    }
                }
                else
                {
                    gridDeposited.DataSource = null;
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
        public void Set_Control_Visibility(bool IsVisible)
        {
            panelFeeA.Visible = IsVisible;
            // panelFeeB.Visible = IsVisible;
            panelFeeC.Visible = IsVisible;
            //panelFeeD.Visible = IsVisible;
            // groupFine.Visible = IsVisible;
            groupFeeCategory.Visible = IsVisible;
            groupPreviousDues.Visible = IsVisible;
            groupBillTransaction.Visible = IsVisible;
            groupDepositList.Visible = IsVisible;
            linkPaidFee.Visible = IsVisible;
        }
        private void ResetGridControls()
        {
            gridFeeType.DataSource = null;
            gridPreviousDues.DataSource = null;
            gridAmountPaid.DataSource = null;
            gridDeposited.DataSource = null;
            gridFine.DataSource = null;
            gridFeeType.Refresh();
            gridPreviousDues.Refresh();
            gridAmountPaid.Refresh();
            gridFeeType.Refresh();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Bill Number Validation
            if (string.IsNullOrEmpty(txtBillNo.Text))
            {
                SetErrorMessage("Bill number is required.\nPlease enter valid bill number.");
                return;
            }

            if (!string.IsNullOrEmpty(txtBillNo.Text))
            {
                feeDeposit = new FeeDeposit();
                string returnValue = feeDeposit.Is_Valid_Fee_Receipt_No(Convert.ToInt64(txtBillNo.Text));
                if (returnValue.ToUpper().Trim() == "N")
                {
                    MessageBox.Show("Invalid bill number.\nPlease enter valid bill number.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBillNo.Select();
                    return;
                }
            }
            #endregion

            if (gridFineValidation())
            {
                if (AmountValidation())
                {
                    btnSave.Enabled = false;
                    SaveFeeDetails();
                    btnSave.Enabled = true;
                }
            }
        }
        private void gridPreviousDues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    // txtBillNo.Text = String.Empty;
                    DefaultFocus();

                    long? receiptNo = Convert.ToInt64(gridPreviousDues.Rows[rowIndex].Cells["colGridDuesBillNo"].Value);
                    GetFeeDetailsByReceiptNo(receiptNo);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
        }
        private void gridFine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridFine.Columns["colIsPaid"].Index)
            {
                gridFine.EndEdit();  //Stop editing of cell.
                if ((bool)gridFine.Rows[e.RowIndex].Cells["colIsPaid"].Value)
                {
                    //Set the fine value;
                    gridFine.Rows[e.RowIndex].Cells["colFinePaidAmount"].Value = gridFine.Rows[e.RowIndex].Cells["colFineAmount"].Value;

                    gridFine.Rows[e.RowIndex].Cells["colIsOff"].Value = false;
                    gridFine.CurrentCell = gridFine["colFinePaidAmount", e.RowIndex];

                    gridFine.BeginEdit(true);
                }
                else
                {
                    //gridFine.Rows[e.RowIndex].Cells["colIsOff"].Value = true;
                    gridFine.Rows[e.RowIndex].Cells["colFinePaidAmount"].Value = string.Empty;
                }
            }

            if (e.ColumnIndex == gridFine.Columns["colIsOff"].Index)
            {
                gridFine.EndEdit();  //Stop editing of cell.
                if ((bool)gridFine.Rows[e.RowIndex].Cells["colIsOff"].Value)
                {
                    gridFine.Rows[e.RowIndex].Cells["colIsPaid"].Value = false;
                    gridFine.Rows[e.RowIndex].Cells["colFinePaidAmount"].Value = string.Empty;
                }
                //else
                //{
                //    gridFine.Rows[e.RowIndex].Cells["colIsPaid"].Value = true;
                //}
            }
        }
        private void gridFine_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(colFinePaidAmount_KeyPress);
            if (gridFine.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                tb.MaxLength = 5;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(colFinePaidAmount_KeyPress);
                }
            }
        }
        private void colFinePaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValidation(e);
        }
        private bool AmountValidation()
        {
            bool returnValue = true;
            if (String.IsNullOrWhiteSpace(txtDepositAmount.Text))
            {
                SetErrorMessage("Amount is Required.");
                returnValue = false;
            }

            if (!String.IsNullOrWhiteSpace(txtDepositAmount.Text))
            {
                if (Convert.ToInt32(txtDepositAmount.Text) <= 0)
                {
                    SetErrorMessage("Amount Should Be Greater Than Zero.");
                    returnValue = false;
                }

                if (gridFine.Rows.Count > 0)
                {
                    if (Convert.ToInt32(txtDepositAmount.Text) > basicFeeAmount)
                    {
                        SetErrorMessage("Amount Should Not Be Greater Than (Total Fee : " +
                            lblDuesLeftOnBillValue.Text + ") - (Total Fine : " +
                            Convert.ToString(Convert.ToInt16(lblTotalFineValue.Text) + Convert.ToInt16(lblReAdmissionValue.Text)) + ") = " +
                            Convert.ToString(basicFeeAmount));
                        returnValue = false;
                    }
                }
                else if (Convert.ToInt32(txtDepositAmount.Text) > Convert.ToInt32(lblDuesLeftOnBillValue.Text))
                {
                    SetErrorMessage("Amount Should Not Be Greater Than " + lblDuesLeftOnBillValue.Text);
                    returnValue = false;
                }
            }

            if (returnValue == false)
            {
                txtDepositAmount.Focus();
                return false;
            }

            if (!String.IsNullOrWhiteSpace(txtDepositAmount.Text) && returnValue != false)
            {
                if ((Convert.ToInt32(txtDepositAmount.Text) > 0) &&
                    (Convert.ToInt32(txtDepositAmount.Text) <= Convert.ToInt32(lblDuesLeftOnBillValue.Text)))
                {
                    //  HideErrorMessage();
                    returnValue = true;
                }
            }
            return returnValue;
        }
        private bool gridFineValidation()
        {
            int textBlank = 0;
            int notSelected = 0;
            int notEqual = 0;
            bool returnValue = false;

            foreach (DataGridViewRow row in gridFine.Rows)
            {
                //If both checkboxes are not selected;
                if (Convert.ToBoolean(row.Cells["colIsPaid"].Value) == false
                    && Convert.ToBoolean(row.Cells["colIsOff"].Value) == false)
                {
                    notSelected++;
                }

                //If Paid Amount text box is empty
                if (Convert.ToBoolean(row.Cells["colIsPaid"].Value) == true
                   && string.IsNullOrWhiteSpace(Convert.ToString(row.Cells["colFinePaidAmount"].Value)))
                {
                    textBlank++;
                }

                //If Paid Amount text is not equal
                if (!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells["colFinePaidAmount"].Value)))
                {
                    if (Convert.ToInt32(row.Cells["colFineAmount"].Value) !=
                        Convert.ToInt32(row.Cells["colFinePaidAmount"].Value))
                    {
                        notEqual++;
                    }
                }
            }
            if (textBlank > 0)
            {
                SetErrorMessage("Please Enter Amount In Fine Table");
                returnValue = false;
            }

            if (notSelected > 0)
            {
                SetErrorMessage("Please Select IS PAID or IS OFF In Fine Table");
                returnValue = false;
            }

            if (notEqual > 0)
            {
                SetErrorMessage("Please Enter Correct Amount In Fine Table");
                returnValue = false;
            }

            if (textBlank == 0 && notSelected == 0 && notEqual == 0)
            {
                //  lblError.Visible = false;
                returnValue = true;
            }
            return returnValue;
        }
        private void SetErrorMessage(string message)
        {
            // lblError.Visible = true;
            // lblError.Text = message;
            MessageBox.Show(message, "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //private void HideErrorMessage()
        //{
        //  //  lblError.Visible = false;
        //}
        private void gridFine_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridFine.EndEdit();
            //this.BeginInvoke(new Action(() =>
            //{
            if (e.ColumnIndex == gridFine.Columns["colFinePaidAmount"].Index)
            {
                gridFine.BeginEdit(true);
                gridFine.CurrentCell = gridFine["colFinePaidAmount", e.RowIndex];
            }
            //}));
        }
        private void SaveFeeDetails()
        {
            try
            {
                monthlyFeeDepositModel = new MonthlyFeeDepositModel();
                monthlyFeeDepositModel.FineDetailsXML = ConvertGridToXML(ConvertGridToList());
                monthlyFeeDepositModel.FeeReceiptNo = Convert.ToInt64(txtBillNo.Text);
                monthlyFeeDepositModel.AmountDeposit = Convert.ToInt32(txtDepositAmount.Text);
                monthlyFeeDepositModel.AmountDues = Convert.ToInt32(lblDuesLeftOnBillValue.Text) - Convert.ToInt32(txtDepositAmount.Text);
                monthlyFeeDepositModel.FeeDepositDate = Common.Convert_String_To_Date(dtpDate.Text);
                monthlyFeeDepositModel.Student_ID = Convert.ToInt64(lblHdnStudentID.Text);
                //DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                feeDeposit = new FeeDeposit();
                short returnValue = feeDeposit.DepositMonthlyFee(monthlyFeeDepositModel);

                if (returnValue == 1)
                {
                    MessageBox.Show("Record Saved Successfully.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetFeeDetailsByReceiptNo(monthlyFeeDepositModel.FeeReceiptNo);
                    DefaultFocus();
                }
                else
                {
                    MessageBox.Show("Error In Saving Records.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error! Please Contact To Admin.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtBillNo.Text = string.Empty;
                txtRegistrationSearch.Text = string.Empty;
                txtBillNo.Focus();
            }
        }
        private List<StudentFineModel> ConvertGridToList()
        {
            List<StudentFineModel> _listStudentFine = new List<StudentFineModel>();
            if (gridFine.Rows.Count > 0)
            {
                foreach (DataGridViewRow rows in gridFine.Rows)
                {
                    _listStudentFine.Add(new StudentFineModel
                    {
                        ReceiptNo = Convert.ToInt64(lblBillNoValue.Text),
                        FineAmount = Convert.ToInt32(rows.Cells["colFineAmount"].Value),
                        FineDate = Convert.ToDateTime(rows.Cells["colFineDate"].Value),
                        IsPaid = Convert.ToBoolean(rows.Cells["colIsPaid"].Value),
                        IsOFF = Convert.ToBoolean(rows.Cells["colIsOff"].Value),
                        DepositAmount = string.IsNullOrWhiteSpace(Convert.ToString(rows.Cells["colFinePaidAmount"].Value)) ? null :
                        (Int32?)Convert.ToInt32(rows.Cells["colFinePaidAmount"].Value),
                        DepositDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)),
                        FineTransactionID = Convert.ToInt64(rows.Cells["colFineTransactionID"].Value),
                        StudentID = Convert.ToInt64(rows.Cells["colStudentID"].Value)
                    });
                }
            }
            return _listStudentFine;
        }
        private string ConvertGridToXML(List<StudentFineModel> ListFeeSetting)
        {
            XElement xmlElements = new XElement("StudentFine", ListFeeSetting// .Where(x => x.FeeTypeID != 0)
            .Select(xmlchild => new XElement("Row",
            new XElement("FineTransactionID", xmlchild.FineTransactionID),
            new XElement("FineAmount", xmlchild.FineAmount),
            new XElement("FineDate", xmlchild.FineDate),
            new XElement("ReceiptNo", xmlchild.ReceiptNo),
            new XElement("IsPaid", xmlchild.IsPaid),
            new XElement("DepositAmount", xmlchild.IsOFF == true ? null : xmlchild.DepositAmount),
            new XElement("IsOFF", xmlchild.IsOFF),
             new XElement("StudentID", xmlchild.StudentID),
            new XElement("DepositDate", xmlchild.DepositDate))));
            return Convert.ToString(xmlElements);
        }
        private void DefaultFocus()
        {
            txtDepositAmount.Text = String.Empty;
            // txtBillNo.Text = String.Empty;
            txtBillNo.Select();
            this.ActiveControl = txtDepositAmount;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";

            //txtDepositAmount.Text = String.Empty;
            //txtDepositAmount.Select();
            //this.ActiveControl = txtDepositAmount;
        }
        private void FeeDepositForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeeDepositForm.instanceFrm = null;
        }
        private void btnRegistrationSearch_Click(object sender, EventArgs e)
        {
            Set_Control_Visibility(false);
            //  txtBillNo.Text = String.Empty;
            if (string.IsNullOrEmpty(txtRegistrationSearch.Text))
            {
                SetErrorMessage("Registration number is required.");
            }
            else
            {
                long registration_No = Convert.ToInt64(txtRegistrationSearch.Text);
                Search_Previous_Dues_Form admissionFeeForm = new Search_Previous_Dues_Form(registration_No);
                admissionFeeForm.StartPosition = FormStartPosition.CenterParent;
                admissionFeeForm.ShowDialog(this);
            }
        }
        private void btnPaidList_Click(object sender, EventArgs e)
        {
            Set_Control_Visibility(false);
            // txtBillNo.Text = String.Empty;
            if (string.IsNullOrEmpty(txtRegistrationSearch.Text))
            {
                SetErrorMessage("Registration number is required.");
            }
            else
            {
                long registration_No = Convert.ToInt64(txtRegistrationSearch.Text);
                Student_Deposited_List_Form deposited_List = new Student_Deposited_List_Form(registration_No);

                deposited_List.StartPosition = FormStartPosition.CenterParent;
                deposited_List.ShowDialog(this);
            }
        }
        private void gridDeposited_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    //  txtBillNo.Text = String.Empty;
                    DefaultFocus();

                    long? receiptNo = Convert.ToInt64(gridDeposited.Rows[rowIndex].Cells["colBillNo_Paid"].Value);
                    GetFeeDetailsByReceiptNo(receiptNo);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    gridDeposited.ClearSelection();
                }
            }
        }
        private void Print_Receipt(long Receipt_No)
        {
            //DepositFeeReceipt feeDepositForm = new DepositFeeReceipt(Convert.ToInt32(lblBillNoValue.Text));
            //feeDepositForm.Show(UIParent.MDIForm.dockPanel);

            DepositFeeReceipt instance = new DepositFeeReceipt(Receipt_No);
            instance.Show(UIParent.MDIForm.dockPanel);
        }
        private void gridAmountPaid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int rowIndex = e.RowIndex;

            try
            {
                long receiptNo = Convert.ToInt64(gridAmountPaid.Rows[rowIndex].Cells["colFeeReceiptNo"].Value);
                long feeTransactionID = Convert.ToInt64(gridAmountPaid.Rows[rowIndex].Cells["colFeeTransactionID"].Value);
                string new_Deposit_Date_string = Convert.ToString(gridAmountPaid.Rows[rowIndex].Cells["colPaidDate"].Value);
                DateTime new_Deposit_Date = DateTime.ParseExact(new_Deposit_Date_string, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                string old_Deposit_Date = Convert.ToString(gridAmountPaid.Rows[rowIndex].Cells["colPaidDateHidden"].Value);

                #region Print Receipt
                if (e.ColumnIndex == 3)
                {
                    Print_Receipt(receiptNo);
                }
                #endregion

                #region Update Date
                if (e.ColumnIndex == 2)
                {
                    if (new_Deposit_Date < fee_generated_date)
                    {
                        MessageBox.Show("Date should not be less than fee generated date.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Set Old Value
                        gridAmountPaid.Rows[rowIndex].Cells["colPaidDate"].Value = old_Deposit_Date;
                    }
                    else
                    {
                        Update_Deposit_Date(feeTransactionID, new_Deposit_Date, receiptNo);
                    }
                }
                #endregion

                #region Delete Entry
                if (e.ColumnIndex == 4)
                {
                    DialogResult output = MessageBox.Show("Are you sure to delete this entry?\n", "Fee Deposit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (output == DialogResult.OK)
                    {
                        Delete_Fee_Entry(feeTransactionID, receiptNo);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                SetErrorMessage("Error! Please Contact To Support Team.");
            }
            finally
            {
                gridAmountPaid.ClearSelection();
            }
        }
        private void gridAmountPaid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridAmountPaid.EndEdit();
                if (e.ColumnIndex == gridAmountPaid.Columns["colPaidDate"].Index)
                {
                    //get Current Index for Date Picker;
                    grid_Amount_Paid_Current_Index = e.RowIndex;
                    //grid_Amount_Paid_Old_Date = Convert.ToString(gridAmountPaid.CurrentCell.Value);

                    gridAmountPaid.BeginEdit(true);
                    gridAmountPaid.ClearSelection();

                    dtp_Change_Date.Location = gridAmountPaid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtp_Change_Date.Visible = true;
                    dtp_Change_Date.Value = DateTime.ParseExact(Convert.ToString(gridAmountPaid.CurrentCell.Value), "dd-MMM-yyyy", CultureInfo.InvariantCulture);

                    gridAmountPaid.CurrentCell.Value = String.Format("{0:dd-MMM-yyyy}", dtp_Change_Date.Value.Date);
                }
                else
                {
                    dtp_Change_Date.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // gridAmountPaid.BeginEdit(false);
                // gridAmountPaid.EndEdit();
            }
        }
        private void dtp_Chage_Date_ValueChange(object sender, EventArgs e)
        {
            int col_Days_Count_Value = Convert.ToInt32(gridAmountPaid.Rows[grid_Amount_Paid_Current_Index].Cells["col_Days_Count"].Value);
            string grid_Amount_Paid_DB_Date = Convert.ToString(gridAmountPaid.Rows[grid_Amount_Paid_Current_Index].Cells["colPaidDateHidden"].Value);
            gridAmountPaid.CurrentCell.Value = dtp_Change_Date.Text.ToString();

            if (
                (gridAmountPaid.CurrentCell.ColumnIndex == 1)
                && (Convert.ToString(grid_Amount_Paid_DB_Date) != dtp_Change_Date.Text.ToString()))
            {
                if (col_Days_Count_Value <= days_Count)
                {
                    gridAmountPaid.Rows[grid_Amount_Paid_Current_Index].Cells["colSave"].Value = "Save";
                }
                else
                {
                    gridAmountPaid.Rows[grid_Amount_Paid_Current_Index].Cells["colSave"].Value = String.Empty;
                    MessageBox.Show("Not Allowed! Date will not modify before 1 Month.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Set Previous Date.
                    gridAmountPaid.CurrentCell.Value = grid_Amount_Paid_DB_Date;
                }
                gridAmountPaid.ClearSelection();
                //gridAmountPaid.BeginEdit(false);
                // gridAmountPaid.EndEdit();
            }
            else
            {
                gridAmountPaid.Rows[grid_Amount_Paid_Current_Index].Cells["colSave"].Value = string.Empty;
            }
        }
        private void Update_Deposit_Date(long feeTransactionID, DateTime new_Deposit_Date, long receiptNo)
        {
            feeDeposit = new FeeDeposit();
            short returnValue = feeDeposit.Update_Deposit_Date(feeTransactionID, new_Deposit_Date);
            if (returnValue == 1)
            {
                MessageBox.Show("Deposit date has been updated.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFeeDetailsByReceiptNo(receiptNo);
            }
        }
        private void Delete_Fee_Entry(long feeTransactionID, long receiptNo)
        {
            feeDeposit = new FeeDeposit();
            short returnValue = feeDeposit.Delete_Deposit_Entry(feeTransactionID, receiptNo);
            if (returnValue == 1)
            {
                MessageBox.Show("Row has been deleted.", "Fee Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFeeDetailsByReceiptNo(receiptNo);
            }
        }
        private void gridAmountPaid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtp_Change_Date.Visible = false;
        }
        private void linkPaidFee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegistrationSearch.Text))
            {
                SetErrorMessage("Registration number is required.");
            }
            else
            {
              //  long bill_No = Convert.ToInt64(gridPreviousDues.Rows[0].Cells["colGridDuesBillNo"].Value);
                long registration_No = Convert.ToInt64(txtRegistrationSearch.Text);
                Deposit_Fee_Multiple_Receipt deposit_Fee_Multiple_Receipt = new Deposit_Fee_Multiple_Receipt(registration_No);
                deposit_Fee_Multiple_Receipt.StartPosition = FormStartPosition.CenterParent;
                deposit_Fee_Multiple_Receipt.ShowDialog(this);
            }
        }
    }
}