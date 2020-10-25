using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
using School.App.Repository;

namespace eVidyalaya.Views.Fee.Reports
{
    public partial class Advance_Pay_Report_Viewer_Form : Form
    {
        string _appPath = Application.StartupPath + "\\";
        long _student_ID;
        long _receipt_No;
        public Advance_Pay_Report_Viewer_Form(long Student_ID, long Receipt_No)
        {
            InitializeComponent();
            _student_ID = Student_ID;
            _receipt_No = Receipt_No;
            Get_Advance_Fee_Pay_Report();
        }
        private void Get_Advance_Fee_Pay_Report()
        {
            try
            {
                Advance_Deposit_Fee advancePay = new Advance_Deposit_Fee();

                DataSet ds_Admission_Fee = advancePay.Get_Advance_Fee_Pay_Report(_student_ID, _receipt_No);

                if (ds_Admission_Fee != null && ds_Admission_Fee.Tables[0].Rows.Count > 0)
                {
                    ds_Admission_Fee.Tables[0].TableName = "DT_Student";
                    ds_Admission_Fee.Tables[1].TableName = "DT_Admission_Fee";
                    ds_Admission_Fee.Tables[2].TableName = "DT_Student_Fee_Setting";
                    ds_Admission_Fee.Tables[3].TableName = "DT_School";

                    ReportDocument rdoc = new ReportDocument();

                    rdoc.Load(_appPath + "Reports\\Advance_Pay_Report.rpt");
                    rdoc.SetDataSource(ds_Admission_Fee);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
