using School.App.Repository;
using SchoolModels;
using School.App.Repository;
using School.App.Repository.StudentViewModels;
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
    public partial class StudentPromotionForm : DockContent
    {
        public static StudentPromotionForm instanceFrm;
        StringBuilder messageSB;
        StudentPromotion studentPromotion;
        StudentPromotionViewModel studentPromotionViewModel;
        ClassSection classSection;
        ClassType classType;
        List<ClassSectionModel> listSection;
        List<ClassTypeModel> listClass;
        public StudentPromotionForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            ddlSelectAllClass.SelectedIndexChanged -= new EventHandler(ddlSelectAllClass_SelectedIndexChanged);
            ControlDisplaySettings();
            BindDropDownControls();
            ddlSelectAllClass.SelectedIndexChanged += new EventHandler(ddlSelectAllClass_SelectedIndexChanged);

            // ddlFromAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            Bind_Academic_Year_Drop_Down();
            //  ddlFromAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);
        }

        #region Methods
        private void ControlDisplaySettings()
        {
            var font = new Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            gridStudent.ColumnHeadersDefaultCellStyle.Font = font;
            gridStudent.DefaultCellStyle.Font = font;
            gridStudent.AutoGenerateColumns = false;

            gridStudentPromotionHistory.ColumnHeadersDefaultCellStyle.Font = font;
            gridStudentPromotionHistory.DefaultCellStyle.Font = font;
            gridStudentPromotionHistory.AutoGenerateColumns = false;
        }
        private bool Validation()
        {
            messageSB = new StringBuilder();

            if (Convert.ToInt32(ddlFromAcademicYear.SelectedValue) == 0)
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
                ShowMessage(messageSB.ToString());
                return false;
            }
        }
        private void BindDropDownControls()
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

                colDDLSection.DataSource = listSection.OrderBy(x => x.ClassSectionID).ToList();
                colDDLSection.DisplayMember = "SectionName";
                colDDLSection.ValueMember = "ClassSectionID";
            }

            if (listClass != null)
            {
                listClass.Add(new ClassTypeModel { ClassID = 0, ClassName = "Select", Active = true });
                ddlClass.DataSource = listClass.OrderBy(x => x.ClassID).ToList();
                ddlClass.DisplayMember = "ClassName";
                ddlClass.ValueMember = "ClassID";

                colDDLClass.DataSource = listClass.OrderBy(x => x.ClassID).ToList();
                colDDLClass.DisplayMember = "ClassName";
                colDDLClass.ValueMember = "ClassID";

                ddlSelectAllClass.DataSource = listClass.OrderBy(x => x.ClassID).ToList();
                ddlSelectAllClass.DisplayMember = "ClassName";
                ddlSelectAllClass.ValueMember = "ClassID";
            }
        }
        private void BindStudentGrid(List<StudentPromotionViewModel> studentList)
        {
            if (studentList != null)
            {
                int index = 0;
                //panelSaveControls.Enabled = false;
                gridStudent.DataSource = studentList;

                foreach (StudentPromotionViewModel list in studentList)
                {
                    DataGridViewTextBoxCell colRegistrationNo = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colRegistrationNo"]);
                    DataGridViewTextBoxCell colStudentName = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colStudentName"]);
                    DataGridViewTextBoxCell colHiddenClassID = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colHiddenClassID"]);
                    DataGridViewTextBoxCell colHiddenSectionID = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colHiddenSectionID"]);
                    DataGridViewTextBoxCell colHiddenStudentID = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colHiddenStudentID"]);
                    DataGridViewTextBoxCell colCurrentClass = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colCurrentClass"]);
                    DataGridViewTextBoxCell colSection = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colSection"]);
                    DataGridViewTextBoxCell colStudentPromotionID = (DataGridViewTextBoxCell)(gridStudent.Rows[index].Cells["colStudentPromotionID"]);

                    colHiddenStudentID.Value = list.StudentID;
                    colRegistrationNo.Value = list.RegistrationNo;
                    colStudentName.Value = list.StudentName;
                    colHiddenClassID.Value = list.FromClassID;
                    colHiddenSectionID.Value = list.FromSectionID;
                    colCurrentClass.Value = list.FromClassName;
                    colSection.Value = list.FromSectionName;
                    colStudentPromotionID.Value = list.PromotionID == null ? null : list.PromotionID;
                    index++;
                }
            }
            else
            {
                //panelSaveControls.Enabled = false;
                gridStudent.DataSource = null;
            }
        }
        private void BindStudentPromotionGrid(List<StudentPromotionViewModel> studentList)
        {
            BindingSource bindingSource = new BindingSource();
            // BindingList<StudentPromotionViewModel> studentBindingList = new BindingList<StudentPromotionViewModel>(studentList);
            bindingSource.DataSource = studentList;
            if (studentList != null)
            {
                int index = 0;
                gridStudentPromotionHistory.DataSource = bindingSource;
                foreach (StudentPromotionViewModel model in studentList)
                {
                    DataGridViewCheckBoxCell colSelectT = (DataGridViewCheckBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colSelectT"]);
                    DataGridViewTextBoxCell colHistoryRegistrationNo = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHistoryRegistrationNo"]);
                    DataGridViewTextBoxCell colHistoryStudentName = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHistoryStudentName"]);
                    DataGridViewTextBoxCell colHistoryFromClass = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHistoryFromClass"]);
                    DataGridViewTextBoxCell colHistoryFromSection = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHistoryFromSection"]);
                    DataGridViewTextBoxCell colHdnFromClassID = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHdnFromClass"]);
                    DataGridViewTextBoxCell colHdnFromSectionID = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHdnFromSection"]);
                    DataGridViewLinkCell colDelete = (DataGridViewLinkCell)(gridStudentPromotionHistory.Rows[index].Cells["colDelete"]);
                    DataGridViewComboBoxCell colDDLClass = (DataGridViewComboBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colDDLClass"]);
                    DataGridViewComboBoxCell colDDLSection = (DataGridViewComboBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colDDLSection"]);
                    DataGridViewTextBoxCell colPromotionID = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colPromotionID"]);
                    DataGridViewTextBoxCell colHiddenPromotedStudenID = (DataGridViewTextBoxCell)(gridStudentPromotionHistory.Rows[index].Cells["colHiddenPromotedStudenID"]);

                    colHiddenPromotedStudenID.Value = model.StudentID;
                    colDelete.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colPromotionID.Value = model.PromotionID;
                    colHistoryRegistrationNo.Value = model.RegistrationNo;
                    colHistoryStudentName.Value = model.StudentName;
                    colHistoryFromClass.Value = model.FromClassName;
                    colHdnFromClassID.Value = model.FromClassID;
                    colHdnFromSectionID.Value = model.FromSectionID;
                    colHistoryFromSection.Value = model.FromSectionName;
                    if (model.PromotionID == null)
                    {
                        colDelete.Value = "x";
                        colDelete.ToolTipText = "Delete record from table.";
                    }
                    else
                    {
                        colDelete.Value = "Delete";
                        colDelete.ToolTipText = "Delete record from database.";
                        colSelectT.ReadOnly = true;
                        colSelectT.Style.BackColor = Color.Red;
                        //gridStudentPromotionHistory.Rows[index].Cells["colSelectT"].ReadOnly = true;
                    }


                    // colDelete.Value = model.PromotionID == null ? "x" : "Delete";
                    // colDelete.ToolTipText=model.PromotionID == null ? "Delete record from table." : "Delete record from database.";
                    colDDLClass.Value = model.ToClassID == null ? 0 : model.ToClassID;
                    colDDLSection.Value = model.ToSectionID == null ? model.FromSectionID : model.ToSectionID;
                    index++;
                }
                gridStudentPromotionHistory.ClearSelection();
            }
            else
            {
                //btnPrint.Visible = false;
                //panelSaveControls.Enabled = false;
                //   gridStudent.DataSource = null;
            }
        }
        private List<StudentPromotionViewModel> ConvertPromotionGridToList()
        {
            List<StudentPromotionViewModel> listPromoted = new List<StudentPromotionViewModel>();
            //Convrting Promoted Grid To List
            foreach (DataGridViewRow rows in gridStudentPromotionHistory.Rows)
            {
                listPromoted.Add(new StudentPromotionViewModel
                {
                    IsSelected = Convert.ToBoolean(rows.Cells["colSelectT"].Value),
                    RegistrationNo = Convert.ToInt64(rows.Cells["colHistoryRegistrationNo"].Value),
                    StudentName = Convert.ToString(rows.Cells["colHistoryStudentName"].Value),
                    StudentID = Convert.ToInt64(rows.Cells["colHiddenPromotedStudenID"].Value),
                    FromSectionID = Convert.ToInt16(rows.Cells["colHdnFromSection"].Value),
                    FromClassID = Convert.ToInt16(rows.Cells["colHdnFromClass"].Value),
                    FromClassName = Convert.ToString(rows.Cells["colHistoryFromClass"].Value),
                    FromSectionName = Convert.ToString(rows.Cells["colHistoryFromSection"].Value),
                    ToClassID = Convert.ToInt16(rows.Cells["colDDLClass"].Value),
                    ToSectionID = Convert.ToInt16(rows.Cells["colDDLSection"].Value),
                    PromotionID = Convert.ToInt64(rows.Cells["colPromotionID"].Value) == 0 ? null : (long?)Convert.ToInt64(rows.Cells["colPromotionID"].Value),
                    IsDeleted = false
                });
            }
            return listPromoted;
        }
        private List<StudentPromotionViewModel> ConvertStudentGridToList()
        {
            List<StudentPromotionViewModel> _listStudent = new List<StudentPromotionViewModel>();
            //Convrting Student Grid To List
            foreach (DataGridViewRow rows in gridStudent.Rows)
            {
                _listStudent.Add(new StudentPromotionViewModel
                {
                    IsSelected = Convert.ToBoolean(rows.Cells["colSelect"].Value),
                    RegistrationNo = Convert.ToInt64(rows.Cells["colRegistrationNo"].Value),
                    StudentName = Convert.ToString(rows.Cells["colStudentName"].Value),
                    StudentID = Convert.ToInt64(rows.Cells["colHiddenStudentID"].Value),
                    FromClassID = Convert.ToInt16(rows.Cells["colHiddenClassID"].Value),
                    FromSectionID = Convert.ToInt16(rows.Cells["colHiddenSectionID"].Value),
                    FromClassName = Convert.ToString(rows.Cells["colCurrentClass"].Value),
                    FromSectionName = Convert.ToString(rows.Cells["colSection"].Value),
                    PromotionID = Convert.ToInt64(rows.Cells["colStudentPromotionID"].Value) == 0 ? null : (long?)Convert.ToInt64(rows.Cells["colStudentPromotionID"].Value)
                    //ToClassID = 0,
                    //ToSectionID = 0
                });
            }
            return _listStudent;
        }
        private void AddDeletedRowsToStudentGrid(StudentPromotionViewModel deletedRow)
        {
            List<StudentPromotionViewModel> _listStudent = new List<StudentPromotionViewModel>();
            _listStudent = ConvertStudentGridToList();
            _listStudent.Add(deletedRow);
            BindStudentGrid(_listStudent.OrderBy(x => x.StudentName).ToList());
        }
        private bool ValidatePromoteStudent()
        {
            messageSB = new StringBuilder();
            bool isValid = true;
            int blankClassID = 0;
            int blankSectionID = 0;
            int sameClassID = 0;
            int lessClassID = 0;

            if (Convert.ToInt32(ddlFromAcademicYear.SelectedValue) == 0)
                messageSB.Append("\u2022 From Academic Year is required.\n");
            if (Convert.ToSByte(ddlClass.SelectedValue) == 0)
                messageSB.Append("\u2022 Class is required.\n");
            if (Convert.ToSByte(ddlSection.SelectedValue) == 0)
                messageSB.Append("\u2022 Section is required.\n");
            if (Convert.ToInt32(ddlToAcademicYear.SelectedValue) == 0)
                messageSB.Append("\u2022 To Academic Year is required.\n");

            List<StudentPromotionViewModel> listPromote = ConvertPromotionGridToList();
            if (listPromote.Count > 0)
            {
                //Checking for blank ClassID
                blankClassID = listPromote.Where(x => x.ToClassID == 0).GroupBy(x => x.ToClassID)
                             .Where(g => g.Count() >= 1)
                             .Select(g => g.Key)
                             .ToList().Count();

                //Checking for blank SectionID
                blankSectionID = listPromote.Where(x => x.ToSectionID == 0).GroupBy(x => x.ToSectionID)
                             .Where(g => g.Count() >= 1)
                             .Select(g => g.Key)
                             .ToList().Count();

                //Checking for Same Class
                sameClassID = listPromote.Where(x => x.ToClassID == x.FromClassID).GroupBy(x => x.ToClassID)
                             .Where(g => g.Count() >= 1)
                             .Select(g => g.Key)
                             .ToList().Count();

                //Checking for less Class ID
                lessClassID = listPromote.Where(x => x.ToClassID < x.FromClassID).GroupBy(x => x.ToClassID)
                             .Where(g => g.Count() >= 1)
                             .Select(g => g.Key)
                             .ToList().Count();



                if (blankClassID != 0)
                    messageSB.Append("\u2022 Please select To Class. To Class is required.\n");
                if (blankSectionID != 0)
                    messageSB.Append("\u2022 Please select To Section. To Section is required.\n");
                if (sameClassID != 0)
                    messageSB.Append("\u2022 Please select different Class from current Class.\n");
                if (blankClassID == 0 && lessClassID != 0)
                    messageSB.Append("\u2022 To Class should not be less than current Class.");
            }
            else
                messageSB.Append("\u2022 Please add records to student promotion table.");

            if (!string.IsNullOrEmpty(messageSB.ToString()))
            {
                MessageBox.Show("Validation fail! To continue, please correct below error:\n\n" + messageSB, "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            return isValid;
        }
        private string ConvertGridToXML(List<StudentPromotionViewModel> ListPromoteStudent)
        {
            XElement xmlElements = new XElement("PromoteStudent", ListPromoteStudent
            .Select(xmlchild => new XElement("Row",
            new XElement("PromotionID", xmlchild.PromotionID),
            new XElement("StudentID", xmlchild.StudentID),
            new XElement("FromClassID", xmlchild.FromClassID),
            new XElement("FromSectionID", xmlchild.FromSectionID),
            new XElement("ToClassID", xmlchild.ToClassID),
            new XElement("ToSectionID", xmlchild.ToSectionID),
            new XElement("From_Academic_Year", Convert.ToInt32(ddlFromAcademicYear.SelectedValue)),
            new XElement("To_Academic_Year", Convert.ToInt32(ddlToAcademicYear.SelectedValue)),
            new XElement("IsDeleted", xmlchild.IsDeleted))));
            return Convert.ToString(xmlElements);
        }
        private void GetStudentPromotionDetails()
        {
            studentPromotion = new StudentPromotion();

            studentPromotionViewModel = studentPromotion.GetStudentPromotionDetails(
            Convert.ToInt16(ddlClass.SelectedValue),
            Convert.ToInt16(ddlSection.SelectedValue),
            Convert.ToInt32(ddlFromAcademicYear.SelectedValue));

            BindStudentGrid(studentPromotionViewModel.ListStudent);
            BindStudentPromotionGrid(studentPromotionViewModel.ListStudentPromotion);
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Student Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SavePromotionStudent(string promoteStudentXML)
        {
            try
            {
                messageSB = new StringBuilder();
                studentPromotion = new StudentPromotion();
                short result = studentPromotion.SavePromotionStudent(promoteStudentXML);
                switch (result)
                {
                    case 1:
                        messageSB.Append("\u2022 Record successfully saved.\n");
                        break;
                    case -1:
                        messageSB.Append("\u2022 Error in saving records.\n");
                        break;
                }
                if (!string.IsNullOrEmpty(messageSB.ToString()))
                    MessageBox.Show(messageSB.ToString(), "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeletePromotionStudent(string promoteStudentXML)
        {
            try
            {
                messageSB = new StringBuilder();
                studentPromotion = new StudentPromotion();
                short result = studentPromotion.SavePromotionStudent(promoteStudentXML);
                switch (result)
                {
                    case 1:
                        messageSB.Append("\u2022 Record successfully deleted.\n");
                        break;
                    case -1:
                        messageSB.Append("\u2022 Error in deleting records.\n");
                        break;
                }
                if (!string.IsNullOrEmpty(messageSB.ToString()))
                    MessageBox.Show(messageSB.ToString(), "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Please contact to admin.", "Promote Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridStudent.DataSource = null;
            gridStudentPromotionHistory.DataSource = null;
            if (Validation())
            {
                GetStudentPromotionDetails();

                //if (gridStudent != null && gridStudent.Rows.Count > 0)
                //    //panelSaveControls.Enabled = true;
                //else
                //    //  panelSaveControls.Enabled = false;
            }
        }
        private void StudentPromotionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudentPromotionForm.instanceFrm = null;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidatePromoteStudent())
            {
                SavePromotionStudent(ConvertGridToXML(ConvertPromotionGridToList()));
            }
        }
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                List<StudentPromotionViewModel> listStudent = new List<StudentPromotionViewModel>();
                List<StudentPromotionViewModel> listPromoted = new List<StudentPromotionViewModel>();
                listStudent = ConvertStudentGridToList();
                listPromoted = ConvertPromotionGridToList();

                if (listStudent.Count > 0)
                {
                    var selectedRows = listStudent.Where(x => x.IsSelected == true).ToList();
                    var unSelectedRows = listStudent.Where(x => x.IsSelected == false).ToList();

                    listPromoted.AddRange(selectedRows);
                    BindStudentPromotionGrid(listPromoted.OrderBy(x => x.StudentName).ToList());

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
                List<StudentPromotionViewModel> _listStudent = new List<StudentPromotionViewModel>();
                List<StudentPromotionViewModel> _listPromotedStudent = new List<StudentPromotionViewModel>();

                _listStudent = ConvertStudentGridToList();
                _listPromotedStudent = ConvertPromotionGridToList();

                if (_listPromotedStudent.Count > 0)
                {
                    var selectedRows = _listPromotedStudent.Where(x => x.IsSelected == true).ToList();
                    _listStudent.AddRange(selectedRows);
                    BindStudentGrid(_listStudent.OrderBy(x => x.StudentName).ToList());

                    //Remove Selected Rows From Promoted Grid
                    _listPromotedStudent.RemoveAll(x => x.IsSelected == true);
                    BindStudentPromotionGrid(_listPromotedStudent.OrderBy(x => x.StudentName).ToList());
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridStudentPromotionHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 7)
            {
                try
                {
                    StudentPromotionViewModel deletedRow = (StudentPromotionViewModel)gridStudentPromotionHistory.Rows[rowIndex].DataBoundItem;
                    long? colPromotionID = Convert.ToInt64(gridStudentPromotionHistory.Rows[rowIndex].Cells["colPromotionID"].Value);
                    if (colPromotionID == 0)
                    {
                        AddDeletedRowsToStudentGrid(deletedRow);
                        gridStudentPromotionHistory.Rows.RemoveAt(rowIndex);
                    }
                    if (colPromotionID != 0)
                    {
                        DialogResult result = MessageBox.Show("Are you sure to delete this record from database?" +
                            "\n\n Caution: \n \u2022 Deleting this record may affect monthly fee." +
                            "\n \u2022 Deleting this record will revert the class of student in previous state.",
                            "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            deletedRow.IsDeleted = true;
                            List<StudentPromotionViewModel> listDeletedRow = new List<StudentPromotionViewModel>();
                            listDeletedRow.Add(deletedRow);
                            DeletePromotionStudent(ConvertGridToXML(listDeletedRow));
                            gridStudentPromotionHistory.Rows.RemoveAt(rowIndex);
                            AddDeletedRowsToStudentGrid(deletedRow);
                        }
                    }
                    gridStudentPromotionHistory.ClearSelection();
                }
                catch (Exception ex)
                { }
                finally
                { }
            }
        }
        private void ddlSelectAllClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridStudentPromotionHistory.Rows.Count > 0)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource = (BindingSource)gridStudentPromotionHistory.DataSource;
                    List<StudentPromotionViewModel> list = (List<StudentPromotionViewModel>)bindingSource.DataSource;
                    list = list.Select(x => { x.ToClassID = Convert.ToInt16(ddlSelectAllClass.SelectedValue); return x; }).ToList();
                    BindStudentPromotionGrid(list);
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void Bind_Academic_Year_Drop_Down()
        {
            Dictionary<int, string> dic_From_Session = new Dictionary<int, string>();

            dic_From_Session.Add(0, "Select");
            dic_From_Session.Add(
                  Convert.ToInt32(Convert.ToString(DateTime.Today.AddYears(-1).Year) + Convert.ToString(DateTime.Today.Year))
                  , DateTime.Today.AddYears(-1).Year.ToString() + "-" + DateTime.Today.Year.ToString());

            ddlFromAcademicYear.DataSource = dic_From_Session.ToList();
            ddlFromAcademicYear.DisplayMember = "value";
            ddlFromAcademicYear.ValueMember = "key";

            Dictionary<int, string> dic_To_Session = new Dictionary<int, string>();
            dic_To_Session.Add(0, "Select");
            dic_To_Session.Add(
              Convert.ToInt32(Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.AddYears(1).Year)),
              DateTime.Today.Year.ToString() + "-" + DateTime.Today.AddYears(1).Year.ToString());

            ddlToAcademicYear.DataSource = dic_To_Session.ToList();
            ddlToAcademicYear.DisplayMember = "value";
            ddlToAcademicYear.ValueMember = "key";
        }
    }
}
/* 
 * Implement INotifyPropertyChanged in Windows Forms and GridView
 * https://vivekcek.wordpress.com/2013/05/03/implement-inotifypropertychanged-in-windows-forms-and-gridview/
 * Convert IList<T> to BindingList<T>
 * https://stackoverflow.com/questions/14953461/convert-ilistt-to-bindinglistt */
