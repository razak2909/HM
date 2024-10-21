using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RoomsModel
    {
    
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public DateTime? LatestService { get; set; }
        public string roomStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? Status { get; set; }

        public int RoomTypeId { get; set; }

       
    }
}
