
using Microsoft.AspNetCore.Mvc;
using UnionMarket.Models.Entities;

namespace UnionMarket.Interfaces.Repositories
{
    public interface IProductRepository
    {
       Task<IEnumerable<Product>> GetAllAsync();
       Task<Product?> GetDetailAsync(int id);
       Task<Product> AddProductAsync(Product x);
       Task<Product?> UpdateProductAsync(int id,Product x);
       Task<bool> DeleteProductAsync(int id);

    }
}
