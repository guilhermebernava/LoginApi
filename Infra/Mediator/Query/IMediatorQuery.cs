using Infra.Mediator.Classes;

namespace Infra.Mediator
{
    public interface IMediatorQuery
    {
        public Task<ResponseDto> SendQuery<T>(T request) where T : Request;
    }
}
