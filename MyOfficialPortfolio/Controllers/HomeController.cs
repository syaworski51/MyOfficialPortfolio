using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyOfficialPortfolio.Models;
using MyOfficialPortfolio.Models.InputForms;

namespace MyOfficialPortfolio.Controllers
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

        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactForm form)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var errorMessage = new ErrorViewModel
                {
                    Description = ex.Message
                };

                return View("Error", errorMessage);
            }
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
