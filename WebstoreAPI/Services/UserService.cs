using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebstoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext dbContext, IConfiguration config)
        {
            _context = dbContext;
            _configuration = config;
        }

        public async Task<UserResponse> CheckLoginInfo(LoginRequest userRequest)
        {
            var user = await _context
                .Users
                .SingleOrDefaultAsync(entity =>
                    entity.UserName == userRequest.UserName && entity.Password == userRequest.Password);

            if (user == null) return null;
            var generatedToken = GenerateJwtToken(user);
            return new UserResponse(user, generatedToken);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var secutiryToken = tokenHandler.CreateToken(tokenDescriptor);
            var generatedTokenAsString = tokenHandler.WriteToken(secutiryToken);
            return generatedTokenAsString;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users
                .ToListAsync();

            return users.ToList();
        }

        public async Task<User> UpdateUser(User userInRequest)
        {
            var oldUser = await _context
                .Users
                .SingleOrDefaultAsync(entity => entity.Id == userInRequest.Id);

            var updatedUser = new User(oldUser, userInRequest);
            _context.Remove(oldUser);
            _context.Add(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<User> CreateUser(UserRequest userRequest)
        {
            var user = new User(userRequest);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}