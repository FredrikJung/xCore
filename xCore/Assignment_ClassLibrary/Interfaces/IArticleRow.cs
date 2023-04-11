using Assignment_ClassLibrary.Models.Entities;

namespace Assignment_ClassLibrary.Interfaces;

public interface IArticleRow
{
    public int ArticleId { get; set; }
    public ArticleEntity Article { get; set; } 
    public int AuthorId { get; set; }
    public AuthorEntity Author { get; set; } 
}
