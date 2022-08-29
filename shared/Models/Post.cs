using System.ComponentModel.DataAnnotations;

namespace Stamford.Models
{
    public partial class Post
    {
        public Post()
        {
            PostAssets = new HashSet<PostAsset>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Postun Başlığı Boş olmamalıdır")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Postun Açıqlaması Boş olmamalıdır")]
        public string Content { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<PostAsset> PostAssets { get; set; }
    }
}
