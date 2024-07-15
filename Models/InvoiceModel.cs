using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string PrInvoiceNo { get; set; }
        public Nullable<DateTime> BillingMonth { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int InvoiceType { get; set; }
        public int LocationId { get; set; }
        public string Remarks { get; set; }
        public string KindAttn { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public Nullable<DateTime> SubmitDate { get; set; }
        public Nullable<DateTime> ApproveDate { get; set; }
        public int ShippingAddress { get; set; }
        public int BillingAddress { get; set; }
        public int StatusId { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }


        public string StatusName { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string LocationName { get; set; }
        public string BillingAddressName { get; set; }
        public string ShippingAddressName { get; set; }
        public string PoTypeName { get; set; }

        public int EmployeeId3 { get; set; }
        public int PlacementCalculationTypeId { get; set; }
        public int CurrencyId3 { get; set; }
        public int CurrencyId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId3 { get; set; }
        public int PoRateType { get; set; }
        public int SrClientId { get; set; }
        public int SrProjectId { get; set; }
        public int SrInvoiceType { get; set; }
        public int SrLocationId { get; set; }

    }
}