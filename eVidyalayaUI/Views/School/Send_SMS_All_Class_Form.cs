using eVidyalaya.Customization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using School.App.Models;
using School.App.Repository.CommonRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya.Views.School
{
    public partial class Send_SMS_All_Class_Form : DockContent
    {
        SMS_Repository sms_repository = new SMS_Repository();
        List<SMS_Model> list_recepient = new List<SMS_Model>();
        public static Send_SMS_All_Class_Form instanceFrm;

        public Send_SMS_All_Class_Form()
        {
            InitializeComponent();
            gridSMS.AutoGenerateColumns = false;

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd-MMM-yyyy";

            Check_SMS_Balance();
        }

        private void Check_SMS_Balance()
        {
            lblBalancedSMSValue.Text = SMS_Service_API.SMS_Balance_Service();
        }

        private void Send_SMS_All_Class_Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Send_SMS_All_Class_Form.instanceFrm = null;
        }

        private void btnGenerateNumber_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_message_text.Text))
            {
                Message_PopUp.Show_Error_Message("Please Enter Message Text");
            }
            else
            {
                string result = sms_repository.Construct_SMS_All_Class(txt_message_text.Text);

                if (result == "ARGEN001")
                {
                    Message_PopUp.Show_Error_Message("Already Constructed.");
                }
                if (result == "S")
                {
                    Message_PopUp.Show_Success_Message("Message Constructed.");
                }
            }
            bind_Grid();
        }

        private void bind_Grid()
        {
            list_recepient = sms_repository.Get_SMS_Recipient_All_Class();
            list_recepient = list_recepient ?? new List<SMS_Model>();
            int total_sms_recepient_count = list_recepient.Where(x => x.IS_Send == 0).Count();

            if (list_recepient.Count > 0)
            {
                gridSMS.Refresh();
                gridSMS.DataSource = list_recepient;
            }
            else
            {
                gridSMS.Refresh();
                gridSMS.DataSource = null;
            }

            if (total_sms_recepient_count > 0)
                btnSendSMS.Enabled = true;
            else
                btnSendSMS.Enabled = false;
        }

        private void btnSendSMS_Click(object sender, System.EventArgs e)
        {
            btnSendSMS.Enabled = false;
            int totalsend = 0;
            List<SMS_Model> sms_list_recepient = list_recepient.Where(x => x.IS_Send == 0).ToList();

            string sms_api_response = string.Empty;
            foreach (SMS_Model item in sms_list_recepient)
            {
                totalsend++;
                sms_api_response = SMS_Service_API.Send_SMS_Service(item.Mobile_Number, item.Message_Text);

                if (sms_api_response == "S")
                {
                    sms_repository.Update_SMS_Status_All_Class(item.SMS_ID);
                }
            }

            if (totalsend > 0)
            {
                Message_PopUp.Show_Success_Message("SMS Successfully Send ");
            }

            bind_Grid();

            Check_SMS_Balance();
        }

        private void txt_message_text_TextChanged(object sender, System.EventArgs e)
        {
            lblTotalLength.Text = txt_message_text.Text.Length.ToString();
        }

        public void Export_To_Excel(List<SMS_Model> model, string fileName)
        {

            #region Save Dialog Box
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = fileName;
            saveFile.Filter = "Excel Files|*.xlsx;*.xls";

            DialogResult result = saveFile.ShowDialog();
            #endregion

            if (result == DialogResult.OK)

                using (ExcelPackage pck = new ExcelPackage())
                {
                    var ws = pck.Workbook.Worksheets.Add("Fee Deposit List");

                    #region Header
                    //Headers
                    ws.Cells["A1"].Value = "Mobile Number";
                    ws.Cells["B1"].Value = "SMS Text";
                    ws.Cells["C1"].Value = "Send Status";
                    ws.Cells["D1"].Value = "Send Date Time";
                    #endregion

                    #region Auto Width
                    ws.Column(1).AutoFit(15.00, 20.00);
                    ws.Column(2).AutoFit(25.00, 35.00);
                    ws.Column(3).AutoFit(15.00, 20.00);
                    ws.Column(4).AutoFit(10.00, 20.00);
                    #endregion

                    #region Creating Rows
                    int i = 2;
                    foreach (SMS_Model item in model)
                    {
                        ws.Cells["A" + i.ToString()].Value = Convert.ToString(item.Mobile_Number);
                        ws.Cells["B" + i.ToString()].Value = item.Message_Text;
                        ws.Cells["C" + i.ToString()].Value = item.Send_Status;
                        ws.Cells["D" + i.ToString()].Value = item.Send_Date_Time;
                        i++;
                    }
                    #endregion

                    #region Set Style
                    using (ExcelRange row = ws.Cells["A1:D1"])
                    {
                        row.Style.Font.Bold = true;
                    }

                    using (ExcelRange row = ws.Cells["A1:D" + (i - 1)])
                    {
                        row.Style.Font.Size = 9;
                        row.Style.Font.Name = "Tahoma";
                        row.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        row.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        row.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        row.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                    #endregion

                    pck.SaveAs(new FileInfo(saveFile.FileName));

                    Process Proc = new Process();
                    Proc.StartInfo.FileName = saveFile.FileName;
                    Proc.Start();
                }
        }

        private void linkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<SMS_Model> list_sms = sms_repository.Get_SMS_Report(dtpDate.Text, "AC-SMS");
            list_sms = list_sms ?? new List<SMS_Model>();
            Export_To_Excel(list_sms, $"SMS_Report_All_Class_{ dtpDate.Text}.xlsx");
        }
    }
}