using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.ApplicationDbContext;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContexts>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;

        }
    }
}
