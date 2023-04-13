using Assignment_ClassLibrary.Models.DTOs;
using Assignment_ClassLibrary.Models.Entities;
using Assignment_WebApi.Contexts;

namespace Assignment_WebApi.Repositories;

public class ContentTypeRepository
{
    private readonly DataContext _context;

    public ContentTypeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ContentTypeEntity> CreateContentTypeAsync(ContentTypeRequest req)
    {
        ContentTypeEntity contentTypeEntity = req;

        _context.ContentTypes.Add(contentTypeEntity);
        await _context.SaveChangesAsync();

        return contentTypeEntity;
    }

    public async Task<ContentTypeEntity?> GetContentTypeAsync(int contentTypeId)
    {
        return await _context.ContentTypes.FindAsync(contentTypeId);
    }
}
