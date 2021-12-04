using Microsoft.AspNetCore.Mvc;
using PostValueChange.Models;
using System.Diagnostics;

namespace PostValueChange.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
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

		[HttpGet]
		public IActionResult Sample() => View();

		[HttpPost]
		public IActionResult Sample(SampleViewModel model)
		{
			if (ModelState.IsValid == false) View(model);

			// ModelState の値を消してモデルの値をビューに返却できるようにする
			ModelState.Remove(nameof(model.ResultValue1));

			// ビューに返す値を設定する
			model.ResultValue1 = model.InputValue + " テキストを追加1";
			model.ResultValue2 = model.InputValue + " テキストを追加2";

			return View(model);
		}
	}
}