using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class PostAsset
    {
        public int Id { get; set; }
        public int Postid { get; set; }
        public int Imageid { get; set; }

        public virtual Asset Image { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
    }
}
