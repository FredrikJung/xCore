using Assignment_ClassLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ClassLibrary.Models.Base;

public abstract class TagBase : ITag
{
    [Required]
    public string TagName { get; set; } = null!;
}
