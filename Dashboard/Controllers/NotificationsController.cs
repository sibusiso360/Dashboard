using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
