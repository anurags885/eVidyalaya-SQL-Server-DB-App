using SchoolModels;
using School.App.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya
{
    public partial class TransportChargesForm : DockContent
    {
        TransportFeeSetting transportFeeSetting;
        TransportRouteModel transportRouteModel;
        public static TransportChargesForm instanceFrm;
        public TransportChargesForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            this.KeyPreview = true;
            hdnRouteID.Text = "0";
            txtRouteName.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.TextValidation(e); };
            txtAmount.KeyPress += delegate (object sender, KeyPressEventArgs e) { Common.NumericValidation(e); };
            var font = new Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            gridTransport.ColumnHeadersDefaultCellStyle.Font = font;
            gridTransport.DefaultCellStyle.Font = font;
            gridTransport.AutoGenerateColumns = false;

            StringBuilder sbShortCutKeys = new StringBuilder();
            sbShortCutKeys.Append("Use following shortcut keys :\n")
                .Append("\t\u2022 Clear: Ctrl + D \n")
                .Append("\t\u2022 New: Ctrl + N \n")
                .Append("\t\u2022 Save: Ctrl + S \n");
            lblShortCutKeys.Text = sbShortCutKeys.ToString();
        }
        private void BindTransportGrid()
        {
            hdnRouteID.Text = "0";
            try
            {
                int index = 0;
                transportFeeSetting = new TransportFeeSetting();
                List<TransportRouteModel> listTransport = transportFeeSetting.GetTransportRoute();
                if (listTransport != null && listTransport.Count > 0)
                {
                    gridTransport.DataSource = transportFeeSetting.GetTransportRoute();

                    foreach (TransportRouteModel list in listTransport)
                    {
                        DataGridViewTextBoxCell colRouteID = (DataGridViewTextBoxCell)(gridTransport.Rows[index].Cells["colRouteID"]);
                        DataGridViewLinkCell colRouteName = (DataGridViewLinkCell)(gridTransport.Rows[index].Cells["colRouteName"]);
                        DataGridViewTextBoxCell colAmount = (DataGridViewTextBoxCell)(gridTransport.Rows[index].Cells["colAmount"]);

                        colRouteID.Value = list.RouteID;
                        colRouteName.Value = list.RouteName;
                        colAmount.Value = list.Amount;
                        index++;
                    }
                    gridTransport.ClearSelection();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void TransportChargesForm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                BindTransportGrid();
            }));
        }
        private void gridTransport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
                try
                {
                    hdnRouteID.Text = Convert.ToString(gridTransport.Rows[rowIndex].Cells["colRouteID"].Value);
                    txtRouteName.Text = Convert.ToString(gridTransport.Rows[rowIndex].Cells["colRouteName"].Value);
                    txtAmount.Text = Convert.ToString(gridTransport.Rows[rowIndex].Cells["colAmount"].Value);
                    gridTransport.ClearSelection();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
        }
        private bool ValidateControls()
        {
            bool _isValid = false;
            StringBuilder messageBuilder = new StringBuilder();
            if (String.IsNullOrWhiteSpace(txtRouteName.Text))
                messageBuilder.Append("\u2022 Route Name Is Required\n");

            if (String.IsNullOrWhiteSpace(txtAmount.Text))
                messageBuilder.Append("\u2022 Amount Is Required\n");

            if (!string.IsNullOrWhiteSpace(messageBuilder.ToString()))
            {
                ShowMessageBox(messageBuilder.ToString());
                _isValid = false;
            }
            else
            {
                _isValid = true;
            }
            return _isValid;
        }
        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "Transport Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    transportRouteModel = new TransportRouteModel
                    {
                        RouteID = Convert.ToInt32(hdnRouteID.Text) == 0 ? null : (int?)Convert.ToInt32(hdnRouteID.Text),
                        RouteName = txtRouteName.Text.ToProper(),
                        Amount = Convert.ToInt16(txtAmount.Text)
                    };

                    transportFeeSetting = new TransportFeeSetting();
                    short result = transportFeeSetting.SaveTransportRoute(transportRouteModel);
                    switch (result)
                    {
                        case 0:
                            ShowMessageBox("Record Already Exists.");
                            txtRouteName.Focus();
                            break;
                        case 1:
                            ShowMessageBox("Record Successfully Saved.");
                            BindTransportGrid();
                            ClearControls();
                            break;
                        case -1:
                            ShowMessageBox("Error In Saving Details. Please Contact to Admin.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error: Please contact to Admin.");
            }
        }
        private void ClearControls()
        {
            txtAmount.Text = string.Empty;
            txtRouteName.Text = string.Empty;
            hdnRouteID.Text = "0";
            txtRouteName.Focus();
        }
        private void TransportChargesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.D)
                ClearControls();
            if (e.Control == true && e.KeyCode == Keys.S)
                btnSave_Click(null, null);
            if (e.Control == true && e.KeyCode == Keys.N)
                ClearControls();
        }

        private void TransportChargesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TransportChargesForm.instanceFrm = null;
        }
    }
}
