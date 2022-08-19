using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Asset
    {
        public Asset()
        {
            PostAssets = new HashSet<PostAsset>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public virtual ICollection<PostAsset> PostAssets { get; set; }
        public virtual ICollection<Graduate> Graduates { get; set; }
    }
}
