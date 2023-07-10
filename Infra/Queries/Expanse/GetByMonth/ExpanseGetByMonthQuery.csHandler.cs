using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByMonthQueryHandler : IRequestHandler<ExpanseGetByMonthQuery, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseGetByMonthQueryHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseGetByMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _expanseRepository.GetByMonthAsync(request.Date, request.UserId);
            return new ResponseDto(list);
        }
    }
}
