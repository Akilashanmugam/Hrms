using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class ClientAddressController : Controller
    {
        readonly ClientAddressDBHandle CAmodel = new ClientAddressDBHandle();
        public IEnumerable client { get; private set; }

        public IEnumerable addresstype { get; private set; }

        private string sql1;

        public IEnumerable city { get; private set; }
        public IEnumerable state { get; private set; }
        public IEnumerable country { get; private set; }


        
        public ActionResult Index()
        {
            sql1 = "Select * from QryCity";
            city = CAmodel.LookUpDetailList(sql1);
            ViewBag.city = city;

            sql1 = "Select * from QryState";
            state = CAmodel.LookUpDetailList(sql1);
            ViewBag.state = state;

            sql1 = "Select * from QryCountry";
            country = CAmodel.LookUpDetailList(sql1);
            ViewBag.country = country;

            var client = CAmodel.Client();
            ViewBag.client = client;


            sql1 = "Select * from QryAddressType";
            addresstype = CAmodel.LookUpDetailList(sql1);
            ViewBag.addresstype = addresstype;
            return View();

        }
        public JsonResult List()
        {
            var list = CAmodel.List();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ClientAddressModel CAddress)
        {
            return Json(CAmodel.Add(CAddress), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var CAddress = CAmodel.List().Find(x => x.AddressId.Equals(Id));
            return Json(CAddress, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ClientAddressModel caddress)
        {
            return Json(CAmodel.Update(caddress), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(CAmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}