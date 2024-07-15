using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class ClientContactModel
    {
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public string ContactName { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}