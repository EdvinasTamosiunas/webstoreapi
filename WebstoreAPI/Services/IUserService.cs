using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;

namespace WebstoreAPI.Services
{
    public interface IUserService
    {
        public Task<UserResponse> CheckLoginInfo(LoginRequest userRequest);
        public Task<List<User>> GetUsers();
        public Task<User> UpdateUser(User user);
        public Task<User> CreateUser(UserRequest userRequest);
    }
}