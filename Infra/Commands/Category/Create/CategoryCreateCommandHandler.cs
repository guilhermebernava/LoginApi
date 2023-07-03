using Domain.Entities;
using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.CategoryCommands
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, ResponseDto>
    {
        private ICategoryRepository _categoryRepository;

        public CategoryCreateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category(request.Name,request.IsCore );
            await _categoryRepository.AddAsync(entity);
            return new ResponseDto();
        }
    }
}
