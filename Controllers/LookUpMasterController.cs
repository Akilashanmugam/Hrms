using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;

namespace HrmsWeb.Controllers
{
    public class LookUpMasterController : Controller
    {
        dynamic mymodel = new System.Dynamic.ExpandoObject();
        
        LookUpMasterDBHandle dataDB = new LookUpMasterDBHandle();
        //LookUpDetailDBHandle dataDB1 = new LookUpDetailDBHandle();
        // GET: LookUpMaster
        public ActionResult Index()
        {
            var lum = dataDB.List();
            ViewBag.lookupMaster = lum;

            return View();
        }
        //Get LookUpmaster Items List
        public JsonResult List()
        {
          
            var lum = dataDB.List();
            return Json(lum, JsonRequestBehavior.AllowGet);
        }
        //Get LookUpDetailsItemList
         public JsonResult LookupDetailListAll()
        {

            var ld = dataDB.LookUpDetailListAll();
            return Json(ld, JsonRequestBehavior.AllowGet);

        }
        public JsonResult LookupDetailList(int ID)
        {

            var ld = dataDB.LookUpDetailList(ID);
            return Json(ld, JsonRequestBehavior.AllowGet);

        }
        //Add new lookup item details
        public JsonResult Add(LookUpDetailModel lud)

        {

            return Json(dataDB.Add(lud), JsonRequestBehavior.AllowGet);

        }

        //Get LookUpItem for Edit
        public JsonResult Edit(int id)
        {

            var ld = dataDB.LookUpDetailListAll().Find(x => x.LookUpDetailId.Equals(id));
            return Json(ld, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Update(LookUpDetailModel luObj)
        {

            return Json(dataDB.Update(luObj), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {

            return Json(dataDB.Delete(id), JsonRequestBehavior.AllowGet);
        }

        

    }
}