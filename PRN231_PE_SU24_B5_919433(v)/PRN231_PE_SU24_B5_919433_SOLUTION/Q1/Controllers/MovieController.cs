using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly PE_PRN_24SumB5Context _context;
		public MovieController(PE_PRN_24SumB5Context context)
		{
			_context = context;
		}
		[EnableQuery]
		[HttpGet("GetAllMovies")]
		public async Task<IActionResult> GetAllMovies()
		{
			var movies = await _context.Movies
							.Include(m => m.Director)
							.Include(m => m.Genres)
							.ToListAsync();

			var response = movies.Select(m => new
			{
				id = m.Id,
				title = m.Title,
				year = m.Year,
				description = m.Description,
				directorId = m.DirectorId,
				directorName = m.Director.Name,
				genres = m.Genres.Select(g => g.Title)
			});

			return Ok(response);
		}

		[HttpGet("GetAllMoviesByGenre/{genre}")]
		public async Task<IActionResult> GetAllMoviesByGenre([FromRoute] string genre)
		{
			var movies = await _context.Movies
							.Include(m => m.Director)
							.Include(m => m.Genres)
							.Where(m => m.Genres.Any(g => g.Title.ToLower() == genre.ToLower()))
							.ToListAsync();

			if (!movies.Any()) return NotFound($"Not found any movie with genre {genre}");

			var response = movies.Select(m => new
			{
				id = m.Id,
				title = m.Title,
				year = m.Year,
				description = m.Description,
				directorId = m.DirectorId,
				directorName = m.Director.Name,
				genres = m.Genres.Select(g => g.Title)
			});

			return Ok(response);
		}
	}
}
