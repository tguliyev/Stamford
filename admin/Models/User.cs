using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace admin.Models
{
    public class User
    {
        public User(string Email, string password)
        {
            this.Email = Email;
            Password = password;
        }

        public User(){}
        public string Email { get; set; }

        public string Password { get; set; }     
    }
}