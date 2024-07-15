using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hrmsweb.Models
{
    public class CompanyContactModel
    {
        public int CompanyId { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }
        public string EmailId { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> ContactStartDate { get; set; }
        public Nullable<DateTime> ContactEndDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}