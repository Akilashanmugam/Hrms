using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class InvoiceManagedServiceModel
    {
        public int InvoiceManagedServiceItemId { get; set; }
        public int InvoiceManagedServiceId { get; set; }
        public int ProjectId { get; set; }
        public int InvoiceId { get; set; }
        public int PoId { get; set; }
        public string PoCode { get; set; }
        public Nullable<DateTime> PoDate { get; set; }
        public int PoName { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<DateTime> AssignmentStartDate { get; set; }
        public Nullable<DateTime> AssignmentEndDate { get; set; }
        public int PoRateType { get; set; }
        public decimal PoRate { get; set; }
        public int BillableDays { get; set; }
        public decimal BillableHours { get; set; }
        public int CurrencyId { get; set; }
        public int CurrencyId3 { get; set; }
        public int InvoiceId3 { get; set; }
        public int ProjectId3 { get; set; }
        public int EmployeeId3 { get; set; }
        public int PoEmployeeId { get; set; }
        public decimal BillableAmount { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
        public string CurrencyName { get; set; }
        public string RateType { get; set; }
        public int PoRateTypeId { get; set; }
        public string PoRateTypeName { get; set; }
    }
    
}