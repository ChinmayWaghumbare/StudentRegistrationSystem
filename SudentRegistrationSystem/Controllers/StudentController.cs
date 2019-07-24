using SudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentRegistrationSyastemEntities db = new StudentRegistrationSyastemEntities();
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
            if (ModelState.IsValid)
            {
                List<Project> prjct = new List<Project>();
                prjct.AddRange(obj.Projects);
                obj.Projects = new List<Project>();

                db.Entry(obj).State = EntityState.Added;

                int id = db.SaveChanges();
                foreach(Project p in prjct)
                {
                    p.StudId = id;
                    db.Entry(p).State = EntityState.Added;
                    db.SaveChanges();
                }
                

            }
            return View();
        }
    }
}