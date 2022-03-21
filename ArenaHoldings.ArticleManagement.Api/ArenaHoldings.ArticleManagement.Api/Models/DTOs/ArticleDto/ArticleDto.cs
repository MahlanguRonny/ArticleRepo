namespace ArenaHoldings.ArticleManagement.Api.Models.DTOs.ArticleDto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserDto UserDto { get; set; }
    }
}
