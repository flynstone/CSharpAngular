using AutoMapper;
using CSharpAngular.Interfaces;
using CSharpAngular.Repositories;
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
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("sqlConnection")));
        }
    }
}
