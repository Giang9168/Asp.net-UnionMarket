using Microsoft.EntityFrameworkCore;
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
             return  await _context.Users.FirstOrDefaultAsync(u =>

                u.Username == request.Username && u.Password == request.Password

                );
            

        }
    }
}
