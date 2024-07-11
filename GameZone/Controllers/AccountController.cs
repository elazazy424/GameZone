using Game.DAL.Entity;
using GameZone.Helpers;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region sign up
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        
       
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    IsAgree = model.IsAgree
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("SignIn");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        #endregion
        #region sign in
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Email");
                }
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        #endregion
        #region sign out
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
        #endregion
        #region foreget password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { Email = model.Email, token = token}, Request.Scheme);
                    Email email = new Email()
                    {
                        To = model.Email,
                        Title = "Reset Password",
                        Body = $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>"
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CompleteResetPassword");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email");
                }
            }
            return View(model);
        }
        #endregion
        #region complete reset password
        [HttpGet]
        public IActionResult CompleteResetPassword(string Email, string token)
        {
            return View();
        }
        #endregion
        #region reset password
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ResetPasswordDone");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email");
                }
            }
            return View(model);
        }
        #endregion
        #region reset password done
        public IActionResult ResetPasswordDone()
        {
            return View();
        }
        #endregion
    }
}
