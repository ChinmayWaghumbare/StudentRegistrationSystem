using SudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Project> projects = new List<Project>();
            projects.Add(new Project { PrjctName = "1", TeamSize = 1, Description = "1" });
            ViewData["Projects"] = projects;

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student obj)
        {
            return View();
        }
    }
}