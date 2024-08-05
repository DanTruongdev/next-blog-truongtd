using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categoryList = await _categoryService.GetAllCategoryAsync();
            return Ok(categoryList);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLocationById([FromRoute]Guid id)
        //{
        //    var blog = await _locationService(id);
        //    return Ok(blog);
        //}
       
    }
}