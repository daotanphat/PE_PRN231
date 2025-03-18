namespace Q1.DTOs
{
	public class GetAllMovies
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public int? Year { get; set; }
		public string? Description { get; set; }
		public int DirectorId { get; set; }
		public string? DirectorName { get; set; }
		public List<string> Genres { get; set; } = new List<string>();
	}
}