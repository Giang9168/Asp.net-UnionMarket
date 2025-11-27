using Azure;
using Microsoft.EntityFrameworkCore;
using UnionMarket.Data.Repositories;
using UnionMarket.DTOs;
using UnionMarket.Models.Entities;
using UnionMarket.Validators;

namespace UnionMarket.Service
{

    public interface IAuthService
    {
        void Register(string username, string password);
        Task<UserDTO?> Login(LoginValidator x);
    }
    public class AuthService : IAuthService
    {
        public readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository _authRepository)
        {
            authRepository = _authRepository;
        }

        async public Task<UserDTO?> Login(LoginValidator x)
        {
            var priorityOrder = new Dictionary<string, int>
                {
                          { "ADMIN", 3 },
                          { "SELLER", 2 },
                          { "BUYER", 1 }
        };
            var user= await authRepository.Login(x);
            if (user == null)
            {
                return null;
            }
            else
            {


                var highestRole = user.Roles
                    .OrderByDescending(r => priorityOrder.ContainsKey(r.Code) ? priorityOrder[r.Code] : 0)
                    .FirstOrDefault();
                var z = new UserDTO();
                if (user != null)
                {
                    var listRoles = user.Roles.ToList();          
                    var roleCodes = user.Roles.Select(r => r.Code).ToList(); 
                }
                z.role = highestRole?.Code;
                z.id =user.Id;
                z.userName = user.Email;

                return z;
            }
        }

        public void Register(string username, string password)
        {

            throw new NotImplementedException();
        }
    }
}
