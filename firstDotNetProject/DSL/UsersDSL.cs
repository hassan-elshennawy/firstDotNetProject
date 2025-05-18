using BCrypt.Net;
using firstDotNetProject.Config;
using firstDotNetProject.DAL;
using firstDotNetProject.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace firstDotNetProject.DSL
{
    public class UsersDSL
    {
        private readonly UseresDAL _users;
        private readonly JwtAuthService _jwtAuthService;
        private readonly PasswordHasher<string> _passwordHasher = new();
        public UsersDSL(UseresDAL users, JwtAuthService jwtAuthService) 
        {
            _users = users;
            _jwtAuthService = jwtAuthService;
        }

        public async Task<string> CreateUser(CreateUserRequestDTO requestDTO)
        {
            var existingUser = await _users.GetByUsername(requestDTO.Name);
            if (existingUser != null)
            {
                throw new Exception("please change username already exisit");
            }
            var hashedpassword = _passwordHasher.HashPassword(requestDTO.Name, requestDTO.password);
            requestDTO.password = hashedpassword;
            return await _users.CreateUser(requestDTO);
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _users.GetByUsername(loginDTO.username);
            if(user == null)
            {
                throw new Exception("Wrong username or password");
            }
            var res = _passwordHasher.VerifyHashedPassword(user.Name, user.password, loginDTO.password);
            if(res == PasswordVerificationResult.Failed)
            {
                throw new Exception("Wrong username or password");  
            }
             return(_jwtAuthService.GenerateToken(user));
        }
    }
}
