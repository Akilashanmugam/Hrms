using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class RateCardController : Controller
    {
        readonly RateCardDBHandle RCDB = new RateCardDBHandle();
        readonly RateCardDBHandle RCDDB = new RateCardDBHandle();
        private string sql1;

        public IEnumerable client { get; private set; }
        public IEnumerable project { get; private set; }
        public IEnumerable status { get; private set; }
        public IEnumerable ratecardtype { get; private set; }
        public IEnumerable location { get; private set; }
        public IEnumerable currency { get; private set; }
        public ActionResult Index()
        {
            sql1 = "Select * from QryLocation";
            location = RCDB.LookUpDetailList(sql1);
            ViewBag.location = location;

            sql1 = "Select * from QryCurrency";
            currency = RCDB.LookUpDetailList(sql1);
            ViewBag.currency = currency;

            var client = RCDB.Client();
            ViewBag.client = client;

            var project = RCDB.Project();
            ViewBag.project = project;

            var status = RCDB.Status();
            ViewBag.status = status;

            var ratecardtype = RCDB.RateCardType();
            ViewBag.ratecardtype = ratecardtype;

          
            return View();

        }
        public JsonResult List()
        {
            var list = RCDB.List();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(RateCardModel RC)
        {
            return Json(RCDB.Add(RC), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var RC = RCDB.List().Find(x => x.RateCardId.Equals(Id));
            return Json(RC, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(RateCardModel RC)
        {
            return Json(RCDB.Update(RC), JsonRequestBehavior.AllowGet);
        }

       //-------------------Delete validation----------------//
        public JsonResult DeleteMainTableData(int rateCardId)
        {
            bool result = RCDB.Delete(rateCardId);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckChildTableCount(int rateCardId)
        {
            int childCount = RCDB.CheckChildTableCount(rateCardId);
            return Json(new { childCount = childCount }, JsonRequestBehavior.AllowGet);
        }

        //----------------------RateCardDetail ----------------//
        public JsonResult RCDList(int id)
        {
            var RCD = RCDDB.RCDList(id);
            return Json(RCD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddRCD(RateCardModel RCD)
        {
            return Json(RCDDB.AddRCD(RCD), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyIDRCD(int id)
        {
            var RCD = RCDDB.getbyIDRCD(id).Find(x => x.RateCardDetailId.Equals(id));
            return Json(RCD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateRCD(RateCardModel RCD)
        {
            return Json(RCDDB.UpdateRCD(RCD), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteRCD(int Id)
        {
            return Json(RCDDB.DeleteRCD(Id), JsonRequestBehavior.AllowGet);
        }
    }
}