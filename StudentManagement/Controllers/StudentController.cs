using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Repository;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext context;
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository repository;

        public StudentController(DataContext context, ILogger<HomeController> logger, IStudentRepository repository)
        {
            this.context = context;
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> View()
        {
            var resopnse = await repository.GetAllStudents();
            return View("/Views/New Student/View.cshtml", resopnse);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var response = await repository.GetStduentById(id);
            return View("/Views/New Student/Index.cshtml",response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                await repository.SaveOrUpdate(student);
            }

            return RedirectToAction("View");
        }

        [HttpGet]
        public IActionResult Delete(Student student)
        {
            var response = repository.Delete(student);

            return RedirectToAction("View");
        }
    }
}