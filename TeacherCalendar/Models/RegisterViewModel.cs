using System.ComponentModel.DataAnnotations;

namespace TeacherCalendar.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıc adı alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adınız:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad alanını boş bırakılamaz.")]
        [Display(Name = "Adınız:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [Display(Name = "Soyadınız:")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [Display(Name = "Email adresiniz:")]
        [EmailAddress(ErrorMessage = "Lütfen email alanını kontrol ediniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Randevu rengi alanı boş bırakılamaz.")]
        [Display(Name = "Randevu Rengi:")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Hesap türü alanı boş bırakılamaz.")]
        [Display(Name = "Hesap türü:")]
        public string AccountType { get; set; }

        [Display(Name = "Bölüm:")]
        public string Job { get; set; }
    }
}
