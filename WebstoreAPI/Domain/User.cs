using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;

namespace API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User () { }
        public User (UserRequest userRequest)
        {

            UserName = userRequest.UserName;
            Password = userRequest.Password;
            Email = userRequest.Email;
            Role = userRequest.Role;

        }

        public User (User oldUser, User user)
        {

            Id = oldUser.Id;
            UserName = user.UserName;
            Password = user.Password;
            Email = user.Email;
            Role = user.Role;

        }
    }
}