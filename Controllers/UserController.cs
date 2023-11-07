using GeeksProject02.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Controllers
{
    public class UserController : Controller
    {
        private readonly GeeksProject02Context DbContext;

        public UserController(GeeksProject02Context dbContext)
        {
            this.DbContext = dbContext;
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
    }
}
