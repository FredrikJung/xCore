using Assignment_ClassLibrary.Interfaces;
using Assignment_ClassLibrary.Models.Base;

namespace Assignment_ClassLibrary.Models.DTOs;

public class ContentTypeResponse : ContentTypeBase, IContentTypeResponse
{
    public int ContentTypeId { get; set; }
}
