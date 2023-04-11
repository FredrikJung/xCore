using Assignment_ClassLibrary.Models.DTOs;
using Assignment_ClassLibrary.Models.Entities;
using Assignment_ClassLibrary.Models.Validators;
using Assignment_WebApi.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WebApi.Repositories;

public class ArticleRepository
{
    private readonly DataContext _context;
    private readonly ArticleValidator _validator;

    public ArticleRepository(DataContext context, ArticleValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<ArticleEntity> CreateArticleAsync(ArticleRequest req)
    {
        _validator.ValidateArticleRequest(req);

        ArticleEntity articleEntity = req;

        _context.Articles.Add(articleEntity);
        await _context.SaveChangesAsync();

        return articleEntity;   
    }
    
    public async Task<IEnumerable<ArticleEntity>> GetAllArticlesAsync()
    {
        return await _context.Articles
            .Include(x => x.ContentType)
            .Include(x => x.Tag)
            .Include(x => x.ArticleRows).ThenInclude(x => x.Author)
            .ToListAsync();
    }

    public async Task<ArticleEntity?> GetArticleAsync(int id)
    {
        _validator.ValidateGetArticleById(id);

        return await _context.Articles
            .Include(x => x.ContentType)
            .Include(x => x.Tag)
            .Include(x => x.ArticleRows).ThenInclude(x => x.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> DeleteArticleAsync(int id)
    {
        var articleEntity = await _context.Articles.FindAsync(id);
        if (articleEntity != null)
        {
            _context.Articles.Remove(articleEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;

    }

    public async Task<ArticleEntity> UpdateArticleAsync(int id, ArticleRequest req)
    {
        _validator.ValidateArticleRequest(req);

        var articleEntity = await _context.Articles
            .Include(x => x.ArticleRows)
            .FirstOrDefaultAsync(x => x.Id == id);

        articleEntity?.ArticleRows.Clear();

        if (articleEntity != null)
        {
            articleEntity.Headline = req.Headline;
            articleEntity.Content = req.Content;
            articleEntity.Created = req.Created;
            articleEntity.ContentTypeId = req.ContentTypeId;
            articleEntity.TagId = req.TagId;

            _context.Update(articleEntity);
            await _context.SaveChangesAsync();

            return articleEntity;
        }

        return null!;
    }

}



