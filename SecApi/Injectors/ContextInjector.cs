using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace SecApi.Injectors
{
    public static class ContextInjector
    {
        public static void AddDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
        }
    }
}
