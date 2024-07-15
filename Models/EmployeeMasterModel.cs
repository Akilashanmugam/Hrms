using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class EmployeeMasterModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string ClientName { get; set; }
        public Nullable<DateTime> DOJ { get; set; }

        public Nullable<DateTime> DOL { get; set; }

        public string ProjectName { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }
      
    }
}