using ArenaHoldings.ArticleManagement.Api.configurations;
using ArenaHoldings.ArticleManagement.Api.Models;
using ArenaHoldings.ArticleManagement.Api.Models.DTOs.ArticleDto;
using ArenaHoldings.ArticleManagement.Api.Utils;
using Microsoft.AspNetCore.Cors;
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
        private readonly IDtoMapper _dtoMapper;

        public ArticleController(IUnitOfWork unitOfWork, IDtoMapper dtoMapper)
        {
            _unitOfWork = unitOfWork;
            _dtoMapper = dtoMapper;
        }

        [HttpPost]
        [Route("PublishArticle")]
        public async Task<IActionResult> PublishArticle(ArticleDto articleDto)
        {
            if (ModelState.IsValid)
            {
                var newArticle = _dtoMapper.ArticleMapper(articleDto);

                if (articleDto.UserDto.Id == 0)
                {
                    var newUser = _dtoMapper.UserMapper(articleDto.UserDto);
                    await _unitOfWork.UserRepository.Add(newUser);
                    await _unitOfWork.CompleteAsync(); //Todo look for better ways to handle the transactions here

                    newArticle.UserId = newUser.Id;
                }

                await _unitOfWork.ArticleRepository.Add(newArticle);
                await _unitOfWork.CompleteAsync(); //Todo same as line 37, needs attention on transaction and roll backs

                return CreatedAtAction("GetArticleById", new { newArticle.Id }, newArticle);
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
            var articles = await _unitOfWork.ArticleRepository.All();
            return Ok(articles);
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

