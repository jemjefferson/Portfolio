using ICSharpCode.SharpZipLib.Zip;
using JordanJeffersonPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace JordanJeffersonPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
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
            ProjectViewModel vm = new ProjectViewModel();
            vm.WebApps = Util.GetWebApps();
            vm.ConsoleApps = Util.GetConsoleApps();
            vm.WPFApps = Util.GetWPFApps();
            return View(vm);
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

        [HttpPost("contact")]
        public ActionResult Contact(Models.Email email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            if (!ModelState.IsValid)
            {
                return View();
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
                ViewBag.Error = "Please enter a valid email address.";
                return View();
            }

            return RedirectToAction(nameof(ContactSuccess));
        }

        public IActionResult ContactSuccess()
        {
            return View();
        }

        public void RunPigLatin()
        {
            

            //var webRoot = _webHostEnvironment;
            //var fileName = "PigLatinTranslator.zip";
            //var tempOutput = webRoot + fileName;

            //using (ZipOutputStream zipOutputStream = new ZipOutputStream(System.IO.File.Create(tempOutput)))
            //{
            //    zipOutputStream.SetLevel(9);
            //    byte[] buffer = new byte[4096];
            //    var fileList = new List<string>();
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/PigLatinTranslator.deps.json");
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/PigLatinTranslator.dll");
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/PigLatinTranslator.exe");
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/PigLatinTranslator.pdb");
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/PigLatinTranslator.runtimeconfig.json");
            //    fileList.Add("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/Settings.job");

            //    for (int i = 0; i < fileList.Count; i++)
            //    {
            //        ZipEntry zipEntry = new ZipEntry(Path.GetFileName(fileList[i]));
            //        zipEntry.DateTime = DateTime.Now;
            //        zipEntry.IsUnicodeText = true;
            //        zipOutputStream.PutNextEntry(zipEntry);

            //        using (FileStream fileSteam = System.IO.File.OpenRead(fileList[i]))
            //        {
            //            int sourceBytes;
            //            do
            //            {
            //                sourceBytes = fileSteam.Read(buffer, 0, buffer.Length);
            //                zipOutputStream.Write(buffer, 0, sourceBytes);
            //            } while (sourceBytes > 0);
            //        }
            //    }

            //    zipOutputStream.Finish();
            //    zipOutputStream.Flush();
            //    zipOutputStream.Close();

            //byte[] finalResult = System.IO.File.ReadAllBytes(tempOutput);
            //    if (System.IO.File.Exists(tempOutput))
            //    {
            //        System.IO.File.Delete(tempOutput);
            //    }

            //    if (finalResult == null || finalResult.Any())
            //    {
            //        throw new Exception(String.Format("Nothing Found"));
            //    }

            //return File(finalResult, "application/zip", fileName);
            //}
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}