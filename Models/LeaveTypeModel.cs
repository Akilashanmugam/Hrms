using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HrmsWeb.Models
{
    public class LeaveTypeModel
    {
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }

        public string LeaveTypeShortName { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }
    }
}