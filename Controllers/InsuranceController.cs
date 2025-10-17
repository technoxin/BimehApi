using Microsoft.AspNetCore.Mvc;
using BimehApi.DTOs;
using BimehApi.Commands;
using BimehApi.Queries;
using MediatR;

namespace BimehApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly IMediator _mediator;

    public InsuranceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitRequest([FromBody] CreateInsuranceRequestCommand command)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate coverage is 1, 2, or 3
            if (command.coverage < 1 || command.coverage > 3)
            {
                return BadRequest(new { error = "Coverage must be 1, 2, or 3" });
            }

            var response = await _mediator.Send(command);
            
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "An error occurred while processing your request." });
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetRequests()
    {
        try
        {
            var query = new GetAllInsuranceRequestsQuery();
            var responses = await _mediator.Send(query);
            
            return Ok(responses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "An error occurred while retrieving requests." });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRequest(int id)
    {
        try
        {
            var query = new GetInsuranceRequestByIdQuery(id);
            var response = await _mediator.Send(query);
            
            if (response == null)
            {
                return NotFound(new { error = "Request not found." });
            }
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "An error occurred while retrieving the request." });
        }
    }
}