using Microsoft.AspNetCore.Identity;

namespace TeacherCalendar.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public string AccountType { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Color { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
