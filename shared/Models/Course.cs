using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Course
    {
        public Course()
        {
            Graduates = new HashSet<Graduate>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }

        public virtual Asset Image { get; set; } = null!;
        public virtual ICollection<Graduate> Graduates { get; set; }
    }
}
