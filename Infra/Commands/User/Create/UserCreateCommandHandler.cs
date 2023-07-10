using Domain.Entities;
using Domain.Repositories;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, ResponseDto>
    {
        private IUserRepository _userRepository;
        private IUserCategoryRepository _userCategoryRepository;
        private IUserWalletRepository _userWalletRepository;
        private ICategoryRepository _categoryRepository;

        public UserCreateCommandHandler(IUserRepository userRepository, IUserCategoryRepository userCategoryRepository,ICategoryRepository categoryRepository, IUserWalletRepository userWalletRepository)
        {
            _userRepository = userRepository;
            _userCategoryRepository = userCategoryRepository;
            _categoryRepository = categoryRepository;
            _userWalletRepository = userWalletRepository;
        }

        public async Task<ResponseDto> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new AppUser(request.Email, request.Password, request.TwoFactor, request.UserName);
            await _userRepository.AddAsync(entity);
            var savedUser = await _userRepository.GetByEmailAsync(request.Email);

            if(savedUser ==null)
            {
                throw new NotFoundException("Not found saved user");
            }

            await _userWalletRepository.AddAsync(new UserWallet(request.MonthlyEarning,request.MonthlyExpanses,savedUser.Id));
            var categories = await _categoryRepository.GetAllCoreCategoriesAsync();

            Parallel.ForEach(categories, async category => {
                await _userCategoryRepository.AddAsync(new UserCategory(savedUser.Id, category.Id));
            });

            return new ResponseDto();
        }
    }
}
