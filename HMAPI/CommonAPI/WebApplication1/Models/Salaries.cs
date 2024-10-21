using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Salaries
    {
        public int StaffId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Salary { get; set; }  // Renamed from Salary to Amount
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Status { get; set; }

        public virtual Staff Staff { get; set; }
    }
}