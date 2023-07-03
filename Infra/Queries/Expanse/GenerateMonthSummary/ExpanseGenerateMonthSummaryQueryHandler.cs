using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGenerateMonthSummaryQueryHandler : IRequestHandler<ExpanseGenerateMonthSummaryQuery, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseGenerateMonthSummaryQueryHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseGenerateMonthSummaryQuery request, CancellationToken cancellationToken)
        {
            var list = await _expanseRepository.GenerateMonthSummary(request.UserId);
            return new ResponseDto(list);
        }
    }
}
