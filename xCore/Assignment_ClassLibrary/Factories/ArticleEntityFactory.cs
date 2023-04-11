using Assignment_ClassLibrary.Models.Entities;

namespace Assignment_ClassLibrary.Factories;

public class ArticleEntityFactory
{
    public static ArticleEntity Create()
    {
        return new ArticleEntity();
    }
}
