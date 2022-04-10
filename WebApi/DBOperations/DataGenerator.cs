using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return; 
                }

                context.Books.AddRange(
                    new Book{  
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, // PersonalGrowth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book{                            
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, // ScienceFiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,11)
                    },
                    new Book{
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, // ScienceFiction
                        PageCount = 500,
                        PublishDate = new DateTime(2002,12,8)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}