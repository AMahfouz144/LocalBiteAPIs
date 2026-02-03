using Application.Common;
using MediatR;

namespace Application.Usecase.Categories.Commands
{
    public class DeleteCategoryCommand : BaseModel,IRequest<bool>
    {
        public Guid Id{ get; set; }
    }
}
