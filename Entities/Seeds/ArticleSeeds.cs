using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharpAngular.Api.Entities.Seeds
{
    public class ArticleSeeds : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new Article
                {
                    Id = 1,
                    Title = "What is Lorem Ipsum?",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                },
                new Article
                {
                    Id = 2,
                    Title = "Where does it come from?",
                    Content = "Contrary to popular belief, Lorem Ipsum is not simply random text.",
                },
                new Article
                {
                    Id = 3,
                    Title = "Why do we use it?",
                    Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.",
                },
                new Article
                {
                    Id = 4,
                    Title = "Where can I get some?",
                    Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which dont look even slightly believable.",
                }
            );
        }
    }
}
