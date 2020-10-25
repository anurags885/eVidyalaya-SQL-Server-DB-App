using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;
using School.App.Repository;

namespace eVidyalaya.Views.Fee.Reports
{
    public partial class Admission_Report_Viewer_Form : Form
    {
        string _appPath = Application.StartupPath + "\\";
        long _student_ID;
        public Admission_Report_Viewer_Form(long Student_ID)
        {
            InitializeComponent();
            _student_ID = Student_ID;
            Get_Admission_Fee_Report();
        }
        private void Get_Admission_Fee_Report()
        {
            try
            {
                AdmissionFee admissionFee = new AdmissionFee();

                DataSet ds_Admission_Fee = admissionFee.Get_Admission_Fee_Report(_student_ID);

                if (ds_Admission_Fee != null && ds_Admission_Fee.Tables[0].Rows.Count > 0)
                {
                    ds_Admission_Fee.Tables[0].TableName = "DT_Student";
                    ds_Admission_Fee.Tables[1].TableName = "DT_Admission_Fee";
                    ds_Admission_Fee.Tables[2].TableName = "DT_Student_Fee_Setting";
                    ds_Admission_Fee.Tables[3].TableName = "DT_School";

                    ReportDocument rdoc = new ReportDocument();

                    rdoc.Load(_appPath + "Reports\\Admission_Fee_Report.rpt");
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
