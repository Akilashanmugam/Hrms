using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class InvoiceMilestoneModel
    {
        public int MilestoneId { get; set; }
        public int InvoiceId { get; set; }
        public int PoId { get; set; }
        public string PoCode { get; set; }
        public string PoName { get; set; }
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal PoQuantity { get; set; }
        public decimal InvoiceQuantity { get; set; }
        public decimal BalanceQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal PoValue { get; set; }
        public decimal Amount { get; set; }
        public decimal Amount1 { get; set; }
        public int InvoiceMilestoneItemId { get; set; }

    }
}