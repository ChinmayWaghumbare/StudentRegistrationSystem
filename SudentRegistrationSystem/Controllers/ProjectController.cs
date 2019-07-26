
using SudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SudentRegistrationSystem.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(Project obj)
        {
            if (obj == null)
                obj = new Project();

            return PartialView("ProjectPartial",obj);
        }

        public ActionResult saveProject(Project prjobj)
        {
            //TryValidateModel(prjobj);
            if (!ModelState.IsValid)
            {
                var err = ModelState.Values.Where(data =>  data.Errors.Count > 0 ).SelectMany(E=>E.Errors).Select(M=>M.ErrorMessage);
                string error = string.Empty;
                foreach(string errMsg in err)
                {
                    error += errMsg;
                }
                return Json( new {error = error});
            }
            return Json(prjobj);
        }
    }
}