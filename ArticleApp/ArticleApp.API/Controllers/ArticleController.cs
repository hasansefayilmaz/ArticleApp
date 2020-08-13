using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleApp.Service;
using ArticleApp.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _articleService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleDto articleDto)
        {
            try
            {
                return Ok(await _articleService.Insert(articleDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleDto articleDto)
        {
            try
            {
                return Ok(await _articleService.Update(articleDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ArticleDto articleDto)
        {
            try
            {
                return Ok(await _articleService.Delete(articleDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
