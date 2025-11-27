using Microsoft.EntityFrameworkCore;
using UnionMarket.Models;
using UnionMarket.Models.Entities;
using UnionMarket.Validators;

namespace UnionMarket.Data.Repositories
{

    public interface IAuthRepository
    {
        Task<User?> Login(LoginValidator x);
    }
    public class AuthRepository : IAuthRepository
    {
        private readonly UnionMarketContext _context;
        public AuthRepository(UnionMarketContext context)
        {
            _context = context;
        }
       async public Task<User?> Login(LoginValidator request)
        {
           var  user = await _context.Users
        .Where(u => u.Email == request.Username)
        .Include(u => u.Roles)
        .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            

               
            return user;
            
           

        }
    }
}
