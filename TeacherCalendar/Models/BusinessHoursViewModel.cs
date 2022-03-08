using TeacherCalendar.Data.Entity;

namespace TeacherCalendar.Models
{
    public class BusinessHoursViewModel
    {
        public AppUser User { get; set; }
        public List<BusinessHour> BusinessHours { get; set; }
    }
}
