using CSharpAngular.Api.Entities;
using CSharpAngular.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSharpAngular.Api.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }

        // Get all articles
        public async Task<IEnumerable<Article>> GetArticles(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();
        

        // Get single article
        public async Task<Article> GetArticle(int id, bool trackChanges) =>
            await FindByCondition(a => a.Id.Equals(id), (trackChanges ? 1 : 0) != 0).SingleOrDefaultAsync();

        public void CreateArticle(Article article) =>
            Create(article);

        public void UpdateArticle(Article article) =>
            Update(article);

        public void DeleteArticle(Article article) =>
            Delete(article);
    }
}
