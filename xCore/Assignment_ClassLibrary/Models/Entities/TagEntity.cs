using Assignment_ClassLibrary.Models.Base;

namespace Assignment_ClassLibrary.Models.Entities;

public class TagEntity : TagBase
{
    public int Id { get; set; }
    public ICollection<ArticleEntity>? Articles { get; set; }
}
