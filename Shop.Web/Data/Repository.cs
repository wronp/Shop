﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        #region Type of Methods
        public IEnumerable<Product> GetProducts() => context.Products.OrderBy(p => p.Name); // This is a expresion LinQ to show the list by order
        //public IEnumerable<Product> GetProducts()
        //{
        //    return context.Products.OrderBy(p => p.Name); // This is a expresion LinQ to show the list by order
        //}
        #endregion

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            context.Products.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}
