using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace admin.Models
{
    public class ExamStudent
    {
        [Required(ErrorMessage = "Tələbənin adını girin")]
        public string StudentName { get; set; } = null!;
        [Required(ErrorMessage = "Fənnin adını girin")]
        public string ExamName { get; set; } = null!;
        [Required (ErrorMessage = "Tələbənin qiymətini girin")]
        public byte Mark { get; set; }
        [Required(ErrorMessage = "Kodu Generate eliyin")]
        public string? StudentCode { get; set; }
    }
}