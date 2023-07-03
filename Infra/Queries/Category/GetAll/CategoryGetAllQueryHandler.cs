using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.CategoryQuery
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, ResponseDto>
    {
        private ICategoryRepository _categoryRepository;

        public CategoryGetAllQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetAllAsync();
            return new ResponseDto(list);
        }
    }
}
