using System.ComponentModel.DataAnnotations;

namespace Stamford.Models
{
    public partial class ExamStudent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tələbənin adını girin")]
        public string StudentName { get; set; } = null!;

        [Required(ErrorMessage = "Fənnin adını girin")]
        public string ExamName { get; set; } = null!;

        [Required (ErrorMessage = "Tələbənin qiymətini girin")]
        
        public byte Mark { get; set; }
        
        [Required(ErrorMessage = "Kodu Generate eliyin")]
        public string Code { get; set; }
    }
}
