using API.Models;

namespace API.DataTransferObjects
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public UserResponse () { }
        public UserResponse (User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}