using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HrmsWeb.Models
{
    public class EmployeeModel
    {
       
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public int DepartmentId { set; get; }
        public Nullable<DateTime> DOB { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<DateTime> DOL { get; set; }
        public string DepartmentName { get; set; }


        //Dashboard
      
        public int EmployeeCount { get; set; }

    }
    
}