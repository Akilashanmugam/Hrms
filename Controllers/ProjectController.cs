using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class ProjectController : Controller
    {
        readonly ProjectDBHandle cmodel = new ProjectDBHandle();
        public IEnumerable Leaves { get; private set; }
        public IEnumerable client1 { get; private set; }
        public IEnumerable projectTID { get; private set; }
        public IEnumerable emp { get; private set; }
        public IEnumerable lookupDetail { get; private set; }
        public IEnumerable MLU { get; private set; }
        public ActionResult Index()
        {
            var Leaves = cmodel.Leaves();
            ViewBag.leaves = Leaves;

            var client1 = cmodel.client();
            ViewBag.client = client1;

            var project = cmodel.Project();
            ViewBag.projectTID = project;

            var emp = cmodel.Employee();
            ViewBag.Employee = emp;

            var lookupDetail = cmodel.Lookupdetail();
            ViewBag.lookupdetail = lookupDetail;

            var MLU = cmodel.MasterLook();
            ViewBag.masterlookup = MLU;
            return View();
         
        }
        public JsonResult List()
        {
            var project = cmodel.List();
            return Json(project, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ProjectModel project)
        {
            return Json(cmodel.Add(project), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var project = cmodel.List().Find(x => x.ProjectId.Equals(Id));
            return Json(project, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ProjectModel project)
        {
            return Json(cmodel.Update(project), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(cmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}
