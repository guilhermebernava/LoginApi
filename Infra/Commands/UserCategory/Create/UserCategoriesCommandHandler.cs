using Domain.Entities;
using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.UserCategoryCommand
{
    public class UserCategoryCreateCommandHandler : IRequestHandler<UserCategoryCreateCommand, ResponseDto>
    {
        private IUserCategoryRepository _userCategoryRepository;
        private ICategoryRepository _categoryRepository;

        public UserCategoryCreateCommandHandler(IUserCategoryRepository userCategoryRepository, ICategoryRepository categoryRepository)
        {
            _userCategoryRepository = userCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseDto> Handle(UserCategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await _categoryRepository.GetCategoryByNameAsync(request.Name);

            if (existCategory == null)
            {
                await _categoryRepository.AddAsync(new Category(request.Name, false));
                var category = await _categoryRepository.GetCategoryByNameAsync(request.Name);

                var entity = new UserCategory(request.UserId, category!.Id);
                await _userCategoryRepository.AddAsync(entity);
            }
            else
            {
                var entity = new UserCategory(request.UserId, existCategory.Id);
                await _userCategoryRepository.AddAsync(entity);
            }


            return new ResponseDto();
        }
    }
}
