using Application.Common;
using Application.Usecase.Menu.DTOs;
using Application.Usecase.Menu.Queries;
using MediatR;


namespace Application.Usecase.Menu.Handler
{
    public class GetMenuItemTabsHandler(ICategoryRepository _categoryRepository) : IRequestHandler<GetMenuItemTabsQuery, PageResult<MenuItemTabsDto>>
    {
        async Task<PageResult<MenuItemTabsDto>> IRequestHandler<GetMenuItemTabsQuery, PageResult<MenuItemTabsDto>>.Handle(GetMenuItemTabsQuery request, CancellationToken cancellationToken)
        {
            var categories =await _categoryRepository.GetPagedAsync(request.PageIndex,request.PageSize);
            return new PageResult<MenuItemTabsDto>
            {
                Data = categories.Data.Select(c => new MenuItemTabsDto
                {
                    CategoryId = c.ID,
                    CategoryName = c.Name,
                    Icon=c.Icon,
                }).ToList(),
                Count = categories.Count
            };

        }
    }
}
