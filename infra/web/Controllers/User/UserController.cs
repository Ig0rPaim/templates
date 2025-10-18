using Application.UseCases.User.Commands.CreateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    IMediator _mediator;
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Created("/", result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}