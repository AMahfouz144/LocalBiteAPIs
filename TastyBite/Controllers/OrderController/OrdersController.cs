using Application.Common;
using Application.Usecase.Order.Command;
using Application.Usecase.Order.DTOs;
using Application.Usecase.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OrderController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var orderId = await _mediator.Send(new CreateOrderCommand { Order = dto });
            return Ok(new { OrderId = orderId });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] int PageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetAllOrdersQuery{
                PageIndex = PageIndex, PageSize = pageSize}
            );
            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<PageResult<OrderResponseDto>> GetOrdersByCustomerId(Guid customerId, [FromQuery] int PageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetOrdersByCustomerIdQuery { CustomerId = customerId, PageIndex = PageIndex, PageSize = pageSize });
            return result;
        }
        [HttpGet("{orderId}")]
        public async Task<OrderResponseDto> GetOrderById(Guid orderId)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { OrderId = orderId });
            return result;
        }
    }

}
