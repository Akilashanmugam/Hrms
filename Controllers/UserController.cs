using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrmsWeb.Models;

namespace HrmsWeb.Controllers
{
    public class UserController : Controller
    {
        UserDBHandle umodel = new UserDBHandle();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(umodel.List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(UserModel userObj)
        {
            return Json(umodel.Add(userObj), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int Id)
        {
            var user = umodel.List().Find(x => x.UserId.Equals(Id));
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(UserModel user)
        {
            return Json(umodel.Update(user), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int Id)
        {
            return Json(umodel.Delete(Id), JsonRequestBehavior.AllowGet);
        }

    }
}