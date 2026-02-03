using Application.Usecase.Categories.DTOs;
using Application.Usecase.Categories.Queries;
using MediatR;
using static Application.Usecase.Categories.Queries.GetCategoryQuery;

namespace Application.Usecase.Categories.Handlers
{
    public class GetCategoryByIdHandler(ICategoryRepository categoryRepository):IRequestHandler<GetCategoryByIdQuery,CategoryResponseDto>
    {
        
        public async Task<CategoryResponseDto> Handle(GetCategoryByIdQuery request,CancellationToken cancellationToken)
        {
           var category=await categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return null;
            }
            var response = new CategoryResponseDto
            {
                Id = category.ID,
                IsActive = category.IsActive,
                Name = category.Name,
                SortOrder = category.sortOrder

            };
            return response;
        }
    }
}
