using BlogOnline.Base;
using BlogOnline.Models.Entities;
using BlogOnline.Services;
using BlogOnline.Services.Interfaces;
using BlogOnline.Services.Services;

namespace BlogOnline.Extension
{
    public class ServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            //Services
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILocationService, LocationService>();

            //Repositories
            services.AddScoped<IBaseRepository<Blog>, BaseRepository<Blog>>();
            services.AddScoped<IBaseRepository<Location>, BaseRepository<Location>>();
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();




        }
    }
}
