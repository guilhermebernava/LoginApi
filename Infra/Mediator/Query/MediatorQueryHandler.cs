using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Mediator
{
    public class MediatorQueryHandler : IMediatorQuery
    {
        private readonly IMediator _mediator;

        public MediatorQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseDto> SendQuery<T>(T request) where T : Request
        {
            return await _mediator.Send(request);
        }
    }
}
