using System;

namespace WebApplication1.Models
{
    public class UserLevel
    {
        public string UserLevelName { get; set; }
        public string UserLevelDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Status { get; set; }
    }
}
