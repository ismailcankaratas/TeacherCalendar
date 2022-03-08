namespace TeacherCalendar.Data.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StudentNameSurname { get; set; }
        public string StudentId { get; set; }
        public string Description { get; set; }
    }
}
