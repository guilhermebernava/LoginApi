using Domain.Entities;
using Domain.Repositories;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserCategoriesCommandHandler : IRequestHandler<UserCategoriesCommand, ResponseDto>
    {
        private IUserCategoryRepository _userCategoryRepository;
        private ICategoryRepository _categoryRepository;

        public UserCategoriesCommandHandler(IUserCategoryRepository userCategoryRepository,ICategoryRepository categoryRepository)
        {
            _userCategoryRepository = userCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto> Handle(UserCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (categories == null)
            {
                throw new NotFoundException("Not found any categories");
            }

            Parallel.ForEach(categories, async category =>
            {
                var entity = new UserCategory(request.UserId, category.Id);
                await _userCategoryRepository.AddAsync(entity);
            });

            return new ResponseDto();
        }
    }
}
