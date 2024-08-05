using BlogOnline.Models.DTOs.Responses;
using BlogOnline.Models.Entities;

namespace BlogOnline.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationRes>> GetAllLocationAsync();
    }
}
