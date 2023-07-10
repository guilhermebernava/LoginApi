using Infra.Commands.UserWalletCommand;
using Infra.Commands.UserWalletQuery;
using Infra.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserWalletController : ControllerBase
    {
        private readonly IMediatorCommand _mediatorCommand;
        private readonly IMediatorQuery _mediatorQuery;

        public UserWalletController(IMediatorQuery mediatorQuery, IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
            _mediatorQuery = mediatorQuery;
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        public async Task<IActionResult> Create(UserWalletCreateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Created with success!");
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        [Route("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery]Guid userId)
        {
            var result = await _mediatorQuery.SendQuery(new UserWalletGetByUserIdQuery(userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}