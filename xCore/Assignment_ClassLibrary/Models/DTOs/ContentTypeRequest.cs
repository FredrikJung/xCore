using Assignment_ClassLibrary.Factories;
using Assignment_ClassLibrary.Models.Base;
using Assignment_ClassLibrary.Models.Entities;

namespace Assignment_ClassLibrary.Models.DTOs;

public class ContentTypeRequest : ContentTypeBase
{
    public static implicit operator ContentTypeEntity(ContentTypeRequest req)
    {
        var contentTypeEntity = ContentTypeEntityFactory.Create();

        contentTypeEntity.TypeName = req.TypeName;

        return contentTypeEntity;
    }
}
