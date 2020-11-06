using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ProductOrdersApi.Models;

namespace ProductOrdersApi.Repositories
{

    public interface IProductsRepository {
        public Product GetProductsById(int Id);
        public List<Product> GetAllProducts();
        public Product CreateProduct(Product product);
    }


    public class ProductsRepository: IProductsRepository
    {
        private IMemoryCache productsCache;

        public ProductsRepository(IMemoryCache cache)
        {
            this.productsCache = cache;
            
            productsCache.Set("ProductList", Initialize());
            
        }


        public Product GetProductsById(int Id)
        {  
            var products = new List<Product>();
            productsCache.TryGetValue("ProductList", out products);
            return products.Find(x => x.Id == Id);
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            productsCache.TryGetValue("ProductList", out products);
            return products;
        }


        public Product CreateProduct(Product product)
        {
            var products = new List<Product>();
            productsCache.TryGetValue("ProductList", out products);

            var lastEnrtry = products.Last();
            var newID =  lastEnrtry.Id + 1;
            product.Id = newID;
            products.Add(product);

            productsCache.Set("ProductList", products);

            return product;
        }

        private List<Product> Initialize()
            => new List<Product>()
            {
                {
                    new Product() { Id = 1, Name = "Cookies", Price = 2.99M }
                },
                {
                    new Product() { Id = 2, Name = "Bread", Price = 2.00M }
                },
                {
                    new Product() { Id = 3, Name = "Orange Juice", Price = 5.00M }
                },
            };
        

    }
}
