using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeacherCalendar.Data.Entity;

namespace TeacherCalendar.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BusinessHour> BusinessHours { get; set; }
    }
}
