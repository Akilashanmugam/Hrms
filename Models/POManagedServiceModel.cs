using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class POManagedServiceModel
    {
        public int PoEmployeeId { get; set; }
        public int PoId { get; set; }
        public int ClientId2 { get; set; }
        public int ProjectId2 { get; set; }
        public int EmployeeId2 { get; set; }
        public Nullable<DateTime> AssignmentStartDate { get; set; }
        public Nullable<DateTime> AssignmentEndDate { get; set; }
        public int RateCardId { get; set; }
        public int CurrencyId2 { get; set; }
        public decimal PoRate { get; set; }
        public string Remarks2 { get; set; }
        public int LastUpdatedBy { get; set; }
    
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string RateCardName { get; set; }
        public string CurrencyName { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }

    }

}