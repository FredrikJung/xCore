using Assignment_ClassLibrary.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Assignment_ClassLibrary.Models.Base;

public abstract class ArticleBase : IArticle
{
    [Required]
    public string Headline { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Created { get; set; }
    public int ContentTypeId { get; set; }
    public int TagId { get; set; }
  
}
