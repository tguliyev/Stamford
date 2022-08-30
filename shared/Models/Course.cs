using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Fənnin Adı Boş olmamalıdır")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Fənnin Qiyməti Boş olmamalıdır")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Fənn Haqqında heç olmasa biraz açıqlama olmalıdır")]
        public string Desc { get; set; } = null!;

        public int ImageId { get; set; }

        public virtual Asset Image { get; set; } = null!;
    
        public virtual ICollection<Graduate> Graduates { get; set; }
    }
}
