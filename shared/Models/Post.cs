using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Post
    {
        public Post()
        {
            PostAssets = new HashSet<PostAsset>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = null!;

        public virtual ICollection<PostAsset> PostAssets { get; set; }
    }
}
