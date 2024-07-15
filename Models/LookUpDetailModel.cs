using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class LookUpDetailModel
    {

        public int LookUpMasterId { get; set; }
        [Key]
        public int LookUpDetailId { get; set; }
        public string LookUpDetailName { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}