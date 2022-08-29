using System.ComponentModel.DataAnnotations;
namespace Stamford.Models
{
    public partial class Graduate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Məzunun adı boş olmalıdır")]
        public string? FullName { get; set; }

         [Required(ErrorMessage = "Açıqlama hissəsini doldurun")]
        public string Desc { get; set; } = null!;
        public int ImageId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Asset Image { get; set; } = null!;
    }
}
