namespace Assignment_ClassLibrary.Interfaces;

public interface IArticleResponse 
{
    public int ArticleId { get; set; }
    public string ContentTypeName { get; set; }
    public string TagName { get; set; }
    public List<int> AuthorIds { get; set; }
}
