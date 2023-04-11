using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.Entities;
using Assignment_WebApi.Contexts;

namespace Assignment_WebApi.Repositories;

public class ArticleRowRepositoy
{
    private readonly DataContext _context;

    public ArticleRowRepositoy(DataContext context)
    {
        _context = context;
    }

    public async Task<ArticleRowEntity> CreateArticleRowsAsync (ArticleEntity articleEntity, AuthorEntity authorEntity)
    {
        var articleRowEntity = ArticleRowEntityFactory.Create();
        articleRowEntity.Author = authorEntity;
        articleRowEntity.Article = articleEntity;

        _context.ArticleRows.Add(articleRowEntity);
        await _context.SaveChangesAsync();

        return articleRowEntity;
    }

}

