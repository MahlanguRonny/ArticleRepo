using ArenaHoldings.ArticleManagement.Api.DataEntities;
using ArenaHoldings.ArticleManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.repositories.services
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleContext articleContext, ILogger logger) : base(articleContext, logger)
        {
        }
        public override async Task<bool> CreateOrUpdate(Article article)
        {
            try
            {
                var existingArticle = await dbSet.Where(x => x.Id == article.Id).FirstOrDefaultAsync();
                if (existingArticle == null)
                    return await Add(existingArticle);

                existingArticle.Title = article.Title;
                existingArticle.Content = article.Content;
                existingArticle.UserId = article.UserId;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} CreateOrUpdate function error", typeof(ArticleRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Article Repo Delete function error", typeof(ArticleRepository));
                return false;

            }
        }

        public override async Task<IEnumerable<Article>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Get All Articles function error", typeof(ArticleRepository));
                return new List<Article>();

            }
        }


    }
}