using GivenAPIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Q2_WebApp.Controllers
{
	public class ScheduleController : Controller
	{
		private HttpClient client;
		private string movieApiUrl;
		private string roomApiUrl;
		private string timeSlotApiUrl;
		private string movieScheduleApiUrl;
		public ScheduleController()
		{
			client = new HttpClient();
			movieApiUrl = "http://localhost:5000/api/movie/list";
			roomApiUrl = "http://localhost:5000/api/room/list";
			timeSlotApiUrl = "http://localhost:5000/api/timeSlot/list";
			movieScheduleApiUrl = "http://localhost:5000/api/schedule/list";
		}
		public async Task<IActionResult> List(DateTime? date)
		{
			string dateValue = date?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");
			string scheduleApiWithDate = $"{movieScheduleApiUrl}/{dateValue}";

			HttpResponseMessage response1 = await client.GetAsync(movieApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(roomApiUrl);
			HttpResponseMessage response3 = await client.GetAsync(timeSlotApiUrl);
			HttpResponseMessage response4 = await client.GetAsync(scheduleApiWithDate);

			var movies = await response1.Content.ReadFromJsonAsync<List<Movie>>();
			var rooms = await response2.Content.ReadFromJsonAsync<List<Room>>();
			var timeSlots = await response3.Content.ReadFromJsonAsync<List<TimeSlot>>();
			var movieSchedules = await response4.Content.ReadFromJsonAsync<List<Schedule>>();

			ViewData["date"] = dateValue;
			ViewBag.Rooms = rooms;
			ViewBag.TimeSlots = timeSlots;
			ViewBag.Movies = movies;
			return View(movieSchedules);
		}
	}
}
