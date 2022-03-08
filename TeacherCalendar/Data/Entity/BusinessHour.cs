namespace TeacherCalendar.Data.Entity
{
    public class BusinessHour
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int daysOfWeek { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
