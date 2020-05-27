namespace Shop.Web.Data
{
    using Entities;
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }
    }
}
