using Assignment_ClassLibrary.Models.Base;

namespace Assignment_ClassLibrary.Models.Entities;

public class AuthorEntity : AuthorBase
{
    public int Id { get; set; }
    public ICollection<ArticleRowEntity>? ArticlesRows { get; set; }

}
