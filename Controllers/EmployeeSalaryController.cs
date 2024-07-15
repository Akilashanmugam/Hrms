using HrmsWeb.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Collections;

namespace HrmsWeb.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        readonly EmployeeSalaryDBHandle Emodel = new EmployeeSalaryDBHandle();
        public IEnumerable emp { get; private set; }
        
        public IEnumerable stacklist { get; private set; }

        private string sql1;

        public IEnumerable gender { get; private set; }
        public IEnumerable designation { get; private set; }
        public IEnumerable department { get; private set; }
        public IEnumerable religion { get; private set; }
        public IEnumerable nationality { get; private set; }
        public IEnumerable Client { get; private set; }

        // GET: EmployeeSalary

        public ActionResult Index()
        {
            var emp = Emodel.Employee();
            ViewBag.employee = emp;
           
            var stacklist = Emodel.StackList();
            ViewBag.stacklist = stacklist;
           
            sql1 = "Select * from QryGender";
            gender = Emodel.LookUpDetailList(sql1);
            ViewBag.gender = gender;

            sql1 = "Select * from QryClientLookUpDetail";
            Client = Emodel.LookUpDetailList(sql1);
            ViewBag.client = Client;

            sql1 = "Select * from QryDesignation";
            designation = Emodel.LookUpDetailList(sql1);
            ViewBag.designation = designation;

            sql1 = "Select * from QryDepartment";
            department = Emodel.LookUpDetailList(sql1);
            ViewBag.department = department;

            sql1 = "Select * from QryReligion";
            religion = Emodel.LookUpDetailList(sql1);
            ViewBag.religion = religion;

            sql1 = "Select * from QryNationality";
            nationality = Emodel.LookUpDetailList(sql1);
            ViewBag.nationality = nationality;

           

            return View();

        }

        public JsonResult List(EmployeeSalaryModel list)
        {
            var ES = Emodel.List(list);
            return Json(ES, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(EmployeeSalaryModel ESAdd)
        {
            return Json(Emodel.Add(ESAdd), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var EmpS = Emodel.ListGetById(Id).Find(x => x.EmployeeSalaryId.Equals(Id));
            return Json(EmpS, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(EmployeeSalaryModel empsalary)
        {
            return Json(Emodel.Update(empsalary), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(Emodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}
