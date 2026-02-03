using Application.Common;
using Application.Usecase.Categories.DTOs;
using MediatR;


namespace Application.Usecase.Categories.Queries
{
    public class GetCategoryQuery
    {
        public class GetCategoryByIdQuery : IRequest<CategoryResponseDto>
        {
            public Guid Id { get; set; }

        }
        public class GetCategoriesPagedQuery : IRequest<PageResult<CategoryResponseDto>>
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }


        }
    }
}
