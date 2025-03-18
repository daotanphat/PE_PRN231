using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly PE_PRN_24FallB1Context _context;
		private readonly IMapper _mapper;
		public BooksController(PE_PRN_24FallB1Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[EnableQuery]
		[HttpGet]
		public IActionResult GetBooks()
		{
			var books = _context.Books
				.Include(b => b.Authors);
			var bookResponse = _mapper.Map<IEnumerable<BookResponse>>(books);
			return Ok(bookResponse);
		}

		[HttpGet("search/{title}/{author}")]
		public IActionResult Search([FromRoute] string title, [FromRoute] string author)
		{
			if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
			{
				return BadRequest();
			}

			var books = _context.Books
									.Include(b => b.Authors)
									.ToList();
			if (title != "*")
			{
				books = books.Where(b => b.Authors
											.Any(a => a.Name.ToLower().Contains(author.ToLower()))
									).ToList();
			}
			if (author != "*")
			{
				books = books.Where(b => b.Title.ToLower().Contains(title.ToLower()))
					.ToList();
			}

			var bookResponse = _mapper.Map<IEnumerable<BookResponse>>(books);
			return Ok(bookResponse);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			using var transaction = await _context.Database.BeginTransactionAsync();

			try
			{
				var book = await _context.Books
								.Include(b => b.BookCopies)
									.ThenInclude(bc => bc.BorrowTransactions)
								.Include(b => b.Authors)
								.FirstOrDefaultAsync(b => b.BookId == id);

				if (book == null) return NotFound();

				foreach (var item in book.BookCopies)
				{
					_context.BorrowTransactions.RemoveRange(item.BorrowTransactions);
				}

				_context.BookCopies.RemoveRange(book.BookCopies);

				book.Authors.Clear();

				var numBookCopies = book.BookCopies.Count();
				var numBorrowTransaction = book.BookCopies.SelectMany(bc => bc.BorrowTransactions).Count();

				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
				await transaction.CommitAsync();

				return Ok(new
				{
					message = "Book deleted successfully",
					deletedCopies = numBookCopies,
					deletedTransactions = numBorrowTransaction
				});
			}
			catch
			{
				await transaction.RollbackAsync();
				return StatusCode(500, "An error occurred while deleting the book.");
			}

		}
	}
}
