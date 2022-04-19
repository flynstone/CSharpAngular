using AutoMapper;
using CSharpAngular.Api.Interfaces;
using CSharpAngular.Api.Repositories;
using CSharpAngular.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace CSharpAngular.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureScopes(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ITokenService, TokenService>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("sqlConnection")));
        }
    }
}
