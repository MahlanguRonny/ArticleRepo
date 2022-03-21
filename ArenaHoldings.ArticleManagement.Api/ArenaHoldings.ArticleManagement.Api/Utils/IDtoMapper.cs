using ArenaHoldings.ArticleManagement.Api.Models;
using ArenaHoldings.ArticleManagement.Api.Models.DTOs.ArticleDto;

namespace ArenaHoldings.ArticleManagement.Api.Utils
{
    public interface IDtoMapper
    {
        //TODO look at ways of making this more generic
        Article ArticleMapper(ArticleDto articleDto);
        User UserMapper(UserDto userDto);
    }
}
