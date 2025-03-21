using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GivenAPI_SU24.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private static List<Employee> employees = new List<Employee>
		{
			new Employee
			{
				EmployeeId = 1,
				Name = "John Doe",
				Gender = "Male",
				Dob = new DateOfBirth { Year = 1990, Month = 5, Day = 15 },
				Position = "Software Engineer",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 2,
				Name = "Jane Smith",
				Gender = "Female",
				Dob = new DateOfBirth { Year = 1985, Month = 8, Day = 23 },
				Position = "Product Manager",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 3,
				Name = "Alice Johnson",
				Gender = "Female",
				Dob = new DateOfBirth { Year = 1992, Month = 12, Day = 10 },
				Position = "UI/UX Designer",
				IsFullTime = false
			},
			new Employee
			{
				EmployeeId = 4,
				Name = "Michael Brown",
				Gender = "Male",
				Dob = new DateOfBirth { Year = 1988, Month = 3, Day = 5 },
				Position = "DevOps Engineer",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 5,
				Name = "Emily Davis",
				Gender = "Female",
				Dob = new DateOfBirth { Year = 1995, Month = 7, Day = 20 },
				Position = "QA Engineer",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 6,
				Name = "William Wilson",
				Gender = "Male",
				Dob = new DateOfBirth { Year = 1983, Month = 11, Day = 30 },
				Position = "Team Lead",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 7,
				Name = "Olivia Martinez",
				Gender = "Female",
				Dob = new DateOfBirth { Year = 1991, Month = 9, Day = 14 },
				Position = "Business Analyst",
				IsFullTime = false
			},
			new Employee
			{
				EmployeeId = 8,
				Name = "James Anderson",
				Gender = "Male",
				Dob = new DateOfBirth { Year = 1987, Month = 6, Day = 25 },
				Position = "Backend Developer",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 9,
				Name = "Sophia Thomas",
				Gender = "Female",
				Dob = new DateOfBirth { Year = 1993, Month = 4, Day = 9 },
				Position = "HR Specialist",
				IsFullTime = true
			},
			new Employee
			{
				EmployeeId = 10,
				Name = "Daniel Taylor",
				Gender = "Male",
				Dob = new DateOfBirth { Year = 1989, Month = 2, Day = 18 },
				Position = "Frontend Developer",
				IsFullTime = false
			}
		};


		[HttpGet]
		public IActionResult GetEmployees()
		{
			return Ok(employees.
				Select(Employee => new
				{
					Employee.EmployeeId,
					Employee.Name,
					Employee.Gender,
					Dob = new
					{
						Employee.Dob.Year,
						Employee.Dob.Month,
						Employee.Dob.Day
					},
					Employee.Position,
					Employee.IsFullTime
				}).ToList());
		}

		[HttpPost]
		public IActionResult AddEmployee([FromBody] Employee newEmployee)
		{
			var existingEmployee = employees.FirstOrDefault(e => e.EmployeeId == newEmployee.EmployeeId);
			if (existingEmployee != null)
			{
				return Conflict("Employee already exists with the same EmployeeId.");
			}

			employees.Add(newEmployee);

			return Ok(newEmployee);
		}
	}
}
