using System;

namespace HrmsWeb.Models
{
    public class EmployeeSalaryModel
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int StackId { get; set; }
        public decimal CTC_Month { get; set; }
        public decimal CTC_PA { get; set; }

        public decimal BDA { get; set; }
        public decimal HRA { get; set; }
        public decimal TA { get; set; }
        public Nullable<DateTime> WEFrom { get; set; }
        public Nullable<DateTime> WETo { get; set; }

        public decimal MA { get; set; }
        public decimal Bonus { get; set; }
        public decimal SA { get; set; }
        public decimal OA { get; set; }
        public decimal Gross { get; set; }

        public decimal EPF { get; set; }
        public decimal EESI { get; set; }
        public decimal OB { get; set; }
        public decimal ESI { get; set; }
        public decimal PF { get; set; }

        public decimal VPF_Percentage { get; set; }
        public decimal VPF_Amount { get; set; }
        public decimal PT { get; set; }
        public decimal TDS { get; set; }
        public decimal OD { get; set; }

        public decimal TotBen { get; set; }
        public decimal TotDed { get; set; }
        public decimal NetPay { get; set; }
        public int Increment { get; set; }
        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        public string Remarks { get; set; }

        public string LastUpdatedByName { get; set; }

        public string EmployeeName { get; set; }
        public string StackDetailName { get; set; }
        public string ClientName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string ReligionName { get; set; }
        public string GenderName { get; set; }
        public string NationalityName { get; set; }
    
        public int srClientId { get; set; }
        public int srEmployeeId { get; set; }
        public int srStackId { get; set; }
        public int srDepartmentId { get; set; }
        public int srDesignationId { get; set; }
        public int srReligionId { get; set; }
        public int srGenderId { get; set; }
        public int srNationalityId { get; set; }

    }
}