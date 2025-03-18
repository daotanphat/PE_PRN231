namespace Q1.DTOs
{
	public class AuthorResponse
	{
		public int AuthorId { get; set; }
		public string Name { get; set; } = null!;
		public string? Bio { get; set; }
	}
}
