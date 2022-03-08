using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherCalendar.Data;
using TeacherCalendar.Data.Entity;
using TeacherCalendar.Models;

namespace TeacherCalendar.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public JsonResult GetAppointment() // tüm randevuları getir
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Teacher = x.User.Name + " " + x.User.Surname,
                    Student = x.StudentNameSurname,
                    StudentId = x.StudentId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });
            return Json(model);
        }
        public JsonResult GetAppointmentsByTeacher(string userId = " ") // istediğim öğretmenin randevularını alma
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Teacher = x.User.Name + " " + x.User.Surname,
                    Student = x.StudentNameSurname,
                    StudentId = x.StudentId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });
            return Json(model);
        }
        public JsonResult GetAppointmentsByStudent(string userId = " ") // istediğim Öğrencinin randevularını alma
        {
            var model = _context.Appointments.Where(x => x.StudentId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Teacher = x.User.Name + " " + x.User.Surname,
                    Student = x.StudentNameSurname,
                    StudentId = x.StudentId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });
            return Json(model);
        }
        [HttpPost]
        public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentModel model)
        {
            if(model.Description == null)
            {
                model.Description = "";
            }
            //validasyon
            if (model.Id == 0)
            {
                Appointment entity = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    StudentId = model.StudentId,
                    StudentNameSurname = model.StudentNameSurname,
                    Description = model.Description,
                    UserId = model.UserId
                };

                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.Appointments.SingleOrDefault(x => x.Id == model.Id);
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.UpdatedDate = DateTime.Now;
                entity.StudentId = model.StudentId;
                entity.StudentNameSurname = model.StudentNameSurname;
                entity.Description = model.Description;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.UserId = model.UserId;

                _context.Update(entity);
                _context.SaveChanges();
            }
            return Json("200");
        }

        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _context.Appointments.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                Json("Kayıt bulunamadı");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return Json("200");
        }
    }
}
