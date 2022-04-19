using AutoMapper;
using CSharpAngular.Api.DataTransferObjects.Articles;
using CSharpAngular.Api.Entities;
using CSharpAngular.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharpAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticlesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/articles
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            // Get all articles
            var articles = await _unitOfWork.Article.GetArticles(trackChanges: false);

            // Map articles to articles DTO
            var articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            return Ok(articlesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            // Get article by Id
            var article = await _unitOfWork.Article.GetArticle(id, trackChanges: false);

            // Make sure article exists, handle null
            if (article == null)
            {
                return NotFound();
            }
            else
            {
                var articleDto = _mapper.Map<ArticleDto>(article);
                return Ok(articleDto);
            }
        }

        // POST: api/articles
        [HttpPost]
        public async Task<ActionResult<CreateArticleDto>> CreateArticle([FromBody] CreateArticleDto article)
        {
            // Map Article to CreateArticleDto
            var articleEntity = _mapper.Map<Article>(article);

            // Create article, then save
            _unitOfWork.Article.CreateArticle(articleEntity);
            await _unitOfWork.SaveAsync();

            // Map ArticleDto to Article
            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);

            return CreatedAtRoute("Id", new { id = articleToReturn.Id }, articleToReturn);
        }

        // PUT: api/articles/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] ArticleForUpdateDto article)
        {
            // Handle null
            if (id != article.Id) return NotFound();

            // Update article
            else
            {
                var articleEntity = HttpContext.Items["article"] as Article;

                _mapper.Map(article, articleEntity);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }

        // DELETE: api/articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            // Handle null
            if (!ModelState.IsValid) return NotFound();

            else
            {
                var article = HttpContext.Items["article"] as Article;

                _unitOfWork.Article.DeleteArticle(article);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
        }
    }
}
