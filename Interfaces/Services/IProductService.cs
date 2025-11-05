using UnionMarket.DTOs;
using UnionMarket.Models.Entities;

namespace UnionMarket.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateAsync(Product product);
        Task<ProductDTO?> UpdateAsync(int id,Product product);
        Task<bool> DeleteAsync(int id);
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<ProductDTO> GetByNameAsync(string name);
        Task<IEnumerable<ProductDTO>> GetAllProduct();
    }
}
