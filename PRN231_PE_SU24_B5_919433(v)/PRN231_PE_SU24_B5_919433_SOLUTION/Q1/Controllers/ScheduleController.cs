using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly PE_PRN_24SumB5Context _context;
		public ScheduleController(PE_PRN_24SumB5Context context)
		{
			_context = context;
		}
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateSchedule request)
		{
			if (request.EndDate < request.StartDate)
			{
				return Conflict("End Date must be after Start Date");
			}

			var isExistMovieSchedule = await _context.Schedules
				.AnyAsync(s => s.RoomId == request.RoomId
							&& s.TimeSlotId == request.TimeSlotId
							&& s.StartDate.Date == request.StartDate.Date
							&& s.EndDate.Date == request.EndDate.Date);

			if (isExistMovieSchedule) return StatusCode(406, "This schedule has exist movie in");

			var schedule = new Schedule
			{
				MovieId = request.MovieId,
				RoomId = request.RoomId,
				TimeSlotId = request.TimeSlotId,
				StartDate = request.StartDate,
				EndDate = request.EndDate,
				Note = request.Note,
			};

			_context.Schedules.Add(schedule);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
