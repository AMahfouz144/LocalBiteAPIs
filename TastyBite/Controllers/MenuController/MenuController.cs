using Application.Common;
using Application.Usecase.Menu.DTOs;
using Application.Usecase.Menu.Queries;
using Application.Usecase.Products.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.MenuController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<PageResult<ProductDto>> Get([FromQuery] GetMenuQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet("GetTabs")]
        public async Task<PageResult<MenuItemTabsDto>> GetCategoryTabs([FromQuery] GetMenuItemTabsQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

    }
}
