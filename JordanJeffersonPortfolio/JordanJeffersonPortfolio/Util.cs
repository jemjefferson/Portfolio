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
            p.Description = "Translate from English to Pig Latin.";
            p.Action = "RunPigLatin";
            projects.Add(p);

            return projects;
        }

        public static List<Project> GetWPFApps()
        {
            List<Project> projects = new List<Project>();
            Project p = new Project();
            p.Name = "Employee Management Simulator";
            p.Image = "../images/em.png";
            p.Description = "Create, manage, and notify employees.";
            p.Action = "InstallEM";
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
