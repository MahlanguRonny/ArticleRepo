using ArenaHoldings.ArticleManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaHoldings.ArticleManagement.Api.DataEntities
{
    public class ArticleContext: DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
    }
}
