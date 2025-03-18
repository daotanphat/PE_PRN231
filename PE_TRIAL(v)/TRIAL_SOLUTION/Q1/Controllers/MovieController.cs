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
	public class MovieController : ControllerBase
	{
		private readonly PE_PRN_Fall2023B1Context _context;
		public MovieController(PE_PRN_Fall2023B1Context context)
		{
			_context = context;
		}
		[EnableQuery]
		[HttpGet("GetAllMovies")]
		public async Task<IActionResult> GetAllMovies()
		{
			var movies = await _context.Movies
				.Include(m => m.Genres)
				.Include(m => m.Director)
				.ToListAsync();

			List<GetAllMovies> response = new List<GetAllMovies>();
			foreach (var movie in movies)
			{
				var movieResponse = new GetAllMovies
				{
					Id = movie.Id,
					Title = movie.Title,
					Year = movie.Year,
					Description = movie.Description,
					DirectorId = movie.DirectorId,
					DirectorName = movie.Director.Name,
					Genres = movie.Genres.Select(g => g.Title).ToList()
				};

				response.Add(movieResponse);
			}

			return Ok(response);
		}

		[HttpGet("GetMoviesByGenre/{genre}")]
		public async Task<IActionResult> GetAllMoviesByGenre([FromRoute] string genre)
		{
			var movies = await _context.Movies
				.Include(m => m.Genres)
				.Include(m => m.Director)
				.Where(m => m.Genres.Any(g => g.Title == genre))
				.ToListAsync();

			List<GetAllMovies> response = new List<GetAllMovies>();
			foreach (var movie in movies)
			{
				var movieResponse = new GetAllMovies
				{
					Id = movie.Id,
					Title = movie.Title,
					Year = movie.Year,
					Description = movie.Description,
					DirectorId = movie.DirectorId,
					DirectorName = movie.Director.Name,
					Genres = movie.Genres.Select(g => g.Title).ToList()
				};

				response.Add(movieResponse);
			}

			return Ok(response);
		}
	}
}
