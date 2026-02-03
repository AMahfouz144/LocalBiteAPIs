using Application.Common;
using Application.Usecase.Menu.DTOs;
using Application.Usecase.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecase.Menu.Queries
{
    public class GetMenuItemTabsQuery: IRequest<PageResult<MenuItemTabsDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
