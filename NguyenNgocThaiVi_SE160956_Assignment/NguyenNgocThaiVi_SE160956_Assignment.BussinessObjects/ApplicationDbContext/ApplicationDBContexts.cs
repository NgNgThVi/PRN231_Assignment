using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.ApplicationDbContext
{
    public class ApplicationDBContexts : DbContext
    {
        public ApplicationDBContexts() { }
        public ApplicationDBContexts(DbContextOptions<ApplicationDBContexts> options)
    : base(options)
        { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingsDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("8F0DD22F-B780-4F87-949D-3568F3205D3B"),
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("6EB99A73-CC38-4F04-86AB-A3923AFA0201"),
                    RoleName = "Customer"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
