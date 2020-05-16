  using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore;
    //using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class DataContext:DbContext 
    {
        //Colection Object
        public DbSet<Products> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
    
            

        }

 
    }
}
