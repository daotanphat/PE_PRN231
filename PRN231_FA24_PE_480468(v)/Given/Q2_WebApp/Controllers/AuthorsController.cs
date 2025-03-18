using GivenAPI_PE_FA24.Models;
using Microsoft.AspNetCore.Mvc;
using Q2_WebApp.DTOs;
using System.Globalization;
using System.Text.Json;

namespace Q2_WebApp.Controllers
{
	public class AuthorsController : Controller
	{
		private readonly HttpClient client = null;
		private string BookApiUrl = "";
		private string AuthorApiUrl = "";
		public AuthorsController()
		{
			client = new HttpClient();
			BookApiUrl = "http://localhost:5100/api/books";
			AuthorApiUrl = "http://localhost:5100/api/authors";
		}
		public async Task<IActionResult> Index()
		{
			HttpResponseMessage response1 = await client.GetAsync(BookApiUrl);
			HttpResponseMessage response2 = await client.GetAsync(AuthorApiUrl);

			var books = await response1.Content.ReadFromJsonAsync<List<Book>>();
			var authors = await response2.Content.ReadFromJsonAsync<List<Author>>();

			var authorResponses = authors.Select(a => new AuthorResponse
			{
				AuthorId = a.AuthorId,
				Name = a.Name,
				Bio = a.Bio,
				Books = books.Where(b => b.Authors.Any(a1 => a1.AuthorId == a.AuthorId))
							.Select(b => new BookResponse
							{
								BookId = b.BookId,
								Title = b.Title,
								Publisher = b.Publisher,
								PublicationYear = b.PublicationYear
							}).ToList()
			}).ToList();

			return View(authorResponses);
		}

		public async Task<IActionResult> Create()
		{
			HttpResponseMessage response = await client.GetAsync(BookApiUrl);
			var books = await response.Content.ReadFromJsonAsync<List<Book>>();

			ViewBag.Books = books;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateAuthor request)
		{
			if (!ModelState.IsValid)
			{
				HttpResponseMessage response = await client.GetAsync(BookApiUrl);
				var books = await response.Content.ReadFromJsonAsync<List<Book>>();
				ViewBag.Books = books;
				return View(request);
			}

			HttpResponseMessage response1 = await client.GetAsync(BookApiUrl);
			var booksData = await response1.Content.ReadFromJsonAsync<List<Book>>();

			var selectedBook = booksData.Where(b => request.BookIds.Contains(b.BookId)).ToList();
			Author author = new()
			{
				Name = request.Name,
				Bio = request.Bio
			};

			foreach (var book in selectedBook)
			{
				book.Authors.Add(author);
			}

			HttpResponseMessage postResponse = await client.PostAsJsonAsync(AuthorApiUrl, author);
			if (postResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			else
			{
				//ModelState.AddModelError("", "Error creating author");
				string errorDetails = await postResponse.Content.ReadAsStringAsync();
				ModelState.AddModelError("", $"Error creating author: {errorDetails}");

				HttpResponseMessage response = await client.GetAsync(BookApiUrl);
				var books = await response.Content.ReadFromJsonAsync<List<Book>>();
				ViewBag.Books = books;

				return View();
			}
		}
	}
}
