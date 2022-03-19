using ArenaHoldings.ArticleManagement.Api.DataEntities;
using ArenaHoldings.ArticleManagement.Api.Models;
using ArenaHoldings.ArticleManagement.Api.repositories.services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.configurations
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly ArticleContext _articleContext;
        private readonly ILogger _logger;

        public IUserRepository UserRepository { get; private set; }
        public IArticleRepository ArticleRepository { get; private set; }

        public UnitOfWork(ArticleContext context, ILoggerFactory loggerFactory)
        {
            _articleContext = context;
            _logger = loggerFactory.CreateLogger("logs");

            UserRepository = new UserRepository(context, _logger);
            ArticleRepository = new ArticleRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _articleContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _articleContext.Dispose();
        }
    }
}
