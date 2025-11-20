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
           var user= await authRepository.Login(x);
            if (user == null)
            {
                return null;
            }
            else
            {

               

                
                var z = new UserDTO();
                z.role = user.Role;
                z.userName = user.Username;

                return z;
            }
        }

        public void Register(string username, string password)
        {

            throw new NotImplementedException();
        }
    }
}
