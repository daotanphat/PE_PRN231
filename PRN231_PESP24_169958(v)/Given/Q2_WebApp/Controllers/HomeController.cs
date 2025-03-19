using Microsoft.AspNetCore.Mvc;
using Q2_API.Models;
using Q2_WebApp.Models;
using System.Diagnostics;

namespace Q2_WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient client = null;
		private string EmployeeApiUrl = "";
		private string SkillApiUrl = "";
		private string EmployeeSkillApiUrl = "";

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			client = new HttpClient();
			EmployeeApiUrl = "http://localhost:5100/api/employee/list";
			SkillApiUrl = "http://localhost:5100/api/skill/list";
			EmployeeSkillApiUrl = "http://localhost:5100/api/employeeskill/list";
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> EmployeeWithSkill()
		{
			HttpResponseMessage response1 = await client.GetAsync(EmployeeApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(SkillApiUrl);
			HttpResponseMessage response3 = await client.GetAsync(EmployeeSkillApiUrl);

			var employees = await response1.Content.ReadFromJsonAsync<List<Employee>>();
			var skills = await response2.Content.ReadFromJsonAsync<List<Skill>>();
			var employeeSkills = await response3.Content.ReadFromJsonAsync<List<EmployeeSkill>>();

			ViewBag.Employees = employees;
			ViewBag.Skills = skills;

			return View(employeeSkills);
		}
	}
}
