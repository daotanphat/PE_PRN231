using Microsoft.AspNetCore.Mvc;
using Q2_API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Q2_Web_MVC.Controllers
{
	public class SchedulesController : Controller
	{
		private readonly HttpClient client = null;
		private string ScheduleApiUrl = "";
		private string RoomApiUrl = "";
		private string TimeSlotApiUrl = "";
		public SchedulesController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			ScheduleApiUrl = "http://localhost:5100/api/schedule/list";
			RoomApiUrl = "http://localhost:5100/api/room/list";
			TimeSlotApiUrl = "http://localhost:5100/api/timeslot/list";
		}
		public async Task<IActionResult> Index(DateTime? dateSchedule)
		{
			string scheduleApiWithDate = $"{ScheduleApiUrl}/{dateSchedule?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd")}";

			HttpResponseMessage response1 = await client.GetAsync(scheduleApiWithDate);
			HttpResponseMessage response2 = await client.GetAsync(RoomApiUrl);
			HttpResponseMessage response3 = await client.GetAsync(TimeSlotApiUrl);

			string strData1 = await response1.Content.ReadAsStringAsync();
			string strData2 = await response2.Content.ReadAsStringAsync();
			string strData3 = await response3.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			List<Schedule> schedules = JsonSerializer.Deserialize<List<Schedule>>(strData1, options);
			List<Room> rooms = JsonSerializer.Deserialize<List<Room>>(strData2, options);
			List<TimeSlot> timeSlots = JsonSerializer.Deserialize<List<TimeSlot>>(strData3, options);

			ViewBag.Rooms = rooms;
			ViewBag.TimeSlots = timeSlots;
			ViewData["date"] = dateSchedule;

			return View(schedules);
		}
	}
}
