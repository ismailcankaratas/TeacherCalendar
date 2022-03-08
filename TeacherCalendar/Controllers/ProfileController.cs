using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeacherCalendar.Data;
using TeacherCalendar.Data.Entity;
using TeacherCalendar.Models;

namespace TeacherCalendar.Controllers
{
    [Authorize(Roles = "Teacher, Student, Manager")]
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        private ApplicationDbContext _context;
        public ProfileController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            if (user == null)
            {
                return View("Error");
            }
            if (_userManager.IsInRoleAsync(user, "Teacher").Result)
            {
                var student = _userManager.Users.Where(x => x.AccountType == "Student");
                var teacher = _userManager.Users.Where(x => x.AccountType == "Teacher");
                TeacherViewModel model = new TeacherViewModel()
                {
                    User = user,
                    Student = student,
                    Teacher = teacher,
                    TeacherSelectList = teacher.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                    StudentSelectList = student.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                };
                return View("Teacher", model);
            }
            else if (_userManager.IsInRoleAsync(user, "Student").Result)
            {
                var student = _userManager.Users.Where(x => x.AccountType == "Student");
                var teacher = _userManager.Users.Where(x => x.AccountType == "Teacher");
                TeacherViewModel model = new TeacherViewModel()
                {
                    User = user,
                    Student = student,
                    Teacher = teacher,
                    TeacherSelectList = teacher.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                    StudentSelectList = student.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                };
                return View("Student", model);
            }
            else if (_userManager.IsInRoleAsync(user, "Manager").Result)
            {
                var student = _userManager.Users.Where(x => x.AccountType == "Student");
                var teacher = _userManager.Users.Where(x => x.AccountType == "Teacher");
                TeacherViewModel model = new TeacherViewModel()
                {
                    User = user,
                    Student = student,
                    Teacher = teacher,
                    TeacherSelectList = teacher.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                    StudentSelectList = student.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList(),
                };
                return View("Manager", model);
            }else
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Teacher()
        {
            return View();
        }
        [Authorize(Roles = "Student")]
        public IActionResult Student()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }
        [Authorize]
        public IActionResult BusinessHours()
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var businessHour = _context.BusinessHours.Where(x => x.UserId == user.Id).ToList();
            BusinessHoursViewModel model = new BusinessHoursViewModel()
            {
                User = user,
                BusinessHours = businessHour
            };
            return View(model);
        }
        
    }
}
