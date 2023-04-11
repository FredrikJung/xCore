using Assignment_ClassLibrary.Models.Entities;
using Assignment_WebApi.Contexts;

namespace Assignment_WebApi.Repositories;

public class TagRepository
{
    private readonly DataContext _context;

    public TagRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<TagEntity?> GetTagAsync(int tagId)
    {
        return await _context.Tags.FindAsync(tagId);
    }
}
