using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            var locationList = await _locationService.GetAllLocationAsync();
            return Ok(locationList);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetLocationById([FromRoute]Guid id)
        //{
        //    var blog = await _locationService(id);
        //    return Ok(blog);
        //}
       
    }
}