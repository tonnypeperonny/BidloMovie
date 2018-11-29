using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.BL.UserService;
using Lab._06.MVC.Web.Models;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace Lab._06.MVC.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthenticationManager authManager;

        public AccountController(IUserService userService, IAuthenticationManager authManager)
        {
            this.userService = userService;
            this.authManager = authManager;
        }

        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto { UserLogin = model.UserLogin, UserPasswd = model.UserPasswd };
                var claim = userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError(string.Empty, "Wrong email or password");
                }
                else
                {
                    authManager.SignOut();
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("GetAllMovies", "Movie");
                    }
                    return Redirect(returnUrl);
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        public ActionResult SignOut()
        {
            authManager.SignOut();
            return RedirectToAction("GetAllMovies", "Movie");
        }

        public ActionResult SignUp() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = new UserDto
            {
                UserLogin = model.UserLogin,
                UserPasswd = model.UserPasswd,
                UserName = model.UserName,
                Role = "user",
            };
            userService.Create(userDto);
            authManager.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}