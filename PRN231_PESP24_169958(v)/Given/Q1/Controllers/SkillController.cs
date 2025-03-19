using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillController : ControllerBase
	{
		private readonly PE_PRN_SP24Context _context;
		public SkillController(PE_PRN_SP24Context context)
		{
			_context = context;
		}

		[EnableQuery]
		[HttpGet("GetSkills")]
		public async Task<IActionResult> GetSkills()
		{
			var skills = await _context.Skills
				.Include(s => s.EmployeeSkills)
				.ToListAsync();

			var response = skills.Select(s => new
			{
				skillId = s.SkillId,
				skillName = s.SkillName,
				description = s.Description,
				numberOfEmployee = s.EmployeeSkills.Count()
			});

			return Ok(response);
		}

		[HttpGet("GetSkill/{skillId}")]
		public async Task<IActionResult> GetSkillById([FromRoute] int skillId)
		{
			var skill = await _context.Skills
				.Include(s => s.EmployeeSkills)
					.ThenInclude(es => es.Employee)
						.ThenInclude(e => e.Department)
				.SingleOrDefaultAsync(s => s.SkillId == skillId);

			if (skill == null) return NotFound();

			var response = new
			{
				skillId = skill.SkillId,
				skillName = skill.SkillName,
				description = skill.Description,
				employees = skill.EmployeeSkills.Select(es => new
				{
					employeeId = es.EmployeeId,
					employeeName = es.Employee.Name,
					department = es.Employee.Department.DepartmentName,
					proficiencyLevel = es.ProficiencyLevel,
					acquireDate = es.AcquiredDate
				})
			};

			return Ok(response);
		}
	}
}
