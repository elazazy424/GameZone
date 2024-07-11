using Game.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        #region show the users to admin
        public async Task<IActionResult> Index(string SearchValue = "")
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var users = userManager.Users;
                return View(users);
            }
            else
            {
                var users = await userManager.Users.Where(u => u.Email.Contains(SearchValue)).ToListAsync();
                return View(users);
            }
        }
        #endregion
        #region details of user
        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(viewName, user);

        }
        #endregion
        #region update user
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var appUser = await userManager.FindByIdAsync(id);
                    //map the data from user to appUser
                    appUser.UserName = user.UserName;
                    appUser.NormalizedUserName = user.UserName.ToUpper();
                    appUser.PhoneNumber = user.PhoneNumber;
                    var result = await userManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View(user);
        }
        #endregion
        #region delete user
        // i want to delete user without confirmation


        public async Task<IActionResult> Delete(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
                var appUser = await userManager.FindByIdAsync(id);
                var result = await userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
