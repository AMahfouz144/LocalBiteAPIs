
using Domain.Common;
using Domain.Products;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Categories
{
    [Table(nameof(Category))]
    //public class Categorie: AuditableEntity<long>
    public class Category :IEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public SortOrder sortOrder { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(256)]
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
