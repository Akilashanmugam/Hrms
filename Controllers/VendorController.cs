using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class VendorController : Controller
    {
        readonly VendorDBHandle vmodel = new VendorDBHandle();
       
        public IEnumerable vendor { get; private set; }

        public IEnumerable client { get; private set; }

        public ActionResult Index()
        {
            var client = vmodel.Client();
            ViewBag.client = client;

            var vendor = vmodel.Vendor();
            ViewBag.vendor = vendor;

            return View();

        }
        public JsonResult List()
        {
            var vendor = vmodel.List();

            return Json(vendor, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(VendorModel vendor)
        {
            return Json(vmodel.Add(vendor), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var vendor = vmodel.List().Find(x => x.VendorId.Equals(Id));
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(VendorModel vendor)
        {
            return Json(vmodel.Update(vendor), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(vmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}