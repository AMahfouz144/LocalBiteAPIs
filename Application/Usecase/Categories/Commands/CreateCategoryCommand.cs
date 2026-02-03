using Application.Common;
using Application.Usecase.Categories.DTOs;
using MediatR;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Application.Usecase.Categories.Commands
{
    public class CreateCategoryCommand:BaseModel,IRequest<Guid>
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.Unspecified;
        public bool IsActive { get; set; } = true;
    }
}