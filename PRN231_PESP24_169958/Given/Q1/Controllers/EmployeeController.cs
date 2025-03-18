using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly PE_PRN_SP24Context _context;
		public EmployeeController(PE_PRN_SP24Context context)
		{
			_context = context;
		}

		[HttpDelete("{employeeId}")]
		public Task<IActionResult> Delete([FromRoute] int employeeId)
		{

		}
	}
