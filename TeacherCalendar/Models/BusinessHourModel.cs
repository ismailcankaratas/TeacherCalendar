using TeacherCalendar.Data.Entity;

namespace TeacherCalendar.Models
{
    public class BusinessHourModel
    {
        public string UserId { get; set; }
        public int daysOfWeek { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }

    }
}
