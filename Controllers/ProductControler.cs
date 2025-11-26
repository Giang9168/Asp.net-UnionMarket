using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnionMarket.Data;
using UnionMarket.DTOs;
using UnionMarket.Models.Entities;
using UnionMarket.Service;
using UnionMarket.Validators;

namespace UnionMarket.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductControler : ControllerBase
    {
       
        private readonly UnionMarketContext _context;
        private readonly IProductService _productService;

        public ProductControler( UnionMarketContext context,IProductService productService)
        {
           
            _context = context;
            _productService = productService;
        }
       
        [HttpGet("{id}")]
         public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductbyId(string id)
        {
            var x = await _productService.GetByIdAsync(id);
            if (x == null)
            {
                return NotFound();
            }
            return Ok(x);
        }

        //Thêm sản phẩm
        [HttpPost("add")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<ProductDTO?>>> AddProducts([FromBody] ProductValidator product)
        {
            var newProduct = new Product
            {
                // Giả sử Product model của bạn có các thuộc tính này
                Name = product.Name,
                Price = product.Price,
                Description= product.Description

                // Sao chép các thuộc tính khác nếu có...
            };
            var x = await _productService.CreateAsync(newProduct);
;         
            return Ok(x);
        }
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "ADMIN")]


        public async Task<bool> DeleteProducts(string id)
        {
            var b = await _productService.DeleteAsync(id);
            return b;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var x = await _productService.GetAllProduct();
            return Ok(x);
        }


        [HttpPut("update/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> UpdateProducts(string id,[FromBody] ProductValidator product)
        {

            var newProduct = new Product
            {
                // Giả sử Product model của bạn có các thuộc tính này
                Name = product.Name,
                Price = product.Price,
                Description = product.Description

                // Sao chép các thuộc tính khác nếu có...
            };
            var x = await _productService.UpdateAsync(id, newProduct);
            if (x != null)
            {
                return Ok(x);
            }
            return NotFound();
            
        }
        [HttpGet("admin")]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> update()
        {
            await _context.SaveChangesAsync();
            return Ok(new { mesagge ="okkkk"});
        }
        
    }
}
