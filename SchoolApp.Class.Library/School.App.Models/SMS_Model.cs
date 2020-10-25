using System;

namespace School.App.Models
{
    public class SMS_Model
    {
        public string SMS_ID { get; set; }
        public string Mobile_Number { get; set; }
        public string Message_Text { get; set; }
        public byte IS_Send { get; set; }
        public string Send_Date_Time { get; set; }
        public string SMS_Category { get; set; }
        public string Send_Status { get; set; }
    }
}
