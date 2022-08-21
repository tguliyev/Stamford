using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stamford.Models;

namespace admin.Models
{
    public class PostViewModel
    {
        public string? Title { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}