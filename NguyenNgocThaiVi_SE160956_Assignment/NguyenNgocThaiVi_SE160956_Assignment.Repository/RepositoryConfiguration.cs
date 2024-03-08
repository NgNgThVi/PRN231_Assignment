using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NguyenNgocThaiVi_SE160956_Assignment.Repository.AccountsRepository;

namespace NguyenNgocThaiVi_SE160956_Assignment.Repository
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
