using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace eVidyalaya
{
    public static class Common
    {
        public static void NumericValidation(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 32 && ascii <= 47) || (ascii >= 58 && ascii <= 126) || (ascii >= 123 && ascii <= 126))//Only Numeric
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void DateKeyPressValidation(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 32 && ascii <= 46) || (ascii >= 58 && ascii <= 126) || (ascii >= 123 && ascii <= 126))//Only Numeric AND/ Symbol
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void AlphaNumericValidation(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 32 && ascii <= 43) || (ascii == 47) || (ascii >= 58 && ascii <= 126) || (ascii >= 123 && ascii <= 126))//Only Numeric With - , .
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void TextValidation(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 33 && ascii <= 64) || (ascii >= 91 && ascii <= 96) || (ascii >= 123 && ascii <= 126)) //Only Text Input Without Decimal.
            // if ((ascii >= 33 && ascii <= 45) || (ascii >= 47 && ascii <= 64) || (ascii >= 91 && ascii <= 96) || (ascii >= 123 && ascii <= 126)) //Only Text Input With Decimal.
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            e.KeyChar = e.KeyChar;
            // e.KeyChar = char.ToUpper(e.KeyChar);
        }
        public static void TextValidationWithSymbol(KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if ((ascii >= 33 && ascii <= 39) || (ascii >= 42 && ascii <= 43) ||
                (ascii >= 59 && ascii <= 64) || (ascii >= 94 && ascii <= 96) ||
                (ascii >= 123 && ascii <= 126) || ascii == 91 || ascii == 93)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            e.KeyChar = e.KeyChar;
        }
        //public static bool ValidateDate(string date)
        //{
        //    //[RegularExpression(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d+$", ErrorMessage = "Date should be in MM/DD/YYYY format")]
        //    bool IsValid = false;
        //    DateTime d;
        //    IsValid = DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        //    return IsValid;
        //}
        //public static bool ValidateDateRegularExpression(string date)
        //{
        //    bool IsValid = false;
        //    if (Regex.Match(date, @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d+$").Success)
        //    {
        //        IsValid = ValidateDate(date);
        //    }
        //    return IsValid;
        //}
        public static bool ValidateDate(string date)
        {
            bool IsValid = false;
            //if (date.Contains('.'))
            //    date = date.Replace('.', '/');

            DateTime d;
            IsValid = DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
            return IsValid;
        }
        public static DateTime Convert_String_To_Date(string date)
        {
            return DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //DateTime d;
            //IsValid = DateTime.TryParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        }
        public static string ToTitle(this string myString)
        {
            if (!string.IsNullOrWhiteSpace(myString))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return textInfo.ToTitleCase(myString);
            }
            else
            {
                return null;
            }
        }
        public static string ToProper(this string strParam)
        {
            String strTitleCase = string.Empty;
            if (!string.IsNullOrWhiteSpace(strParam))
            {
                strTitleCase = strParam.Substring(0, 1).ToUpper();
                strParam = strParam.Substring(1).ToLower();
                String strPrev = "";


                for (int iIndex = 0; iIndex < strParam.Length; iIndex++)
                {
                    if (iIndex > 1)
                    {
                        strPrev = strParam.Substring(iIndex - 1, 1);
                    }
                    if (strPrev.Equals(" ") ||
                        strPrev.Equals("\t") ||
                       strPrev.Equals("\n") ||
                        strPrev.Equals("."))
                    {
                        strTitleCase += strParam.Substring(iIndex, 1).ToUpper();
                    }
                    else
                    {
                        strTitleCase += strParam.Substring(iIndex, 1);
                    }
                }
            }
            return strTitleCase;
        }
        public static string Left(this string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(this string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
        public static string Mid(this string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }
        public static string Mid(this string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }
        public static DataTable ConvertToDataTable<TSource>(this IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name,
              Nullable.GetUnderlyingType(p.PropertyType) != null ? typeof(string)
                    : p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                dt.Columns.Add(pi.Name,
                    Nullable.GetUnderlyingType(pi.PropertyType) != null ? typeof(string)
                    //? new Type{ Name= "String",FullName="System.String"  }
                    : pi.PropertyType);

            }
            //Populate the table
            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null);
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static byte[] ResizeImage(Int32 MWidth, Int32 MHeight, string sourceImagePath, string destinationImagePath, string filename)
        {
            Bitmap bm = new System.Drawing.Bitmap(sourceImagePath) as Bitmap;
            // original dimensions
            int w = bm.Width;
            int h = bm.Height;
            // Longest and shortest dimension
            int longestDimension = (w > h) ? w : h;
            int shortestDimension = (w < h) ? w : h;
            // propotionality
            float factor = ((float)longestDimension) / shortestDimension;
            // default width is greater than height
            double newWidth = MWidth;
            double newHeight = MHeight; //MWidth; // / factor;
            int startX = 0;
            int startY = (Convert.ToInt32(newWidth - newHeight) / 2);
            // if height greater than width recalculate
            if (w < h)
            {
                newWidth = MHeight / factor;
                newHeight = MHeight;
                startX = (Convert.ToInt32(newHeight - newWidth) / 2);
                startY = 0;
            }
            Bitmap bitmap = new Bitmap((int)MWidth, (int)MHeight);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.FillRectangle(Brushes.White, 0, 0, MWidth, MHeight);
            graphics.DrawImage(bm, startX, startY, (int)newWidth, (int)newHeight);
            bitmap.Save(destinationImagePath + filename, System.Drawing.Imaging.ImageFormat.Png);
            bm.Dispose();
            bitmap.Dispose();

            FileStream fileStream = new FileStream(destinationImagePath + filename, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((Int32)fileStream.Length);
            //byte[] binaryImage = binaryReader.ReadBytes((Int32)fileStream.Length);
            //File.Delete(destinationImagePath + filename);
            //return binaryImage;
        }
        public static Int32 Get_Current_Academic_Year()
        {
            int returnValue = 0;
            if (DateTime.Today.Month > 3)
                returnValue = Convert.ToInt32(Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.AddYears(1).Year));
            if (DateTime.Today.Month <= 3)
                returnValue = Convert.ToInt32(Convert.ToString(DateTime.Today.AddYears(-1).Year) + Convert.ToString(DateTime.Today.Year));
            return returnValue;
        }
        public static Dictionary<Int32, string> Get_Academic_Year_List()
        {
            Dictionary<Int32, string> dicSession = new Dictionary<Int32, string>();

            dicSession.Add(0, "Select");

            if (DateTime.Today.Month == 1 || DateTime.Today.Month == 2 || DateTime.Today.Month == 3)
            {
                dicSession.Add(
                    Convert.ToInt32(Convert.ToString(DateTime.Today.AddYears(-1).Year) + Convert.ToString(DateTime.Today.Year))
                    , DateTime.Today.AddYears(-1).Year.ToString() + "-" + DateTime.Today.Year.ToString());

                dicSession.Add(
                     Convert.ToInt32(Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.AddYears(1).Year)),
                     DateTime.Today.Year.ToString() + "-" + DateTime.Today.AddYears(1).Year.ToString());
            }
            else
            {
                dicSession.Add(
                    Convert.ToInt32(Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.AddYears(1).Year)),
                    DateTime.Today.Year.ToString() + "-" + DateTime.Today.AddYears(1).Year.ToString());
            }
            return dicSession;
        }
        public static int GetMonthValue(string monthName)
        {
            int returnValue = 0;
            switch (monthName)
            {
                case "April":
                    returnValue = 4;
                    break;
                case "May":
                    returnValue = 5;
                    break;
                case "June":
                    returnValue = 6;
                    break;
                case "July":
                    returnValue = 7;
                    break;
                case "August":
                    returnValue = 8;
                    break;
                case "September":
                    returnValue = 9;
                    break;
                case "October":
                    returnValue = 10;
                    break;
                case "November":
                    returnValue = 11;
                    break;
                case "December":
                    returnValue = 12;
                    break;
                case "January":
                    returnValue = 13;
                    break;
                case "February":
                    returnValue = 14;
                    break;
                case "March":
                    returnValue = 15;
                    break;
            }
            return returnValue;
        }
    }
}
