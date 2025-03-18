using GivenAPI_PE_FA24.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GivenAPI_PE_FA24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        // Dữ liệu tĩnh cho Authors
        private static List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "J.K. Rowling", Bio = "British author, best known for the Harry Potter series." },
            new Author { AuthorId = 2, Name = "J.R.R. Tolkien", Bio = "English writer, poet, and academic, best known for 'The Hobbit' and 'The Lord of the Rings.'" }
        };

        // GET api/authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(authors);
        }

        // POST api/authors
        [HttpPost]
        public ActionResult<Author> CreateAuthor([FromBody] Author author)
        {
            author.AuthorId = authors.Max(a => a.AuthorId) + 1; // Tự động tăng ID
            authors.Add(author);
            return CreatedAtAction(nameof(GetAuthors), new { id = author.AuthorId }, author);
        }

        // DELETE api/authors/{authorId}
        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            var author = authors.FirstOrDefault(a => a.AuthorId == authorId);
            if (author == null)
            {
                return NotFound();
            }

            authors.Remove(author);
            return NoContent();
        }
    }
}
