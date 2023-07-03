using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByUserIdQueryHandler : IRequestHandler<ExpanseGetByUserId, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseGetByUserIdQueryHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseGetByUserId request, CancellationToken cancellationToken)
        {
            var list = await _expanseRepository.GetAllByUserId( request.UserId);
            return new ResponseDto(list);
        }
    }
}
