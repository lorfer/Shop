

namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        //private readonly UserManager<User> userManager;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            //this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("Fernandogarciaolivo@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Fernando",
                    LastName = "Garcia",
                    Email = "fernandogarciaolivo@gmail.com",
                    UserName = "fernandogarciaolivo@gmail.com",
                    PhoneNumber = "8299247774"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }




            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone 6 Plus", user);
                this.AddProduct("Iwasch", user);
                this.AddProduct("LG G20", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {

            this.context.Products.Add(new Products
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                LastPurchase = DateTime.Now,
                LastSale = DateTime.Now,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
