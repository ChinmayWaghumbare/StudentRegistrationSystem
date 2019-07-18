using SudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudentRegistrationSystem.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            List<Project> projects = new List<Project>();
            projects.Add(new Project());
            ViewData["Projects"] = projects;
            return PartialView("ProjectPartial");
        }

        public void saveProject(Project prjobj)
        {
            //List<Project> projects = new List<Project>();
            //projects.AddRange((ViewData["Projects"]));
            //ViewData["Projects"] = null;
        }
    }
}