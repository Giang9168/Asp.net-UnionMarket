using Microsoft.AspNetCore.Authorization;
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
    [Route("auth")]
    public class AuthControler :ControllerBase
    {
        private readonly UnionMarketContext _context;
        private readonly IAuthService _authService;
        public AuthControler(UnionMarketContext context, IAuthService authService)
        {

            _context = context;
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginValidator request)
        {
             var user=await _authService.Login(request);
            if (user != null) {
               
                var token = GenerateJwtToken.Generate(user.userName, user.role);

                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,


                    Expires = DateTimeOffset.UtcNow.AddMinutes(20),
                    SameSite = SameSiteMode.Lax
                });
                return Ok(user);
            }
           return NotFound("Không tìm thấy dữ liệu");

        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var username = User.Identity?.Name;
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            return Ok(new { username, role });
        }
    }
}
