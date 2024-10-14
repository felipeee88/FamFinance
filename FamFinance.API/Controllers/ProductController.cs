using FamFinance.Application.Commands.Product.CreateProduct;
using FamFinance.Application.Commands.Product.DeleteProduct;
using FamFinance.Application.Commands.Product.UpdateProduct;
using FamFinance.Application.DTOs;
using FamFinance.Application.Queries.Products.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(true);
            }

            return BadRequest("Error while creating the product.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { ProductId = id };
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }
    }
}
