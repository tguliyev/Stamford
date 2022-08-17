using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Imageid { get; set; }
        public int AccumulatedMoney { get; set; }
    }
}
