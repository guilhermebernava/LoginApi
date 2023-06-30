using Domain.DTOs;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExpanseRepository : IRepository<Expanse>
    {
        public Task<List<Expanse>> GetByMonth(DateTime date, Guid userId);
        public Task<List<Expanse>> GetByCategoryId(Guid categoryId, Guid userId);
        public Task<List<Expanse>> GetAllByUserId(Guid userId);
        public Task<ExpanseMonthSummaryDto> GenerateMonthSummary(Guid userId);
    }
}
