using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByCategoryIdQueryHandler : IRequestHandler<ExpanseGetByCategoryIdQuery, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseGetByCategoryIdQueryHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseGetByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _expanseRepository.GetByCategoryIdAsync(request.CategoryId,request.UserId);
            return new ResponseDto(list);
        }
    }
}
