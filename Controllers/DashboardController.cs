using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrmsWeb.Controllers
{
    public class DashboardController : Controller
    {
        readonly DashboardDBHandle DDB = new DashboardDBHandle();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


      
        public JsonResult GetEmployeeData()
        {
            var employees = DDB.GetEmployeeData();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetClientDataCombine()
        {
            var clients = DDB.GetCombinedClientData();
            return Json(clients, JsonRequestBehavior.AllowGet);
        }

        public JsonResult List()
        {
            var list = DDB.List();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}