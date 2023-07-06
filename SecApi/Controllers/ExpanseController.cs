using Infra.Commands.ExpanseCommands;
using Infra.Commands.ExpanseQuery;
using Infra.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpanseController : ControllerBase
    {
        private readonly IMediatorCommand _mediatorCommand;
        private readonly IMediatorQuery _mediatorQuery;

        public ExpanseController(IMediatorQuery mediatorQuery, IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
            _mediatorQuery = mediatorQuery;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ExpanseCreateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Created with success!");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ExpanseUpdateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Updated with success!");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(ExpanseDeleteCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Deleted with success!");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery] Guid userId)
        {
            var result = await _mediatorQuery.SendQuery(new ExpanseGetByUserIdQuery(userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllByMonth")]
        public async Task<IActionResult> GetByMonth([FromQuery] Guid userId, DateTime date)
        {
            var result = await _mediatorQuery.SendQuery(new ExpanseGetByMonthQuery(date,userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllByCategoryId")]
        public async Task<IActionResult> GetByCategoryId([FromQuery] Guid userId, Guid categoryId)
        {
            var result = await _mediatorQuery.SendQuery(new ExpanseGetByCategoryIdQuery(categoryId, userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GenerateMonthSummary")]
        public async Task<IActionResult> GenerateMonthSummary([FromQuery] Guid userId)
        {
            var result = await _mediatorQuery.SendQuery(new ExpanseGenerateMonthSummaryQuery(userId));

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}