using Application.Common;
using Application.Usecase.Categories.Commands;
using Application.Usecase.Categories.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Usecase.Categories.Queries.GetCategoryQuery;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> Create(CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(Guid id, UpdateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand() { Id=id});
            return result;
        }

        [HttpGet("{id}")]
        public async Task<CategoryResponseDto> GetById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery { Id=id});
           
            return category;
        }
        [HttpGet]
        public async Task<PageResult<CategoryResponseDto>> Get([FromQuery]GetCategoriesPagedQuery query)
        {
            var result = await _mediator.Send(query);
           
            return result;
        }

       
    }
}