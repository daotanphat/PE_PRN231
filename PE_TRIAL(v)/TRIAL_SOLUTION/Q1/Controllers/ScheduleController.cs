using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTOs;
using Q1.Models;
using System.Net;

namespace Q1.Controllers
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

		[HttpPost("add")]
		public async Task<IActionResult> AddSchedule([FromBody] AddMovie request)
		{
			if (request.EndDate > request.StartDate)
			{
				return Conflict("End Date must be after start date");
			}

			var checkIsExist = _context.Schedules
				.Any(s => request.RoomId == s.RoomId
				&& request.TimeSlotId == s.TimeSlotId
				&& request.MovieId == s.MovieId);

			if (checkIsExist) return StatusCode(406, "Conflict movie timeslot and room");

			Schedule schedule = new Schedule
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
