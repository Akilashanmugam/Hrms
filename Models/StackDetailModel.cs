using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class StackDetailModel
    {
        public int StackId { get; set; }
        public string  StackDetailName { get; set; }
        public object EmployeeSalaryId { get; internal set; }
    }
}