using System.ComponentModel.DataAnnotations;

namespace Stamford.Models
{
    public partial class ExamStudent
    {
        public int Id { get; set; }
<<<<<<< HEAD

        [Required(ErrorMessage = "Tələbənin adını girin")]
        public string StudentName { get; set; } = null!;

        [Required(ErrorMessage = "Fənnin adını girin")]
        public string ExamName { get; set; } = null!;

        [Required (ErrorMessage = "Tələbənin qiymətini girin")]
        
        public byte Mark { get; set; }
        
        [Required(ErrorMessage = "Kodu Generate eliyin")]
        public string Code { get; set; }
=======
        public string StudentName { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public byte Mark { get; set; }
        public string Code { get; set; } = null!;
>>>>>>> b45096743a5e846f90a139636fd2ebf8aaf237d5
    }
}
