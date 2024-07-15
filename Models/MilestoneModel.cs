using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class MilestoneModel
    {
        public int MilestoneId { get; set; }
        public int PoId { get; set; }
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int CurrencyId1 { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public Nullable<DateTime> EffectiveStartDate { get; set; }
        public Nullable<DateTime> EffectiveEndDate { get; set; }
        public int StatusId1 { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public string UserName { get; set; }
        public string CurrencyName { get; set; }
        public string StatusName { get; set; }

    }
}