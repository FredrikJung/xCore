using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.DTOs;
using Assignment_WebApi.Contexts;

namespace Assignment_ClassLibrary.Models.Validators;

public class ArticleValidator
{
    private readonly DataContext _context;

    public ArticleValidator(DataContext context)
    {
        _context = context;
    }

    public void ValidateArticleRequest(ArticleRequest req)
    {
        if (req == null)
        {
            throw ArgumentExceptionFactory.Create(nameof(req));
        }

        var contentType = _context.ContentTypes.FirstOrDefault(x => x.Id == req.ContentTypeId);
        if (contentType == null)
        {
            throw ArgumentExceptionFactory.Create($"ContentTypeId {req.ContentTypeId} is not valid");
        }

        var tag = _context.Tags.FirstOrDefault(x => x.Id == req.TagId);
        if (tag == null)
        {
            throw ArgumentExceptionFactory.Create($"TagId {req.TagId} is not valid");
        }

        if(req.AuthorIds != null && req.AuthorIds.Any())
        {
            foreach(var authorId in req.AuthorIds)
            {
                var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
                if (author == null) 
                {
                    throw ArgumentExceptionFactory.Create($"AuthorId {authorId} is not valid");
                }
            }
        }

    }

    public void ValidateGetArticleById(int Id)
    {
        var article = _context.Articles.FirstOrDefault(x => x.Id == Id);
        if (article == null)
        {
            throw ArgumentExceptionFactory.Create($"ArticleId {Id} is not valid");
        }
    }

    public void ValidateGetArticleContentTypeId(int Id)
    {
        var contentType = _context.Articles.FirstOrDefault(x => x.ContentTypeId == Id);
        if (contentType == null)
        {
            throw ArgumentExceptionFactory.Create($"ContentTypeId {Id} is not valid");
        }
    }
}
