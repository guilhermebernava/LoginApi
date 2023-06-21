using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Mediator
{
    public class MediatorCommandHandler : IMediatorCommand
    {
        private readonly IMediator _mediator;

        public MediatorCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseDto> SendCommand<T>(T request) where T : Request
        {
            return await _mediator.Send(request);
        }
    }
}
