using System;

namespace Common.Extension
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Convert Date Time to string Date Tie
        /// Ex : 
        /// Input : 2019-10-21 15:45:30.1867511
        /// Output : 21/10/2019 3:45 PM
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>string</returns>
        public static string DateTimeToStringDateTime(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm tt");
        }

        /// <summary>
        /// Convert Date Time to string Date 
        /// Ex : 
        /// Input : 2019-10-21 15:45:30.1867511
        /// Output : 2019-10-21
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>string</returns>
        public static string DateTimeToStringDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Convert String to Guid 
        /// Ex : 
        /// Input : 20:20:30.0000000
        /// Output : 8:20 PM
        /// </summary>
        /// <param name="date">TimeSpan</param>
        /// <returns>string</returns>
        public static string TimeSpanTostring(this TimeSpan value)
        {
            try
            {
                return DateTime.Today.Add(value).ToString("hh:mm tt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convert DateTime to DayTime 
        /// Ex : 
        /// Input : 2019-10-21 15:45:30.1867511
        /// Output : Sun 8:20 PM
        /// </summary>
        /// <param name="value">DateTime</param>
        /// <returns>string</returns>
        public static string DateTimeTostringDayTime(this DateTime value)
        {
            try
            {
                return value.ToString("ddd hh:mm tt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convert Date Time to  string birth date
        /// Ex : 
        /// Input : 2019-10-21 15:45:30.1867511
        /// Output : OCT 21, 2019
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>string</returns>
        public static string DateTimeToStringBirthDate(this DateTime date)
        {
            return date.ToString("MMM dd, yyyy");
        }

        /// <summary>
        /// Convert String to Guid 
        /// Ex : 
        /// Input : "C243B056-0F86-463C-8B26-8FED53DDEB33"
        /// Output : C243B056-0F86-463C-8B26-8FED53DDEB33
        /// </summary>
        /// <param name="date">string</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(this string value)
        {
            try
            {
                return Guid.Parse(value);
            }
            catch (Exception ex)
            {
                //"Invalid guid pattern";
                throw ex;
            }
        }
    }
}