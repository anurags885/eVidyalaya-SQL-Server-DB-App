using School.App.Repository;
using SchoolModels;
using School.App.Repository;
using School.App.Repository.FeeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class StudentFineForm : DockContent
    {
        FineSettings fineSettings;
        StudentFineViewModel studentFineModel;
        ClassSection classSection;
        ClassType classType;
        List<FineTypeModel> listFineType;
        List<ClassSectionModel> listSection;
        List<ClassTypeModel> listClass;
        short ISBillPaid = 0;
        public static StudentFineForm instanceFrm;
        public StudentFineForm()
        {
            InitializeComponent();
            var font = new Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            gridStudent.ColumnHeadersDefaultCellStyle.Font = font;
            gridStudent.DefaultCellStyle.Font = font;
            gridStudent.AutoGenerateColumns = false;

            gridFine.ColumnHeadersDefaultCellStyle.Font = font;
            gridFine.DefaultCellStyle.Font = font;
            gridFine.AutoGenerateColumns = false;
        }
        private void BindDropDownControls()
        {
            fineSettings = new FineSettings();
            listFineType = fineSettings.GetFineType();

            classSection = new ClassSection();
            listSection = classSection.GetSectionDetails();

            classType = new ClassType();
            listClass = classType.GetClassDetails();

            if (listSection != null)
            {
                listSection.Add(new ClassSectionModel { ClassSectionID = 0, SectionName = "Select" });
                ddlCurrentSection.DataSource = listSection.OrderBy(x => x.ClassSectionID).ToList();
                ddlCurrentSection.DisplayMember = "SectionName";
                ddlCurrentSection.ValueMember = "ClassSectionID";
            }


            if (listFineType != null)
            {
                listFineType.Add(new FineTypeModel { FineTypeID = 0, FineType = "Select" });
                ddlFeeType.DataSource = listFineType.OrderBy(x => x.FineTypeID).ToList();
                ddlFeeType.DisplayMember = "FineType";
                ddlFeeType.ValueMember = "FineTypeID";
            }

            if (listClass != null)
            {
                listClass.Add(new ClassTypeModel { ClassID = 0, ClassName = "Select", Active = true });
                ddlCurrentClass.DataSource = listClass.OrderBy(x => x.ClassID).ToList();
                ddlCurrentClass.DisplayMember = "ClassName";
                ddlCurrentClass.ValueMember = "ClassID";
            }

            datePickerReport.Format = DateTimePickerFormat.Custom;
            datePickerReport.Value = DateTime.Now;
            datePickerReport.CustomFormat = "dd.MM.yyyy";
        }
        private bool Validation()
        {
            StringBuilder messageSB = new StringBuilder();

            if (Convert.ToSByte(ddlCurrentClass.SelectedValue) == 0)
                messageSB.Append("\u2022 Class is required.\n");

            if (Convert.ToSByte(ddlCurrentSection.SelectedValue) == 0)
                messageSB.Append("\u2022 Section is required.\n");

            if (Convert.ToSByte(ddlFeeType.SelectedValue) == 0)
                messageSB.Append("\u2022 Fee Type is required.\n");

            //if (!Common.ValidateDate(Convert.ToString(datePickerReport.Value)))
            //    messageSB.Append("\t\u2022 Date Should Be In Correct Format. (DD/MM/YYYY)\n");

            if (string.IsNullOrWhiteSpace(messageSB.ToString()))
            {
                return true;
            }
            else
            {
                ShowMessage(messageSB.ToString());
                //  lblError.Visible = true;
                //  lblError.Text = messageSB.ToString();

                return false;
            }
        }
        private void StudentFineForm_Load(object sender, EventArgs e)
        {
            BindDropDownControls();
        }
        private void BindStudentGrid(List<StudentFineViewModel> listStudent)
        {
            if (listStudent != null)
            {
                int index = 0;
                btnSave.Enabled = true;

                gridStudent.DataSource = listStudent;

                foreach (StudentFineViewModel list in listStudent)
                {
                    // DataGridViewCheckBoxCell colSelect = (DataGridViewCheckBoxCell)(gridStudent.Rows[index].Cells["colSelect"]);
                    DataGridViewTextBoxCell colRegistrationNo = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colRegistrationNo"]);
                    DataGridViewTextBoxCell colStudentName = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colStudentName"]);
                    DataGridViewTextBoxCell colStudentID = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colStudentID"]);

                    //colSelect.Value = list.FineTransactionID != 0 ? true : false;
                    colRegistrationNo.Value = list.RegistrationNo;
                    colStudentName.Value = list.StudentName;
                    colStudentID.Value = list.StudentID;
                    index++;
                }
            }
            else
            {
                btnSave.Enabled = false;
                //ShowMessage("No Record Found.");
                gridStudent.DataSource = null;
            }
        }
        private void BindFineGrid(List<StudentFineViewModel> listFine)
        {
            if (listFine != null)
            {
                int index = 0;
                btnSave.Enabled = true;
                gridFine.DataSource = listFine;

                foreach (StudentFineViewModel list in listFine)
                {
                    //  DataGridViewCheckBoxCell colSelectF = (DataGridViewCheckBoxCell)(gridFine.Rows[index].Cells["colSelectF"]);
                    DataGridViewTextBoxCell colRegistrationNoF = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colRegistrationNoF"]);
                    DataGridViewTextBoxCell colStudentNameF = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colStudentNameF"]);
                    DataGridViewTextBoxCell colFineAmountF = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colAmountF"]);
                    DataGridViewTextBoxCell colStudentIDF = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colStudentIDF"]);
                    DataGridViewTextBoxCell colFineTransactionIDF = (DataGridViewTextBoxCell)(gridFine.Rows[index].Cells["colFineTransactionIDF"]);
                    //

                    //colSelectF.Value = list.FineTransactionID != null && list.FineTransactionID != 0 ? true : false;
                    colRegistrationNoF.Value = list.RegistrationNo;
                    colStudentNameF.Value = list.StudentName;
                    colStudentIDF.Value = list.StudentID;
                    colFineTransactionIDF.Value = list.FineTransactionID;
                    colFineAmountF.Value = list.FineAmount == 0 ? null : list.FineAmount;
                    index++;
                }
            }
            else
            {
                btnSave.Enabled = false;
                // ShowMessage("No Record Found.");
                gridFine.DataSource = null;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                BindGridControlsOnSearch();
            }
        }
        private void BindGridControlsOnSearch()
        {
            gridStudent.DataSource = null;
            gridFine.DataSource = null;
            studentFineModel = new StudentFineViewModel();
            fineSettings = new FineSettings();

            studentFineModel.ClassID = Convert.ToInt16(ddlCurrentClass.SelectedValue);
            studentFineModel.SectionID = Convert.ToInt16(ddlCurrentSection.SelectedValue);
            studentFineModel.FineDate = Common.Convert_String_To_Date(datePickerReport.Text);
           // DateTime.ParseExact(datePickerReport.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            studentFineModel.FineTypeID = Convert.ToInt16(ddlFeeType.SelectedValue);

            studentFineModel = fineSettings.GetStudentFineDetails(studentFineModel, out ISBillPaid);

            BindStudentGrid(studentFineModel.ListStudent);
            BindFineGrid(studentFineModel.ListStudentFine);

            if (ISBillPaid == 1)
            {
                btnSave.Enabled = false;
                btnMoveLeft.Enabled = false;
                btnMoveRight.Enabled = false;
                lblError.Visible = true;
            }
            else
            {
                btnSave.Enabled = true;
                btnMoveLeft.Enabled = true;
                btnMoveRight.Enabled = true;
                lblError.Visible = false;
            }
        }
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                List<StudentFineViewModel> _listStudent = new List<StudentFineViewModel>();
                List<StudentFineViewModel> _listFine = new List<StudentFineViewModel>();

                _listStudent = ConvertStudentGridToList();
                _listFine = ConvertFineGridToList();

                if (_listStudent.Count > 0)
                {
                    var selectedRows = _listStudent.Where(x => x.IsSelected == true).ToList();
                    var unSelectedRows = _listStudent.Where(x => x.IsSelected == false).ToList();

                    _listFine.AddRange(selectedRows);
                    BindFineGrid(_listFine.OrderBy(x => x.StudentName).ToList());

                    //Remove Selected Rows From Student Grid
                    BindStudentGrid(unSelectedRows.OrderBy(x => x.StudentName).ToList());
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            try
            {
                List<StudentFineViewModel> _listStudent = new List<StudentFineViewModel>();
                List<StudentFineViewModel> _listFine = new List<StudentFineViewModel>();

                _listStudent = ConvertStudentGridToList();
                _listFine = ConvertFineGridToList();

                if (_listFine.Count > 0)
                {
                    var selectedRows = _listFine.Where(x => x.IsSelected == true).ToList();
                    _listStudent.AddRange(selectedRows);
                    BindStudentGrid(_listStudent.OrderBy(x => x.StudentName).ToList());

                    //Remove Selected Rows From Fine Grid
                    _listFine.RemoveAll(x => x.IsSelected == true);
                    BindFineGrid(_listFine.OrderBy(x => x.StudentName).ToList());
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void gridFine_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridFine.EndEdit();
            if (e.ColumnIndex == gridFine.Columns["colAmountF"].Index)
            {
                gridFine.BeginEdit(true);
                gridFine.CurrentCell = gridFine["colAmountF", e.RowIndex];
            }
        }
        private List<StudentFineViewModel> ConvertStudentGridToList()
        {
            List<StudentFineViewModel> _listStudent = new List<StudentFineViewModel>();
            //Convrting Student Grid To List
            foreach (DataGridViewRow rows in gridStudent.Rows)
            {
                _listStudent.Add(new StudentFineViewModel
                {
                    IsSelected = Convert.ToBoolean(rows.Cells["colSelect"].Value),
                    RegistrationNo = Convert.ToInt64(rows.Cells["colRegistrationNo"].Value),
                    StudentName = Convert.ToString(rows.Cells["colStudentName"].Value),
                    StudentID = Convert.ToInt64(rows.Cells["colStudentID"].Value)
                });
            }
            return _listStudent;
        }
        private List<StudentFineViewModel> ConvertFineGridToList()
        {
            List<StudentFineViewModel> _listFine = new List<StudentFineViewModel>();
            //Convrting Fine Grid To List
            foreach (DataGridViewRow rows in gridFine.Rows)
            {
                _listFine.Add(new StudentFineViewModel
                {
                    IsSelected = Convert.ToBoolean(rows.Cells["colSelectF"].Value),
                    FineTransactionID = Convert.ToInt64(rows.Cells["colFineTransactionIDF"].Value),
                    RegistrationNo = Convert.ToInt64(rows.Cells["colRegistrationNoF"].Value),
                    StudentName = Convert.ToString(rows.Cells["colStudentNameF"].Value),
                    StudentID = Convert.ToInt64(rows.Cells["colStudentIDF"].Value),
                    FineAmount = Convert.ToInt16(rows.Cells["colAmountF"].Value)
                });
            }
            return _listFine;
        }
        private void gridFine_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(colFinePaidAmount_KeyPress);
            if (gridFine.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                tb.MaxLength = 5;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(colFinePaidAmount_KeyPress);
                }
            }
        }
        private void colFinePaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumericValidation(e);
        }
        private string ConvertGridToXML(List<StudentFineViewModel> ListFeeSetting)
        {
            XElement xmlElements = new XElement("StudentFine", ListFeeSetting
            .Select(xmlchild => new XElement("Row",
            new XElement("FineTransactionID", xmlchild.FineTransactionID),
            new XElement("FineAmount", xmlchild.FineAmount),
            new XElement("FineDate", Common.Convert_String_To_Date(datePickerReport.Text)),
            //DateTime.ParseExact(datePickerReport.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)),
            new XElement("FineTypeID", Convert.ToInt16(ddlFeeType.SelectedValue)),
            new XElement("StudentID", xmlchild.StudentID)
            )));
            return Convert.ToString(xmlElements);
        }
        private bool gridFineValidation()
        {
            int textBlank = 0;
            bool returnValue = false;
            if (gridFine.Rows.Count == 0)
            {
                ShowMessage("Please Select Record In Fine List.");
                returnValue = false;
            }
            else
            {
                foreach (DataGridViewRow row in gridFine.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(row.Cells["colAmountF"].Value)))
                    {
                        textBlank++;
                    }
                }

                if (textBlank > 0)
                {
                    ShowMessage("Amount Is Required.");
                    returnValue = false;
                }

                if (textBlank == 0)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridFineValidation())
            {
                fineSettings = new FineSettings();
                string studentFineXML = ConvertGridToXML(ConvertFineGridToList());
                short result = fineSettings.SaveStudentFine(studentFineXML);
                switch (result)
                {
                    case 1:
                        ShowMessage("Record Saved Successfully.");
                        BindGridControlsOnSearch();
                        btnSave.Enabled = false;
                        break;
                    case -1:
                        ShowMessage("Error: Please Contact To Admin.");
                        break;
                }
            }
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Student Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void StudentFineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudentFineForm.instanceFrm = null;
        }
    }
}
