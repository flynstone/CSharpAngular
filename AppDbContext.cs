using CSharpAngular.Api.Entities;
using CSharpAngular.Api.Entities.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CSharpAngular.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ArticleSeeds());
        }
    }
}
