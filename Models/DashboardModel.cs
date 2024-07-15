using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class DashboardModel
    {
        public string ClientName { get; set; }
        public string ClientShortName { get; set; }

        public int ActiveEmployeeCount { get; set; }
        public int EmployeeId { get; set; }

        public int ClientId { get; set; }

        public int ProjectId { get; set; }

        public decimal Gross { get; set; }
        public decimal NetPay { get; set; }
        public int DesignationId { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public Nullable<DateTime> ClientDOJ { get; set; }
        public Nullable<DateTime> ClientDOL { get; set; }
    }
}