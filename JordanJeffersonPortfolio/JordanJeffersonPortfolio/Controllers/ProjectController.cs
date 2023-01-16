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
            string token = "sl.BXAEdcomvgzG6vQR12yBb1a75XZgXvwcM7A03d09dhmDr7G7Km6p8KOkhmLVomkfRBL7hZ2gLjwwxbcGVT2IikisbnQfwLkJ-8wa_-jrwhCuQaYFah5KkvDA9YTWU6B_pRaX7h5a";
            using (var dbx = new DropboxClient(token))
            {
                string folder = "";
                string file = "PigLatinTranslator.zip";
                Console.WriteLine("Folders");

                var list = await dbx.Files.ListFolderAsync(string.Empty);
                foreach (var item in list.Entries.Where(i => i.IsFolder))
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Files");

                foreach (var item in list.Entries.Where(i => i.IsFile))
                {
                    Console.WriteLine(item.Name, item.AsFile.Size);
                }

                using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    var d = s.Result;
                    System.IO.File.WriteAllBytes(file, d);
                }
            }
        }
    }
}
