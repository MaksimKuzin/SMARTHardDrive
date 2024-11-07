using Microsoft.AspNetCore.Mvc;
using SMARTHardDrive.Models;

namespace SMARTHardDrive.Controllers
{
    public class SMARTDataController : Controller
    {
        HDContext _db = new HDContext();
        public IActionResult Index()
        {
            var model = _db.SMARTData.AsEnumerable();
            return View("SMARTDatasList", model);
        }
        public IActionResult Create()
        {
            ViewBag.HardDrives = _db.HardDrives.ToList();
            ViewBag.Attributes = _db.SMARTAttributes.ToList();
            var model = new SMARTData();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(SMARTData SMARTData)
        {
            _db.SMARTData.Add(SMARTData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.HardDrives = _db.HardDrives.ToList();
            ViewBag.Attributes = _db.SMARTAttributes.ToList();
            var model = _db.SMARTData.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(SMARTData SMARTData)
        {
            _db.SMARTData.Update(SMARTData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var SMARTData = _db.SMARTData.FirstOrDefault(x => x.Id == id);
            _db.SMARTData.Remove(SMARTData);
            return RedirectToAction("Index");
        }
    }
}
