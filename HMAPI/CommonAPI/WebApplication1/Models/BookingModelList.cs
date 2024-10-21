using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookingModelList
    {
        public int Booking_ID { get; set; }
        public DateTime BookingDate { get; set; }

        public string BookingStatus { get; set; }
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public int RoomId { get; set; }

        //public int ContactNumber { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public Boolean Status { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime CheckIn { get; set; }
        



        // Add other properties as necessary
    }

}