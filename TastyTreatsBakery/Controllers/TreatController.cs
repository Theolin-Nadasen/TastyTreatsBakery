using Microsoft.AspNetCore.Mvc;
using TastData.Data;
using TastyModels;

namespace TastyTreatsBakery.Controllers
{
    public class TreatController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public TreatController(ApplicationDbContext DB)
        {
            _Db = DB;
        }

        public IActionResult Index()
        {
            List<Treat> treats = _Db.treats.ToList();
            return View(treats);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Treat treat)
        {
            if (ModelState.IsValid)
            {
                _Db.treats.Add(treat);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(int id)
        {
            Treat? obj = _Db.treats.Where(x => x.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Remove(Treat obj)
        {
            _Db.treats.Remove(obj);
            _Db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
