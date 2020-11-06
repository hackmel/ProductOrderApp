using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductOrdersApi.Repositories;
using ProductOrdersApi.Models;

namespace ProductOrdersApi.Services
{

    public interface IProductsService
    {
        public ProductsResponseDto GetProductsById(int Id);
        public List<ProductsResponseDto> GetAllProducts();

        public ProductsResponseDto CreateProduct(Product product);
    }

    public class ProductsService: IProductsService
    {
        private IProductsRepository repository;
        public ProductsService(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }

        public ProductsResponseDto GetProductsById(int Id)
        {
            var product = this.repository.GetProductsById(Id);

            return new ProductsResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = $"${product.Price}"
            };
        }

        public List<ProductsResponseDto> GetAllProducts()
        {
            var products = this.repository.GetAllProducts();

            return this.MapToProductResponseDto(products);
        }

        public ProductsResponseDto CreateProduct(Product product)
        {
            var newProduct = this.repository.CreateProduct(product);

            return new ProductsResponseDto()
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = $"${newProduct.Price}"
            };
        }

        private List<ProductsResponseDto> MapToProductResponseDto(List<Product> products)
        {
            var productItems = new List<ProductsResponseDto>();
            
            products.ForEach(item =>
            {
                productItems.Add(new ProductsResponseDto()
                {
                   Id = item.Id,
                   Name = item.Name,
                   Price = $"${item.Price}"
                });
            });

            return productItems;
        }
    }
}
