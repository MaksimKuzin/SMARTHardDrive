using Microsoft.AspNetCore.Mvc;

namespace SMARTHardDrive.Controllers
{
    public class MaintenanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
