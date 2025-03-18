using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2_API.Models;

namespace Q2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly PE_PRN_Fall2023B1Context _context;
		public ScheduleController(PE_PRN_Fall2023B1Context context)
		{
			_context = context;
		}

		[HttpGet("List/{date}")]
		public async Task<IActionResult> GetScheduleList([FromRoute] DateTime? date)
		{
			var schedules = await _context.Schedules
				.ToListAsync();

			var response = schedules.Where(s => date >= s.StartDate && date <= s.EndDate)
				.ToList();

			return Ok(response);
		}
	}
}
