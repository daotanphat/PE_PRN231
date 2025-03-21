using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly PE_PRN_24SumB1Context _context;
		public CourseController(PE_PRN_24SumB1Context context)
		{
			_context = context;
		}
		[HttpDelete("{cid}/{uid}")]
		public async Task<IActionResult> DeleteEnrollment([FromRoute] int cid, [FromRoute] int uid)
		{
			try
			{
				var enrollment = await _context.Enrollments
					.SingleOrDefaultAsync(e => e.UserId == uid && e.CourseId == cid);

				if (enrollment == null) return NoContent();

				_context.Enrollments.Remove(enrollment);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return Conflict();
			}

		}
	}
}
