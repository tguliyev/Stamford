using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Asset
    {
        public Asset()
        {
            Admins = new HashSet<Admin>();
            Courses = new HashSet<Course>();
            Graduates = new HashSet<Graduate>();
            PostAssets = new HashSet<PostAsset>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Graduate> Graduates { get; set; }
        public virtual ICollection<PostAsset> PostAssets { get; set; }
    }
}
