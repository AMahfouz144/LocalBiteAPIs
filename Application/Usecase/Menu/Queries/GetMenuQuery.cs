

using Application.Common;
using Application.Usecase.Menu.DTOs;
using Application.Usecase.Products.DTOs;
using MediatR;

namespace Application.Usecase.Menu.Queries
{
    public class GetMenuQuery : IRequest<PageResult<ProductDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? Type { get; set; }
        public Guid? CategoryId { get; set; }
    }

}
