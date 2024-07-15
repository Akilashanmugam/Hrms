using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HrmsWeb.Controllers
{
    public class POManagementController : Controller
    {
        readonly POManagementDBHandle pommodel = new POManagementDBHandle();
        readonly POManagementDBHandle ppemodel = new POManagementDBHandle();
        readonly POManagementDBHandle Mmodel = new POManagementDBHandle();
        readonly POManagementDBHandle POMDB = new POManagementDBHandle();
        private string sql1;
        public IEnumerable client { get; private set; }
        public IEnumerable shippingaddress { get; private set; }
        public IEnumerable project { get; private set; }
        public IEnumerable clientpono { get; private set; }
        public IEnumerable potype { get; private set; }
        public IEnumerable billingaddress { get; private set; }
        public IEnumerable currency { get; private set; }
        public IEnumerable tax { get; private set; }
        public IEnumerable ratecard { get; private set; }
        public IEnumerable status { get; private set; }

        public ActionResult Index()
        {
            var potype = pommodel.POType();
            ViewBag.potype = potype;

            var client = pommodel.Client();
            ViewBag.client = client;

            sql1 = "Select * from QryCurrency";
            currency = pommodel.LookUpDetailList(sql1);
            ViewBag.currency = currency;

            var billing = pommodel.BillingAddress();
            ViewBag.billingaddress = billing;

            var shipping = pommodel.ShippingAddress();
            ViewBag.shippingaddress = shipping;

            var project = pommodel.Project();
            ViewBag.project = project;
            //------PO Managed Services dropdowns-------------//

            var ratecard = POMDB.RateCard();
            ViewBag.ratecard = ratecard;

            //------pommodel placement calculation  dropdowns-------------//

            var vendor = ppemodel.Vendor();
            ViewBag.vendor = vendor;

            var tax = ppemodel.Taxable();
            ViewBag.tax = tax;

            var employee = ppemodel.Employee();
            ViewBag.employee = employee;

            var PlacementCalculation = ppemodel.PlacementCalculation();
            ViewBag.placementCalculation = PlacementCalculation;

            var status = ppemodel.Status();
            ViewBag.status = status;

            return View();

        }
        public JsonResult List(POManagementModel list)
        {
            var pom = pommodel.List(list);
            return Json(pom, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(POManagementModel pom)
        {
            return Json(pommodel.Add(pom), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var pom = pommodel.ListGetById(Id).Find(x => x.PoId.Equals(Id));
            return Json(pom, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(POManagementModel pom)
        {
            return Json(pommodel.Update(pom), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id, int PoTypeId)
        {
            bool success = pommodel.Delete(Id, PoTypeId);
            return Json(success, JsonRequestBehavior.AllowGet);
        }


        //-----------------PO Placement Employee------------------------//
        public JsonResult POPEList(int id)
        {
            var ppoe = ppemodel.POPEList(id);
            return Json(ppoe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPOPE(POManagementModel ppoe)
        {
            return Json(ppemodel.AddPOPE(ppoe), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyIDPOPE(int id)
        {
            var pope = ppemodel.POPEEdit(id).Find(x => x.PEId.Equals(id));
            return Json(pope, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdatePOPE(POManagementModel pope)
        {
            return Json(ppemodel.UpdatePOPE(pope), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePOPE(int Id)
        {
            return Json(ppemodel.DeletePOPE(Id), JsonRequestBehavior.AllowGet);
        }

        //--------------PO Milestone---------------------//
        public JsonResult MilestoneList(int id)
        {
            var milestone = Mmodel.MilestoneList(id);
            return Json(milestone, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddMilestone(MilestoneModel milestone)
        {
            return Json(Mmodel.AddMilestone(milestone), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyIDMilestone(int id)
        {
            var milestone = Mmodel.MilestoneEdit(id).Find(x => x.MilestoneId.Equals(id));
            return Json(milestone, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateMilestone(MilestoneModel milestone)
        {
            return Json(Mmodel.UpdateMilestone(milestone), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteMilestone(int Id)
        {
            return Json(Mmodel.DeleteMilestone(Id), JsonRequestBehavior.AllowGet);
        }

        //--------------EMployeeMAster---------------------//
        public JsonResult GetActiveEmployeesList()
        {
            var Empmt = POMDB.GetActiveEmployeesList();
            return Json(Empmt, JsonRequestBehavior.AllowGet);
        }
      
        //--------------PO Managed Services---------------------//
        public JsonResult POManagedList(int id)
        {
            var managed = POMDB.POManagedList(id);
            return Json(managed, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddPOManaged(POManagedServiceModel pomanaged)
        {
            return Json(POMDB.AddPOManaged(pomanaged), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyIDPOManaged(int id)
        {
            var managed = POMDB.POManagedEdit(id).Find(x => x.PoEmployeeId.Equals(id));
            return Json(managed, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdatePOManaged(POManagedServiceModel Managed)
        {
            return Json(POMDB.UpdatePOManaged(Managed), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletePOManaged(int Id)
        {
            return Json(POMDB.DeletePOManaged(Id), JsonRequestBehavior.AllowGet);
        }
    }
}