namespace Q2_WebApp.DTOs
{
	public class BookResponse
	{
		public int BookId { get; set; }
		public string Title { get; set; } = null!;
		public string? Publisher { get; set; }
		public int? PublicationYear { get; set; }
	}
}
