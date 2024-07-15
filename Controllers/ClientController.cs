using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;


namespace HrmsWeb.Controllers
{
    public class ClientController : Controller
    {
        ClientDBHandle cmodel = new ClientDBHandle();
        readonly ClientSetUpDBHandle csuDB = new ClientSetUpDBHandle();
        private string sql1;
        public IEnumerable location { get; private set; }
        public IEnumerable client { get; private set; }
        public IEnumerable project { get; private set; }
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


      
        public JsonResult List()
        {
            var clients = cmodel.List();
                
            return Json(clients, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ClientModel client)
        {
            return Json(cmodel.Add(client), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int Id)
        {
            var Client = cmodel.List().Find(x => x.ClientId.Equals(Id));
            return Json(Client, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ClientModel client)
        {
            return Json(cmodel.Update(client), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(cmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ContactList(int id)
        {
            ModelState.Clear();
            var clients = cmodel.ContactList(id);

            return Json(clients, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ContactAdd(ClientContactModel client)
        {
            return Json(cmodel.ContactAdd(client), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ContactUpdate(ClientContactModel client)
        {
          
            var clients = cmodel.ContactUpdate(client);

            return Json(clients, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ContactGetById(int id)
        {

            var contacteditlist = cmodel.ContactEditList(id).Find(x => x.ContactId.Equals(id)); 
            return Json(contacteditlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ContactDelete(int Id)
        {
            return Json(cmodel.ContactDelete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}