using GivenAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Q2_WebApp.Models;
using System.Diagnostics;

namespace Q2_WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient client;
		private string StudioApiUrl = "";
		private string MovieApiUrl = "";
		private string MovieByStudioApiUrl = "";
		private string AddMovieApiUrl = "";

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			client = new HttpClient();
			StudioApiUrl = "http://localhost:5000/api/studio/list";
			MovieApiUrl = "http://localhost:5000/api/movie/list";
			MovieByStudioApiUrl = "http://localhost:5000/api/movie/list";
			AddMovieApiUrl = "http://localhost:5000/api/movie/add";
		}

		public async Task<IActionResult> Index()
		{
			HttpResponseMessage response1 = await client.GetAsync(StudioApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(MovieApiUrl);

			var studio = await response1.Content.ReadFromJsonAsync<List<Studio>>();
			var movies = await response2.Content.ReadFromJsonAsync<List<Movie>>();

			ViewBag.Studios = studio;

			return View(movies);
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

		public async Task<IActionResult> GetMoviesByStudio(int studioId)
		{
			string movieByStudioIdApiUrl = $"{MovieByStudioApiUrl}/{studioId}";
			HttpResponseMessage response1 = await client.GetAsync(movieByStudioIdApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(StudioApiUrl);

			var movieStudio = await response1.Content.ReadFromJsonAsync<List<Movie>>();
			var studio = await response2.Content.ReadFromJsonAsync<List<Studio>>();

			ViewBag.Studios = studio;

			return View("Index", movieStudio);
		}

		public async Task<IActionResult> AddMovie([FromForm] int MovieId, [FromForm] string Title, [FromForm] int StudioId)
		{
			var formData = new MultipartFormDataContent();

			formData.Add(new StringContent(MovieId.ToString()), "MovieId");
			formData.Add(new StringContent(Title), "Title");
			formData.Add(new StringContent(StudioId.ToString()), "StudioId");
			formData.Add(new StringContent(DateTime.Now.ToString("yyyy-MM-dd")), "PublishDate");

			if (!ModelState.IsValid)
			{
				HttpResponseMessage response1 = await client.GetAsync(StudioApiUrl);
				HttpResponseMessage response2 = await client.GetAsync(MovieApiUrl);

				var studio = await response1.Content.ReadFromJsonAsync<List<Studio>>();
				var movies = await response2.Content.ReadFromJsonAsync<List<Movie>>();

				ViewBag.Studios = studio;

				return View("Index", movies);
			}

			HttpResponseMessage postResponse = await client.PostAsync(AddMovieApiUrl, formData);
			if (postResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			else
			{
				HttpResponseMessage response1 = await client.GetAsync(StudioApiUrl);
				HttpResponseMessage response2 = await client.GetAsync(MovieApiUrl);

				var studio = await response1.Content.ReadFromJsonAsync<List<Studio>>();
				var movies = await response2.Content.ReadFromJsonAsync<List<Movie>>();

				ViewBag.Studios = studio;

				return View("Index", movies);
			}
		}
	}
}
