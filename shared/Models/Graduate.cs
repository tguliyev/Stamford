using System;
namespace Stamford.Models
{
    public class Graduate
    {
        public Graduate()
        {
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }

        public virtual Asset Image { get; set; } = null!;
    }
}

