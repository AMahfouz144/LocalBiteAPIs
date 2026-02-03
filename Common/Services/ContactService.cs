using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Common.ValidationAttributes
{
    public class ContactService
    {
        public static bool IsMobile(string contact)
        {
            if (string.IsNullOrEmpty(contact)) return false;

            // إزالة الفراغات والرموز الشائعة
            contact = contact.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            // إزالة "+" في البداية إن وجدت
            if (contact.StartsWith("+"))
                contact = contact.Substring(1);

            // تأكد أن كل المحتوى أرقام
            if (!Regex.IsMatch(contact, @"^\d{7,15}$"))
                return false;


            var mobileRules = new Dictionary<string, string>
            {
                { "20",  @"^20(10|11|12|15)\d{8}$" }, // مصر
                { "966", @"^9665\d{8}$" },  // السعودية
                { "971", @"^9715\d{8}$" }, // الإمارات
                { "962", @"^9627\d{8}$" }, // الأردن
                { "965", @"^965[569]\d{7}$" }, // الكويت
                { "974", @"^974[3567]\d{7}$" }, // قطر
                // ... أكمل حسب الدول
            };

            foreach (var rule in mobileRules)
            {
                if (contact.StartsWith(rule.Key))
                {
                    return Regex.IsMatch(contact, rule.Value);
                }
            }

            return true;
        }

        public static bool IsEmail(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
                return false;

            // حظر أي حرف غير لاتيني
            if (Regex.IsMatch(contact, @"[^\u0000-\u007F]+")) return false;

            try
            {
                var addr = new MailAddress(contact);
                return addr.Address == contact;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsDigit(string contact)
        {
            if (contact.StartsWith("+"))
                contact = contact.Substring(1);

            contact = contact.Replace(" ", "");
            bool res = long.TryParse(contact, out long number);
            return res;
        }
    }
}