using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class LeaveSetUpModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int LeaveTypeDetailId { get; set; }
        public int LeaveTypeId { get; set; }
       
        public string LeaveTypeName { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LastupdatedBy { get; set; }
      
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedByName { get; set; }

        

    }
}