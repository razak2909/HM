using System;

namespace WebApplication1.DAO
{
    public class User
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoFileName { get; set; }
        public string Designation { get; set; }
        public string RoleName { get; set; }
        public int? Age { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string LandlineNo { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class UserDetails
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoFileName { get; set; }
        public string RoleName { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string LandlineNo { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }


}