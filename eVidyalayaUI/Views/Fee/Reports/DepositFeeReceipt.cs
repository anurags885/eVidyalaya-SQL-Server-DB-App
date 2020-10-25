using CrystalDecisions.CrystalReports.Engine;
using School.App.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class DepositFeeReceipt : DockContent
    {
        FeeReport feeReport;
        // string _appPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
        string _appPath = Application.StartupPath + "\\";
        public static DepositFeeReceipt instanceFrm;
        public DepositFeeReceipt()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }
        public DepositFeeReceipt(long receiptNo) : this()
        {
            GetMonthlyFeeReport(receiptNo);
        }
        private void GetMonthlyFeeReport(long receiptNo)
        {
            try
            {
                feeReport = new FeeReport();

                DataSet dsFeeDeposit = feeReport.GetFeeDepositReportByReceiptNo(receiptNo);

                if (dsFeeDeposit != null && dsFeeDeposit.Tables.Count > 0)
                {
                    dsFeeDeposit.Tables[0].TableName = "FeeDetails";
                    dsFeeDeposit.Tables[1].TableName = "FeeTransaction";
                    dsFeeDeposit.Tables[2].TableName = "School";

                    ReportDocument rdoc = new ReportDocument();

                    rdoc.Load(_appPath + "Reports\\FeeDepositReport.rpt");
                    rdoc.SetDataSource(dsFeeDeposit);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = true;
                    MessageBox.Show("No Result Found.", "Fee Deposit Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DepositFeeReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            DepositFeeReceipt.instanceFrm = null;
        }
    }
}
