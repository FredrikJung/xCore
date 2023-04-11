using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Interfaces;
using Assignment_ClassLibrary.Models.Base;
using Assignment_ClassLibrary.Models.Entities;

namespace Assignment_ClassLibrary.Models.DTOs;

public class ArticleRequest : ArticleBase, IArticleRequest
{
    public List<int> AuthorIds { get; set; } = null!;

    public static implicit operator ArticleEntity(ArticleRequest req)
    {
        var articleEntity = ArticleEntityFactory.Create();

        articleEntity.Headline = req.Headline;
        articleEntity.Content = req.Content;
        articleEntity.Created = req.Created = DateTime.Now;
        articleEntity.ContentTypeId = req.ContentTypeId;
        articleEntity.TagId = req.TagId;

        return articleEntity;
    }


}
