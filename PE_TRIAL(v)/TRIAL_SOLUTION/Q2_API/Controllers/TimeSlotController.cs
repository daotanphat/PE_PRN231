using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2_API.Models;

namespace Q2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimeSlotController : ControllerBase
	{
		private readonly PE_PRN_Fall2023B1Context _context;
		public TimeSlotController(PE_PRN_Fall2023B1Context context)
		{
			_context = context;
		}

		[HttpGet("List")]
		public async Task<IActionResult> GetTimeSlotList()
		{
			var timeSlots = await _context.TimeSlots.ToListAsync();
			return Ok(timeSlots);
		}
	}
}
