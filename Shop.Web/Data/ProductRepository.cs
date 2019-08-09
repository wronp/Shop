using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Shop.Web.Data
{
    using Entities;

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUser()
        {
            return context.Products.Include(p => p.User);
        }
    }


}
