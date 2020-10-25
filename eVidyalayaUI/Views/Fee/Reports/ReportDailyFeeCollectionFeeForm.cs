using CrystalDecisions.CrystalReports.Engine;
using SchoolModels.Report;
using School.App.Repository;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class ReportDailyFeeCollectionFeeForm : DockContent
    {
        FeeReport _feeReport;
        string _appPath = Application.StartupPath + "\\";
        public static ReportDailyFeeCollectionFeeForm instanceFrm;
        public ReportDailyFeeCollectionFeeForm()
        {
            InitializeComponent();

            datePickerReport.Format = DateTimePickerFormat.Custom;
            datePickerReport.Value = DateTime.Now;
            datePickerReport.CustomFormat = "dd.MM.yyyy";
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            btnViewReport.Enabled = false;
            lblPleaseWait.Visible = true;
            GetDailyFeeCollection();
            btnViewReport.Enabled = true;
            lblPleaseWait.Visible = false;
        }

        private void GetDailyFeeCollection()
        {
            try
            {
                _feeReport = new FeeReport();

                DateTime feeDate = Common.Convert_String_To_Date(datePickerReport.Text);
                //DateTime.ParseExact(datePickerReport.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                DataSet dsFeeCollection = _feeReport.GetDailyFeeCollection(feeDate);

                if (dsFeeCollection != null && dsFeeCollection.Tables.Count > 0)
                {
                    if (dsFeeCollection.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Result Found.", "Daily Fee Collection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        crystalReportViewer.Visible = false;
                        return;
                    }

                    dsFeeCollection.Tables[0].TableName = "FeeCollection";

                    ReportDocument rdoc = new ReportDocument();

                    rdoc.Load(_appPath + "Reports\\DailyFeeCollectionReport.rpt");
                    rdoc.SetDataSource(dsFeeCollection);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = false;
                    MessageBox.Show("No Result Found.", "Daily Fee Collection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ReportDailyFeeCollectionFeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportDailyFeeCollectionFeeForm.instanceFrm = null;
        }
    }
}
