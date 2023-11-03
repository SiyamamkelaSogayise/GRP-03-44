using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GeeksProject02.Controllers
{
    
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AppRolesController( RoleManager<IdentityRole> roleManager)
        {
                _roleManager = roleManager;
        }
        //list all roles created by user
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Create(IdentityRole model)
        {
            //avoid duplicate roles
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult()) 
            {
                _roleManager.CreateAsync(new IdentityRole { Name = model.Name }).GetAwaiter().GetResult(); 
                
            
            }
            return RedirectToAction("Index");
        }
    }
}
