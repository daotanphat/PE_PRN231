using GivenAPI_PE_FA24.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GivenAPI_PE_FA24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                BookId = 1,
                Title = "Harry Potter and the Philosopher's Stone",
                Publisher = "Bloomsbury",
                PublicationYear = 1997,
                Authors = new HashSet<Author>
                {
                    new Author { AuthorId = 1, Name = "J.K. Rowling", Bio = "British author, best known for the Harry Potter series." }
                }
            },
            new Book
            {
                BookId = 2,
                Title = "The Hobbit",
                Publisher = "HarperCollins",
                PublicationYear = 1937,
                Authors = new HashSet<Author>
                {
                    new Author { AuthorId = 2, Name = "J.R.R. Tolkien", Bio = "English writer, poet, and academic, best known for 'The Hobbit' and 'The Lord of the Rings.'" }
                }
            }
        };

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        // POST api/books
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            book.BookId = books.Max(b => b.BookId) + 1; // Tự động tăng ID
            books.Add(book);
            return CreatedAtAction(nameof(GetBooks), new { id = book.BookId }, book);
        }

        // DELETE api/books/{bookId}
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            var book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }
}
