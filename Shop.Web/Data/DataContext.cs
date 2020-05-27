  using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore;
    //using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.Web.Data
{
    public class DataContext:IdentityDbContext<User> 
    {
        //Colection Object
        public DbSet<Products> Products { get; set; }
        public DbSet<Country> countries { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
           

        }

 
    }
}
