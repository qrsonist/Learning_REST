using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Learning_REST.Models;

namespace Learning_REST.APIControllers
{
    [Route("api/[controller]")]
    // can be accessed by going to site URL /api/NAME_OF_CONTROLLER
    [ApiController]
    public class BookController : ControllerBase
    {
        // list is static so that it is not re-initialized every single time the controller is called
        static private List<Book> allBooks = new List<Book>
        {

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
        };

        // denotes that the below function corresponds to the HTTP Get method
        [HttpGet]
        // return type is ActionResult because regardless of the data type we want to return the method must also return a status code (200 - Ok, 404 - Error, etc.)
        public ActionResult<List<Book>> getBooks()
        {
            // the Ok() object is responsible for the status code
            return Ok(allBooks);
        }

        // another get method but the associated function will be responsible for serving user data for specific book
        // '"{id}"' denotes that we expect the id of a book to be provided when making the request
        [HttpGet("{id}")]
        public ActionResult<Book> getBookById(int id)
        {
            // returns the first element of the allBooks sequence whose Id value matches the id parameter
            Book? book = allBooks.FirstOrDefault(x => x.Id == id);

            // see if the book exists
            if (book == null)
            {
                // 404 status code
                return NotFound($"Book with ID: {id} does not exist.");
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult addBook(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                // 400 status code - data that was sent is not in a valid format
                return BadRequest("Try again!");
            }

            if (allBooks.FirstOrDefault(x => x.Id == bookToAdd.Id) != null)
            {
                // 409 status code - indicates that there is some conflict with the current state of the resource
                return Conflict($"Book with ID: {bookToAdd.Id} already exists.");
            }

            // NO GAPS!!!
            bookToAdd.Id = allBooks.Count + 1;
            allBooks.Add(bookToAdd);

            // 201 status code - indicates a resouce was created
            //                          route      id (which i found out is neccessary)   \/ and book
            return CreatedAtAction(nameof(getBookById), new { Id = bookToAdd.Id }, bookToAdd);

        }

        [HttpPut("{id}")]
        public ActionResult updateBook(int id, Book bookToPut)
        {
            Book? bookToReplace = allBooks.FirstOrDefault(x => x.Id == id);
            if (bookToReplace == null)
            {
                return NotFound($"Book with ID: {id} does not exist.");
            }
            if (id != bookToPut.Id)
            {
                return Conflict($"Mismatch between destination ID: {id} and provided book's ID: {bookToPut.Id}");
            }

            allBooks[bookToReplace.Id-1] = bookToPut;
            return CreatedAtAction(nameof(getBookById), new { Id = bookToPut.Id }, bookToPut);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteBook(int id)
        {
            Book? bookToDelete = allBooks.FirstOrDefault(x => x.Id == id);
            if (bookToDelete == null)
            {
                return NotFound($"Book with ID: {id} does not exist.");
            }

            allBooks.Remove(bookToDelete);
            // iterating over each book whose id is greater than the book that was just removed
            foreach (Book book in allBooks.Where(x => x.Id > id))
            {
                // subtracting the Id because NO GAPS >:(
                book.Id--;
            }
            return Ok($"Book with ID: {id} successfully removed.");
        }
    }
}
