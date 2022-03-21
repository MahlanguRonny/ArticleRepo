using ArenaHoldings.ArticleManagement.Api.repositories.services;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.configurations
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
