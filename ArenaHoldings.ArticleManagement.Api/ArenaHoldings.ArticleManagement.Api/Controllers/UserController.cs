using ArenaHoldings.ArticleManagement.Api.configurations;
using ArenaHoldings.ArticleManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaHoldings.ArticleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("", new { user.Id }, user);//Todo add correct action name here
            }

            return new JsonResult("An error occured while creating a user") { StatusCode = 500 };
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            if (user == null)
                return BadRequest();

            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(user);
        }

    }
}
