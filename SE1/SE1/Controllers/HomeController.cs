using Microsoft.AspNetCore.Mvc;
using SE1.Models;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace SE1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
        }

        public IActionResult ShowImagesFromFolder()
        {
            //Get the Folder Path
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            //Get the File Path
            var imageFileNames = Directory.EnumerateFiles(imageFolder)
                                          .Select(fn => Path.GetFileName(fn));
            //Return all the Images to the View
            return View(imageFileNames);
        }

        public IActionResult Index()
		{
            return View();
		}

		public IActionResult Login()
		{
			return View();
		}

        public IActionResult Dashboard()
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
