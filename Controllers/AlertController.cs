using Microsoft.AspNetCore.Mvc;
using SMARTHardDrive.Models;

namespace SMARTHardDrive.Controllers
{
    public class AlertController : Controller
    {
        HDContext _db = new HDContext();
        public IActionResult Index()
        {
            var model = _db.Alerts.AsEnumerable();
            return View("AlertsList", model);
        }
        public IActionResult Create()
        {
            ViewBag.HardDrives = _db.HardDrives.ToList();
            var model = new Alert();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Alert alert, List<int> hardDrives)
        {
            if (hardDrives != null)
            {
                foreach (var hard in hardDrives)
                {
                    alert.HardDrives.Add(_db.HardDrives.FirstOrDefault(x => x.Id == hard));
                }
            }
            else
                alert.HardDrives = null;
            _db.Alerts.Add(alert);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Alerts.FirstOrDefault(x => x.Id == id);
            ViewBag.HardDrives = _db.HardDrives.ToList();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Alert alert, List<int> hardDrives)
        {
            var existingAlert = _db.Alerts.FirstOrDefault(x => x.Id == alert.Id);
            if (existingAlert == null)
            {
                return NotFound();
            }
            existingAlert.HardDrives.Clear();
            if(hardDrives !=null && hardDrives.Any())
            {
                var selectedHardDrives = _db.HardDrives.Where(h => hardDrives.Contains(h.Id)).ToList();
                foreach(var hardDrive in selectedHardDrives)
                {
                    existingAlert.HardDrives.Add(hardDrive);
                }
            }
            existingAlert.Severity = alert.Severity;
            existingAlert.Status = alert.Status;
            existingAlert.Date = alert.Date;
            existingAlert.Description = alert.Description;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var alert = _db.Alerts.FirstOrDefault(x => x.Id == id);
            _db.Alerts.Remove(alert);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OnlyCritical()
        {
            var model = _db.Alerts.Where(x => x.Severity == "Критическое").AsEnumerable();
            return View("AlertsList", model);
        }
    }
}
