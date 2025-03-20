using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly PE_PRN_24SumB1Context _context;
		public UserController(PE_PRN_24SumB1Context context)
		{
			_context = context;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			var user = await _context.Users
				.Include(u => u.Enrollments)
					.ThenInclude(e => e.Course)
				.SingleOrDefaultAsync(u => u.UserId == id);

			if (user == null) return NoContent();

			var response = new
			{
				userId = user.UserId,
				userName = user.Username,
				userEmail = user.Email,
				courses = user.Enrollments.Select(e => new
				{
					courseId = e.CourseId,
					title = e.Course.Title,
					enrollDate = e.EnrolledDate
				})
			};

			return Ok(response);
		}
	}
}
