using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.UserArea.Products
{
    public class IndexModel : ClientAbstract
    {


        public IndexModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        public IList<Product> Product { get;set; } = default!;
        [BindProperty]
        public int CartCount { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            string token = _context.HttpContext.Session.GetString("token");
            // Lưu trữ list
            string cart = _context.HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cart))
            {
                cart = new List<ProductForBooking>().ToJson();
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                _context.HttpContext.Session.SetString("Cart", products.ToJson());
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                CartCount = products!.Sum(x => x.ProductQuantity);
                _context.HttpContext.Session.SetString("Cart", products.ToJson());

            }

            /*           ;
                        products.Add(newProduct);*/

            /*
                        // Truy xuất list
                        string cart = _context.HttpContext.Session.GetString("Cart");
                        var products = JsonConvert.DeserializeObject<List<Product>>(cart);*/
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await HttpClient.GetAsync("api/v1/Product");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Product = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return Page();
        }
    }
}
