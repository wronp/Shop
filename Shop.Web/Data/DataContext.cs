using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.Web.Data
{
    using Entities;

    // We change the DbContext for the IdentityDbContext because this had the security of CORE and makes the custom User's table
    public class DataContext : IdentityDbContext<User> 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}