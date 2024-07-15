using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class LeaveAllotmentController : Controller

    {
        readonly LeaveSetUpDBHandle cmodel = new LeaveSetUpDBHandle();
       
        // GET: LeaveAllotment from client 
        public ActionResult Index()
        {
            var client = cmodel.List();
            ViewBag.ClientList = client;

            return View();
        }

        public JsonResult List()
        {

            var la = cmodel.List();
            return Json(la, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult LeaveAllotmentList(int id)
        //{
        //    var leaveallotments = cmodel.LeaveAllotmentList123(id);
        //    return Json(leaveallotments, JsonRequestBehavior.AllowGet);
        //}

    }
}
