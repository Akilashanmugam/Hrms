using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class ClientAddressModel
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public int AddressTypeId { get; set; }
        public string Floor { get; set; }
        public string BuildingName { get; set; }
        public string Road { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string PinCode { get; set; }
        public int CountryId { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Fax { get; set; }
        public string EmailId { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public string GSTIN { get; set; }

        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string ClientName { get; set; }
        public string AddressTypeName { get; set; }
        public object PoId { get; internal set; }
    }
}