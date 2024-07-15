using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class LeaveAllotmentModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int LeaveTypeId { get; set; }
        public int LeaveTypeName { get; set; }
        public string LeaveTypeName1 { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}