using Assignment_ClassLibrary.Models.Entities;
using Assignment_WebApi.Contexts;

namespace Assignment_WebApi.Repositories;

public class AuthorRepository
{
    private readonly DataContext _context;

    public AuthorRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<AuthorEntity?> GetAuthorAsync(int authorId)
    {
        return await _context.Authors.FindAsync(authorId);
    }
}
