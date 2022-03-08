using Microsoft.AspNetCore.Mvc.Rendering;
using TeacherCalendar.Data.Entity;

namespace TeacherCalendar.Models
{
    public class TeacherViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Student { get; set; }
        public IEnumerable<AppUser> Teacher { get; set; }
        public List<SelectListItem> TeacherSelectList { get; internal set; }
        public List<SelectListItem> StudentSelectList { get; internal set; }
    }
}
