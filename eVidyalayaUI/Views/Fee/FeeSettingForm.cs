using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using School.App.Repository;
using SchoolModels;
using System.Xml.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class FeeSettingForm : DockContent
    {
        // FeeSettingModel 
        FeeType _feetype;
        FeeSetting _feeSetting;
        string xmlString = null;
        public static FeeSettingForm instanceFrm;
        public FeeSettingForm()
        {
            InitializeComponent();
            ChangeGridSetting();
            BindFeeTypeDropDownList();
            this.KeyPreview = true;
            #region Shortcut Keys Description
            StringBuilder sbShortCutKeys = new StringBuilder();
            sbShortCutKeys.Append("Use following shortcut keys :\n")
                .Append("\t\u2022 Load: Ctrl + L \n")
                .Append("\t\u2022 Add New Row: Ctrl + N \n")
                .Append("\t\u2022 Save: Ctrl + S \n");
            lblShortCutKeys.Text = sbShortCutKeys.ToString();
            #endregion

            ddlAcademicYear.SelectedIndexChanged -= new EventHandler(ddlAcademicYear_SelectedIndexChanged);
            Bind_Academic_Year_Drop_Down();
            ddlAcademicYear.SelectedIndexChanged += new EventHandler(ddlAcademicYear_SelectedIndexChanged);
        }
        private void BindFeeSettingGrid(int Academic_Year)
        {
            _feeSetting = new FeeSetting();
            List<FeeSettingModel> _listFeeSettingModel = _feeSetting.GetFeeSetting(Academic_Year);

            if (_listFeeSettingModel != null && _listFeeSettingModel.Count > 0)
            {
                //   gridFeeSetting.DataSource = bindingSource; //_listFeeSettingModel.ToList();
                BindGridContols(_listFeeSettingModel);
            }
            else
            {
                DialogResult dResult = MessageBox.Show("There is no record for this academic year.\nDo you want to copy previous academic year data?", "Fee Setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Copy_Previous_Academic_Year_Setting();
                }
            }
        }
        private void AddBlankRows()
        {
            if (colFeeType.Items.Count == 0)
            {
                MessageBox.Show("There Is No Fee Type Exists.\nPlease Add Fee Type First.", "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<FeeSettingModel> _gridRows = new List<FeeSettingModel>();
            List<FeeSettingModel> _gridBlankRows = new List<FeeSettingModel>();

            #region BlankRows
            _gridBlankRows.Add(new FeeSettingModel
            {
                FeeSettingID = 0,
                FeeTypeID = 0,
                January = false,
                February = false,
                March = false,
                April = false,
                May = false,
                June = false,
                July = false,
                August = false,
                September = false,
                October = false,
                November = false,
                December = false,
                OneTime = false
            });
            #endregion

            #region GridWithData
            if (gridFeeSetting.Rows.Count > 0)
            {
                foreach (DataGridViewRow rows in gridFeeSetting.Rows)
                {
                    _gridRows.Add(new FeeSettingModel
                    {
                        FeeSettingID = Convert.ToInt64(rows.Cells["colFeeSettingID"].Value),
                        FeeTypeID = Convert.ToInt16(rows.Cells["colFeeType"].Value),
                        January = Convert.ToBoolean(rows.Cells["colJan"].Value),
                        February = Convert.ToBoolean(rows.Cells["colFeb"].Value),
                        March = Convert.ToBoolean(rows.Cells["colMar"].Value),
                        April = Convert.ToBoolean(rows.Cells["colApr"].Value),
                        May = Convert.ToBoolean(rows.Cells["colMay"].Value),
                        June = Convert.ToBoolean(rows.Cells["colJun"].Value),
                        July = Convert.ToBoolean(rows.Cells["colJul"].Value),
                        August = Convert.ToBoolean(rows.Cells["colAug"].Value),
                        September = Convert.ToBoolean(rows.Cells["colSep"].Value),
                        October = Convert.ToBoolean(rows.Cells["colOct"].Value),
                        November = Convert.ToBoolean(rows.Cells["colNov"].Value),
                        December = Convert.ToBoolean(rows.Cells["colDec"].Value),
                        OneTime = Convert.ToBoolean(rows.Cells["colOneTime"].Value)
                    });
                }
            }
            #endregion

            #region Set Value To Grid
            if (gridFeeSetting.Rows.Count != colFeeType.Items.Count - 1)
            {
                _gridRows.AddRange(_gridBlankRows);
            }
            //  gridFeeSetting.DataSource = _gridRows.ToList();
            BindGridContols(_gridRows);
            #endregion
        }
        private void BindGridContols(List<FeeSettingModel> listFeeSettingmodel)
        {
            try
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = listFeeSettingmodel;
                gridFeeSetting.DataSource = bindingSource;
                int index = 0;
                foreach (FeeSettingModel feeSettingModel in listFeeSettingmodel)
                {
                    DataGridViewTextBoxCell txtFeeSetting = (DataGridViewTextBoxCell)(gridFeeSetting.Rows[index].Cells["colFeeSettingID"]);
                    DataGridViewComboBoxCell ddlFeeType = (DataGridViewComboBoxCell)(gridFeeSetting.Rows[index].Cells["colFeeType"]);
                    DataGridViewCheckBoxCell chkJan = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colJan"]);
                    DataGridViewCheckBoxCell chkFeb = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colFeb"]);
                    DataGridViewCheckBoxCell chkMar = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colMar"]);
                    DataGridViewCheckBoxCell chkApr = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colApr"]);
                    DataGridViewCheckBoxCell chkMay = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colMay"]);
                    DataGridViewCheckBoxCell chkJun = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colJun"]);
                    DataGridViewCheckBoxCell chkJul = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colJul"]);
                    DataGridViewCheckBoxCell chkAug = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colAug"]);
                    DataGridViewCheckBoxCell chkSep = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colSep"]);
                    DataGridViewCheckBoxCell chkOct = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colOct"]);
                    DataGridViewCheckBoxCell chkNov = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colNov"]);
                    DataGridViewCheckBoxCell chkDec = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colDec"]);
                    DataGridViewCheckBoxCell chkOneTime = (DataGridViewCheckBoxCell)(gridFeeSetting.Rows[index].Cells["colOneTime"]);
                    DataGridViewLinkCell colDelete = (DataGridViewLinkCell)(gridFeeSetting.Rows[index].Cells["colDelete"]);

                    txtFeeSetting.Value = feeSettingModel.FeeSettingID;
                    ddlFeeType.Value = feeSettingModel.FeeTypeID;
                    chkJan.Value = feeSettingModel.January;
                    chkFeb.Value = feeSettingModel.February;
                    chkMar.Value = feeSettingModel.March;
                    chkApr.Value = feeSettingModel.April;
                    chkMay.Value = feeSettingModel.May;
                    chkJun.Value = feeSettingModel.June;
                    chkJul.Value = feeSettingModel.July;
                    chkAug.Value = feeSettingModel.August;
                    chkSep.Value = feeSettingModel.September;
                    chkOct.Value = feeSettingModel.October;
                    chkNov.Value = feeSettingModel.November;
                    chkDec.Value = feeSettingModel.December;
                    chkOneTime.Value = feeSettingModel.OneTime;
                    colDelete.Value = feeSettingModel.FeeSettingID == 0 ? "x" : "";
                    index++;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void FeeSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    //BindFeeSettingGrid();
                }));
            }
            catch (Exception ex)
            {
            }
        }
        private void btnAddRows_Click(object sender, EventArgs e)
        {
            //Maximum rows will be equal to the fee type
            if (gridFeeSetting.Rows.Count == colFeeType.Items.Count - 1)
                MessageBox.Show(String.Format("Sorry! You cannot add more than {0} records.", colFeeType.Items.Count - 1), "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                AddBlankRows();
        }
        private void ChangeGridSetting()
        {
            gridFeeSetting.AutoGenerateColumns = false;
            gridFeeSetting.Columns["colJan"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colFeb"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colMar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colApr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colMay"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colJun"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colJul"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colAug"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colSep"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colOct"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colNov"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colDec"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colOneTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridFeeSetting.Columns["colDelete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void BindFeeTypeDropDownList()
        {
            _feetype = new FeeType();
            List<FeeTypeModel> _listFeeList = _feetype.GetFeeType();

            if (_listFeeList != null)
            {
                _listFeeList.Add(new FeeTypeModel { FeeTypeID = 0, FeeType = "Select" });
                colFeeType.DataSource = _listFeeList.OrderBy(x => x.FeeTypeID).ToList();
                colFeeType.DisplayMember = "FeeType";
                colFeeType.ValueMember = "FeeTypeID";
            }
            //foreach (DataGridViewRow row in gridFeeSetting.Rows)
            //{
            //    DataGridViewComboBoxCell ddlFeeType = (DataGridViewComboBoxCell)(row.Cells["colFeeType"]);
            //    ddlFeeType.DataSource = dicFeeType.ToList();
            //    ddlFeeType.DisplayMember = "Value";
            //    ddlFeeType.ValueMember = "Key";
            //    ddlFeeType.Value = 0;
            //}
        }
        private void FeeSettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.L)
            {
                ddlAcademicYear.SelectedIndex = 0;
                gridFeeSetting.DataSource = null;
            }
            if (e.Control == true && e.KeyCode == Keys.N)
                btnAddRows_Click(null, null);
            if (e.Control == true && e.KeyCode == Keys.S)
                btnSave_Click(null, null);
        }
        private bool ValidateGrid()
        {
            StringBuilder sbMessage = new StringBuilder();
            List<FeeSettingModel> _listGridrecord = new List<FeeSettingModel>();

            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) == 0)
            {
                sbMessage.Append("\u2022 Please Select Academic Year.\n");
            }

            #region Check if grid has rows
            //Checking blank grid if there is no record in grid.
            if (gridFeeSetting.Rows.Count == 0)
            {
                //lblError.Visible = true;
                // lblError.Text = "There is no record in table.";
                sbMessage.Append("\u2022 There is no record in table.\n");
            }
            #endregion

            //Get the grid data in list;
            _listGridrecord = ConvertGridToList();

            #region Validate Grid for duplicate records
            int duplicatesRecords = 0;
            int blankRecords = 0;
            if (gridFeeSetting.Rows.Count > 0)
            {
                //Checking For Blank Records
                blankRecords = _listGridrecord.Where(x => x.FeeTypeID == 0).GroupBy(x => x.FeeTypeID)
                             .Where(g => g.Count() >= 1)
                             .Select(g => g.Key)
                             .ToList().Count();

                //Checking for duplicate records
                duplicatesRecords = _listGridrecord.Where(x => x.FeeTypeID != 0).GroupBy(x => x.FeeTypeID)
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key)
                             .ToList().Count();

                if (duplicatesRecords > 0)
                {
                    // lblError.Visible = true;
                    sbMessage.Append("\u2022 There are duplicates fee type selected in table, Please Correct.\n");
                    //lblError.Text = "There are duplicates fee type selected in table, Please Correct.";
                    // isValid = false;
                }

                if (blankRecords > 0)
                {
                    sbMessage.Append("\u2022 Please select fee type.\n");
                }
            }
            #endregion

            if (!string.IsNullOrEmpty(sbMessage.ToString()))
            {
                ShowMessage(sbMessage.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
        private List<FeeSettingModel> ConvertGridToList()
        {
            List<FeeSettingModel> _listGridRecord = new List<FeeSettingModel>();
            if (gridFeeSetting.Rows.Count > 0)
            {
                foreach (DataGridViewRow rows in gridFeeSetting.Rows)
                {
                    _listGridRecord.Add(new FeeSettingModel
                    {
                        FeeSettingID = Convert.ToInt64(rows.Cells["colFeeSettingID"].Value),
                        FeeTypeID = Convert.ToInt16(rows.Cells["colFeeType"].Value),
                        January = Convert.ToBoolean(rows.Cells["colJan"].Value),
                        February = Convert.ToBoolean(rows.Cells["colFeb"].Value),
                        March = Convert.ToBoolean(rows.Cells["colMar"].Value),
                        April = Convert.ToBoolean(rows.Cells["colApr"].Value),
                        May = Convert.ToBoolean(rows.Cells["colMay"].Value),
                        June = Convert.ToBoolean(rows.Cells["colJun"].Value),
                        July = Convert.ToBoolean(rows.Cells["colJul"].Value),
                        August = Convert.ToBoolean(rows.Cells["colAug"].Value),
                        September = Convert.ToBoolean(rows.Cells["colSep"].Value),
                        October = Convert.ToBoolean(rows.Cells["colOct"].Value),
                        November = Convert.ToBoolean(rows.Cells["colNov"].Value),
                        December = Convert.ToBoolean(rows.Cells["colDec"].Value),
                        OneTime = Convert.ToBoolean(rows.Cells["colOneTime"].Value)
                    });
                }
            }
            return _listGridRecord;
        }
        private string ConvertGridToXML(List<FeeSettingModel> ListFeeSetting)
        {
            XElement xmlElements = new XElement("FeeSetting", ListFeeSetting.Where(x => x.FeeTypeID != 0)
            .Select(xmlchild => new XElement("Row",
            new XElement("FeeSettingID", xmlchild.FeeSettingID),
            new XElement("FeeTypeID", xmlchild.FeeTypeID),
            new XElement("January", xmlchild.January),
            new XElement("February", xmlchild.February),
            new XElement("March", xmlchild.March),
            new XElement("April", xmlchild.April),
            new XElement("May", xmlchild.May),
            new XElement("June", xmlchild.June),
            new XElement("July", xmlchild.July),
            new XElement("August", xmlchild.August),
            new XElement("September", xmlchild.September),
            new XElement("October", xmlchild.October),
            new XElement("November", xmlchild.November),
            new XElement("December", xmlchild.December),
            new XElement("OneTime", xmlchild.OneTime))));
            return Convert.ToString(xmlElements);
        }
        private void FeeSettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeeSettingForm.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValidGrid = ValidateGrid();
            if (isValidGrid)
            {
                _feeSetting = new FeeSetting();
                xmlString = ConvertGridToXML(ConvertGridToList());
                if (!string.IsNullOrWhiteSpace(xmlString))
                {
                    try
                    {
                        short output = _feeSetting.SaveFeeSetting(xmlString, Convert.ToInt32(ddlAcademicYear.SelectedValue));
                        if (output == 1)
                        {
                            //  lblError.Visible = false;
                            ShowMessage("Record Successfully Saved.");
                            // MessageBox.Show("Record Successfully Saved.", "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindFeeSettingGrid(Convert.ToInt32(ddlAcademicYear.SelectedValue));
                        }
                        if (output == -1)
                        {
                            //lblError.Visible = true;
                            ShowMessage("Error occured while saving records.\n Please contact to admin.");
                            //lblError.Text = "Error! Please contact to admin.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // lblError.Visible = true;
                        // lblError.Text = "Error! Please contact to admin.";
                        ShowMessage("Error! Please contact to admin.");
                    }
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "Error! Please contact to admin.";
                    ShowMessage("Error! Please contact to admin.");
                }
            }
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gridFeeSetting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 15)
            {
                try
                {
                    long? colFeeSettingID = Convert.ToInt16(gridFeeSetting.Rows[rowIndex].Cells["colFeeSettingID"].Value);
                    if (colFeeSettingID == 0)
                        gridFeeSetting.Rows.RemoveAt(rowIndex);
                    gridFeeSetting.ClearSelection();
                }
                catch (Exception ex)
                { }
                finally
                { }
            }
        }
        private void Bind_Academic_Year_Drop_Down()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();
            dicSession = Common.Get_Academic_Year_List();
            ddlAcademicYear.DataSource = dicSession.ToList();
            ddlAcademicYear.DisplayMember = "value";
            ddlAcademicYear.ValueMember = "key";
        }
        private void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridFeeSetting.DataSource = null;
            if (Convert.ToInt32(ddlAcademicYear.SelectedValue) != 0)
            {
                BindFeeSettingGrid(Convert.ToInt32(ddlAcademicYear.SelectedValue));
            }
        }
        private void Copy_Previous_Academic_Year_Setting()
        {
            try
            {
                string Selected_Academic_Year = ((KeyValuePair<int, string>)ddlAcademicYear.SelectedItem).Value;
                string[] arr = Selected_Academic_Year.Split('-');
                int Previous_Academic_Year = Convert.ToInt32(Convert.ToString(Convert.ToInt16(arr[0]) - 1) + Convert.ToString(Convert.ToInt16(arr[1]) - 1));
                List<FeeSettingModel> _listFeeSettingModel = _feeSetting.GetFeeSetting(Previous_Academic_Year);

                if (_listFeeSettingModel != null)
                {
                    _listFeeSettingModel.Select(x => { x.FeeSettingID = 0; return x; }).ToList();
                    BindGridContols(_listFeeSettingModel);

                    MessageBox.Show("Below table contains copied data of previous academic year.\nPlease edit & click on save button to save recods for this academic year.", "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Record Found For Previous Year.\n Please Add New Record.", "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error! Please contact to support team.", "Fee Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}