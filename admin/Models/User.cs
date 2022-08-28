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
        public string Email { get; set; }

        public string Password { get; set; }
    }
}