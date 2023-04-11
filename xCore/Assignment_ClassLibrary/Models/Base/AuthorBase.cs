using Assignment_ClassLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Assignment_ClassLibrary.Models.Base;

public abstract class AuthorBase : IAuthor
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
}
