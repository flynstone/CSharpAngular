using CSharpAngular.Api.Entities;

namespace CSharpAngular.Api.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles(bool trackChanges);
        Task<Article> GetArticle(int id, bool trackChanges);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
