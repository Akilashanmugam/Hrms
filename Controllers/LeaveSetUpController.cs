using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class LeaveSetUpController : Controller
    {
       
        readonly LeaveSetUpDBHandle cmodel = new LeaveSetUpDBHandle();
        public IEnumerable Leaves { get; private set; }
        public IEnumerable ClientList { get; private set; }
        public ActionResult Index()
        {
            var client = cmodel.List();
            ViewBag.ClientList = client;
            //Leaveoptions dropdown Table data;
            var Leaves = cmodel.Leaves();
            ViewBag.leaves = Leaves;
           
            return View();
            
        }
       
        public JsonResult List()
        {

            var lsu = cmodel.List();
            return Json(lsu, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult LeaveSetUpDetailList(int id)
        {

            var lSUD = cmodel.LeaveSetUpDetailList(id) ;
            return Json(lSUD, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Add(LeaveSetUpModel Leave)
        {
            return Json(cmodel.Add(Leave), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(cmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyID(int ID)
        {
            var LeaveSetUp = cmodel.getbyID(ID).Find(x => x.LeaveTypeDetailId.Equals(ID));
            return Json(LeaveSetUp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(LeaveSetUpModel Leave)
        {
            return Json(cmodel.Update(Leave), JsonRequestBehavior.AllowGet);
        }

        
    }
}
