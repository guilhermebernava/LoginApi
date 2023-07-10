using Domain.DTOs;
using Domain.Entities;
using Infra.Context;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGenerateMonthSummaryQueryHandler : IRequestHandler<ExpanseGenerateMonthSummaryQuery, ResponseDto>
    {
        private AppDbContext _db;

        public ExpanseGenerateMonthSummaryQueryHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseDto> Handle(ExpanseGenerateMonthSummaryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expanses = await _db.Set<Expanse>().Where(_ => _.UserId == request.UserId).OrderBy(_ => _.Title).ToListAsync();
                var totalSpend = expanses.Sum(_ => _.Value);
                var userWallet = await _db.Set<UserWallet>().FirstOrDefaultAsync(_=> _.UserId == request.UserId);

                if(userWallet == null)
                {
                    throw new NotFoundException($"Not found any USER WALLET with this USER ID {request.UserId}");
                }

                var categorySpend = new List<CategorySpend>();

                var categories = await (from userCategory in _db.UserCategories
                                        join category in _db.Categories on userCategory.CategoryId equals category.Id
                                        where userCategory.UserId == request.UserId
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

                var monthlyEarningLeft = userWallet.MonthlyEarning - userWallet.MonthlyExpanse - totalSpend;
                var result = new ExpanseMonthSummaryDto(expanses, categorySpend, totalSpend,monthlyEarningLeft);
                return new ResponseDto(result);
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
