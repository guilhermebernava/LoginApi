using Domain.Entities;
using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseCreateCommandHandler : IRequestHandler<ExpanseCreateCommand, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseCreateCommandHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Expanse(request.Title,request.Value,request.Date,request.CategoryId,request.UserId);
            await _expanseRepository.AddAsync(entity);
            return new ResponseDto();
        }
    }
}
