using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.Base;
using Assignment_ClassLibrary.Models.DTOs;

namespace Assignment_ClassLibrary.Models.Entities;

public class ArticleEntity : ArticleBase
{
    public int Id { get; set; }
    public ContentTypeEntity ContentType { get; set; } = null!;
    public TagEntity Tag { get; set; } = null!;

    public ICollection<ArticleRowEntity> ArticleRows { get; set; } = null!;

    public static implicit operator ArticleResponse(ArticleEntity articleEntity)
    {
        var res = ArticleResponseFactory.Create();

        res.ArticleId = articleEntity.Id;
        res.Headline = articleEntity.Headline;
        res.Content = articleEntity.Content;
        res.Created = articleEntity.Created;
        res.AuthorIds = articleEntity.ArticleRows.Select(x => x.AuthorId).ToList();
        res.Authors = articleEntity.ArticleRows?.Select(x => $"{x.Author.FirstName} {x.Author.LastName}").ToList();
        res.TagId = articleEntity.TagId;
        res.TagName = articleEntity.Tag.TagName;
        res.ContentTypeId = articleEntity.ContentTypeId;
        res.ContentTypeName = articleEntity.ContentType.TypeName;

        return res;
         
    }

}
