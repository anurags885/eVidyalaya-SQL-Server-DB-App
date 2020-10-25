using System.Configuration;
using System.Net;

namespace eVidyalaya.Customization
{
    public static class SMS_Service_API
    {
        static string sms_service_base_uri = string.Empty;
        static string sms_service_send_single_endpoint = string.Empty;
        static string sms_service_check_balance_endpoint = string.Empty;
        static string sms_service_user_name = string.Empty;
        static string sms_service_user_password = string.Empty;
        static string sms_service_sender_id = string.Empty;

        static SMS_Service_API()
        {
            sms_service_base_uri = ConfigurationManager.AppSettings["sms_service_base_uri"];
            sms_service_send_single_endpoint = ConfigurationManager.AppSettings["sms_service_send_single_endpoint"];
            sms_service_check_balance_endpoint = ConfigurationManager.AppSettings["sms_service_check_balance_endpoint"];
            sms_service_user_name = ConfigurationManager.AppSettings["sms_service_user_name"];
            sms_service_user_password = ConfigurationManager.AppSettings["sms_service_user_password"];
            sms_service_sender_id = ConfigurationManager.AppSettings["sms_service_sender_id"];
        }

        public static string SMS_Balance_Service()
        {
            string serviceUrl = $"{sms_service_base_uri}{sms_service_check_balance_endpoint}?username={sms_service_user_name}&password={sms_service_user_password}";

            WebClient wc = new WebClient();
            return wc.DownloadString(serviceUrl);
        }

        public static string Send_SMS_Service(string mobile_number, string message_text)
        {
            string serviceUrl = $"{sms_service_base_uri}{sms_service_send_single_endpoint}?username={sms_service_user_name}&password={sms_service_user_password}&sender={sms_service_sender_id}&sendto={mobile_number}&message={message_text}";
            WebClient wc = new WebClient();
            string responseFromServer = wc.DownloadString(serviceUrl);
            return responseFromServer.ToLower().Contains("logid") ? "S" : "F";
        }
    }
}
