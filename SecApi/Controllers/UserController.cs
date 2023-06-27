using Infra.Commands.User;
using Infra.Mediator;
using Infra.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediatorCommand _mediatorCommand;
        private readonly IMediatorQuery _mediatorQuery;

        public UserController(IMediatorQuery mediatorQuery, IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
            _mediatorQuery = mediatorQuery;
        }

        [HttpGet]
        [Route("TwoFactor")]
        public async Task<IActionResult> TwoFactor([FromQuery] string code)
        {
            var result = await _mediatorQuery.SendQuery(new UserTwoFactorQuery(code));
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Route("UpdatePassword")]
        public async Task<IActionResult> Update([FromBody] string newPassword)
        {
            var email = RequestUtils.GetEmailFromJWT(Request.Headers);
            var result = await _mediatorCommand.SendCommand(new UserPasswordUpdateCommand() { Email = email, NewPassword = newPassword });

            if (result.Sucess)
            {
                return Ok("Change password with success!");
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> Create(UserCreateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Created with success!");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] UserGetByEmailQuery query)
        {
            var result = await _mediatorQuery.SendQuery(query);

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
    }
}