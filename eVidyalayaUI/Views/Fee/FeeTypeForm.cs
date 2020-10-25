using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class FeeTypeForm : DockContent
    {
        public static FeeTypeForm instanceFrm;
        private FeeType _feeType;
        private FeeTypeModel _feeTypeModel;
        public FeeTypeForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            gridFeeType.AutoGenerateColumns = false;
            chkActive.Checked = true;
            txtFeeType.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            this.KeyPreview = true;
            hdnFeeTypeID.Text = string.Empty;
            #region Shortcut Keys Description
            StringBuilder sbShortCutKeys = new StringBuilder();
            sbShortCutKeys.Append("Use following shortcut keys :\n")
                .Append("\t\u2022 Load Records: Ctrl + L \n")
                .Append("\t\u2022 New: Ctrl + N \n")
                .Append("\t\u2022 Reset: Ctrl + D \n")
                .Append("\t\u2022 Save: Ctrl + S \n");
            lblShortCutKeys.Text = sbShortCutKeys.ToString();
            #endregion
        }
        private void FeeTypeForm_Load(object sender, EventArgs e)
        {

            this.BeginInvoke(new Action(() =>
            {
                BindGrid();
            }));
        }
        private void ResetControls()
        {
            txtFeeType.Text = string.Empty;
            txtFeeType.Focus();
            lblError.Visible = false;
            hdnFeeTypeID.Text = string.Empty;
            chkActive.Checked = false;
            chkIsPurchasable.Checked = false;
            gridFeeType.ClearSelection();
        }
        private void BindGrid()
        {
            try
            {
                _feeType = new FeeType();
                List<FeeTypeModel> _listFeeType = _feeType.GetFeeType();
                if (_listFeeType != null && _listFeeType.Count > 0)
                {
                    gridFeeType.DataSource = _listFeeType;
                    // lblNoRecordFound.Visible = false;
                    BindGridControls(_listFeeType);
                }
                else
                {
                    // lblNoRecordFound.Visible = true;
                }
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error! Please contact to admin.";
            }
        }
        private void BindGridControls(List<FeeTypeModel> listFeeType)
        {
            int index = 0;
            foreach (FeeTypeModel feeType in listFeeType)
            {
                DataGridViewLinkCell colEdit = (DataGridViewLinkCell)(gridFeeType.Rows[index].Cells["colEdit"]);
                DataGridViewTextBoxCell colFeeTypeID = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colFeeTypeID"]);
                DataGridViewTextBoxCell colFeeType = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colFeeType"]);
                DataGridViewTextBoxCell colActive = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colActive"]);
                DataGridViewTextBoxCell colIsPurchasable = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colIsPurchasable"]);
                DataGridViewTextBoxCell colFixedFeeType = (DataGridViewTextBoxCell)(gridFeeType.Rows[index].Cells["colFixedFeeType"]);
                DataGridViewCheckBoxCell colIsActiveHidden = (DataGridViewCheckBoxCell)(gridFeeType.Rows[index].Cells["colIsActiveHidden"]);
                DataGridViewCheckBoxCell colIsLostableHidden = (DataGridViewCheckBoxCell)(gridFeeType.Rows[index].Cells["colIsLostableHidden"]);

                colEdit.Value = "Edit";
                colFeeTypeID.Value = feeType.FeeTypeID;
                colFeeType.Value = feeType.FeeType;
                colFixedFeeType.Value = feeType.FixedName;
                colActive.Value = feeType.Active == true ? "Yes" : "No";

                if(feeType.Active == false)
                    colActive.Style.ForeColor = System.Drawing.Color.Red;

                colIsPurchasable.Value = feeType.IsPurchasable == true ? "Yes" : "No";

                if (feeType.IsPurchasable == true)
                    colIsPurchasable.Style.BackColor = System.Drawing.Color.Yellow;

                colIsActiveHidden.Value = feeType.Active;
                colIsLostableHidden.Value = feeType.IsPurchasable;
                index++;
            }
            gridFeeType.Refresh();
            gridFeeType.ClearSelection();
        }
        private void FeeTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FeeTypeForm.instanceFrm = null;
            //this.Hide();
            //this.Close();
            //e.Cancel = true;
        }
        private void FeeTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.L)
            {
                BindGrid();
                //lblLoadInfo.Visible = false;
                btnSave.Enabled = true;
                txtFeeType.Focus();
            }
            if (e.Control == true && e.KeyCode == Keys.N)
            {
                ResetControls();
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                ResetControls();
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                btnSave_Click(null, null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                _feeTypeModel = new FeeTypeModel();
                _feeTypeModel.FeeTypeID = string.IsNullOrWhiteSpace(hdnFeeTypeID.Text) ? null : (short?)Convert.ToInt16(hdnFeeTypeID.Text);
                _feeTypeModel.FeeType = txtFeeType.Text.ToProper();
                _feeTypeModel.Active = chkActive.Checked == true ? true : false;
                _feeTypeModel.IsPurchasable = chkIsPurchasable.Checked == true ? true : false;
                SaveDetails(_feeTypeModel);
            }
        }
        private void SaveDetails(FeeTypeModel feeTypeModel)
        {
            try
            {
                _feeType = new FeeType();

                short output = _feeType.SaveFeeType(feeTypeModel);
                switch (output)
                {
                    case 1:
                        lblError.Visible = false;
                        MessageBox.Show("Record Successfully Saved.", "Fee Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridFeeType.Refresh();//bind Grid on Insert And Update.
                        BindGrid();
                        ResetControls();
                        hdnFeeTypeID.Text = String.Empty;
                        break;
                    case -1:
                        lblError.Visible = true;
                        lblError.Text = "Error! Please contact to admin.";
                        break;
                    case 0:
                        lblError.Visible = true;
                        lblError.Text = "Record already Exit.";
                        break;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error! Please contact to admin.";
            }
        }
        private bool ValidateControls()
        {
            bool _isValid = false;
            StringBuilder messageBuilder = new StringBuilder();
            if (String.IsNullOrWhiteSpace(txtFeeType.Text))
                messageBuilder.Append("\t\u2022 Fee Type Is Required\n");

            if (!string.IsNullOrWhiteSpace(messageBuilder.ToString()))
            {
                lblError.Visible = true;
                lblError.Text = messageBuilder.ToString();
                _isValid = false;
            }
            else
            {
                lblError.Visible = false;
                _isValid = true;
            }
            return _isValid;
        }
        private void gridFeeType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                try
                {
                    hdnFeeTypeID.Text = Convert.ToString(gridFeeType.Rows[rowIndex].Cells["colFeeTypeID"].Value);
                    txtFeeType.Text = Convert.ToString(gridFeeType.Rows[rowIndex].Cells["colFeeType"].Value);
                    chkActive.Checked = Convert.ToBoolean(gridFeeType.Rows[rowIndex].Cells["colIsActiveHidden"].Value);
                    chkIsPurchasable.Checked = Convert.ToBoolean(gridFeeType.Rows[rowIndex].Cells["colIsLostableHidden"].Value);
                }
                catch (Exception ex)
                { }
                finally
                { }
            }
        }
        private void linkResetControls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetControls();
        }
    }
}