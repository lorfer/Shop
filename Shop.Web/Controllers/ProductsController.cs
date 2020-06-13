

namespace Shop.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Models;

    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        private readonly IUserHelper userHelper;

        public ProductsController(IProductRepository productRepository, IUserHelper userHelper)
        {
            this.productRepository = productRepository;
            this.userHelper = userHelper;
        }

        // GET: Product
        public IActionResult Index()
        {
            return View(this.productRepository.GetAll().OrderBy(p =>p.User));
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.png";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "wwwroot\\images\\Products",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{file}";
                }

                var product = this.ToProudct(view, path);

                // TODO: Pending to change to: this.User.Identity.Name
                product.User = await this.userHelper.GetUserByEmailAsync("fernandogarciaolivo@gmail.com");
                await this.productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Product ToProudct(ProductViewModel view, string path)
        {
            return new Product
            {
                Id = view.Id,
                ImageUrl = path,
                IsAvailabe = view.IsAvailabe,
                LastPurchase = view.LastPurchase,
                LastSale = view.LastSale,
                Name = view.Name,
                Price = view.Price,
                Stock = view.Stock,
                User = view.User

            };
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var view = this.ToProductViewModel(product); 
            return View(view);
        }

        private ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                //ImageUrl = product.ImageUrl,
                    ImageUrl  = product.ImageUrl,
                    IsAvailabe = product.IsAvailabe,
                    LastPurchase = product.LastPurchase,
                    LastSale = product.LastSale,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    User = product.User

            };
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    /*
                        Dot not Initialize Becouse maybe this not lose
                        var path = string.Empty;
                    */

                    //Use the IMAGE url than below with OBJ
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.png";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Products",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Products/{file}";
                    }

                    var product = this.ToProudct(view, path);
                    // TODO: Pending to change to: this.User.Identity.Name
                    view.User = await this.userHelper.GetUserByEmailAsync("fernandogarciaolivo@gmail.com");
                    await this.productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.productRepository.GetByIdAsync(id);

            await this.productRepository.DeleteAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
