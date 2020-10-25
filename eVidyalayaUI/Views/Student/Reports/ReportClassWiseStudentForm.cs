using School.App.Repository;
using CrystalDecisions.CrystalReports.Engine;
using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class ReportClassWiseStudentForm : DockContent
    {
        internal static ReportClassWiseStudentForm instanceFrm;
        ClassSection _classSection;
        ClassType _classType;
        List<ClassTypeModel> _listClassType = new List<ClassTypeModel>();
        List<ClassSectionModel> _listSectionType = new List<ClassSectionModel>();
        string _appPath = Application.StartupPath + "\\";
        StudentReport _studentReport;
        public ReportClassWiseStudentForm()
        {
            InitializeComponent();
            BindConrols();
        }
        private void BindConrols()
        {
            _classType = new ClassType();
            _classSection = new ClassSection();
            _listClassType = _classType.GetClassDetails();
            _listSectionType = _classSection.GetSectionDetails();

            if (_listClassType == null)
                _listClassType = new List<ClassTypeModel>();
            _listClassType.Add(new ClassTypeModel { ClassID = 0, ClassName = "Select" });
            ddlClass.DataSource = _listClassType.OrderBy(x => x.ClassID).ToList();
            ddlClass.DisplayMember = "ClassName";
            ddlClass.ValueMember = "ClassID";

            if (_listSectionType == null)
                _listSectionType = new List<ClassSectionModel>();
            _listSectionType.Add(new ClassSectionModel { ClassSectionID = 0, SectionName = "Select" });
            ddlSection.DataSource = _listSectionType.OrderBy(x => x.ClassSectionID).ToList();
            ddlSection.DisplayMember = "SectionName";
            ddlSection.ValueMember = "ClassSectionID";
        }
        private void ReportClassWiseStudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportClassWiseStudentForm.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void GetStudentDetailsByClassReport()
        {
            btnViewReport.Enabled = false;
            lblPleaseWait.Visible = true;
            try
            {
                _studentReport = new StudentReport();

                short? classID = Convert.ToInt16(ddlClass.SelectedValue);
                short? sectionID = Convert.ToInt16(ddlSection.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlSection.SelectedValue);
                DataSet dsStudentReport = _studentReport.GetStudentDetailsByClass(classID, sectionID);

                if (dsStudentReport != null && dsStudentReport.Tables[1].Rows.Count > 0)
                {
                    dsStudentReport.Tables[0].TableName = "School";
                    dsStudentReport.Tables[1].TableName = "StudentDetailsByClassDT";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\StudentDetailsByClassReport.rpt");
                    rdoc.SetDataSource(dsStudentReport);
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
                    MessageBox.Show("No Result Found.", "No Record Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnViewReport.Enabled = true;
                    lblPleaseWait.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(ddlClass.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Class.", "Student Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GetStudentDetailsByClassReport();
            }
        }
    }
}
