using ArenaHoldings.ArticleManagement.Api.Models;
using ArenaHoldings.ArticleManagement.Api.Models.DTOs.ArticleDto;

namespace ArenaHoldings.ArticleManagement.Api.Utils
{
    public class DtoMapper : IDtoMapper
    {
        public Article ArticleMapper(ArticleDto articleDto)
        {
            return new Article
            {
                Id = articleDto.Id,
                Content = articleDto.Content,
                Title = articleDto.Title,
                UserId = articleDto.UserDto.Id
            };
        }

        public User UserMapper(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
            };
        }
    }
}
