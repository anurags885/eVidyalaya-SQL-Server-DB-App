using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using School.App.Repository;
using SchoolModels;
using School.App.Repository;
using SchoolModels.Report;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class MonthlyFeeReceiptForm : DockContent
    {
        ClassType _classType;
        FeeReport _feeReport;
        FeeMonthlyReportModel _feeMonthlyReportModel;
        List<ClassTypeModel> _listClassType = new List<ClassTypeModel>();
        public static MonthlyFeeReceiptForm instanceFrm;

        // string _appPath = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("bin"));
        string _appPath = Application.StartupPath + "\\";
        public MonthlyFeeReceiptForm()
        {
            InitializeComponent();
        }
        private void MonthlyFeeReceiptForm_Load(object sender, EventArgs e)
        {
            BindControls();
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (Convert.ToSByte(ddlClass.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Class.", "Monthly Fee Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnViewReport.Enabled = false;
                lblPleaseWait.Visible = true;

                GetMonthlyFeeReport();

                btnViewReport.Enabled = true;
                lblPleaseWait.Visible = false;
            }
        }
        private void BindControls()
        {
            _classType = new ClassType();
            _listClassType = _classType.GetClassDetails();

            if (_listClassType == null)
                _listClassType = new List<ClassTypeModel>();
            _listClassType.Add(new ClassTypeModel { ClassID = 0, ClassName = "Select" });
            ddlClass.DataSource = _listClassType.OrderBy(x => x.ClassID).ToList();
            ddlClass.DisplayMember = "ClassName";
            ddlClass.ValueMember = "ClassID";

            datePickerReport.Format = DateTimePickerFormat.Custom;
            datePickerReport.Value = DateTime.Now;
            datePickerReport.CustomFormat = " dd.MM.yyyy";
        }
        private void GetMonthlyFeeReport()
        {
            try
            {
                int year = datePickerReport.Value.Year;
                int month = datePickerReport.Value.Month;

                _feeMonthlyReportModel = new FeeMonthlyReportModel
                {
                    ClassID = Convert.ToInt16(ddlClass.SelectedValue),
                    Month = (short)month,
                    Year = (short)year,
                };

                _feeReport = new FeeReport();

                DataSet dsMonthlyReport = _feeReport.GetFeeReportByMonth(_feeMonthlyReportModel);

                if (dsMonthlyReport != null && dsMonthlyReport.Tables[0].Rows.Count > 0)
                {
                    dsMonthlyReport.Tables[0].TableName = "FeeDetails";
                    dsMonthlyReport.Tables[1].TableName = "FeeApplicable";
                    dsMonthlyReport.Tables[2].TableName = "PreviousBill";
                    dsMonthlyReport.Tables[3].TableName = "School";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\MonthlyFeeReceipt.rpt");
                    rdoc.SetDataSource(dsMonthlyReport);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = true;
                    MessageBox.Show("No Result Found.", "Monthly Fee Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void MonthlyFeeReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MonthlyFeeReceiptForm.instanceFrm = null;
        }
    }
}
