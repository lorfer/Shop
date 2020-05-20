

namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities; 
    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone 6 Plus");
                this.AddProduct("Iwasch");
                this.AddProduct("LG G20");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            
            this.context.Products.Add(new Products
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                LastPurchase = DateTime.Now,
                LastSale = DateTime.Now,
                Stock = this.random.Next(100)
            });
        }
    }
}
