using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2_API.Models;

namespace Q2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillController : ControllerBase
	{
		private readonly PE_PRN_24FallB5_231Context _context;
		public SkillController(PE_PRN_24FallB5_231Context context)
		{
			_context = context;
		}
		[HttpGet("List")]
		public async Task<IActionResult> List()
		{
			var skills = await _context.Skills
				.ToListAsync();

			return Ok(skills);
		}
	}
}
