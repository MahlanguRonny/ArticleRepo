using ArenaHoldings.ArticleManagement.Api.repositories.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.configurations
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
