
using LibraryManager.Application.Commands.LoanCommands.DeleteLoan;
using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Commands.LoanCommands.ReturnLoan;
using LibraryManager.Application.Queries.LoanQueries.GetAll;
using LibraryManager.Application.Queries.LoanQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
        
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var result = await _mediator.Send(new GetAllLoansQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertLoanCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) { 
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }

        [HttpPut("return/{id}")]
        public async Task<IActionResult> Put(int id, ReturnLoanCommand command) 
        {

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _mediator.Send(new DeleteLoanCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
