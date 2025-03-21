using GivenAPI_SU24;
using Microsoft.AspNetCore.Mvc;

namespace Q2_WebApp.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly HttpClient client = null;
		private string EmployeeApiUrl = "";
		public EmployeeController()
		{
			client = new HttpClient();
			EmployeeApiUrl = "http://localhost:5000/api/employee";
		}
		public async Task<IActionResult> List()
		{
			HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);

			var employees = await response.Content.ReadFromJsonAsync<List<Employee>>();

			ViewBag.Employees = employees;
			return View(new Employee());
		}

		[HttpPost]
		public async Task<IActionResult> AddEmployee(Employee employee, string DobDate)
		{
			if (!string.IsNullOrEmpty(DobDate))
			{
				DateTime parsedDate = DateTime.Parse(DobDate);
				employee.Dob = new DateOfBirth
				{
					Year = parsedDate.Year,
					Month = parsedDate.Month,
					Day = parsedDate.Day,
				};
			}

			HttpResponseMessage response = await client.PostAsJsonAsync(EmployeeApiUrl, employee);

			HttpResponseMessage response1 = await client.GetAsync(EmployeeApiUrl);
			var employees = await response1.Content.ReadFromJsonAsync<List<Employee>>();
			ViewBag.Employees = employees;
			if (response.IsSuccessStatusCode)
			{
				//ViewBag.Message = "Add new employee successfully!";
				//return View("List", new Employee());
				return RedirectToAction("List");
			}
			else
			{
				string errorMsg = await response.Content.ReadAsStringAsync();
				ViewBag.Error = $"{errorMsg}";
				return View("List", employee);
			}
		}
	}
}
