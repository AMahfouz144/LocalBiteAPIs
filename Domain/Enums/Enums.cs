using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum DeliveryType
    {
        Delivery,
        Pickup
    }
    public enum OrderStatus
    {
        Pending,

        Cancelled,
        Confirmed,

    }
    public enum UserRole
    {
        Admin,
        Staff,
        Customer
    }
}
