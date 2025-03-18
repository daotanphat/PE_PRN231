using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.Models;
using System.Data;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly PE_PRN_24FallB5_231Context _context;
		public ProjectController(PE_PRN_24FallB5_231Context context)
		{
			_context = context;
		}

		[EnableQuery]
		[HttpGet("GetProjects")]
		public async Task<IActionResult> GetProjects()
		{
			var projects = await _context.Projects
				.Include(p => p.EmployeeProjects)
				.ToListAsync();

			if (!projects.Any()) return NotFound("Not found any project!");

			var numEmployees = projects.SelectMany(p => p.EmployeeProjects).Count();

			var response = projects.Select(p => new
			{
				projectId = p.ProjectId,
				projectName = p.ProjectName,
				startDate = p.StartDate.Value.ToString("dd/MM/yyyy"),
				endDate = p.EndDate.Value.ToString("dd/MM/yyyy"),
				budget = p.Budget,
				numberOfEmployee = numEmployees
			});

			return Ok(response);
		}

		[HttpGet("GetProjects/{projectId}")]
		public async Task<IActionResult> GetProjects([FromRoute] int projectId)
		{
			var project = await _context.Projects
				.Include(p => p.EmployeeProjects)
					.ThenInclude(e => e.Employee)
						.ThenInclude(e1 => e1.Department)
				.SingleOrDefaultAsync(p => p.ProjectId == projectId);

			if (project == null) return NotFound();


			var response = new
			{
				projectId = project.ProjectId,
				projectName = project.ProjectName,
				startDate = project.StartDate,
				endDate = project.EndDate,
				budget = project.Budget,
				employees = project.EmployeeProjects.Select(e => new
				{
					employeeId = e.EmployeeId,
					employeeName = e.Employee.Name,
					department = e.Employee.Department.DepartmentName,
					role = e.Role,
					joinDate = e.JoinDate,
					leaveDate = e.LeaveDate
				})
			};

			return Ok(response);
		}
	}
}
