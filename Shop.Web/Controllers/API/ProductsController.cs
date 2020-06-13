
namespace Shop.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using Shop.Web.Data;


    //Route we will access to the Api / Data Notation 
    [Route("api/[Controller]")]
    public class ProductsController: Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


       [HttpGet]
       public IActionResult GeProducts()
        {
            return Ok(this.productRepository.GetAllWithUser());
        }

    }
}
