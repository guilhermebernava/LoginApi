using Infra.Commands.CategoryCommands;
using Infra.Commands.CategoryQuery;
using Infra.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace SecApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediatorCommand _mediatorCommand;
        private readonly IMediatorQuery _mediatorQuery;

        public CategoryController(IMediatorQuery mediatorQuery, IMediatorCommand mediatorCommand)
        {
            _mediatorCommand = mediatorCommand;
            _mediatorQuery = mediatorQuery;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CategoryCreateCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Created with success!");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(CategoryDeleteCommand command)
        {
            var result = await _mediatorCommand.SendCommand(command);

            if (result.Sucess)
            {
                return Ok("Deleted with success!");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatorQuery.SendQuery(new CategoryGetAllQuery());

            if (result.Sucess)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}