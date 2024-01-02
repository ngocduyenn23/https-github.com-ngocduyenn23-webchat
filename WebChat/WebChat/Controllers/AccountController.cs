using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebChat.Etities;
using WebChat.ViewModels.Account;

namespace WebChat.Controllers
{
    public class AccountController : ChattingAppControllerBase
    {
        private object u;

        public AccountController(ChattingAppDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Register() => View();
        [HttpPost]
        public IActionResult Register(RegisterVM user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }

            // Chuẩn hóa username và Email
            user.Username = user.Username.ToLower().Trim();

            //Check username đã tồn tại chưa
            var exists = _db.AppUsers.Any(u => u.Username == user.Username);
            if (exists)
            {
                ModelState.AddModelError("Err", "Tên đăng nhập đã được sữ dụng");
                return View(user);
            }
            AppUser users = new AppUser
            {
                Username = user.Username.ToLower().Trim(),
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                DisplayName = user.DisplayName.ToLower().Trim(),
                Avatar = "",
                CreateAt = DateTime.Now,

            };



            _db.AppUsers.Add(users);
            _db.SaveChanges();
            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", " Dữ liệu không hợp lệ!");
                return View(loginVM);
            }
            var user = _db.AppUsers.SingleOrDefault(u => u.Username == loginVM.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Tên không hợp lệ!");
                return View(loginVM);

            }

            //check mật khẩu
            if (BCrypt.Net.BCrypt.Verify(loginVM.Password, user.Password) == false)
            {
                ModelState.AddModelError("", " Mật khẩu không hợp lệ!");
                return View(loginVM);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("DisplayName", user.DisplayName)

            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


            HttpContext.SignInAsync("Cookies", claimsPrincipal).Wait();

            return RedirectToAction("Index", "Home");
        }



        /*  public IActionResult Logout()
          {
              HttpContext.Session.Clear();
              return RedirectToAction("Index", "Home");

          }*/
    }
}
