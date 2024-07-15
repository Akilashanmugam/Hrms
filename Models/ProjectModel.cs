using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ProjectStartDate { get; set; }
        public Nullable<DateTime> ProjectEndDate { get; set; }

        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectManagerId { get; set; }
       
        public int BillingCurrencyId { get; set; }
        public int MasterStatusId { get; set; }
        public string Comments { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }       
        public string EmployeeName { get; set; }
        public string CurrencyName { get; set; }
        public string StatusName { get; set; }
        public string ProjectTypeName { get; set; }

    }
}

