using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.AdminArea.Products
{
    public class EditModel : ClientAbstract
    {
        public EditModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public List<SelectListItem> ProductStatusItems { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (!CheckAuthen())
            {
                RedirectToPage("/Login");
            }
            if (id == null)
            {
                return NotFound();
            }
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            string token = _context.HttpContext.Session.GetString("token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await HttpClient.GetAsync($"api/v1/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Product = JsonConvert.DeserializeObject<Product>(content);
            }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            string token = _context.HttpContext.Session.GetString("token");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = $"api/v1/Product/{Product.Id}";
            var jsonContent = JsonConvert.SerializeObject(Product);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await HttpClient.PutAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
