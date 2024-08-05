using BlogOnline.Models.DTOs.Requests;
using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using BlogOnline.Services;
using BlogOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<Blog> _logger;


        public BlogController(IBlogService blogService, ILocationService locationService, ICategoryService categoryService, ILogger<Blog> logger)
        {
            _blogService = blogService;
            _locationService = locationService;
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                _logger.LogInformation("Hello from logger");
                var blogList = await _blogService.GetAllBlogsAsync();
                if (!blogList.Any()) return Ok(new List<Blog>());
                return Ok(blogList);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById([FromRoute] Guid id)

        {

            try
            {
                var blog = await _blogService.GetBlogByIdAsync(id);
                return Ok(blog);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> CreateBlog([FromForm] BlogDto form)
        {
            try
            {
                var result = await _blogService.AddBlogAsync(form);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveBlog([FromRoute] Guid id)
        {
            try
            {
                var result = await _blogService.RemoveBlogAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }





        [HttpPut("update")]
        public async Task<IActionResult> UpdateBlog([FromForm] BlogDto form)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new Response("Error", ModelState.ToString()));

                }
                var result = await _blogService.UpdateBlogAsync(form);
                if (!result) return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", "An error occurs during update blog"));
                return Ok(new Response("Succes", "Update blog successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }

           
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBlog([FromQuery] string? searchString)
        {
            try
            {
                if (searchString.IsNullOrEmpty()) return Ok(new List<BlogRes>());
                var searchResult = await _blogService.SearchBlogAsync(searchString);
                return Ok(searchResult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }

        }
    }
}