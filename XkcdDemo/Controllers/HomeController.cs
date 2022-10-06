using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XkcdDemo.Models;

namespace XkcdDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		async public Task<IActionResult> Index()
		{
			// Look at how I had to change the signature of the funcdtion. It was this:
			// public IActionResult Index()
			// But I had to add the word "async" before it and wrap the return type in Task<>

			HttpClient web = new HttpClient();
			web.BaseAddress = new Uri("https://xkcd.com/");
			var connection = await web.GetAsync("info.0.json");
			XkcdResult result = await connection.Content.ReadAsAsync<XkcdResult>();
			return View(result);
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