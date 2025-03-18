using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly PE_PRN_24FallB5_231Context _context;
		public EmployeeController(PE_PRN_24FallB5_231Context context)
		{
			_context = context;
		}

		[HttpDelete("Delete/{employeeId}")]
		public async Task<IActionResult> Delete([FromRoute] int employeeId)
		{
			var employee = await _context.Employees
				.Include(e => e.EmployeeProjects)
				.Include(e => e.EmployeeSkills)
				.Include(e => e.Departments)
				.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

			if (employee == null) return NotFound($"No employee has id {employeeId}");

			var numProjects = employee.EmployeeProjects.Count();
			var numSkills = employee.EmployeeSkills.Count();
			var numDepartments = employee.Departments.Count();

			_context.EmployeeProjects.RemoveRange(employee.EmployeeProjects);
			_context.EmployeeSkills.RemoveRange(employee.EmployeeSkills);
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();

			return Ok(new
			{
				numberOfProject = numProjects,
				numberOfSkills = numSkills,
				numberOfDepartments = 1
			});
		}
	}
}
