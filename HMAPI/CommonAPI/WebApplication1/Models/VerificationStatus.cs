using System;

namespace WebApplication1.Models
{
    public class VerificationStatus
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
