using Castle.DynamicProxy;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class MockRepository : IRepository
    {
        public void AddProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public Products GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetProducts()
        {
            var products = new List<Products>();
            products.Add(new Products { 
                Id = 1, Name = "Huawei MY 10 ",Price = 7000});
            products.Add(new Products
            {
                Id = 2,
                Name = "Huawei Mate ",
                Price = 5000
            });
            products.Add(new Products
            {
                Id = 3,
                Name = "Iphone X max ",
                Price = 7000
            });
            products.Add(new Products
            { Id = 4,
                Name = "Iphone X max ",
                Price = 2000});
            return products;

        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
