using Domain.Repositories;
using Infra.Commands.UserCategoryQuery;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.CategoryQuery
{
    public class UserCategoryGetByUserIdQueryHandler : IRequestHandler<UserCategoryGetByUserIdQuery, ResponseDto>
    {
        private IUserCategoryRepository _userCategoryRepository;

        public UserCategoryGetByUserIdQueryHandler(IUserCategoryRepository userCategoryRepository)
        {
            _userCategoryRepository = userCategoryRepository;
        }

        public async Task<ResponseDto> Handle(UserCategoryGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _userCategoryRepository.GetAllByUserIdAsync(request.UserId);
            return new ResponseDto(list);
        }
    }
}
