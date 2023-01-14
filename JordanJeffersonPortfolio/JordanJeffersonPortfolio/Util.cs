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
    }
}
