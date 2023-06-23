using Infra.Commands.User;
using Infra.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class MediatorExtension
    {
        public static void AddCQRS(this IServiceCollection services)
        {
            services.AddScoped<IMediatorCommand, MediatorCommandHandler>();
            services.AddScoped<IMediatorQuery, MediatorQueryHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserCreateCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserUpdateCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserDeleteCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserGetAllQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserGetByEmailQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserTwoFactorQueryHandler>());
        }
    }
}
