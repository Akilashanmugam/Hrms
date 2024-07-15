using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;


namespace HrmsWeb.Controllers
{
    public class EmployeeController : Controller
    {
        readonly EmployeeDBHandle dataDB = new EmployeeDBHandle();

        public IEnumerable Departments { get; private set; }



        // GET: Employee
        public ActionResult Index()
        {
          
            var departments = dataDB.DepartmentList();
            ViewBag.Departments = departments;

            return View();
        }

        public JsonResult List()
        {
            
            var employees = dataDB.List();
      


            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add( EmployeeModel emp)

        {
           
            return Json(dataDB.Add(emp), JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult getbyID(int id)
        {
           
            var emp = dataDB.List().Find(x => x.EmployeeId.Equals(id));
            return Json(emp, JsonRequestBehavior.AllowGet);
           
        }

        public JsonResult Update(EmployeeModel emp)
        {
          
            return Json(dataDB.Update(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            
            return Json(dataDB.Delete(id), JsonRequestBehavior.AllowGet);
        }

    }

   
}