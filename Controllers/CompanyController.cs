using System.Web.Mvc;
using HrmsWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Hrmsweb.Models;

namespace HrmsWeb.Controllers
{
    public class CompanyController : Controller
    {
        readonly  CompanyDBHandle cmodel = new CompanyDBHandle();
        readonly CompanyDBHandle ccmodel = new CompanyDBHandle();
        ////private object db;

        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            var company = cmodel.List();
            return Json(company, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult Add(CompanyModel company)
        {
            return Json(cmodel.Add(company), JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetbyID(int Id)
        {
            var company = cmodel.List().Find(x => x.CompanyId.Equals(Id));
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CompanyModel company)
        {
            return Json(cmodel.Update(company), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(cmodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
        //................Company Contact...............
        public JsonResult CompanyContactList(int id)
        {
            var companyContact = ccmodel.CompanyContactList(id);
            return Json(companyContact, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddCompanyContact(CompanyContactModel Contact)
        {
            return Json(ccmodel.AddCompanyContact(Contact), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCompanyContact(int Id)
        {
            return Json(ccmodel.DeleteCompanyContact(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getbyIDCompanyContact(int id)
        {
            var companyContact = ccmodel.CompanyContactListEdit(id).Find(x => x.ContactId.Equals(id));
            return Json(companyContact, JsonRequestBehavior.AllowGet);
        }       
        public JsonResult UpdateCompanyContact(CompanyContactModel companyContact)
        {
            return Json(ccmodel.UpdateCompanyContact(companyContact), JsonRequestBehavior.AllowGet);
        }
    }


}



