using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol;
using SE160956_KeyboardShop_Assignment.APIClient.Models;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.BookingDataAccessObject;
using SE160956_KeyboardShop_Assignment.DataAccessObject.ProducsDataAccessObject;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.UserArea.Bookings
{
    public class CreateBookingModel : ClientAbstract
    {
        public CreateBookingModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }
        public IList<ProductDTO> Product { get; set; } = default!;

        [BindProperty]
        public double TotalPrice { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public BookingModel BookingModel { get; set; }

        public List<SelectListItem> FreightOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            Product = new List<ProductDTO>();
            string token = _context.HttpContext.Session.GetString("token");
            // Lưu trữ list
            string cart = _context.HttpContext.Session.GetString("Cart");
            string useid = _context.HttpContext.Session.GetString("USERID");
            if (string.IsNullOrEmpty("USERID"))
            {
                return RedirectToPage("/Login");
            }
            else
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string url = $"api/v1/customer/{useid}";
                HttpResponseMessage response = await HttpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<Customer>(content);
                    Customer = user!;
                }
            }
            if (string.IsNullOrEmpty(cart))
            {
                cart = new List<ProductForBooking>().ToJson();
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                _context.HttpContext.Session.SetString("Cart", products.ToJson());
                return RedirectToPage("/UserArea/Products/Index");
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                foreach (var item in products)
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = $"api/v1/Product/{item.ProductId}";
                    HttpResponseMessage response = await HttpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(content);
                        var productWithQuantity = new ProductDTO
                        {
                            CategoryID = product.CategoryID,
                            Description = product.Description,
                            ProductName = product.ProductName,
                            ProductQuantity = item.ProductQuantity,
                            ProductStatus = product.ProductStatus,
                            BookingDetails = product.BookingDetails,
                            Category = product.Category,
                            Supplier = product.Supplier,
                            SupplierID = product.SupplierID,
                            UnitPrice = product.UnitPrice,
                            UnitsInStock = product.UnitsInStock,
                        };
                        TotalPrice += productWithQuantity.UnitPrice * productWithQuantity.ProductQuantity;
                        Product.Add(productWithQuantity);
                    }
                }
            }
            FreightOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Grab", Text = "Grab" },
                new SelectListItem { Value = "Xanh SM", Text = "Xanh SM" },
                new SelectListItem { Value = "Shoppe", Text = "Shoppe" },
                new SelectListItem { Value = "Lazada", Text = "Lazada" }
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            Product = new List<ProductDTO>();
            string token = _context.HttpContext.Session.GetString("token");
            // Lưu trữ list
            string cart = _context.HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cart))
            {
                cart = new List<ProductForBooking>().ToJson();
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                _context.HttpContext.Session.SetString("Cart", products.ToJson());
                return RedirectToPage("/UserArea/Products/Index");
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                foreach (var item in products)
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string url = $"api/v1/Product/{item.ProductId}";
                    HttpResponseMessage response = await HttpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Product>(content);
                        var productWithQuantity = new ProductDTO
                        {
                            CategoryID = product.CategoryID,
                            Description = product.Description,
                            ProductName = product.ProductName,
                            ProductQuantity = item.ProductQuantity,
                            ProductStatus = product.ProductStatus,
                            BookingDetails = product.BookingDetails,
                            Category = product.Category,
                            Supplier = product.Supplier,
                            SupplierID = product.SupplierID,
                            UnitPrice = product.UnitPrice,
                            UnitsInStock = product.UnitsInStock,
                        };
                        TotalPrice += productWithQuantity.UnitPrice * productWithQuantity.ProductQuantity;
                        Product.Add(productWithQuantity);
                    }
                }
                var bookingDTO = new BookingDTO
                {
                    Address = BookingModel.Address,
                    CustomerId = BookingModel.CustomerId,
                    EmailAddress = BookingModel.EmailAddress,
                    Freight = BookingModel.Freight,
                    FullName = BookingModel.FullName,
                    ListProductsAndQuantity = products,
                    TotalPrice = TotalPrice,
                };
                string urlBooking = "api/v1/Booking/create-booking";
                var jsonContent = JsonConvert.SerializeObject(bookingDTO);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var responseForCreatBooking = await HttpClient.PostAsync(urlBooking, httpContent);
                if (responseForCreatBooking.IsSuccessStatusCode)
                {
                    cart = new List<ProductForBooking>().ToJson();
                    var newProducts = JsonConvert.DeserializeObject<List<ProductForBooking>>(cart);
                    _context.HttpContext.Session.SetString("Cart", newProducts.ToJson());
                    return RedirectToPage("/UserArea/Bookings/BookingsOfCustomer");
                }
            }
            return Page();
        }
    }

}