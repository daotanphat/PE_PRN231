using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Q1.Dtos;
using Q1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly PE_PRN_24SumB1Context _context;
		private IConfiguration _configuration;
		public UserController(PE_PRN_24SumB1Context context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			var user = await _context.Users
				.Include(u => u.Enrollments)
					.ThenInclude(e => e.Course)
				.SingleOrDefaultAsync(u => u.UserId == id);

			if (user == null) return NoContent();

			var response = new
			{
				userId = user.UserId,
				userName = user.Username,
				userEmail = user.Email,
				courses = user.Enrollments.Select(e => new
				{
					courseId = e.CourseId,
					title = e.Course.Title,
					enrollDate = e.EnrolledDate
				})
			};

			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var user = await _context.Users
				.SingleOrDefaultAsync(u => u.Username == request.UserName
										&& u.Password == request.Password);

			if (user == null) return Unauthorized("Invald username or password");

			var token = GenerateJwtToken(user);

			return Ok(token);
		}

		private string GenerateJwtToken(User user)
		{
			var claims = new[]{
			new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString()),
			new Claim(JwtRegisteredClaimNames.Name, user.Username)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["JWT:Issuer"],
				audience: _configuration["JWT:Audience"],
				claims: claims,
				expires: DateTime.Now.AddDays(Convert.ToDouble(_configuration["JWT:ExpiryInDays"])),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
