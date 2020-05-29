namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        public IQueryable GetAllWithUser()
        {
            return this.Context.Products.Include(p => p.User);
        }
    }
}
