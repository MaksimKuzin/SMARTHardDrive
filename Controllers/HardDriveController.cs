using Microsoft.AspNetCore.Mvc;
using SMARTHardDrive.Models;

namespace SMARTHardDrive.Controllers
{
    public class HardDriveController : Controller
    {
        HDContext _db = new HDContext();
        public IActionResult Index()
        {
            var model = _db.HardDrives.AsEnumerable();
            return View("HardDrivesList", model);
        }
        public IActionResult Create()
        {
            var model = new HardDrive();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(HardDrive hard)
        {
            _db.HardDrives.Add(hard);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.HardDrives.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(HardDrive hard)
        {
            _db.HardDrives.Update(hard);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var hard = _db.HardDrives.FirstOrDefault(x => x.Id == id);
            _db.HardDrives.Remove(hard);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchString)
        {
            var model = _db.HardDrives.Where(x => x.SerialNumber.Contains(searchString)).AsEnumerable();
            return View("HardDrivesList", model);
        }
    }

}
