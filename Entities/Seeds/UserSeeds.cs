using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpAngular.Api.Entities.Seeds
{
    public class UserSeeds : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Guest"
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "Test"
                }
            );
        }
    }
}
