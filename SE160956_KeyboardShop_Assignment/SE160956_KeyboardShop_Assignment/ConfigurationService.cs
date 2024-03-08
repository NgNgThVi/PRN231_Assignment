using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;
using SE160956_KeyboardShop_Assignment.Models;
using SE160956_KeyboardShop_Assignment.Repository.BookingDetailRepositories;
using SE160956_KeyboardShop_Assignment.Repository.BookingRepositories;
using SE160956_KeyboardShop_Assignment.Repository.CategoryRepositories;
using SE160956_KeyboardShop_Assignment.Repository.CustomerRepositories;
using SE160956_KeyboardShop_Assignment.Repository.ProductRepositories;
using SE160956_KeyboardShop_Assignment.Repository.Suppliers;
using System.Text;

namespace SE160956_KeyboardShop_Assignment.API
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var secretKey = configuration["JwtSettings:Key"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JwtSettings",
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Name = "Authorization",
                    Description = "Please enter a valid token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.AddPolicy("Staff", policy => policy
                    .Combine(options.DefaultPolicy)
                    .RequireRole("Staff")
                    .Build());
                options.AddPolicy("Admin", policy => policy
                    .Combine(options.DefaultPolicy)
                    .RequireRole("Admin")
                    .Build());
                options.AddPolicy("Customer", policy => policy
                   .Combine(options.DefaultPolicy)
                   .RequireRole("Customer")
                   .Build());
                options.AddPolicy("Manager", policy => policy
                  .Combine(options.DefaultPolicy)
                  .RequireRole("Manager")
                  .Build());
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

            return services;
        }

    }
}
