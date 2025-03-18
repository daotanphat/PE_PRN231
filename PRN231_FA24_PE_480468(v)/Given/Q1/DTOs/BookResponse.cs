using Q1.Models;

namespace Q1.DTOs
{
	public class BookResponse
	{
		public int BookId { get; set; }
		public string Title { get; set; } = null!;
		public List<AuthorResponse> Authors { get; set; } = new List<AuthorResponse>();
		public string? Publisher { get; set; }
		public int? PublicationYear { get; set; }
	}
}
