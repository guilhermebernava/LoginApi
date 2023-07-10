using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByUserIdQueryHandler : IRequestHandler<ExpanseGetByUserIdQuery, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseGetByUserIdQueryHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _expanseRepository.GetAllByUserIdAsync( request.UserId);
            return new ResponseDto(list);
        }
    }
}
