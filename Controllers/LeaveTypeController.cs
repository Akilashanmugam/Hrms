using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;

namespace HrmsWeb.Controllers
{
    public class LeaveTypeController : Controller
    {
        LeaveTypeDBHandle lmodel = new LeaveTypeDBHandle();
        // GET: LeaveType
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(lmodel.List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(LeaveTypeModel leavetype)
        {
            return Json(lmodel.Add(leavetype), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var leave = lmodel.List().Find(x => x.LeaveTypeId.Equals(Id));
            return Json(leave, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(LeaveTypeModel leavetype)
        {
            return Json(lmodel.Update(leavetype), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(lmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}