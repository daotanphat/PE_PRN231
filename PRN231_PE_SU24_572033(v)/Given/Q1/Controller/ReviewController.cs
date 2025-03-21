using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly PE_PRN_24SumB1Context _context;
		public ReviewController(PE_PRN_24SumB1Context context)
		{
			_context = context;
		}
		[HttpGet("Course/{id}")]
		public async Task<IActionResult> GetReviewAuth([FromRoute] int id,
			[FromHeader] string? header)
		{
			if (string.IsNullOrEmpty(header) || !header.StartsWith("Bearer "))
			{
				return Unauthorized("Authorization token is missing or invalid.");
			}

			var token = header.Substring("Bearer ".Length).Trim();

			var userId = GetUserIdFromToken(token);

			var reviews = _context.Courses.Include(c => c.Reviews)
										  .ThenInclude(r => r.User)
										  .FirstOrDefault(c => c.CourseId == id)?.Reviews;


			if (reviews == null || !reviews.Any())
			{
				return NoContent();
			}


			var result = reviews.Select(r => new
			{
				userId = r.UserId,
				userName = r.User.Username,
				email = r.User.Email,
				reviewText = r.ReviewText,
				reviewDate = r.ReviewDate,
				rating = r.Rating
			});

			return Ok(result);
		}

		private int GetUserIdFromToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

			var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId);

			if (userIdClaim != null)
			{
				return int.Parse(userIdClaim.Value);
			}

			throw new UnauthorizedAccessException("User ID not found in token.");
		}
	}
}
