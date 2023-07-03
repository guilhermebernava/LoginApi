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


    }
}