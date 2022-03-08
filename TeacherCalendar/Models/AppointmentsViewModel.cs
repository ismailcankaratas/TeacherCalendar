using TeacherCalendar.Data.Entity;

namespace TeacherCalendar.Models
{
    public class AppointmentsViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Student { get; set; }
        public IEnumerable<AppUser> Teacher { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
