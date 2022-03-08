namespace TeacherCalendar.Models
{
    public class AddorDeleteBusinessHourViewModel
    {
        public string UserId { get; set; }
        public int daysOfWeek { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
