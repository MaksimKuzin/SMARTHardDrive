using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMARTHardDrive.Models;
using System.Diagnostics;

namespace SMARTHardDrive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HDContext _db = new HDContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalHardDrives = _db.HardDrives.Count(),
                WorkingHardDrives = _db.HardDrives.Count(hd => hd.Status == "Активен"),
                FaultyHardDrives = _db.HardDrives.Count(hd => hd.Status == "Неисправен"),
                Alerts = _db.Alerts.OrderByDescending(a => a.Date).ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}