using Application.Common;
using Application.Usecase.Order.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecase.Order.Queries
{
    public class GetOrdersByCustomerIdQuery:IRequest<PageResult<OrderResponseDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CustomerId { get; set; }

    }
}
