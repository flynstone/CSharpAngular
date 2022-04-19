using CSharpAngular.Api.Interfaces;

namespace CSharpAngular.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private IArticleRepository _articleRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IArticleRepository Article 
        { 
            get 
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository(_context);
                return _articleRepository;
            } 
        }
         public async Task SaveAsync()
        {
            int num = await this._context.SaveChangesAsync();
        }
    }
}
