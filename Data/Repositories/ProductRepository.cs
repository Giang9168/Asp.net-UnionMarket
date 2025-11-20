using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UnionMarket.Models.Entities;
namespace UnionMarket.Data.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetDetailAsync(int id);
        Task<Product> AddProductAsync(Product x);
        Task<Product?> UpdateProductAsync(int id, Product x);
        Task<bool> DeleteProductAsync(int id);

    }

    public class ProductRepository : IProductRepository
    {
        private readonly UnionMarketContext _context;
      

        public ProductRepository(UnionMarketContext context) { 
            _context = context;
        
        }
        public async Task<Product> AddProductAsync(Product x)
        {
                if(x == null) throw new ArgumentNullException(nameof(x));
                _context.Product.Add(x);
                await _context.SaveChangesAsync();
                return x; 

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var x = await _context.Product.FindAsync(id);
            if (x == null)
            {
                return false;
            }

            // 3. Nếu tìm thấy, đánh dấu để xóa
            _context.Product.Remove(x);

            // 4. Lưu thay đổi vào database (thực hiện xóa)
            await _context.SaveChangesAsync();

            // 5. Trả về response 204 No Content - đây là response chuẩn cho một
            //    yêu cầu DELETE thành công mà không cần trả về dữ liệu gì.
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetDetailAsync(int id)
        {
            return await _context.Product.FindAsync(id);
            
        }

        public async Task<Product?> UpdateProductAsync(int id, Product x)
        {
            var productToUpdate = await _context.Product.FindAsync(id);
            if (productToUpdate == null)
            {
                return null;
            }
            productToUpdate.Name = x.Name;
            productToUpdate.Price = x.Price;
            productToUpdate.Description = x.Description;
            _context.Entry(productToUpdate).State = EntityState.Modified;

            try
            {
                // 4. Lưu các thay đổi vào CSDL
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Product.Any(e => e.Id == id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return productToUpdate;
        }
    }
}
