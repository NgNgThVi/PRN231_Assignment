using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SE160956_KeyboardShop_Assignment.APIClient.Pages.Inheritance;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.APIClient.Pages.UserArea.Bookings
{
    public class BookingsOfCustomerModel : ClientAbstract
    {
        public BookingsOfCustomerModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        public IList<Booking> Booking { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            if (!CheckAuthen())
            {
                return RedirectToPage("/Login");
            }
            Booking = new List<Booking>();
            string token = _context.HttpContext.Session.GetString("token");
            // Lưu trữ list
            string useid = _context.HttpContext.Session.GetString("USERID");
            if (string.IsNullOrEmpty("USERID"))
            {
                return RedirectToPage("/Login");
            }
            else
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string url = $"api/v1/Booking/customer/{useid}";
                HttpResponseMessage response = await HttpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<List<Booking>>(content);
                    Booking = user!;
                }
            }
            return Page();
        }
    }
}
