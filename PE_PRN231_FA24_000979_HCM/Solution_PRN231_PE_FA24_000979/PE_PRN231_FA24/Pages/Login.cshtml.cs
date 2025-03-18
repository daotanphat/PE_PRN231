using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public string ErrorMessage { get; set; }

        [BindProperty]
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();

        public LoginModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient();

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            var apiUrl = new Uri(new Uri(baseUrl), "api/Auth/login");

            var response = await client.PostAsJsonAsync(apiUrl, LoginRequest);

            if (response.IsSuccessStatusCode)
            {
                var userData = await response.Content.ReadFromJsonAsync<LoginResponse>();

                HttpContext.Session.SetString("JWTToken", userData.Token);
                HttpContext.Session.SetString("UserId", userData.UserId);
                HttpContext.Session.SetString("Username", userData.Username);
                HttpContext.Session.SetString("UserRole", userData.Role);

                return RedirectToPage("/Cosmetics");
            }
            else
            {
                ErrorMessage = "You are not allowed to access this function!";
                return Page();
            }
        }
    }
}


public class LoginRequest
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}
