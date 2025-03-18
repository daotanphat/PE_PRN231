using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Dtos;
using System.Net.Http.Headers;

namespace PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Pages
{
    public class EditCosmeticModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public bool IsNew => Cosmetic.CosmeticId == null;
        [BindProperty]
        public CosmeticCreateRequest Cosmetic { get; set; }
        public SelectList CategoryOptions { get; set; }

        public EditCosmeticModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var client = _clientFactory.CreateClient();

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            var categories = await client.GetFromJsonAsync<List<CategoryResponse>>($"{baseUrl}api/CosmeticCategory");
            CategoryOptions = new SelectList(categories, "CategoryId", "CategoryName");

            if (id == null)
            {
                Cosmetic = new CosmeticCreateRequest();
            }
            else
            {
                Cosmetic = await client.GetFromJsonAsync<CosmeticCreateRequest>($"{baseUrl}api/cosmetics/{id}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            if (IsNew)
            {
                await client.PostAsJsonAsync($"{baseUrl}api/cosmetics", Cosmetic);
            }
            else
            {
                await client.PutAsJsonAsync($"{baseUrl}api/cosmetics/{Cosmetic.CosmeticId}", Cosmetic);
            }

            return RedirectToPage("/Cosmetics");
        }
    }
}
