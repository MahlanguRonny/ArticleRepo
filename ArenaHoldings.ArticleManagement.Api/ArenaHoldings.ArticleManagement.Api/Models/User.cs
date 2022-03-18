using ArenaHoldings.ArticleManagement.Api.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.Models
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
    }
}
