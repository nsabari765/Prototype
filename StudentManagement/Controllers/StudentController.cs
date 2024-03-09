using DemoMvc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly DataContext context;

        public StudentController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Student());
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