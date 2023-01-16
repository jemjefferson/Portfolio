using Dropbox.Api;
using JordanJeffersonPortfolio.Models;

namespace JordanJeffersonPortfolio
{
    public static class Util
    {
        public static List<Project> GetWebApps()
        {
            List<Project> projects = new List<Project>();
            Project p = new Project();
            p.Name = "TimeWorks";
            p.Image = "../images/timeworks.png";
            p.Link = "https://timeworks.azurewebsites.net";
            p.Description = "Employee time tracking application.";
            p.FrameWork = "ASP.NET MVC";
            projects.Add(p);

            p = new Project();
            p.Name = "Path Finder";
            p.Image = "../images/pathfinder.png";
            p.Link = "https://pathfinderjefferson.netlify.app/";
            p.Description = "Find the shortest path.";
            p.FrameWork = "React";
            projects.Add(p);

            return projects;
        }

        public static List<Project> GetConsoleApps()
        {
            List<Project> projects = new List<Project>();
            Project p = new Project();
            p.Name = "Pig Latin Translator";
            p.Image = "../images/piglatintranslator.png";
            p.Link = "https://www.dropbox.com/s/kcg24z9fha27cyu/PigLatinTranslator.zip?dl=0";
            p.Description = "Translate from English to Pig Latin.";
            projects.Add(p);

            p = new Project();
            p.Name = "Jefferson Zoo (Console)";
            p.Image = "../images/jeffersonzooconsole.png";
            p.Link = "https://www.dropbox.com/s/otly25wgljfkoyj/JeffersonZooConsole.zip?dl=0";
            p.Description = "";
            projects.Add(p);

            return projects;
        }

        public static List<Project> GetWPFApps()
        {
            List<Project> projects = new List<Project>();
            Project p = new Project();
            p.Name = "Employee Management Simulator";
            p.Image = "../images/em.png";
            p.Link = "https://www.dropbox.com/s/8n829etxi9devl5/EmployeeManagementSimulator.zip?dl=0";
            p.Description = "Create, manage, and notify employees.";
            projects.Add(p);

            p = new Project();
            p.Name = "Jefferson Zoo (WPF)";
            p.Image = "../images/jeffersonzoowpf.png";
            p.Link = "https://www.dropbox.com/s/kfo08ck7s1vqcph/JeffersonZooWPF.zip?dl=0";
            p.Description = "";
            projects.Add(p);

            return projects;
        }

        public static async Task Run()
        {
            using (var dbx = new DropboxClient("sl.BW-vgIJczeHUHEDDWCqwThp40aFzycTfzspZ0PLMsEinCoyreOS0TEsMzz55ea006Azrg1qQX4xWudeN4548lDG0YjZZiUeI5fF15IYtDlrY5pifr3EI_moJ5Eo55TEgBz45jlI"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
        }
    }
}
