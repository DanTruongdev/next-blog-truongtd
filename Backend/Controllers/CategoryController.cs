using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using BlogOnline.Services.Interfaces;
using BlogOnline.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<Category> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<Category> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }


        /**
       * Retrieves all categories.
       * @return A list of all categories.
       */
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var categoryList = await _categoryService.GetAllCategoryAsync();
                return Ok(categoryList);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
            
        }

       
       
    }
}