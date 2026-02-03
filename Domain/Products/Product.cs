using Domain.Categories;
using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Products
{
   [ Table(nameof(Product))]
    public class Product :IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(256)]
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;


    }
}
