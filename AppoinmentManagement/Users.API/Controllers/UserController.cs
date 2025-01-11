using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Actions.Users;
using Users.Application.Actions.Users.Commands.CreateUser;
using Users.Application.Actions.Users.Commands.LoginUser;

namespace Users.API.Controllers
{
    [Authorize]
    [ApiKeyFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost()]
        public Task<UserModel> CreateUserAsync(CreateUserCommand command)
        {
            return _mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public Task<UserTokenModel> LoginUserAsync(LoginUserCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
