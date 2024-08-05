using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using BlogOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<Location> _logger;

        public LocationController(ILocationService locationService, ILogger<Location> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }



        /**
         * Retrieves all locations.
         * @return A list of all locations.
         */
        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var locationList = await _locationService.GetAllLocationAsync();
                return Ok(locationList);

            } catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new Response("Error", e.Message));
            }
        }
    }
}