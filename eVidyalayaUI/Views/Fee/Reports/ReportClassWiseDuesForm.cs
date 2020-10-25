using School.App.Repository;
using CrystalDecisions.CrystalReports.Engine;
using SchoolModels;
using SchoolModels.Report;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class ReportClassWiseDuesForm : DockContent
    {
        internal static ReportClassWiseDuesForm instanceFrm;
        FeeMonthlyReportModel _feeMonthlyReportModel;
        ClassSection _classSection;
        ClassType _classType;
        List<ClassTypeModel> _listClassType = new List<ClassTypeModel>();
        List<ClassSectionModel> _listSectionType = new List<ClassSectionModel>();
        string _appPath = Application.StartupPath + "\\";
        FeeReport _feeReport;
        public ReportClassWiseDuesForm()
        {
            InitializeComponent();

            datePickerReport.Format = DateTimePickerFormat.Custom;
            datePickerReport.Value = DateTime.Now;
            datePickerReport.CustomFormat = " dd.MM.yyyy";

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

        private void ReportClassWiseDuesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportClassWiseDuesForm.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(ddlClass.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Class.", "Fee Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GetStudentDetailsByClassReport();
            }
        }

        private void GetStudentDetailsByClassReport()
        {
            btnViewReport.Enabled = false;
            lblPleaseWait.Visible = true;
            try
            {
                int year = datePickerReport.Value.Year;
                int month = datePickerReport.Value.Month;

                _feeMonthlyReportModel = new FeeMonthlyReportModel
                {
                    ClassID = Convert.ToInt16(ddlClass.SelectedValue),
                    SectionID = Convert.ToInt16(ddlSection.SelectedValue) == 0 ? null : (short?)Convert.ToInt16(ddlSection.SelectedValue),
                    Month = (short)month,
                    Year = (short)year,
                };

                _feeReport = new FeeReport();


                DataSet dsDuesReport = _feeReport.GetStudentDuesDetailsByClass(_feeMonthlyReportModel);

                if (dsDuesReport != null && dsDuesReport.Tables[1].Rows.Count > 0)
                {
                    dsDuesReport.Tables[0].TableName = "School";
                    dsDuesReport.Tables[1].TableName = "StudentDues";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\StudentDuesReport.rpt");
                    rdoc.SetDataSource(dsDuesReport);
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
                MessageBox.Show("Error! Please contact to admin.", "Applicatin Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
