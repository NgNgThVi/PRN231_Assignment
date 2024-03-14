using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.AdminArea.Products
{
    public class CreateModel : ClientAbstract
    {
        public CreateModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }
        public List<SelectListItem> ProductStatusItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            string token = _context.HttpContext.Session.GetString("token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseCategory = await HttpClient.GetAsync("api/v1/category");

            if (responseCategory.IsSuccessStatusCode)
            {
                var content = await responseCategory.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<List<Category>>(content);
                ViewData["CategoryID"] = new SelectList(category, "Id", "CategoryName");

            }
            HttpResponseMessage responseSupplier = await HttpClient.GetAsync("api/v1/supplier");
            if (responseSupplier.IsSuccessStatusCode)
            {
                var content = await responseSupplier.Content.ReadAsStringAsync();
                var supplier = JsonConvert.DeserializeObject<List<Supplier>>(content);
                ViewData["SupplierID"] = new SelectList(supplier, "Id", "SupplierAddress");

            }
            ProductStatusItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Có thể bán" },
                new SelectListItem { Value = "0", Text = "Tạm ngưng giao dịch" },
            };
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            if (!ModelState.IsValid ||  Product == null)
            {
                return Page();
            }
            string token = _context.HttpContext.Session.GetString("token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = "api/v1/Product";
            var jsonContent = JsonConvert.SerializeObject(Product);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
