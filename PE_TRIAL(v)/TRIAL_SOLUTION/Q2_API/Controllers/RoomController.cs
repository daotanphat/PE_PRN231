using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2_API.Models;

namespace Q2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly PE_PRN_Fall2023B1Context _context;
		public RoomController(PE_PRN_Fall2023B1Context context)
		{
			_context = context;
		}

		[HttpGet("List")]
		public async Task<IActionResult> GetRoomList()
		{
			var rooms = await _context.Rooms.ToListAsync();
			return Ok(rooms);
		}
	}
}
