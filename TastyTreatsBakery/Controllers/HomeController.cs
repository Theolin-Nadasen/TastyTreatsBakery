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
