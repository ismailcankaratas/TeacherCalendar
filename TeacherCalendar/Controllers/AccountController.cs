using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherCalendar.Data.Entity;
using TeacherCalendar.Models;

namespace TeacherCalendar.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı bulunamadı.");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile");
            }
            ModelState.AddModelError(String.Empty, "Hatalı şifre.");
            return View(model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.AccountType == "0")
            {
                ModelState.AddModelError(String.Empty,"Lüften bir hesap türü seçiniz.");
                return View(model);
            }
            if (model.AccountType == "Teacher" && model.Job == "0")
            {
                ModelState.AddModelError(String.Empty, "Lüften bölüm seçiniz.");
                return View(model);
            }

            AppUser user = new AppUser()
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Color = model.Color,
                AccountType = model.AccountType,
                Job = model.Job
            };
            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                //bool roleCheck = model.AccountType == "Teacher" ? AddRole("Teacher") : AddRole("Student");
                if(model.AccountType == "Teacher")
                {
                    AddRole("Teacher");
                }
                else if(model.AccountType == "Student")
                {
                    AddRole("Student");
                }
                else if (model.AccountType == "Manager")
                {
                    AddRole("Manager");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Kullanıcı Yetkilendirme hatası.");
                    return View(model);
                }

                _userManager.AddToRoleAsync(user, model.AccountType).Wait();
                return View();
            }else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, item.Description);
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
        public IActionResult Denied()
        {
            return View();
        }
        private bool AddRole(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                AppRole role = new AppRole()
                {
                    Name = roleName
                };

                IdentityResult result = _roleManager.CreateAsync(role).Result;
                return result.Succeeded;
            }
            return true;
        }
    }
}
