using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class RateCardModel
    {
        public int RateCardId { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public string RateCardCode { get; set; }
        public Nullable<DateTime> RateCardDate { get; set; }
        public string RateCardName { get; set; }
        public int RateCardTypeId { get; set; }
        public decimal BilableRate { get; set; }
        public int CurrencyId { get; set; }
        public Nullable<DateTime> EffectiveStartDate { get; set; }
        public Nullable<DateTime> EffectiveEndDate { get; set; }
        public int LocationId { get; set; }
        public int StatusId { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }
       
        
        public string UserName { get; set; }
        public string RateCardType { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string LocationName { get; set; }
        public string CurrencyName { get; set; }
        public string StatusName { get; set; }

        //------------------rate card detail --------------------//
        public int RateCardDetailId { get; set; }
        public string RateCardDescription { get; set; }
        public decimal BilableRate1 { get; set; }
        public int CurrencyId1 { get; set; }
        public int LastUpdatedBy1 { get; set; }
        public Nullable<DateTime> LastUpdatedDate1 { get; set; }


    }
}