using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public class DataGenerator 
    { 
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                var data = new Book[]
                {
                    new Book {
                        Id=1,
                        Title = "Stone Maidens",
                        Author = "Lloyd Devereux Richards",
                        Cover = "test",
                        Genre = "Mystery",
                        Content = "test",
                        Ratings = new Rating[] { new Rating() { Score = 3, BookId = 1 }, new Rating() { Score = 5, BookId = 1 } },
                        Reviews = new Review[] { new Review() { Message = "I couldn't put it down", Reviewer = "test1", BookId = 1 }, new Review() { Message = "I couldn't put it down", Reviewer = "test1", BookId = 1 } },
                    },
                    new Book {
                        Id=2,
                        Title = "Verity",
                        Author = "Colleen Hoover",
                        Cover = "test",
                        Genre = "Fiction",
                        Content = "test",
                        Ratings = new Rating[] { new Rating() { Score = 5, BookId = 2 }, new Rating() { Score = 5, BookId = 2 } },
                        Reviews = new Review[] { new Review() { Message = "Blown away", Reviewer = "test2", BookId = 2 }, new Review() { Message = "Blown away", Reviewer = "test2", BookId = 2 } },
                    },
                    new Book {
                        Id = 3,
                        Title = "Dressed for Sorrow",
                        Author = "RandomGenerator",
                        Cover = "test",
                        Genre = "Crime",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id = 4,
                        Title = "Isle of Lords",
                        Author = "RandomGenerator",
                        Cover = "test",
                        Genre = "Fantasy",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=5,
                        Title = "Paladin's Gold",
                        Author = "RandomGenerator",
                        Cover = "test",
                        Genre = "Fantasy",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=6,
                        Title = "The time of the prey",
                        Author = "RandomGenerator",
                        Cover = "test",
                        Genre = "Fantasy",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=7,
                        Title = "The Shadow Prophecy",
                        Author = "RandomGenerator2",
                        Cover = "test",
                        Genre = "Fantasy",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=8,
                        Title = "The Shadow Prophecy",
                        Author = "RandomGenerator2",
                        Cover = "test",
                        Genre = "Fantasy",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=9,
                        Title = "Clue of the devil's amulet",
                        Author = "RandomGenerator2",
                        Cover = "test",
                        Genre = "Mystery",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                    new Book {
                        Id=10,
                        Title = "The freaky painting",
                        Author = "RandomGenerator2",
                        Cover = "test",
                        Genre = "Mystery",
                        Content = "test",
                        Ratings = new Rating[] {},
                        Reviews = new Review[] { },
                    },
                };

                context.Books.AddRange(data);
                context.SaveChanges();
            }
        }
    }
}
