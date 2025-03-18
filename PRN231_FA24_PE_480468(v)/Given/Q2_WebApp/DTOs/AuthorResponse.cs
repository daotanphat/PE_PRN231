namespace Q2_WebApp.DTOs
{
	public class AuthorResponse
	{
		public int AuthorId { get; set; }
		public string Name { get; set; } = null!;
		public string? Bio { get; set; }

		public List<BookResponse> Books { get; set; }
	}
}
