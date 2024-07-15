using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class ClientSetupController : Controller
    {
        readonly ClientSetUpDBHandle csuDB = new ClientSetUpDBHandle();
        private string sql1;
        public IEnumerable project { get; private set; }
        public IEnumerable location { get; private set; }

        public IEnumerable client { get; private set; }
        public ActionResult Index()
        {
            var project = csuDB.Project();
            ViewBag.project = project;

            var client = csuDB.Client();
            ViewBag.client = client;

            sql1 = "Select * from QryLocation";
            location = csuDB.LookUpDetailList(sql1);
            ViewBag.location = location;

            return View();
        }

        public JsonResult List(int id)
        {
            var clientSetup = csuDB.List(id);
            return Json(clientSetup, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MainTableList()
        {
            var clientSetup = csuDB.MainTableList();
            return Json(clientSetup, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MainTableAdd(ClientBillingModel clientsetup)
        {
            return Json(csuDB.Add(clientsetup), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ClientBillingModel clientsetup)
        {
            return Json(csuDB.Add(clientsetup), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var clientsetup = csuDB.ClientSetUpGetById(Id).Find(x => x.ClientSetUpId.Equals(Id));
            return Json(clientsetup, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult Update(ClientBillingModel clientsetup)
        {
            return Json(csuDB.Update(clientsetup), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(csuDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }


    }
}