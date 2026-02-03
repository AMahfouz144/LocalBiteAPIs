using Application.Common;
using Application.Usecase.Categories.DTOs;
using Application.Usecase.Categories.Queries;
using MediatR;
using static Application.Usecase.Categories.Queries.GetCategoryQuery;

namespace Application.Usecase.Categories.Handlers
{
    public class GetCategoriesPagedHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesPagedQuery, PageResult<CategoryResponseDto>>
    {

        public async Task<PageResult<CategoryResponseDto>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            
            var page = await categoryRepository.GetPagedAsync(request.PageIndex,request.PageSize);

            if (page == null)
            {
                return null;
            }
            var result = new PageResult<CategoryResponseDto>
            {

                Count = page.Count,
                Data = page.Data.Select(a => new CategoryResponseDto
                {
                    Id = a.ID,
                    Name = a.Name,
                    IsActive = a.IsActive,
                    SortOrder = a.sortOrder
                }).ToList()
            };
            return result;
        }
    }
}
