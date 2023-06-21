using Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class RepositoryInjector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTwoFactorRepository, UserTwoFactorRepository>();
        }
    }
}
