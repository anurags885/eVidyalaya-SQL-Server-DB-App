using School.App.Repository;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class ExpensesReportForm : DockContent
    {
        internal static ExpensesReportForm instanceFrm;
        SchoolExpenses _schoolExpenses;
        string _appPath = Application.StartupPath + "\\";
        public ExpensesReportForm(DateTime expenseDate)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = expenseDate;
            dtpDate.CustomFormat = "dd.MM.yyyy";

            GetExpenseReport(expenseDate);
        }
        public ExpensesReportForm()
        {
            InitializeComponent();
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd.MM.yyyy";
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DateTime expenseDate = Common.Convert_String_To_Date(dtpDate.Text);
            //DateTime.ParseExact(dtpDate.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            GetExpenseReport(expenseDate);
        }
        private void GetExpenseReport(DateTime expenseDate)
        {
            btnViewReport.Enabled = false;
            lblPleaseWait.Visible = true;
            try
            {
                _schoolExpenses = new SchoolExpenses();
                DataSet dsExpenseReport = _schoolExpenses.ExpensesReport(expenseDate);

                if (dsExpenseReport != null && dsExpenseReport.Tables[0].Rows.Count > 0)
                {
                    dsExpenseReport.Tables[0].TableName = "Expenses";
                    dsExpenseReport.Tables[1].TableName = "ActualExpenses";
                    dsExpenseReport.Tables[2].TableName = "School";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\DailyExpenseReport.rpt");
                    rdoc.SetDataSource(dsExpenseReport);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;

                    btnViewReport.Enabled = true;
                    lblPleaseWait.Visible = false;
                }
                else
                {
                    crystalReportViewer.Visible = false;
                    MessageBox.Show("No Record Found.", "School Expense", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnViewReport.Enabled = true;
                    lblPleaseWait.Visible = false;
                }
            }
            catch(Exception ex) { }
        }
        private void ExpensesReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExpensesReportForm.instanceFrm = null;
        }
    }
}
