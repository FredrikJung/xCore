using Assignment_ClassLibrary.Interfaces;
using Assignment_ClassLibrary.Models.Base;

namespace Assignment_ClassLibrary.Models.DTOs;

public class ArticleResponse : ArticleBase, IArticleResponse
{
    public int ArticleId { get; set; }
    public string ContentTypeName { get; set; } = null!;
    public string TagName { get; set; } = null!;
    public List<string>? Authors { get; set; } 
    public List<int> AuthorIds { get; set; } = null!;
}
