using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Diagnostics;

namespace HrmsWeb.Controllers
{
    public class InvoiceController : Controller
    {
        readonly InvoiceDBHandle IDB = new InvoiceDBHandle();
        readonly POManagementDBHandle IMDB = new POManagementDBHandle();
        private string sql1;
        public IEnumerable client { get; private set; }
        public IEnumerable billingaddress { get; private set; }
        public IEnumerable shippingaddress { get; private set; }
        public IEnumerable project { get; private set; }
        public IEnumerable status { get; private set; }
        public IEnumerable location { get; private set; }
        public IEnumerable potype { get; private set; }
        public IEnumerable currency { get; private set; }
        public IEnumerable placementCalculation { get; private set; }
        public IEnumerable employee { get; private set; }
        public IEnumerable poratetype { get; private set; }
        public ActionResult Index()
        {
            var client = IDB.Client();
            ViewBag.client = client;

            var billing = IDB.billingAddress();
            ViewBag.billingaddress = billing;

            var shipping = IDB.shippingAddress();
            ViewBag.shippingaddress = shipping;

            var project = IDB.Project();
            ViewBag.project = project;

            var status = IDB.Status();
            ViewBag.status = status;

            var potype = IDB.POType();
            ViewBag.potype = potype;

            sql1 = "Select * from QryLocation";
            location = IDB.LookUpDetailList(sql1);
            ViewBag.location = location;

            sql1 = "Select * from QryCurrency";
            currency = IDB.LookUpDetailList(sql1);
            ViewBag.currency = currency;

            var PlacementCalculation = IDB.PlacementCalculation();
            ViewBag.placementCalculation = PlacementCalculation;

            var employee = IDB.Employee();
            ViewBag.employee = employee;

            var poratetype = IDB.PoRateType();
            ViewBag.poratetype = poratetype;

            return View();

        }
        public JsonResult List(InvoiceModel list)
        {
            var pom = IDB.List(list);
            return Json(pom, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(InvoiceModel invoice)
        {
            return Json(IDB.Add(invoice), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var invoice = IDB.ListGetById(Id).Find(x => x.InvoiceId.Equals(Id));
            return Json(invoice, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(InvoiceModel invoice)
        {
            return Json(IDB.Update(invoice), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(IDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }


        //InvoiceMIlestone
        public JsonResult InvoiceMilestoneList()
        {
            var invoicelist = IDB.InvoiceMilestoneList();

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InvoiceMilestoneItemList(int id)
        {
            var invoicelist = IDB.InvoiceMilestoneItemList(id);

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddInvoiceMilestoneItems(List<InvoiceMilestoneModel> items)
        {
            try
            {
                if (items == null || items.Count == 0)
                {
                    return Json(new { success = false, message = "No invoice items provided." }, JsonRequestBehavior.AllowGet);
                }

                if (IDB == null)
                {
                    return Json(new { success = false, message = "Database handle (IDB) is null." }, JsonRequestBehavior.AllowGet);
                }

                foreach (var item in items)
                {
                    IDB.AddInvoiceMilestoneItem(item);
                }

                return Json(new { success = true, message = "Invoice items added successfully." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error adding invoice items:");
                Debug.WriteLine(ex.ToString());

                return Json(new { success = false, message = "An error occurred while adding invoice items." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteMilestoneItem(int Id)
        {
            return Json(IDB.DeleteMilestoneItem(Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getbyIDInvoiceMilestone(int id)
        {
            var milestone = IDB.InvoiceMilestoneEdit(id).Find(x => x.InvoiceMilestoneItemId.Equals(id));
            return Json(milestone, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateInvoiceMilestone(InvoiceMilestoneModel milestone)
        {
            return Json(IDB.UpdateInvoiceMilestone(milestone), JsonRequestBehavior.AllowGet);
        }
        //InvoicePlacement
        public JsonResult InvoicePlacementList()
        {
            var invoicelist = IDB.InvoicePlacementList();

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InvoicePlacementItemList(int id)
        {
            var invoicelist = IDB.InvoicePlacementItemList(id);

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddInvoicePlacementItems(List<InvoicePlacementModel> items)
        {
            try
            {
                if (items == null || items.Count == 0)
                {
                    return Json(new { success = false, message = "No invoice items provided." }, JsonRequestBehavior.AllowGet);
                }

                if (IDB == null)
                {
                    return Json(new { success = false, message = "Database handle (IDB) is null." }, JsonRequestBehavior.AllowGet);
                }

                foreach (var item in items)
                {
                    IDB.AddInvoicePlacementItem(item);
                }

                return Json(new { success = true, message = "Invoice items added successfully." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error adding invoice items:");
                Debug.WriteLine(ex.ToString());
                return Json(new { success = false, message = "An error occurred while adding invoice items: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getbyIDInvoicePlacement(int id)
        {
            var Placement = IDB.InvoicePlacementEdit(id).Find(x => x.InvoicePlacementItemId.Equals(id));
            return Json(Placement, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateInvoicePlacement(InvoicePlacementModel placement)
        {
            return Json(IDB.UpdateInvoicePlacement(placement), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePlacementItem(int Id)
        {
            return Json(IDB.DeletePlacementItem(Id), JsonRequestBehavior.AllowGet);
        }

        //InvoicemanagedService
        public JsonResult InvoiceManagedServiceList()
        {
            var invoicelist = IDB.InvoiceManagedServiceList();

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InvoiceManagedServiceItemList(int id)
        {
            var invoicelist = IDB.InvoiceManagedServiceItemList(id);

            return Json(invoicelist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddInvoiceManagedServiceItems(List<InvoiceManagedServiceModel> items)
        {
            try
            {
                if (items == null || items.Count == 0)
                {
                    return Json(new { success = false, message = "No invoice items provided." }, JsonRequestBehavior.AllowGet);
                }

                if (IDB == null)
                {
                    return Json(new { success = false, message = "Database handle (IDB) is null." }, JsonRequestBehavior.AllowGet);
                }

                foreach (var item in items)
                {
                    IDB.AddInvoiceManagedServiceItem(item);
                }

                return Json(new { success = true, message = "Invoice items added successfully." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error adding invoice items:");
                Debug.WriteLine(ex.ToString());

                return Json(new { success = false, message = "An error occurred while adding invoice items." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getbyIDInvoiceManagedService(int id)
        {
            var ManagedService = IDB.InvoiceManagedServiceEdit(id).Find(x => x.InvoiceManagedServiceItemId.Equals(id));
            return Json(ManagedService, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateInvoiceManagedService(InvoiceManagedServiceModel ManagedService)
        {
            return Json(IDB.UpdateInvoiceManagedService(ManagedService), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteManagedServiceItem(int Id)
        {
            return Json(IDB.DeleteManagedServiceItem(Id), JsonRequestBehavior.AllowGet);
        }





    }
}