using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CartController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(IMediator _mediator):ControllerBase
    {

    }
}
