using OfficeOpenXml;
using OfficeOpenXml.Style;
using eVidyalaya.Views.Fee.Reports;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya.Views.Fee
{
    public partial class Fee_Deposite_By_Date_Form : DockContent
    {

        public static Fee_Deposite_By_Date_Form instanceFrm;
        int index = 0;
        public Fee_Deposite_By_Date_Form()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            grid_Fee_List.AutoGenerateColumns = false;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd-MMM-yyyy";

            //  gridFeeType.Columns["colGridApplicableFeeType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void Bind_Grid(List<Fee_Deposit_By_Date_View_Model> list_Deposit_Fee)
        {
            try
            {
                // DateTime new_Deposit_Date = DateTime.ParseExact(dtpDate.Value.Date, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                index = 0;
                if (list_Deposit_Fee != null)
                {
                    linkDownload.Visible = true;
                    grid_Fee_List.DataSource = list_Deposit_Fee;
                    foreach (Fee_Deposit_By_Date_View_Model model in list_Deposit_Fee)
                    {
                        DataGridViewTextBoxCell col_FeeReceiptNo = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_FeeReceiptNo"]);
                        DataGridViewTextBoxCell col_Full_Name = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Full_Name"]);
                        DataGridViewTextBoxCell col_Class_Name = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Class_Name"]);
                        DataGridViewTextBoxCell col_AmountDeposit = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_AmountDeposit"]);
                        DataGridViewTextBoxCell col_Fee_Deposit_Type = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Fee_Deposit_Type"]);
                        DataGridViewTextBoxCell col_Fee_Deposit_Code = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Fee_Deposit_Code"]);
                        DataGridViewTextBoxCell col_FeeDepositDate = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_FeeDepositDate"]);
                        DataGridViewLinkCell col_Print = (DataGridViewLinkCell)(grid_Fee_List.Rows[index].Cells["col_Print"]);
                        DataGridViewTextBoxCell col_Student_ID = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Student_ID"]);
                        DataGridViewTextBoxCell col_Registration_No = (DataGridViewTextBoxCell)(grid_Fee_List.Rows[index].Cells["col_Registration_No"]);

                        col_FeeReceiptNo.Value = Convert.ToString(model.FeeReceiptNo);
                        col_Full_Name.Value = model.Student_Name;
                        col_Class_Name.Value = model.Class_Name;
                        col_AmountDeposit.Value = model.AmountDeposit;
                        col_Fee_Deposit_Type.Value = model.Fee_Deposit_Type;
                        col_Fee_Deposit_Code.Value = model.Fee_Deposit_Code;
                        col_FeeDepositDate.Value = String.Format("{0:dd-MMM-yyyy}", model.FeeDepositDate);
                        col_Student_ID.Value = model.Student_ID;
                        col_Registration_No.Value = model.Registration_No;
                        col_Print.Value = "Print";
                        index++;
                    }
                }
                else
                {
                    grid_Fee_List.DataSource = null;
                    linkDownload.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                grid_Fee_List.Refresh();
                grid_Fee_List.ClearSelection();
            }
        }
        private List<Fee_Deposit_By_Date_View_Model> Get_Fee_Deposit_By_Date(DateTime Fee_Deposit_Date)
        {
            FeeDeposit feeDeposit = new FeeDeposit();
            List<Fee_Deposit_By_Date_View_Model> list_Deposit_Fee = feeDeposit.Get_Fee_Deposit_By_Date(Fee_Deposit_Date);
            return list_Deposit_Fee;
        }
        private void Fee_Deposite_By_Date_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fee_Deposite_By_Date_Form.instanceFrm = null;
        }
        private void linkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<Fee_Deposit_By_Date_View_Model> list_Deposit_Fee = Get_Fee_Deposit_By_Date(dtpDate.Value.Date);
            Export_To_Excel(list_Deposit_Fee);
        }
        public void Export_To_Excel(List<Fee_Deposit_By_Date_View_Model> model)
        {
            try
            {
                #region Save Dialog Box
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = "Fee_Deposit_List_" + dtpDate.Text + ".xlsx";
                saveFile.Filter = "Excel Files|*.xlsx;*.xls";
                // string _dialogBoxFilter = "All Files|*.docx;*.doc;*.pdf;*.jpge*.jpg,*.png,*.gif|JPEG Images|*.jpge;*.jpg|Bitmap Files|*.bmp|PNG Image|*.png|GIF Images|*.gif|Document|*.docx;*.doc|Pdf|*.pdf";

                DialogResult result = saveFile.ShowDialog();
                #endregion

                if (result == DialogResult.OK)

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        var ws = pck.Workbook.Worksheets.Add("Fee Deposit List");

                        #region Header
                        //Headers
                        ws.Cells["A1"].Value = "Receipt No";
                        ws.Cells["B1"].Value = "Student Name";
                        ws.Cells["C1"].Value = "Registration No";
                        ws.Cells["D1"].Value = "Class";
                        ws.Cells["E1"].Value = "Deposit Amount";
                        ws.Cells["F1"].Value = "Fee Deposit Type";
                        ws.Cells["G1"].Value = "Deposit Date";
                        #endregion

                        #region Auto Width
                        ws.Column(1).AutoFit(15.00, 20.00);
                        ws.Column(2).AutoFit(25.00, 35.00);
                        ws.Column(3).AutoFit(15.00, 20.00);
                        ws.Column(4).AutoFit(10.00, 20.00);
                        ws.Column(5).AutoFit(10.00, 20.00);
                        ws.Column(6).AutoFit(20.00, 25.00);
                        ws.Column(7).AutoFit(10.00, 20.00);
                        #endregion

                        #region Creating Rows
                        int i = 2;
                        foreach (Fee_Deposit_By_Date_View_Model item in model)
                        {
                            ws.Cells["A" + i.ToString()].Value = Convert.ToString(item.FeeReceiptNo);
                            ws.Cells["B" + i.ToString()].Value = item.Student_Name;
                            ws.Cells["C" + i.ToString()].Value = item.Registration_No;
                            ws.Cells["D" + i.ToString()].Value = item.Class_Name;
                            ws.Cells["E" + i.ToString()].Value = item.AmountDeposit;
                            ws.Cells["F" + i.ToString()].Value = item.Fee_Deposit_Type;
                            ws.Cells["G" + i.ToString()].Value = String.Format("{0:dd-MMM-yyyy}", item.FeeDepositDate); ;
                            i++;
                        }
                        #endregion

                        #region Set Style
                        using (ExcelRange row = ws.Cells["A1:G1"])
                        {
                            row.Style.Font.Bold = true;
                        }

                        using (ExcelRange row = ws.Cells["A1:G" + (i - 1)])
                        {
                            row.Style.Font.Size = 9;
                            row.Style.Font.Name = "Tahoma";
                            row.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            row.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            row.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            row.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }
                        #endregion

                        pck.SaveAs(new FileInfo(saveFile.FileName));

                        Process Proc = new Process();
                        Proc.StartInfo.FileName = saveFile.FileName;
                        Proc.Start();

                    }
            }

            catch (SystemException ex)
            {
                MessageBox.Show(ex.InnerException.GetBaseException().Message + "\n\n Pease close the excel file.", "Fee Deposit List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please Contact To Support Team.", "Fee Deposit List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            List<Fee_Deposit_By_Date_View_Model> list_Deposit_Fee = Get_Fee_Deposit_By_Date(dtpDate.Value.Date);
            Bind_Grid(list_Deposit_Fee);
        }
        private void Fee_Deposite_By_Date_Form_Load(object sender, EventArgs e)
        {
            List<Fee_Deposit_By_Date_View_Model> list_Deposit_Fee = Get_Fee_Deposit_By_Date(dtpDate.Value.Date);
            Bind_Grid(list_Deposit_Fee);
        }
        private void grid_Fee_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            try
            {
                long registration_No = Convert.ToInt64(grid_Fee_List.Rows[rowIndex].Cells["col_Registration_No"].Value);
                long student_ID = Convert.ToInt64(grid_Fee_List.Rows[rowIndex].Cells["col_Student_ID"].Value);
                long receiptNo = Convert.ToInt64(grid_Fee_List.Rows[rowIndex].Cells["col_FeeReceiptNo"].Value);
                string fee_Deposit_Code = Convert.ToString(grid_Fee_List.Rows[rowIndex].Cells["col_Fee_Deposit_Code"].Value);

                #region Print Receipt
                if (e.ColumnIndex == 7)
                {
                    switch (fee_Deposit_Code)
                    {
                        case "MF":
                            Print_Monthly_Receipt(receiptNo);
                            break;

                        case "AAFP":
                            Admission_Report_Viewer_Form addFee = new Admission_Report_Viewer_Form(student_ID);
                            addFee.StartPosition = FormStartPosition.CenterParent;
                            addFee.ShowDialog(this);
                            break;

                        case "PF":
                            PurchasesFeeReportForm.instanceFrm = new PurchasesFeeReportForm(receiptNo, registration_No);
                            PurchasesFeeReportForm.instanceFrm.Show(UIParent.MDIForm.dockPanel);
                            break;

                        case "AFP":
                            Advance_Pay_Report_Viewer_Form report = new Advance_Pay_Report_Viewer_Form(student_ID, receiptNo);
                            report.StartPosition = FormStartPosition.CenterParent;
                            report.ShowDialog(this);
                            break;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please Contact To Support Team.", "Fee Deposit List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                grid_Fee_List.ClearSelection();
            }
        }
        private void Print_Monthly_Receipt(long Receipt_No)
        {
            DepositFeeReceipt instance = new DepositFeeReceipt(Receipt_No);
            instance.Show(UIParent.MDIForm.dockPanel);
        }
    }
}
