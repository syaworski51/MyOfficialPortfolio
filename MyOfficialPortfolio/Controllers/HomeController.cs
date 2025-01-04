using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyOfficialPortfolio.Models;
using MyOfficialPortfolio.Models.OutputModels;
using MyOfficialPortfolio.Models.InputForms;
using MyOfficialPortfolio.Services;

namespace MyOfficialPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SESService _sesService;
        private readonly IConfigurationSection _secrets;

        public HomeController(ILogger<HomeController> logger, SESService sesService, IConfiguration configuration)
        {
            _logger = logger;
            _sesService = sesService;
            _secrets = configuration.GetSection("Secrets");
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
                var toEmail = _secrets["DestinationEmailAddress"]!;
                var subject = $"{form.FirstName} {form.LastName} has sent you a message!";
                var emailSent = await _sesService.SendEmailAsync(form.EmailAddress, toEmail, subject, form.Message);

                if (emailSent)
                {
                    var message = new SuccessModel
                    {
                        Message = "Your message was sent successfully! I will get back to you as soon as I can."
                    };
                    
                    return View("Success", message);
                }
                else
                {
                    var message = new ErrorViewModel
                    {
                        Description = "There was an error sending your message. Please try again later."
                    };
                    
                    return View("Error", message);
                }
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
