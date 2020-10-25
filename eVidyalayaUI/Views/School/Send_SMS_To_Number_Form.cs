using eVidyalaya.Customization;
using School.App.Models;
using School.App.Repository.CommonRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace eVidyalaya.Views.School
{
    public partial class Send_SMS_To_Number_Form : DockContent
    {
        public static Send_SMS_To_Number_Form instanceFrm;
        SMS_Repository sms_repository = new SMS_Repository();
        public Send_SMS_To_Number_Form()
        {
            InitializeComponent();
            gridSMS.AutoGenerateColumns = false;
            lblBalancedSMSValue.Text = SMS_Service_API.SMS_Balance_Service();

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Value = DateTime.Now;
            dtpDate.CustomFormat = "dd-MMM-yyyy";
        }
        private void Send_SMS_To_Number_Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Send_SMS_To_Number_Form.instanceFrm = null;
        }

        private void btnSentMessage_Click(object sender, System.EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb_invalid_mobile_number = new StringBuilder();
            string[] arr_mobile_number = txtNumbers.Text.Split(',');

            #region Validation
            if (string.IsNullOrEmpty(txt_message_text.Text))
                sb.Append("\u2022 Please enter message text.\n");

            if (string.IsNullOrEmpty(txtNumbers.Text))
                sb.Append("\u2022 Please enter mobile number.\n");


            int invalidNumberCount = 0;
            foreach (string numbers in arr_mobile_number)
            {
                if (numbers.Length != 10)
                {
                    sb_invalid_mobile_number.Append(numbers).Append("\n");
                    invalidNumberCount++;
                }
            }

            if (invalidNumberCount > 0)
            {
                sb.Append("\u2022 Invalid mobile number & wrong format, Please Check.\n");
                sb.Append(sb_invalid_mobile_number.ToString()).Append("\n");
            }

            if (sb.ToString().Length > 0)
            {
                Message_PopUp.Show_Error_Message(sb.ToString());
                return;
            }


            #endregion Validation

            if (invalidNumberCount == 0)
            {
                List<SMS_Model> sms_model_list = new List<SMS_Model>();
                string sms_response = string.Empty;
                foreach (string numbers in arr_mobile_number.Distinct())
                {
                    sms_response = SMS_Service_API.Send_SMS_Service(numbers, txt_message_text.Text);
                    if (sms_response == "S")
                    {
                        sms_repository.Log_SMS_Individual(numbers, txt_message_text.Text);
                    }

                    sms_model_list.Add(new SMS_Model { Mobile_Number = numbers, Send_Status = sms_response == "S" ? "Send" : "Not Send" });
                }
                gridSMS.Refresh();
                gridSMS.DataSource = sms_model_list;

                lblBalancedSMSValue.Text = SMS_Service_API.SMS_Balance_Service();
            }
        }

        private void txt_message_text_TextChanged(object sender, System.EventArgs e)
        {
            lblTotalLength.Text = txt_message_text.Text.Length.ToString();
        }

        private void linkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<SMS_Model> list_sms = sms_repository.Get_SMS_Report(dtpDate.Text, "I-SMS");
            list_sms = list_sms ?? new List<SMS_Model>();

            using (Send_SMS_All_Class_Form obj = new Send_SMS_All_Class_Form())
            {
                obj.Export_To_Excel(list_sms, $"SMS_Report_{ dtpDate.Text}.xlsx");
            }
        }
    }
}
