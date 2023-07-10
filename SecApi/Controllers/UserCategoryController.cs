using Infra.Commands.UserCategoryCommand;
using Infra.Commands.UserCategoryQuery;
using Infra.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCategoryController : ControllerBase
    {
        private readonly IMediatorCommand _mediatorCommand;
        private readonly IMediatorQuery _mediatorQuery;

        public UserCategoryController(IMediatorQuery mediatorQuery, IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
            _mediatorQuery = mediatorQuery;
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        public async Task<IActionResult> Create(UserCategoryCreateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Created with success!");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery]Guid userId)
        {
            var result = await _mediatorQuery.SendQuery(new UserCategoryGetByUserIdQuery(userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}