using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.DTOs;
using Assignment_ClassLibrary.Models.Validators;
using Assignment_WebApi.Repositories;

namespace Assignment_WebApi.Services;

public class ArticleService
{
    private readonly ArticleRepository _articleRepo;
    private readonly AuthorRepository _authorRepo;
    private readonly ArticleRowRepositoy _articleRowRepo;
    private readonly ContentTypeRepository _contentTypeRepo;
    private readonly TagRepository _tagRepo;
    private readonly ArticleValidator _validator;

    public ArticleService(ArticleRepository articleRepo, AuthorRepository authorRepo, ArticleRowRepositoy articleRowRepo, ContentTypeRepository contentTypeRepo, TagRepository tagRepo, ArticleValidator validator)
    {
        _articleRepo = articleRepo;
        _authorRepo = authorRepo;
        _articleRowRepo = articleRowRepo;
        _contentTypeRepo = contentTypeRepo;
        _tagRepo = tagRepo;
        _validator = validator;
    }

    public async Task<ArticleResponse> CreateArticleAsync(ArticleRequest req)
    {
        var articleEntity = await _articleRepo.CreateArticleAsync(req);
        await _contentTypeRepo.GetContentTypeAsync(req.ContentTypeId);
        await _tagRepo.GetTagAsync(req.TagId);

        
        if (articleEntity != null)
        {
            foreach (var authorId in req.AuthorIds)
            {
                var authorEntity = await _authorRepo.GetAuthorAsync(authorId);
                if (authorEntity != null)
                {
                    await _articleRowRepo.CreateArticleRowsAsync(articleEntity, authorEntity);
                }

            }

            ArticleResponse res = articleEntity;

            return res;

        }

        return null!;
    }

    public async Task<IEnumerable<ArticleResponse>> GetAllArticlesAsync()
    {
        var articleEntities = await _articleRepo.GetAllArticlesAsync();

        var articleResponses = ArticleResponseFactory.CreateList();

        foreach(var articleEntity in articleEntities)
        {
            articleResponses.Add(articleEntity);
        }

        return articleResponses;
    }

    public async Task<IEnumerable<ArticleResponse>> GetAllArticlesSortedAsync(string sortBy)
    {
        var articleEntities = await _articleRepo.GetAllArticlesAsync();
        var sortedEntities = articleEntities;

        switch (sortBy)
        {
            case "Created":
                sortedEntities = articleEntities.OrderByDescending(x => x.Created).Reverse();
                break;

            case "Content type":
                sortedEntities = articleEntities.OrderByDescending(x => x.ContentType.TypeName).Reverse();
                break;

            case "Tag":
                sortedEntities = articleEntities.OrderByDescending(x => x.Tag.TagName).Reverse();
                break;

            case "Headline":
                sortedEntities = articleEntities.OrderByDescending(x => x.Headline).Reverse();
                break;

            case "Content":
                sortedEntities = articleEntities.OrderByDescending(x => x.Content).Reverse();
                break;

            case "Author":
                sortedEntities = articleEntities.OrderByDescending(x => x.ArticleRows.First().Author.LastName).Reverse();
                break;

            default:
                sortedEntities = articleEntities.OrderByDescending(x => x.Id).Reverse();
                break;
        }

        var articleResponses = ArticleResponseFactory.CreateList();

        foreach (var articleEntity in sortedEntities)
        {
            articleResponses.Add(articleEntity);
        }

        return articleResponses;
    }

    public async Task<IEnumerable<ArticleResponse>> GetAllArticlesByContentType(int id)
    {
        _validator.ValidateGetArticleContentTypeId(id);

        var articles = await _articleRepo.GetAllArticlesAsync();
        var filteredArticles = articles.Where(article => article.ContentTypeId == id);

        var articleResponses = ArticleResponseFactory.CreateList();

        foreach (var articleEntity in filteredArticles)
        {
            articleResponses.Add(articleEntity);
        }

        return articleResponses;

    }

    public async Task<ArticleResponse> GetArticleAsync(int id)
    {
        var articleEntity = await _articleRepo.GetArticleAsync(id);

        return articleEntity!;
    }

    public async Task DeleteArticleAsync(int id)
    {
        await _articleRepo.DeleteArticleAsync(id);
    }

    public async Task<ArticleResponse> UpdateArticleAsync(int id, ArticleRequest req)
    {
        var articleEntity = await _articleRepo.UpdateArticleAsync(id, req);
        await _contentTypeRepo.GetContentTypeAsync(req.ContentTypeId);
        await _tagRepo.GetTagAsync(req.TagId);

        if (articleEntity != null)
        {
            foreach(var authorId in req.AuthorIds)
            {
                var authorEntity = await _authorRepo.GetAuthorAsync(authorId);
                if(authorEntity != null)
                {
                    await _articleRowRepo.CreateArticleRowsAsync(articleEntity, authorEntity);
                }
            }
            
            return articleEntity;
        }

        return null!;
    }
}


