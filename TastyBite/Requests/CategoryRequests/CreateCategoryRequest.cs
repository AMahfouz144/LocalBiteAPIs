using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.CategoryResponse
{
    public class CreateCategoryRequest
    {
       
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public SortOrder sortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
