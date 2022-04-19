using CSharpAngular.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CSharpAngular.Api.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll() => _context.Set<T>();

        public IQueryable<T> FindAll(bool trackChanges) => trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking<T>();

        public IQueryable<T> FindByCondition(
          Expression<Func<T, bool>> expression,
          bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where<T>(expression) : _context.Set<T>().Where<T>(expression).AsNoTracking<T>();
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
