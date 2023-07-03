using Domain.Repositories;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseUpdateCommandHandler : IRequestHandler<ExpanseUpdateCommand, ResponseDto>
    {
        private IExpanseRepository _expanseRepository;

        public ExpanseUpdateCommandHandler(IExpanseRepository expanseRepository)
        {
            _expanseRepository = expanseRepository;
        }

        public async Task<ResponseDto> Handle(ExpanseUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _expanseRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException($"Not found any expanse with this ID - {request.Id}");
            }

            entity.Title = request.Title;
            entity.Value = request.Value;
            entity.CategoryId = request.CategoryId;
            entity.Date = request.Date;
            entity.UserId = request.UserId;

            await _expanseRepository.UpdateAsync(entity);
            return new ResponseDto();
        }
    }
}
