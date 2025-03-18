using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q2_API.Models;

namespace Q2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeProjectController : ControllerBase
	{
		private readonly PE_PRN_24FallB5_231Context _context;
		public EmployeeProjectController(PE_PRN_24FallB5_231Context context)
		{
			_context = context;
		}
		[HttpGet("List")]
		public async Task<IActionResult> List()
		{
			var employeeProjects = await _context.EmployeeProjects
				.ToListAsync();

			return Ok(employeeProjects);
		}
	}
}
