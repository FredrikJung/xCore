using Assignment_ClassLibrary.Interfaces;
using Assignment_ClassLibrary.Models.Entities;

namespace Assignment_ClassLibrary.Models.Base;

public abstract class ArticleRowBase : IArticleRow
{
    public int ArticleId { get; set; }
    public ArticleEntity Article { get; set; } = null!;
    public int AuthorId { get; set; }
    public AuthorEntity Author { get; set; } = null!;
}
