using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SigninInput
    {
        [Required(ErrorMessage = "Email adresi boş olamaz!")]
        [Display(Name = "Email adresiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş olamaz!")]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
