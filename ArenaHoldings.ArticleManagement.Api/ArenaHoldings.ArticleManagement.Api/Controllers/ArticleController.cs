using ArenaHoldings.ArticleManagement.Api.configurations;
using ArenaHoldings.ArticleManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("PublishArticle")]
        public async Task<IActionResult> PublishArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ArticleRepository.Add(article);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetArticleById", new { article.Id }, article);
            }

            return new JsonResult("An error occured while publishing the article") { StatusCode = 500 };
        }
    }
}
