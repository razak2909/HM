//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff
    {
        
    
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }
        public bool Status { get; set; }
        public Nullable<int> RoleId { get; set; }
    
      
    }
}
