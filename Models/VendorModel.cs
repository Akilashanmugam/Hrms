using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class VendorModel
    {
        public int VendorId { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public string VendorName { get; set; }
        public string VendorShortName { get; set; }
        
        public string VendorAddress { get; set; }
        public string SpecialInstructions { get; set; }
        public string ContactName { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string VendorGST { get; set; }
        
        public Nullable<DateTime> EffectiveStartDate { get; set; }
        public Nullable<DateTime> EffectiveEndDate { get; set; }
        public int MasterStatusId { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }


    }
}