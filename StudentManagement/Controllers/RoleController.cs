using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View("/Views/Role/Index.cshtml", roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("/Views/Role/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
