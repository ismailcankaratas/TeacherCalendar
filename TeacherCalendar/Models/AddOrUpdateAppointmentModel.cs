namespace TeacherCalendar.Models
{
    public class AddOrUpdateAppointmentModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StudentNameSurname { get; set; }
        public string StudentId { get; set; }
        public string Description { get; set; }
    }
}
