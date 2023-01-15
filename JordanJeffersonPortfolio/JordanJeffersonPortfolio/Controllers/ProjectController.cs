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
            string fileName = "setup.exe";
            Process.Start("../JordanJeffersonPortfolio/WPFApps/EmployeeManagementSimulator/" + fileName);
            return RedirectToAction("Projects", "Home");
        }
    }
}
