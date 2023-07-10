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

        public async Task<ExpanseMonthSummaryDto> GenerateMonthSummaryAsync(Guid userId)
        {
            try
            {
                var expanses = await _dbSet.Where(_ => _.UserId == userId).OrderBy(_ => _.Title).ToListAsync();
                var totalSpend = expanses.Sum(_ => _.Value);
                var categorySpend = new List<CategorySpend>();

                var categories = await (from userCategory in _db.UserCategories
                                        join category in _db.Categories on userCategory.CategoryId equals category.Id
                                        where userCategory.UserId == userId
                                        select category).ToListAsync();


                await Task.Run(() =>
                {
                    foreach (var expanse in expanses)
                    {
                        var existCategory = categories.FirstOrDefault(_ => _.Id == expanse.CategoryId);
                        if (existCategory == null) throw new DbException($"Not found any User Category for this EXPANSE - {expanse.Id}");

                        var existCategorySpend = categorySpend.FirstOrDefault(_ => _.CategoryName == existCategory.Name);
                        if (existCategorySpend == null)
                        {
                            categorySpend.Add(new CategorySpend(existCategory.Name, expanse.Value));
                            continue;
                        }

                        existCategorySpend.TotalSpend += expanse.Value;
                    }
                });

                var result = new ExpanseMonthSummaryDto(expanses, categorySpend, totalSpend);
                return result;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }

        public async Task<List<Expanse>> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                var expanses = await _dbSet.Where(_ => _.UserId == userId).ToListAsync();
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
                var expanses = await _dbSet.Where(_ => _.CategoryId == categoryId && _.UserId == userId).ToListAsync();
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
                var expanses = await _dbSet.Where(_ => _.Date.Month == date.Month && _.UserId == userId).ToListAsync();
                return expanses;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
