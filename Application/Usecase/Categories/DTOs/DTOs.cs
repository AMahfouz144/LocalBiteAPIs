using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Application.Usecase.Categories.DTOs
{
    public class CreateCategoryDto
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Unspecified;
        public bool IsActive { get; set; } = true;
    }

    public class UpdateCategoryDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}