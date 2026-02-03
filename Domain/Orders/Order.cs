using Domain.Common;
using Domain.Enums;
using Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Orders
{
    [Table(nameof(Order))]
    public class Order:IEntity
    {
        [Key]
        public Guid OrderId { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        public DeliveryType DeliveryType { get; set; }
        [MaxLength(128)]
        public string Address { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        [ForeignKey(nameof(Customer))]
        public Guid? CustomerId { get; set; }
        public User? Customer { get; set; }
        public Guid? GuestUserId { get; set; }
        public GuestUser? GuestUser { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();



    }
}
