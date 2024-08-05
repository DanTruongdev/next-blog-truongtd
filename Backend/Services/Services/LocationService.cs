using BlogOnline.Base;
using BlogOnline.Extentions;
using BlogOnline.Models.DTOs.Requests;
using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;
using BlogOnline.Services.Interfaces;
using System.Linq.Expressions;

namespace BlogOnline.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IBaseRepository<Location> _locationRepository;

        public LocationService(IBaseRepository<Location> blogRepository)
        {
            _locationRepository = blogRepository;
        }

        public async Task<IEnumerable<LocationRes>> GetAllLocationAsync()
        {
            var locationList = await _locationRepository.GetAllAsync();
            if (!locationList.Any()) return new List<LocationRes>();
            var resData = locationList.Select(l => new LocationRes
            {
               Id = l.Id,
               Name = l.Name,
            });
            return resData;
        }

       
    }
}
