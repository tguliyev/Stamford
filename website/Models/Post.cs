using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = null!;
    }
}
