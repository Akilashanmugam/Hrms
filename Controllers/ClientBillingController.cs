using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class ClientBillingController : Controller
    {
        readonly ClientBillingDBHandle CBDB = new ClientBillingDBHandle();
        private string sql1;
        public IEnumerable client { get; private set; }
        public IEnumerable project { get; private set; }
        public IEnumerable location { get; private set; }


        public ActionResult Index()
        {
            var client = CBDB.Client();
            ViewBag.client = client;

            var project = CBDB.Project();
            ViewBag.project = project;

            sql1 = "Select * from QryLocation";
            location = CBDB.LookUpDetailList(sql1);
            ViewBag.location = location;

            return View();

        }

        public JsonResult List(ClientBillingModel filter)
        {
            var data = CBDB.List(filter);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjectsByClientId(int clientId)
        {
            var projects = CBDB.GetProjectsByClientId(clientId);
            return Json(projects, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult Add(ClientBillingModel clientbilling)
        {
            return Json(CBDB.Add(clientbilling), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var pom = CBDB.ListGetById(Id).Find(x => x.CBId.Equals(Id));
            return Json(pom, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ClientBillingModel clientbilling)
        {
            return Json(CBDB.Update(clientbilling), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(CBDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }

      
    }
}