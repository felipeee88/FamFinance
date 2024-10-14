using FamFinance.Application.Commands.Customer.CreateCustomer;
using FamFinance.Application.Commands.Customer.UpdateCustomer;
using FamFinance.Application.Commands.Customers.DeleteCustomer;
using FamFinance.Application.DTOs;
using FamFinance.Application.Queries.Customers.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var customer = await _mediator.Send(query);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(true);
            }

            return BadRequest("Error while creating the customer.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand { CustomerId = id };
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }
    }
}
