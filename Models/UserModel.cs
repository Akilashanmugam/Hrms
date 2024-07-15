using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        

        public Nullable<DateTime> StartDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string LoginPassword { get; set; }

    }
}