using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.PasswordGenerator.Commands;
using PasswordGeneratorCICD.SharedKernel.Results;

namespace PasswordGeneratorCICD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordGeneratorController : ControllerBase
    {
        private IMediator _mediator;

        public PasswordGeneratorController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> CreatePassword([FromBody] PasswordOptionsDto options)
        {
            CreatePasswordCommand command = new(options);
            Result<string> result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Errors);
        }
    }
}
