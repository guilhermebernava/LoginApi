using Infra.Mediator.Classes;

namespace Infra.Mediator
{
    public interface IMediatorCommand
    {
        public Task<ResponseDto> SendCommand<T>(T request) where T : Request;
    }
}
