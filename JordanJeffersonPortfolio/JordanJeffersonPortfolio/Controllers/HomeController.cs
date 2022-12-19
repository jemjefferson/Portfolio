using FluentEmail.Core;
using FluentEmail.Smtp;
using JordanJeffersonPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace JordanJeffersonPortfolio.Controllers
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

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("projects")]
        public IActionResult Projects()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            Models.Email model = new Models.Email();
            return View(model);
        }

        public ActionResult DownloadEmpSim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(Models.Email email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Contact));
            }

            try
            {
                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(email.UserEmail),
                    Subject = email.Subject,
                    Body = $"Email: {email.UserEmail}\nSubject: {email.Subject}\nMessage: {email.Message}"
                };

                SmtpClient smtpClient = new SmtpClient()
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("jemjefferson@gmail.com", "zrghocxybkounkny"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                message.To.Add("jemjefferson@gmail.com");
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Contact));
            }

            return RedirectToAction(nameof(Contact));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}