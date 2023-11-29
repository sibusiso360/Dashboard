using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
