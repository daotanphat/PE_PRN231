using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class InstructorController : ControllerBase
	{
		private readonly PE_PRN_24SumB1Context _context;
		public InstructorController(PE_PRN_24SumB1Context context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var instructors = await _context.Instructors
				.Include(i => i.Courses)
				.ToListAsync();

			var response = instructors.Select(i => new
			{
				instructorId = i.InstructorId,
				name = i.Name,
				bio = i.Bio,
				courses = i.Courses.Select(c => new
				{
					courseId = c.CourseId,
					title = c.Title
				})
			});

			return Ok(response);
		}
	}
}
