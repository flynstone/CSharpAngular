namespace CSharpAngular.Api.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleRepository Article { get; }
        Task SaveAsync();
    }
}
