namespace TeacherCalendar
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Teacher { get; internal set; }
        public string Student { get; internal set; }
        public string StudentNameSurname { get; internal set; }
        public string StudentId { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Description { get; internal set; }
        public string Color { get; internal set; }
        public string UserId { get; internal set; }
    }
}