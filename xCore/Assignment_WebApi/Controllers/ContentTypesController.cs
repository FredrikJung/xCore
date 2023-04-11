using Assignment_ClassLibrary.Models.DTOs;
using Assignment_WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace Assignment_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentTypesController : ControllerBase
    {
        private readonly ContentTypeService _contentTypeService;

        public ContentTypesController(ContentTypeService contentTypeService)
        {
            _contentTypeService = contentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContentTypeAsync(ContentTypeRequest req)
        {
            if (ModelState.IsValid)
            {
                ContentTypeResponse res = await _contentTypeService.CreateContentTypeAsync(req);
                if (res != null)
                    return Created("", res);
            }

            return BadRequest();
        }

    }
}
