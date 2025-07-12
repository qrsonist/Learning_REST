using Learning_REST.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Learning_REST.Data
{
    // this is a context class
    // serves as the bridge between c# code and db
    // inherits DbContext, class from EF core with properties and methods to help interact with db
    public class Learning_RESTContext : DbContext
    {
        public Learning_RESTContext(DbContextOptions<Learning_RESTContext> options) : base(options)
        {

        }

        // overriding a base method of the DbContext class
        // migrating starting data to db
        // then in package manager, Add-Migration "book data added"
        // and Update-Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // calling base function
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Pillars of the Earth",
                    Author = "Follett, Ken",
                    YearPublished = 1989,
                    NumPages = 806,
                    Genres = { "Historical Fiction" },
                },

                new Book
                {
                    Id = 2,
                    Title = "The Left Hand of Darkness",
                    Author = "Le Guin, Ursula K.",
                    YearPublished = 1969,
                    NumPages = 286,
                    Genres = { "Science Fiction" }
                },

                new Book
                {
                    Id = 3,
                    Title = "Sharp Objects",
                    Author = "Flynn, Gillian",
                    YearPublished = 2006,
                    Genres = {
                        "Psychological Thriller",
                        "Southern Gothic",
                        "Mystery"
                    },
                },

                new Book
                {
                    Id = 4,
                    Title = "The Fifth Season",
                    Author = "Jemisin, N. K.",
                    YearPublished = 2015,
                    NumPages = 512,
                    Genres = { "Science Fantasy" }
                },

                new Book
                {
                    Id = 5,
                    Title = "Steve Jobs",
                    Author = "Isaacson, Walter",
                    YearPublished = 2011,
                    NumPages = 656,
                    Genres = { "Biography" }
                },

                new Book
                {
                    Id = 6,
                    Title = "Me Before You",
                    Author = "Moyes, Jojo",
                    YearPublished = 2012,
                    NumPages = 480,
                    Genres = {
                       "Romance",
                       "Fiction"
                    }
                },

                new Book
                {
                    Id = 7,
                    Title = "The Story of Jazz",
                    Author = "Stearns, Marshall W.",
                    YearPublished = 1970,
                    NumPages = 367,
                    Genres = {
                       "Music",
                       "History",
                       "Nonfiction"
                    }
                },

                new Book
                {
                    Id = 8,
                    Title = "It",
                    Author = "King, Stephen",
                    YearPublished = 1986,
                    NumPages = 1138,
                    Genres = {
                       "Horror",
                       "Thriller",
                       "Dark Fantasy"
                    }
                },

                new Book
                {
                    Id = 9,
                    Title = "The Extraordinary Life of Sam Hell",
                    Author = "Dugoni, Robert",
                    YearPublished = 2018,
                    NumPages = 448,
                    Genres = { "Historical Fiction" }
                },

                new Book
                {
                    Id = 10,
                    Title = "The Golden Ratio",
                    Subtitle = "The Story of Phi, the World's Most Astonishing Number",
                    Author = "Livio, Mario",
                    YearPublished = 2002,
                    NumPages = 294,
                    Genres ={
                        "Science",
                        "Nonfiction",
                        "Mathematics",
                        "History",
                        "Philosophy"
                    }
                }
            );
        }

        // helps migrate book model to db as a table in db
        // then in package manager, Add-Migration "book model added"
        // and Update-Database
        public DbSet<Book> Books { get; set; }
    }
}
