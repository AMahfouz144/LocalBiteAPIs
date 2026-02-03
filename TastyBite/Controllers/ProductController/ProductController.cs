using Application.Common;
using Application.Infrastructure;
using Application.Usecase.Products.Commands;
using Application.Usecase.Products.DTOs;
using Application.Usecase.Products.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileStorageService _fileStorageService;

        public ProductsController(IMediator mediator, IFileStorageService fileStorageService)
        {
            _mediator = mediator;
            _fileStorageService = fileStorageService;
        }

        //[HttpPost]
        //public async Task<Guid> Create([FromForm]CreateProductCommand command, IFormFile? imageFile)
        //{
        //    if (imageFile != null)
        //    {
        //        var imageUrl = await _fileStorageService.SaveFileAsync(imageFile, "images/products");
        //        command.ImageUrl = imageUrl;
        //    }

        //    var id = await _mediator.Send(command);
        //    return id;
        //}
        [HttpPost]
        public async Task<Guid> Create([FromForm] CreateProductCommand command,[FromForm] IFormFile? ImageFile)
        {
            if (ImageFile != null)
            {
                var imageUrl = await _fileStorageService
                    .SaveFileAsync(ImageFile, "images/products");

                command.ImageUrl = imageUrl;
            }

            var id = await _mediator.Send(command);
            return id;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(Guid id, UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand() { Id=id});
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ProductResponseDto> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductQuery() { Id=id});
            return product;
        }

    

        [HttpGet]
        public async Task<PageResult<ProductResponseDto>> GetAll([FromQuery] GetProductsPageQuery query)
        {
            var products = await _mediator.Send(query);
            return products;
        }
    }
}