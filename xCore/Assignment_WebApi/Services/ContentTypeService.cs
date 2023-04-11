using Assignment_ClassLibrary.Models.DTOs;
using Assignment_WebApi.Repositories;

namespace Assignment_WebApi.Services;

public class ContentTypeService
{
    private readonly ContentTypeRepository _contentTypeRepo;

    public ContentTypeService(ContentTypeRepository contentTypeRepo)
    {
        _contentTypeRepo = contentTypeRepo;
    }

    public async Task<ContentTypeResponse> CreateContentTypeAsync(ContentTypeRequest req)
    {
        var contentTypeEntity = await _contentTypeRepo.CreateContentTypeAsync(req);

        if(contentTypeEntity != null)
        {
            ContentTypeResponse res = contentTypeEntity;

            return res;
        }

        return null!;
    }
}
