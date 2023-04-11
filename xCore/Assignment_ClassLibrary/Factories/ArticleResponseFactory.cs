using Assignment_ClassLibrary.Models.DTOs;

namespace Assignment_ClassLibrary.Factories;

public class ArticleResponseFactory
{
    public static ArticleResponse Create()
    {
        return new ArticleResponse();
    }

    public static List<ArticleResponse> CreateList()
    {
        return new List<ArticleResponse>();
    }
}
