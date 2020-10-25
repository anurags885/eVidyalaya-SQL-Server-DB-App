using System;

namespace SchoolModels
{
    public class Advance_Pay_Model
    {
        public long? Sequence_ID { get; set; }
        public long? Advance_Pay_Receipt_No { get; set; }
        public long Student_ID { get; set; }
        public Int32 Fee_Type_ID { get; set; }
        public string Fee_Type { get; set; }
        public Int32 Fee_Amount { get; set; }
        public int Number_Of_Months { get; set; }
        public Int32 Total_Amount { get; set; }
        public DateTime Deposit_Date { get; set; }
        public bool Is_Selected { get; set; }
        public Int32 Academic_Year { get; set; }
    }
}
