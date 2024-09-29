using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TastyTreatsBakery.Data;
using TastyTreatsBakery.Models;

namespace TastyTreatsBakery.Controllers
{

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly ApplicationDbContext _Db;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext DB)
		{
			_Db = DB;
			_logger = logger;
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
