using System.ComponentModel.DataAnnotations;

namespace Stamford.Models
{
    public partial class Admin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username Mutleq Doldurulmalidir")]
        public string Username { get; set; } = null!;

       
        [EmailAddress(ErrorMessage ="Email Adress Doldurulmalidir")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Password Mutleq Doldurulmalidir")]
        public string Password { get; set; } = null!;
        public int? Imageid { get; set; }

        public virtual Asset? Image { get; set; }
    }
}
