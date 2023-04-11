using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.Base;
using Assignment_ClassLibrary.Models.DTOs;

namespace Assignment_ClassLibrary.Models.Entities;

public class ContentTypeEntity : ContentTypeBase
{
    public int Id { get; set; }
    public ICollection<ArticleEntity>? Articles { get; set; }

    public static implicit operator ContentTypeResponse(ContentTypeEntity contentTypeEntity)
    {
        var res = ContentTypeResponseFactory.Create();

        res.ContentTypeId = contentTypeEntity.Id;
        res.TypeName = contentTypeEntity.TypeName;

        return res;
    }

}
