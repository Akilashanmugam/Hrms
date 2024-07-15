using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class SkillModel
    {

        public int SkillId { get; set; }

        //[Display(Name = "SkillModel skillName ")]
        public string SkillName { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}