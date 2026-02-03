using Application.Common;
using Domain.Products;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Usecase.Products.Commands
{

    public class UpdateProductCommand : BaseModel,IRequest<bool>
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(256)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
