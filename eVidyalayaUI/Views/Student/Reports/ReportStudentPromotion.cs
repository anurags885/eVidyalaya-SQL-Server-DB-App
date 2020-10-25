using School.App.Repository;
using CrystalDecisions.CrystalReports.Engine;
using School.App.Repository;
using System;
using System.Data;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SchoolModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace eVidyalaya
{
    public partial class ReportStudentPromotion : DockContent
    {
        public static ReportStudentPromotion instanceFrm;
        //This is used for close form if record not found, In this case isRecordFound is false;
        public static bool isRecordFound = true;
        string _appPath = Application.StartupPath + "\\";
        StudentPromotion _studentPromotion;
        ClassSection classSection;
        ClassType classType;
        List<ClassSectionModel> listSection;
        List<ClassTypeModel> listClass;
        public ReportStudentPromotion()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            Bind_DropDown_Controls();
            maskedFromAcademicYear.Focus();
        }
        private void ReportStudentPromotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportStudentPromotion.instanceFrm = null;
        }
        private void GetPurchasesReportFee(short ClassID, short SectionID, int From_Academic_Year)
        {
            try
            {
                _studentPromotion = new StudentPromotion();

                DataSet dsReport = _studentPromotion.GetStudentPromotionReport(ClassID, SectionID, From_Academic_Year);

                if (dsReport != null && dsReport.Tables[0].Rows.Count > 0)
                {
                    ReportStudentPromotion.isRecordFound = true;

                    dsReport.Tables[0].TableName = "StudentPromotion";
                    dsReport.Tables[1].TableName = "School";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\StudentPromotionReport.rpt");
                    rdoc.SetDataSource(dsReport);
                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = false;
                    ReportStudentPromotion.isRecordFound = false;
                    MessageBox.Show("No Result Found.", "Student Promotion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void Bind_DropDown_Controls()
        {
            classSection = new ClassSection();
            listSection = classSection.GetSectionDetails();

            classType = new ClassType();
            listClass = classType.GetClassDetails();

            if (listSection != null)
            {
                listSection.Add(new ClassSectionModel { ClassSectionID = 0, SectionName = "Select" });
                ddlSection.DataSource = listSection.OrderBy(x => x.ClassSectionID).ToList();
                ddlSection.DisplayMember = "SectionName";
                ddlSection.ValueMember = "ClassSectionID";
            }

            if (listClass != null)
            {
                listClass.Add(new ClassTypeModel { ClassID = 0, ClassName = "Select", Active = true });
                ddlClass.DataSource = listClass.OrderBy(x => x.ClassID).ToList();
                ddlClass.DisplayMember = "ClassName";
                ddlClass.ValueMember = "ClassID";
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int from_Academic_Year = Convert.ToInt32(maskedFromAcademicYear.Text.Replace("-", ""));
                GetPurchasesReportFee(
                    Convert.ToInt16(ddlClass.SelectedValue), 
                    Convert.ToInt16(ddlSection.SelectedValue), from_Academic_Year);
            }
        }
        private bool Validation()
        {
            StringBuilder messageSB = new StringBuilder();

            if (!maskedFromAcademicYear.MaskFull)
                messageSB.Append("\u2022 From Academic Year is required.\n");

            if (Convert.ToSByte(ddlClass.SelectedValue) == 0)
                messageSB.Append("\u2022 Class is required.\n");

            if (Convert.ToSByte(ddlSection.SelectedValue) == 0)
                messageSB.Append("\u2022 Section is required.\n");

            if (string.IsNullOrWhiteSpace(messageSB.ToString()))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Validation fail! To continue, please correct below error:\n\n" + messageSB, "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
