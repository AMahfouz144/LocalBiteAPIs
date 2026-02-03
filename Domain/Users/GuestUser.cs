using Domain.Common;
using Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class GuestUser : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [Phone]
        [MaxLength(64)]
        public string Phone { get; set; }
       [MaxLength(128)]
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
