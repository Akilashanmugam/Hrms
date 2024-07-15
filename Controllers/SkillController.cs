using HrmsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrmsWeb.Controllers
{
    public class SkillController : Controller
    {
        SkillDBHandle dataDB = new SkillDBHandle();

        // GET: Skill
        public ActionResult Index()
        {
            return View();
        }

        // GET: Skill/List
        public JsonResult List()
        {
            var Skills = dataDB.List();
            return Json(Skills, JsonRequestBehavior.AllowGet);
        }

        // GET: Skill/Create
        public JsonResult Add(SkillModel skl)
        {
            
            return Json(dataDB.Add(skl), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int Id)
        {
            var skill = dataDB.List().Find(x => x.SkillId.Equals(Id));
            return Json(skill, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(SkillModel skill)
        {
            return Json(dataDB.Update(skill), JsonRequestBehavior.AllowGet);
        }


     
        public JsonResult Delete(int Id)
        {
            return Json(dataDB.Delete(Id), JsonRequestBehavior.AllowGet);
        }

       





    }
}
