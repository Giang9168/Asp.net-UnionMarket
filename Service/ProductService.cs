using UnionMarket.DTOs;
using UnionMarket.Interfaces.Repositories;
using UnionMarket.Interfaces.Services;
using UnionMarket.Models.Entities;

namespace UnionMarket.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) {
        
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> CreateAsync(Product product)
        {
            ProductDTO productDTO = new ProductDTO();
            var x= await _productRepository.AddProductAsync(product);
            productDTO.Description = product.Description;
            productDTO.Name = product.Name;
            productDTO.Id = product.Id;
            productDTO.Price = product.Price;
            return productDTO;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var x= await _productRepository.DeleteProductAsync(id);
            return x;
        }


        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            List<ProductDTO> x = new List<ProductDTO>();
            var products= await _productRepository.GetAllAsync();
           
            foreach(var product in products)
            {
                ProductDTO a = new ProductDTO();
                a.Name = product.Name;
                a.Price = product.Price;
                a.Id = product.Id;
                a.Description = product.Description;
                x.Add(a);
            }

            return x;
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var x = await _productRepository.GetDetailAsync(id);
            ProductDTO a = new ProductDTO();
            if (x != null)
            {
                a.Id = x.Id;
                a.Name = x.Name;
                a.Price = x.Price;
                a.Description = x.Description;
                return a;
            }
            return null;
            

        }

        public Task<ProductDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO?> UpdateAsync(int id, Product product)
        {
            var x = await _productRepository.UpdateProductAsync(id, product);
            ProductDTO a = new ProductDTO();
            if(x != null)
            {
                a.Name = x.Name;
                a.Id = x.Id;
                a.Price = x.Price;
                a.Description = x.Description;
                return a;
            }
            return null;
        }
    }
}
