using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Imageid { get; set; }
        public int AccumulatedMoney { get; set; }

        public virtual Asset Image { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
    }
}
