namespace CSharpAngular.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository Article { get; }
        Task SaveAsync();
    }
}
