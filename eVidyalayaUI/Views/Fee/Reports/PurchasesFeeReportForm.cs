using CrystalDecisions.CrystalReports.Engine;
using School.App.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class PurchasesFeeReportForm : DockContent
    {
        internal static PurchasesFeeReportForm instanceFrm;
        string _appPath = Application.StartupPath + "\\";
        FeeReport _feeReport;
        public PurchasesFeeReportForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }
        public PurchasesFeeReportForm(long ReceiptNo, long RegistrationNo):this()
        {
            GetPurchasesReportFee(ReceiptNo, RegistrationNo);
        }
        private void GetPurchasesReportFee(long ReceiptNo, long RegistrationNo)
        {
            try
            {
                _feeReport = new FeeReport();

                DataSet dsPurchasesReport = _feeReport.GetPurchasesFeeReport(ReceiptNo,RegistrationNo);

                if (dsPurchasesReport != null && dsPurchasesReport.Tables[1].Rows.Count > 0)
                {
                    dsPurchasesReport.Tables[0].TableName = "Student";
                    dsPurchasesReport.Tables[1].TableName = "FeeTransaction";
                    dsPurchasesReport.Tables[2].TableName = "School";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\PurchasesFeeReceiptReport.rpt");
                    rdoc.SetDataSource(dsPurchasesReport);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = false;
                    MessageBox.Show("No Result Found.", "Purchases Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void PurchasesFeeReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PurchasesFeeReportForm.instanceFrm = null;
        }
    }
}
