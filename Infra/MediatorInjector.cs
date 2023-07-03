using Infra.Commands.CategoryCommands;
using Infra.Commands.CategoryQuery;
using Infra.Commands.ExpanseCommands;
using Infra.Commands.ExpanseQuery;
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

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseCreateCommandHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseDeleteCommandHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseUpdateCommandHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseGetByMonthQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseGetByCategoryIdQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseGenerateMonthSummaryQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExpanseGetByUserIdQueryHandler>());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CategoryGetAllQueryHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CategoryCreateCommandHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CategoryDeleteCommandHandler>());
        }
    }
}
