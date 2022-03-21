using ArenaHoldings.ArticleManagement.Api.Models;
using ArenaHoldings.ArticleManagement.Api.Models.DTOs.ArticleDto;

namespace ArenaHoldings.ArticleManagement.Api.Utils
{
    public interface IDtoMapper
    {
        Article ArticleMapper(ArticleDto articleDto);
        User UserMapper(UserDto userDto);
    }
}
