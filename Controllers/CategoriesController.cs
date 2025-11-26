using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UnionMarket.Data;
using UnionMarket.DTOs;
using UnionMarket.Models;
using UnionMarket.Models.Entities;
using UnionMarket.Service;

namespace UnionMarket.Controllers
{
    [ApiController]
    [Route("category")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly UnionMarketContext _context;
        public CategoriesController(UnionMarketContext context)
        {

            _context = context;
            
        }
        [HttpGet("tree")]
        public async Task<IActionResult> GetCategoryTree()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users
            .Include(x => x.Shop)
            .FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            var categories = await _context.ShopCategories.Where(c => c.ShopId == user.Shop.Id).ToListAsync();

            var tree = BuildTree(categories, null);

            return Ok(tree);
        }

        private List<CategoryTreeDto> BuildTree(List<ShopCategory> all, Guid? parentId)
        {
            return all
                .Where(x => x.ParentId == parentId)
              
                .Select(x => new CategoryTreeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Path = x.Slug,               
                    Children = BuildTree(all, x.Id)  // ✅ đệ quy
                })
                .ToList();
        }

    }
}
