<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using System;
using System.Collections.Generic;

>>>>>>> b45096743a5e846f90a139636fd2ebf8aaf237d5
namespace Stamford.Models
{
    public partial class Graduate
    {
        public int Id { get; set; }
<<<<<<< HEAD

        [Required(ErrorMessage = "Məzunun adı boş olmalıdır")]
        public string? FullName { get; set; }

         [Required(ErrorMessage = "Açıqlama hissəsini doldurun")]
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
=======
        public string? FullName { get; set; }
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
>>>>>>> b45096743a5e846f90a139636fd2ebf8aaf237d5
        public virtual Asset Image { get; set; } = null!;
    }
}
