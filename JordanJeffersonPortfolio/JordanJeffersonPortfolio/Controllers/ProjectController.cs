using Dropbox.Api;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JordanJeffersonPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RunPigLatin()
        {
            string fileName = "PigLatinTranslator.exe";
            Process.Start("../JordanJeffersonPortfolio/ConsoleApps/PigLatinTranslator/" + fileName);
            return RedirectToAction("Projects", "Home");
        }

        public IActionResult InstallEM()
        {
            string path = Path.GetDirectoryName(@"../wwwroot/WPFApps/EmployeeManagementSimulator/setup.exe");
            string fileName = "setup.exe";
            Process.Start(path);
            //Process.Start("../WPFApps/EmployeeManagementSimulator/" + fileName);
            return RedirectToAction("Projects", "Home");
        }

        public async Task DownloadPig()
        {
            var dbx2 = new DropboxClient("sl.BXCoVar9kC5Dq4nzFc0BxwwBWrumpJWZGGSdl44AuwS1griyLRDKBKczxTRRx56DaIcsamkyuW8UL17au56-7y4hWsXYeUgp8zRcuAJNYxrIqIMv8su6VE3myilHIjwEkm3XSwCn");
            using (var dbx = new DropboxClient("sl.BXCoVar9kC5Dq4nzFc0BxwwBWrumpJWZGGSdl44AuwS1griyLRDKBKczxTRRx56DaIcsamkyuW8UL17au56-7y4hWsXYeUgp8zRcuAJNYxrIqIMv8su6VE3myilHIjwEkm3XSwCn"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
            string folder = "/Apps/JordanJeffersonPortfolio/PigLatinTranslator";
            string file = "PigLatinTranslator.zip";
            using (var response = await dbx2.Files.DownloadAsync(folder + "/" + file))
            {
                var s = response.GetContentAsByteArrayAsync();
                s.Wait();
                var d = s.Result;
                System.IO.File.WriteAllBytes(file, d);
                Console.WriteLine("Im working.");
            }
        }
    }
}
