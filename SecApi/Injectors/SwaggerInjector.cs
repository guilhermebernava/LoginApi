using Microsoft.OpenApi.Models;

namespace SecApi.Injectors
{
    public static class SwaggerInjector
    {

        public static void AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "ExpansesApi",
                    Version = "v1",
                    Description = "API for organizing your expanses"
                });

                options.ResolveConflictingActions(x => x.First());

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using The Bearer Scheme"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                        }
                });
            });
        }
    }

}
