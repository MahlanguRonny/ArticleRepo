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

        [HttpDelete]
        [Route("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = _unitOfWork.ArticleRepository.GetById(id);
            if (article == null)
                return BadRequest();

            await _unitOfWork.ArticleRepository.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetAllArticles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var users = await _unitOfWork.ArticleRepository.All();
            return Ok(users);
        }

        [HttpGet("GetArticleById/{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetById(id);

            if (article == null)
                return NotFound();

            return Ok(article);
        }
    }
}

