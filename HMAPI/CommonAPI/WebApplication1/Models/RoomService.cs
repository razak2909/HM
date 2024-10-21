namespace HotelManagement.Models
{
    using System;
    using WebApplication1.Models;

    public partial class RoomService
    {
        public int ServiceId { get; set; }
        public int? RoomId { get; set; }
        public string ServiceType { get; set; }
        public DateTime? ServiceDate { get; set; }
        public string StatusOfService { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? Status { get; set; }

        public virtual RoomsModel Room { get; set; }
    }
}
