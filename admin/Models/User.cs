using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Stamford.Models;

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

        public Admin CurrentUser(string email,string password,StamfordDBContext _context){

            Admin admin = _context.Admins.Where(a=>a.Password == password && a.Email == email).ToList()[0];

            return admin;
        }
    }
}