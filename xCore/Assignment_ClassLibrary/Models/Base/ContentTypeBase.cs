using Assignment_ClassLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ClassLibrary.Models.Base;

public abstract class ContentTypeBase : IContentType
{
    [Required]
    public string TypeName { get; set; } = null!;
}
