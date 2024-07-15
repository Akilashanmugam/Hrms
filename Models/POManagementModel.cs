using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class POManagementModel
    {
        public int PoId { get; set; }
        public string PoCode { get; set; }
        public string PoName { get; set; }
        public int PoTypeId { get; set; }
        public Nullable<DateTime> PoDate { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public string PaymentTerms { get; set; }
        public decimal PoValue { get; set; }
        public int CurrencyId { get; set; }
        public string ClientPoNo { get; set; }
        public Nullable<DateTime> ClientPoDate { get; set; }
        public Nullable<DateTime> PoStartDate { get; set; }
        public Nullable<DateTime> PoEndDate { get; set; }
        public int PoBillingAddressId { get; set; }
        public int PoShippingAddressId { get; set; }
        
        public string PoContactPerson { get; set; }

        public string PoMobileNo { get; set; }
        public string PoEmailId { get; set; }
        public string Remarks { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public string UserName { get; set; }
        public string ClientName1 { get; set; }
        public string ProjectName1 { get; set; }
        public string BillingAddressName { get; set; }
        public int BillingAddressId { get; set; }
        public string ShippingAddressName { get; set; }
        public int ShippingAddressId { get; set; }
        public string PTName { get; set; }
        public string PoTypeName { get; set; }
        public string CurrencyName { get; set; }
       
        public int srClientId { get; set; }
        public int srProjectId { get; set; }
        public int srPoTypeId { get; set; }
        public string srClientPoNo { get; set; }


        //---------------PO placement Employee-------------//

        public int PEId { get; set; }
        public int EmployeeId { get; set; }
       
        public Nullable<DateTime> DateofJoin { get; set; }
        public string Skills { get; set; }
        public decimal MonthlyCTC { get; set; }
        public decimal AnnualCTC { get; set; }
        public int PlacementCalculationTypeId { get; set; }
        public decimal CalculationValue { get; set; }
        public decimal BillingAmount { get; set; }
        
        public int BillableDays { get; set; }
        public int Taxable { get; set; }

        public int SubVendorId { get; set; }

        public string EmployeeAddress { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int StatusId { get; set; }
        public string Remarks1 { get; set; }

        public string PlacementCalculationType { get; set; }
        public string VendorName { get; set; }
        public string EmployeeName { get; set; }
        public string StatusName { get; set; }
        public int TaxId { get; set; }
        public string TaxType { get; set; }

        //----------------------PO Milestone--------------------------//
        public int CurrencyId1 { get; set; }
        public int StatusId1 { get; set; }
        //--------------------POManagedService dropdown-------------------//
        public int CurrencyId2 { get; set; }
        public int RateCardId { get; set; }
        public int EmployeeId2 { get; set; }
        //--------------------Delete validatione----------------//
        public int ManagedServiceCount { get; set; }
        public int PlacementEmployeeCount { get; set; }
        public int MilestoneCount { get; set; }

    }
}