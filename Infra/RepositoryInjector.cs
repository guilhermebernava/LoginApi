using Domain.Redis;
using Domain.Repositories;
using Infra.Redis;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class RepositoryInjector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITwoFactorRedisRepository, TwoFactorRedisRepository>();
            services.AddScoped<IExpanseRepository, ExpanseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserCategoryRepository, UserCategoryRepository>();
        }
    }
}
