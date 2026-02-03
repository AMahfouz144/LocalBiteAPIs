using Application.Common;
using Application.Usecase.Categories.DTOs;
using Application.Usecase.Products.DTOs;
using Domain.Products;
using MediatR;

namespace Application.Usecase.Products.Queries
{
    //public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
  
    public class GetProductsPageQuery : IRequest<PageResult<ProductResponseDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }


    }
}