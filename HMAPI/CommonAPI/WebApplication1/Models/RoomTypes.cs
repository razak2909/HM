using System;

namespace HotelManagement.Models
{
    public class RoomTypes
    {
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }  // Changed from 'TypeName' to 'RoomType'
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Status { get; set; }
    }
}
