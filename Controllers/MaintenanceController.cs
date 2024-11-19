using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMARTHardDrive.Models;

namespace SMARTHardDrive.Controllers
{
    public class MaintenanceController : Controller
    {
        HDContext _db = new HDContext();
        public IActionResult Index()
        {
            var model = _db.Maintenances.Include(x => x.HardDrive);
            return View("MaintenancesList", model);
        }
        public IActionResult Create()
        {
            ViewBag.HardDrives = _db.HardDrives.ToList();
            var model = new Maintenance();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Maintenance maintenance)
        {
            _db.Maintenances.Add(maintenance);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.HardDrives = _db.HardDrives.ToList();
            var model = _db.Maintenances.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Maintenance maintenance)
        {
            _db.Maintenances.Update(maintenance);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var maintenance = _db.Maintenances.FirstOrDefault(x => x.Id == id);
            _db.Maintenances.Remove(maintenance);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MaintenancesByDate(DateTime? startDate, DateTime? endDate)
        {
            var model = _db.Maintenances.AsQueryable();
            if (startDate.HasValue)
            {
                model = model.Where(o => o.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                model = model.Where(o => o.Date <= endDate.Value);
            }
            return View("MaintenancesList", model);
        }
    }
}
