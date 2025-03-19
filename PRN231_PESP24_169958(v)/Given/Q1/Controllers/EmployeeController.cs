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
		private readonly PE_PRN_SP24Context _context;
		public EmployeeController(PE_PRN_SP24Context context)
		{
			_context = context;
		}

		[HttpDelete("Delete/{employeeId}")]
		public async Task<IActionResult> Delete([FromRoute] int employeeId)
		{
			using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				var employee = await _context.Employees
					.Include(e => e.EmployeeProjects)
					.Include(e => e.EmployeeSkills)
					.Include(e => e.Departments)
					.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

				if (employee == null) return NotFound($"No employee with id {employeeId}");

				var numEmpProjects = employee.EmployeeProjects.Count();
				var numEmpSkills = employee.EmployeeSkills.Count();
				var numEmpDeparts = employee.Departments.Count();

				var departments = await _context.Departments
					.Where(d => d.ManagerId == employeeId)
					.ToListAsync();
				foreach (var department in departments)
				{
					department.ManagerId = null;
				}

				_context.EmployeeProjects.RemoveRange(employee.EmployeeProjects);
				_context.EmployeeSkills.RemoveRange(employee.EmployeeSkills);
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();

				await transaction.CommitAsync();

				return Ok(new
				{
					numberOfProjects = numEmpProjects,
					numberOfSkills = numEmpSkills,
					numberOfDepartment = numEmpDeparts
				});
			}
			catch (Exception)
			{
				await transaction.RollbackAsync();
				return StatusCode(500, "An error occurred while deleting the employee");
			}
		}
	}
}
