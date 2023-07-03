using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseDeleteCommandHandler : IRequestHandler<ExpanseDeleteCommand, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseDeleteCommandHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseDeleteCommand request, CancellationToken cancellationToken)
        {
            await _expanseRepository.DeleteByIdAsync(request.Id);
            return new ResponseDto();
        }
    }
}
