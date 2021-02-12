using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            {
               new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
               new Product{ProductId=1,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitInStock=70},
               new Product{ProductId=1,CategoryId=1,ProductName="Telefon",UnitPrice=1500,UnitInStock=4},
               new Product{ProductId=1,CategoryId=1,ProductName="Klavye",UnitPrice=100,UnitInStock=3},
               new Product{ProductId=1,CategoryId=1,ProductName="Fare",UnitPrice=85,UnitInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ language ıntegrated query
            //Product  productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //} aşağıdaki ile aynı mantık
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
