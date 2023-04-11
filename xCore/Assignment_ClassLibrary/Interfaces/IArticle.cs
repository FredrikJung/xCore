namespace Assignment_ClassLibrary.Interfaces;

public interface IArticle
{
    public string Headline { get; set; } 
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public int ContentTypeId { get; set; }
    public int TagId { get; set; }

}
