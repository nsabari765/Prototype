using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class DataTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}