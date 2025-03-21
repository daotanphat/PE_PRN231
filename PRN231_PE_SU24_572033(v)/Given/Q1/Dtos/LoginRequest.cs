using System.ComponentModel.DataAnnotations;

namespace Q1.Dtos
{
	public class LoginRequest
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
