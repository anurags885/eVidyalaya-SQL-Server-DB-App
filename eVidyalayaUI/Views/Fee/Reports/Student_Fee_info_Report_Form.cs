using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class Student_Fee_info_Report_Form : DockContent
    {
        internal static Student_Fee_info_Report_Form instanceFrm;
        string _appPath = Application.StartupPath + "\\";
        Student_Fee_Setting _student_Fee_Setting;

        public Student_Fee_info_Report_Form()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            Bind_Academic_Year_Drop_Down();
            Bind_Student_Fee_Info_Type_Drop_Down();
        }
        private void Get_Student_Fee_Info_Report()
        {
            try
            {
                _student_Fee_Setting = new Student_Fee_Setting();
                string setting_Code = Convert.ToString(ddlSettingType.SelectedValue);
                Int32 academic_Year = Convert.ToInt32(ddlAcademicYear.SelectedValue);

                DataSet dsPartialReport = _student_Fee_Setting.Get_Student_Fee_Info_Report(academic_Year, setting_Code);

                if (dsPartialReport != null && dsPartialReport.Tables[1].Rows.Count > 0)
                {
                    dsPartialReport.Tables[0].TableName = "DT_Student_Fee_Info";
                    dsPartialReport.Tables[1].TableName = "DT_School";

                    ReportDocument rdoc = new ReportDocument();
                    rdoc.Load(_appPath + "Reports\\Student_Fee_Info_Report.rpt");
                    rdoc.SetDataSource(dsPartialReport);

                    //rdoc.SetParameterValue("Heading_Text", ddlSettingType.SelectedText);
                    //rdoc.SetParameterValue("Fee_Code", Convert.ToString(ddlSettingType.SelectedValue));
                    //crystalReportViewer.ParameterFieldInfo.Clear();

                    crystalReportViewer.ReportSource = rdoc;
                    rdoc.Refresh();
                    crystalReportViewer.Refresh();
                    crystalReportViewer.Show();
                    crystalReportViewer.Visible = true;
                }
                else
                {
                    crystalReportViewer.Visible = false;
                    MessageBox.Show("No Result Found.", "Partial Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void PartialFeeReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Student_Fee_info_Report_Form.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void Bind_Student_Fee_Info_Type_Drop_Down()
        {
            List<Student_Fee_Info_Type> list_Student_Info = new List<Student_Fee_Info_Type>();
            list_Student_Info.Add(new Student_Fee_Info_Type { Fee_Info_Code = "0", Fee_Info_Type = "Select" });
            _student_Fee_Setting = new Student_Fee_Setting();

            List<Student_Fee_Info_Type> list_Student_Info_Output = _student_Fee_Setting.Get_Student_Fee_Info_Type(true);
            if (list_Student_Info_Output != null)
            {
                list_Student_Info.AddRange(list_Student_Info_Output);
            }

            ddlSettingType.DataSource = list_Student_Info;
            ddlSettingType.DisplayMember = "Fee_Info_Type";
            ddlSettingType.ValueMember = "Fee_Info_Code";
        }
        private void Bind_Academic_Year_Drop_Down()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();
            dicSession = Common.Get_Academic_Year_List();
            ddlAcademicYear.DataSource = dicSession.ToList();
            ddlAcademicYear.DisplayMember = "value";
            ddlAcademicYear.ValueMember = "key";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validate_Controls())
            {
                Get_Student_Fee_Info_Report();
            }
        }
        private bool Validate_Controls()
        {
            StringBuilder sbMessage = new StringBuilder();

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
                sbMessage.Append("\u2022 Academic year is required.\n");

            if (Convert.ToString(ddlSettingType.SelectedValue) == "0")
                sbMessage.Append("\u2022 Setting Type is required.\n");

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                MessageBox.Show(sbMessage.ToString(), "Student Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
