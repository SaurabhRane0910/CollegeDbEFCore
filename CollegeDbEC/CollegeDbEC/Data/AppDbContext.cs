using Microsoft.EntityFrameworkCore;

namespace CollegeDbEC.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(

                new Currency { Id =1 , title ="INR", Description ="Indian INR"},
                 new Currency { Id = 2, title = "Doller", Description = "Doller" },
                  new Currency { Id = 3, title = "Euro", Description = "Euro" }
                );


            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Titile = "Hindi", Description = "National Language" },
                new Language { Id = 2, Titile = "English", Description = "Universal Language" },
                new Language { Id = 3, Titile = "Marathi", Description = "Maharashtrian Language" }
                );


            modelBuilder.Entity<Author>().HasData(
                new Author { Author_id = 1, AuthorName = "Harry", Email = "harry@gmail.com" },
                new Author { Author_id = 2, AuthorName = "Hermoine", Email = "hermoine@gmail.com" },
                new Author { Author_id = 3, AuthorName = "Peter", Email = "peterParkar@gmail.com" }

                );
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Currency> currencies { get; set; }

        public DbSet<Author> author { get; set; }
    }
}
