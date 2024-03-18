using Microsoft.EntityFrameworkCore;
using PetShop.BusinessObject.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Implements;
using PetShop.Services.Intefaces;

namespace PetShop.GRPC.Commons
{
    public static class DependencyInjection
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddDbContext<PetShopContext>(options =>
            {
                options.UseSqlServer("PetShopDB");
            });

            //Inject Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Inject Service
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}