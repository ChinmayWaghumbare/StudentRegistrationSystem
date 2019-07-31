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
        public ActionResult Index(string Name)
        {
            Student stud = new Student();
            if (Name != null)
            {
                stud = db.Students.Include("Projects").Where(s => s.Name == Name).Select(s => s).FirstOrDefault();
            }

            return View(stud);
        }
        [HttpPost]
        public ActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                List<Project> prjct = new List<Project>();
                if (obj.ID == 0)
                {
                    
                    prjct.AddRange(obj.Projects);
                    obj.Projects = new List<Project>();

                    db.Entry(obj).State = EntityState.Added;

                    db.SaveChanges();
                    int id = obj.ID;
                    foreach (Project p in prjct)
                    {
                        p.StudId = id;
                        db.Entry(p).State = EntityState.Added;
                        db.SaveChanges();
                    }
                }
                else
                {
                    List<Project> prjctsInDB = db.Projects.Where(s=>s.StudId==obj.ID).Select(s => s).ToList();
                    db.Projects.RemoveRange(prjctsInDB);
                    db.SaveChanges();
                    int id = obj.ID;

                    prjct.AddRange(obj.Projects);
                    foreach (Project p in prjct)
                    {
                        p.StudId = id;
                        db.Entry(p).State = EntityState.Added;
                        db.SaveChanges();
                    }
                }
            }
            return Json(new { Name = obj.Name });
        }

        public ActionResult Edit(string Name)
        {
            Student stud = new Student();
            if (Name != null)
            {
                stud = db.Students.Include("Projects").Where(s => s.Name == Name).Select(s => s).FirstOrDefault();
            }

            return View("Index",stud);
        }

        public ActionResult List()
        {
            List<Student> studList = new List<Student>();
            studList = db.Students.ToList();
            return View(studList);
        }
    }
}