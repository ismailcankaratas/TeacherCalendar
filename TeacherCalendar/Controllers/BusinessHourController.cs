using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherCalendar.Data;
using TeacherCalendar.Data.Entity;
using TeacherCalendar.Models;

namespace TeacherCalendar.Controllers
{
    public class BusinessHourController : Controller
    {
        private ApplicationDbContext _context;
        public BusinessHourController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public JsonResult AddorDeleteBusinessHour(AddorDeleteBusinessHourViewModel businessHours)
        {
            var entity = _context.BusinessHours.SingleOrDefault(x => x.UserId == businessHours.UserId && x.daysOfWeek == businessHours.daysOfWeek && x.startTime == businessHours.startTime && x.endTime == businessHours.endTime);
            if (entity == null)
            {
                BusinessHour businessHour = new BusinessHour()
                {
                    UserId = businessHours.UserId,
                    daysOfWeek = businessHours.daysOfWeek,
                    startTime = businessHours.startTime,
                    endTime = businessHours.endTime,
                };
                _context.Add(businessHour);
                _context.SaveChanges();
                return Json("Kayıt eklendi");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return Json("Kayıt silindi");
        }
        public JsonResult GetBusinessHourByTeacher(string userId = " ")
        {
            var model = _context.BusinessHours.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new BusinessHourModel()
                {
                    UserId = x.UserId,
                    daysOfWeek = x.daysOfWeek,
                    startTime = x.startTime,
                    endTime = x.endTime,
                });

            return Json(model);
        }
    }
}
