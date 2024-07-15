using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class ClientModel
    {
        public int ClientId {get; set; } 

        public string ClientName { get; set; } 

        public string ClientShortName { get; set; }

        public Nullable<DateTime> StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public int LastUpdatedBy { get; set; }

        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public string LastUpdatedByName { get; set; }

        public int ProjectId { get; set; }
        public int LocationId { get; set; }

    }

}
