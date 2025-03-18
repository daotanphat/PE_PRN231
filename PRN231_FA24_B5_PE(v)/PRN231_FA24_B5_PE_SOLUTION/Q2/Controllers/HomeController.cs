using Microsoft.AspNetCore.Mvc;
using Q2.Models;
using Q2_API.Models;
using System.Diagnostics;

namespace Q2.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient client = null;
		private string EmployeeApiUrl = "";
		private string ProjectApiUrl = "";
		private string EmployeeProjectApiUrl = "";

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			client = new HttpClient();
			EmployeeApiUrl = "http://localhost:5100/api/employee/list";
			ProjectApiUrl = "http://localhost:5100/api/project/list";
			EmployeeProjectApiUrl = "http://localhost:5100/api/employeeProject/list";
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

		public async Task<IActionResult> EmployeeWithProject()
		{
			HttpResponseMessage response1 = await client.GetAsync(EmployeeApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(ProjectApiUrl);
			HttpResponseMessage response3 = await client.GetAsync(EmployeeProjectApiUrl);

			var employees = await response1.Content.ReadFromJsonAsync<List<Employee>>();
			var projects = await response2.Content.ReadFromJsonAsync<List<Project>>();
			var employeeProjects = await response3.Content.ReadFromJsonAsync<List<EmployeeProject>>();

			ViewBag.Projects = projects;
			ViewBag.Employees = employees;
			return View(employeeProjects);
		}

	}
}
