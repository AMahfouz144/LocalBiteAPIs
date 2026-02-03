using System.ComponentModel.DataAnnotations;

namespace API.Requests.ProductResponse
{
    public class CreateProductRequest
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
