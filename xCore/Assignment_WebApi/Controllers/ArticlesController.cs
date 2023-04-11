using Assignment_ClassLibrary.Models.DTOs;
using Assignment_WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<ArticleResponse>> GetAllAsync()
        {
            if(ModelState.IsValid)
            {
                return await _articleService.GetAllArticlesAsync();
            }

            return null!;
            
        }

        [HttpGet("sorted")]
        public async Task<IEnumerable<ArticleResponse>> GetAllAriclesSorrtedAsync(string sortBy)
        {
            if (ModelState.IsValid)
            {
                return await _articleService.GetAllArticlesSortedAsync(sortBy);
            }

            return null!;

        }

        [HttpGet("content-type")]
        public async Task<IEnumerable<ArticleResponse>> GetAllArticlesByContentType(int id)
        {
            if (ModelState.IsValid)
            {
                return await _articleService.GetAllArticlesByContentType(id);
            }

            return null!;

        }

        [HttpGet("id")]
        public async Task<ActionResult<ArticleResponse>> GetArticleAsync(int id)
        {
            if(ModelState.IsValid)
            {
                var res = await _articleService.GetArticleAsync(id);
                
                if(res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticleAsync(ArticleRequest req)
        {
            if(ModelState.IsValid)
            {
                ArticleResponse res = await _articleService.CreateArticleAsync(req);
                if (res != null)
                {
                    return Created("", res);
                }
                else
                {
                    return NotFound();
                }
                    
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleAsync(int id)
        {
            if (ModelState.IsValid)
            {
                await _articleService.DeleteArticleAsync(id);
                return new OkResult();
            }

            return new BadRequestResult();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleResponse>> UpdateArticleAsync(int id, ArticleRequest req)
        {
            if (ModelState.IsValid)
            {
                var res = await _articleService.UpdateArticleAsync(id, req);

                if(res != null)
                {
                    return Ok(res);
                }

                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }
    }
}
