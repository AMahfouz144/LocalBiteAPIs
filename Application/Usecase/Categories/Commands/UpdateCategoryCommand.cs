using Application.Common;
using Application.Usecase.Categories.DTOs;
using MediatR;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace Application.Usecase.Categories.Commands
{
    public class UpdateCategoryCommand : BaseModel,IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }
        public SortOrder SortOrder { get; set; }
        public bool IsActive { get; set; }
    };
}
