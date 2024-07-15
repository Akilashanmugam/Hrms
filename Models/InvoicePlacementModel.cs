using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class InvoicePlacementModel
    {
        public int InvoicePlacementItemId { get; set; }
        public int InvoicePlacementId { get; set; }
        public int PoId { get; set; }
        public string PoCode { get; set; }
        public Nullable<DateTime> PoDate { get; set; }
        public int PEId { get; set; }
        public int EmployeeId { get; set; }
        public string Skills { get; set; }
        public decimal MonthlyCTC { get; set; }
        public int PlacementCalculationTypeId { get; set; }
        public decimal CalculationValue { get; set; }
        public decimal BillingAmount { get; set; }
        public int CurrencyId { get; set; }
        public int InvoiceId { get; set; }

        public string EmployeeName { get; set; }
        public string PlacementCalculationType { get; set; }
        public string CurrencyName { get; set; }



    }
}