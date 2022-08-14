using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Asset
    {
        public Asset()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
