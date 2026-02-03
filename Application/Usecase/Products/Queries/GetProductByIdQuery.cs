using Application.Usecase.Products.DTOs;
using MediatR;

namespace Application.Usecase.Products.Queries
{
    public class GetProductQuery : IRequest<ProductResponseDto>
    {
        public Guid Id { get; set; }

    }
}