using DemoMvc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext context;
        private readonly ILogger<HomeController> _logger;

        public StudentController(DataContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("/Views/New Student/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                await context.Student.AddAsync(student);
                await context.SaveChangesAsync();
                return RedirectToAction("Add");
            }

            return View(new Student());
        }
    }
}