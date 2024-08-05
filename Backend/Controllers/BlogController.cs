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

        /**
          * Retrieves all blogs.
          * @return A list of all blogs.
          */
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        /**
         * Retrieves a blog by its ID.
         * @param id The ID of the blog.
         * @return The blog with the specified ID.
         */
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        /**
         * Creates a new blog.
         * @param form The blog data transfer object containing the blog details.
         * @return The result of the blog creation.
         */
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
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        /**
         * Removes a blog by its ID.
         * @param id The ID of the blog to be removed.
         * @return No content if the blog is successfully removed.
         */
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
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        /**
         * Updates an existing blog.
         * @param form The blog data transfer object containing the updated blog details.
         * @return A response indicating the result of the update.
         */
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
                return Ok(new Response("Success", "Update blog successfully"));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }

        /**
         * Searches for blogs based on a search string.
         * @param searchString The search string to filter blogs.
         * @return A list of blogs that match the search criteria.
         */
        [HttpGet("search")]
        public async Task<IActionResult> SearchBlog([FromQuery] string? searchString)
        {
            try
            {
                if (string.IsNullOrEmpty(searchString)) return Ok(new List<BlogRes>());
                var searchResult = await _blogService.SearchBlogAsync(searchString);
                return Ok(searchResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }
    }
}