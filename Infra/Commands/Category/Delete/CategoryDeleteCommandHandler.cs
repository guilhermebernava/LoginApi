using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.CategoryCommands
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, ResponseDto>
    {
        private ICategoryRepository _categoryRepository;

        public CategoryDeleteCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteByIdAsync(request.Id);
            return new ResponseDto();
        }
    }
}
