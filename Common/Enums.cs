namespace Common
{
    public enum Language
    {
        En = 1,
        Ar
    }

    public enum AppPlatform
    {
        Android = 10,
        IOS = 20,
    }

    public enum SystemStatus
    {
        None = 0,              // Default / Not Set

        // --- حالات عامة ---
        New = 10,              // تم الإنشاء حديثًا
        Pending = 20,          // في انتظار الإجراء
        InProgress = 30,       // قيد التنفيذ
        Approved = 40,         // تم الموافقة عليه
        Declined = 50,         // تم الرفض
        Cancelled = 60,        // تم الإلغاء
        Expired = 70,          // منتهي الصلاحية
        Closed = 80,           // تم الإغلاق
        Rejected = 90,         // مرفوض

        // --- الطلبات / التوصيل ---
        Accepted = 100,        // تم قبول الطلب
        Preparing = 110,       // يتم التحضير
        Ready = 120,           // جاهز للتوصيل
        Assigned = 130,        // تم إسناده لمندوب
        OnTheWay = 140,        // في الطريق
        Delivered = 150,       // تم التوصيل
        Returned = 160,        // تم الإرجاع

        // --- المدفوعات ---
        Paid = 170,            // تم الدفع
        Unpaid = 180,          // لم يتم الدفع
        Refunded = 190,        // تم الاسترداد
        Failed = 200,          // فشل الدفع

        // --- الدعم الفني / التذاكر ---
        Confirmed = 210,       // تم التأكيد
        Resolved = 220,        // تم الحل
        Escalated = 230,       // تم التصعيد
        WaitingForCustomer = 240,  // في انتظار العميل
        WaitingForSupport = 250,   // في انتظار الدعم

        // --- حالات إضافية ---
        Done = 260,            // تم الانتهاء
        Draft = 270,           // مسودة
        Deleted = 280,         // محذوفة
        Archived = 290,        // مؤرشفة

        // --- حالات مخصصة ---
        Custom1 = 1001,
        Custom2 = 1002,
        Custom3 = 1003
    }
}