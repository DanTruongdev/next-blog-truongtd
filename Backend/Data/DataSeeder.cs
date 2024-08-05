using BlogOnline.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogOnline.Data
{
    public class DataSeeder
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (!dbContext.Locations.Any())
                {
                    dbContext.AddRange(
                        new Location
                        {
                            Name = "Vietnam"
                        },
                        new Location
                        {
                            Name = "Asia"
                        },
                        new Location
                        {
                            Name = "Euro"
                        },
                        new Location
                        {
                            Name = "Africa"
                        },
                        new Location
                        {
                            Name = "America"
                        }
                    );
                    dbContext.SaveChanges();
                }

                if (!dbContext.Categories.Any())
                {
                    dbContext.AddRange(
                        new Category
                        {
                            Name = "Business"
                        },
                        new Category
                        {
                            Name = "Politics"
                        },
                        new Category
                        {
                            Name = "Society"
                        },
                        new Category
                        {
                            Name = "Law"
                        },
                        new Category
                        {
                            Name = "Entertainment"
                        }
                    );
                    dbContext.SaveChanges();
                }

                if (!dbContext.Blogs.Any())
                {
                    dbContext.AddRange(
                            new Blog
                            {
                                Title = "This is my first blog",
                                ShortDescription = "This is my first blog",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Veritatis veniam cum autem iusto ducimus optio sint! Qui molestiae, " +
                                            "quidem esse autem accusamus saepe placeat, officiis vero vitae laboriosam maxime. Ut.",
                                LocationId = dbContext.Locations.First().Id,
                                CategoryId = dbContext.Categories.First().Id
                            },
                            new Blog
                            {
                                Title = "Exploring the Mountains",
                                ShortDescription = "A journey through the mountains",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusamus, nulla? Voluptates, nostrum! Consequatur repudiandae " +
                                            "itaque impedit tempora temporibus distinctio, fugiat quidem dolore. Autem, dignissimos? Quisquam!",
                                LocationId = dbContext.Locations.Skip(1).First().Id,
                                CategoryId = dbContext.Categories.Skip(1).First().Id
                            },
                            new Blog
                            {
                                Title = "City Lights and Nights",
                                ShortDescription = "The beauty of city life at night",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusantium, quisquam eaque. Voluptates, alias? Nobis nisi dolore " +
                                            "voluptatibus placeat adipisci consequuntur ipsum perferendis molestiae quibusdam facilis.",
                                LocationId = dbContext.Locations.Skip(2).First().Id,
                                CategoryId = dbContext.Categories.Skip(2).First().Id
                            },
                            new Blog
                            {
                                Title = "Tech Innovations 2024",
                                ShortDescription = "Latest trends in technology",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quas, dolorem! Voluptatibus ratione, perferendis saepe amet quidem " +
                                            "quibusdam tempora, nihil provident obcaecati sed ex, molestiae repellendus?",
                                LocationId = dbContext.Locations.Skip(3).First().Id,
                                CategoryId = dbContext.Categories.Skip(3).First().Id
                            },
                            new Blog
                            {
                                Title = "Healthy Living Tips",
                                ShortDescription = "Guide to a healthier lifestyle",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit, facilis? Officia iure tempora porro rerum ex quod beatae " +
                                            "nesciunt distinctio. Molestiae, ipsam! Facere, tempore consequatur!",
                                LocationId = dbContext.Locations.Skip(4).First().Id,
                                CategoryId = dbContext.Categories.Skip(4).First().Id
                            },
                            new Blog
                            {
                                Title = "A Trip to Remember",
                                ShortDescription = "Travel experiences worth sharing",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatum, mollitia. Ab quaerat, deserunt veniam reprehenderit " +
                                            "voluptatibus magni tempora laudantium! Illo, natus dolor? Eaque, dolorem perspiciatis.",
                                LocationId = dbContext.Locations.Skip(1).First().Id,
                                CategoryId = dbContext.Categories.Skip(1).First().Id
                            },
                            new Blog
                            {
                                Title = "Gourmet Delights",
                                ShortDescription = "Exploring fine dining",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Similique, deserunt? Magnam consectetur nihil odio, " +
                                            "doloribus aspernatur recusandae inventore unde animi aliquam! Sunt, dignissimos dolore!",
                                LocationId = dbContext.Locations.Skip(2).First().Id,
                                CategoryId = dbContext.Categories.Skip(2).First().Id
                            },
                            new Blog
                            {
                                Title = "Art and Culture",
                                ShortDescription = "The essence of art in our lives",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis deleniti doloribus, harum veritatis quisquam saepe " +
                                            "porro, nisi iste iure autem quae quos aspernatur officiis deserunt.",
                                LocationId = dbContext.Locations.Skip(3).First().Id,
                                CategoryId = dbContext.Categories.Skip(2).First().Id
                            },
                            new Blog
                            {
                                Title = "Fitness Journey",
                                ShortDescription = "Steps to achieving your fitness goals",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta, perspiciatis. Excepturi nemo, delectus culpa illum " +
                                            "obcaecati quos assumenda voluptas neque ullam laboriosam, error quam, debitis tenetur.",
                                LocationId = dbContext.Locations.Skip(4).First().Id,
                                CategoryId = dbContext.Categories.Skip(1).First().Id
                            },
                            new Blog
                            {
                                Title = "Sustainable Living",
                                ShortDescription = "How to live sustainably",
                                Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam, nostrum! Magnam nesciunt nulla itaque quam, " +
                                            "voluptatibus provident ipsam cum, voluptate libero eos tempora nisi doloremque.",
                                LocationId = dbContext.Locations.Skip(3).First().Id,
                                CategoryId = dbContext.Categories.Skip(2).First().Id
                            }
                        );
                    dbContext.SaveChanges();
                }

            }
        }
    }
}
