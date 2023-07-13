using Domain.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ExpanseRepository : Repository<Expanse>, IExpanseRepository
    {
        public ExpanseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Expanse>> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                var expanses = await _dbSet.Where(_ => _.UserId == userId).AsNoTracking().ToListAsync();
                return expanses;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }

        public async Task<List<Expanse>> GetByCategoryIdAsync(Guid categoryId, Guid userId)
        {
            try
            {
                var expanses = await _dbSet.Where(_ => _.CategoryId == categoryId && _.UserId == userId).AsNoTracking().ToListAsync();
                return expanses;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }

        public async Task<List<Expanse>> GetByMonthAsync(DateTime date, Guid userId)
        {
            try
            {
                var expanses = await _dbSet.Where(_ => _.Date.Month == date.Month && _.UserId == userId).AsNoTracking().ToListAsync();
                return expanses;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
