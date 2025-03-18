using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Dtos;
using System.Net.Http.Headers;

namespace PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Pages
{
    public class CosmeticsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public List<CosmeticResponse> CosmeticList { get; set; }
        public string UserRole => HttpContext.Session.GetString("UserRole");
        public string JWTToken => HttpContext.Session.GetString("JWTToken");

        public string ErrorMessage { get; set; }

        public CosmeticsModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(JWTToken))
            {
                return RedirectToPage("/Login");
            }

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWTToken);

            try
            {
                var baseUrl = _configuration["ApiSettings:BaseUrl"];
                CosmeticList = await client.GetFromJsonAsync<List<CosmeticResponse>>($"{baseUrl}/api/cosmetics");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Unable to load cosmetics. Please try again later.";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (UserRole != "Administrator")
            {
                ErrorMessage = "You are not allowed to access this function!";
                await OnGetAsync(); 
                return Page();
            }

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWTToken);

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            var response = await client.DeleteAsync($"{baseUrl}/api/cosmetics/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = "Failed to delete the item. Please try again.";
                await OnGetAsync();
                return Page();
            }

            return RedirectToPage();
        }
    }
}
