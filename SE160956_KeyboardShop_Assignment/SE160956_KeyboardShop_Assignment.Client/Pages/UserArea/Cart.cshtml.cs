using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;
using System.Net.Http.Headers;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.UserArea
{
    public class CartModel : ClientAbstract
    {
        public CartModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            string token = _context.HttpContext!.Session.GetString("token")!;
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = $"api/v1/Product/{id}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                // Lưu trữ list
                string cart = _context.HttpContext.Session.GetString("Cart")!;
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart!);

                if (product != null && products != null)
                {
                    var pfb = products.Where(x => x.ProductId == product.Id).FirstOrDefault();
                    if (pfb != null)
                    {
                        pfb.ProductQuantity++;
                    }
                    else
                    {
                        products.Add(new ProductForBooking { ProductId = product.Id, ProductQuantity = 1 });
                    }

                }
                _context.HttpContext.Session.SetString("Cart", products.ToJson());
                return RedirectToPage("/UserArea/Products/Index");
            }
            return Page();
        }
    }
}
