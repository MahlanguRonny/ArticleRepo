using ArenaHoldings.ArticleManagement.Api.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.Models
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
