using Microsoft.AspNetCore.Mvc;
using SMARTHardDrive.Models;

namespace SMARTHardDrive.Controllers
{
    public class SMARTAttributeController : Controller
    {
        HDContext _db = new HDContext();
        public IActionResult Index()
        {
            var model = _db.SMARTAttributes.AsEnumerable();
            return View("SMARTAttributesList", model);
        }
        public IActionResult Create()
        {
            var model = new SMARTAttribute();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(SMARTAttribute SMARTAttribute)
        {
            _db.SMARTAttributes.Add(SMARTAttribute);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.SMARTAttributes.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(SMARTAttribute hard)
        {
            _db.SMARTAttributes.Update(hard);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var SMARTAttribute = _db.SMARTAttributes.FirstOrDefault(x => x.Id == id);
            _db.SMARTAttributes.Remove(SMARTAttribute);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
