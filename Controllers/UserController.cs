using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{
    public class UserController : Controller
    {
        private readonly GeeksProject02Context DbContext;
        private readonly UserManager<GeeksProject02User> _userManager;

        public UserController(GeeksProject02Context dbContext , UserManager<GeeksProject02User> userManager)
        {
            this.DbContext = dbContext;
            _userManager = userManager;
        }
        
        public ActionResult Index()
        {

            ViewData["Title"] = "User List";
            var usersWithNullChecks = DbContext.Users
                .ToList()
                .Where(user => user.FirstName != null && user.LastName != null)
                .ToList();

            return View(usersWithNullChecks);
        }
        public async Task<bool> UpdateUserStatusAsync(string userId, string status)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.Status = status;
                var result = await _userManager.UpdateAsync(user);
                return result.Succeeded;
            }

            return false;
        }
        public async Task<IActionResult> DeactivateUser(string userId)
        {
           
            var status = "Inactive";

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
               
                return RedirectToAction("UserNotFound");
            }

            
            user.Status = status;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                
                return RedirectToAction("UserDeactivated");
            }
            else
            {
                return RedirectToAction("UserStatusUpdateFailed");
            }
        }
        [HttpPost]
        public JsonResult ToggleStatus(string userId, string status)
        {
            // Update the user's status in your database using the userId and status
            // You can use your DbContext to make the necessary changes

            return Json(new { success = true }); // Return a JSON response for success
        }


    }
}
