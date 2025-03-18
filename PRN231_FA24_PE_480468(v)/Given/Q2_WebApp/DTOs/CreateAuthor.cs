using System.ComponentModel.DataAnnotations;

namespace Q2_WebApp.DTOs
{
	public class CreateAuthor
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Bio { get; set; }
		[Required]
		public List<int> BookIds { get; set; }
	}
}
