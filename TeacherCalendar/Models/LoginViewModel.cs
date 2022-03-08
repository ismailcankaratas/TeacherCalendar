using System.ComponentModel.DataAnnotations;

namespace TeacherCalendar.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıc adı alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adınız:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
