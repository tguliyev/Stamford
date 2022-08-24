using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Graduate
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Asset Image { get; set; } = null!;
    }
}
