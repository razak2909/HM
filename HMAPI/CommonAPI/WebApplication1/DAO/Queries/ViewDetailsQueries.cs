using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO.Queries
{
    public class ViewDetailsQueries
    {
       
            public const string GetAllViewDetails = "SELECT * FROM ViewDetails"; // Adjust table name
            public const string GetViewDetailsById = "	SELECT g.GuestId,g.GuestName,g.ContactNumber,b.BookingDate,g.IdProofType,g.IDProofPhoto, g.IdProofNumber, r.RoomNumber, rt.RoomType FROM  Guests g JOIN " +
            " Bookings b ON g.GuestId = b.GuestId JOIN Rooms r ON b.RoomId = r.RoomId JOIN RoomType rt ON r.RoomTypeId = rt.RoomTypeId WHERE g.GuestId = @GuestId";


        //SELECT g.GuestId, g.GuestName, g.ContactNumber, g.IdProofType, g.IdProofNumber, b.BookingDate, r.RoomNumber, 
        //    rt.RoomType FROM Guests g JOIN Bookings b ON g.GuestId = b.GuestId JOIN Rooms r ON b.RoomId = r.RoomId JOIN RoomType rt ON r.RoomTypeId = rt.RoomTypeId WHERE g.GuestId = @GuestId"


            public const string AddViewDetails = "INSERT INTO ViewDetails (BookingDate, GuestName, ContactNumber, IdProofType, IdProofNumber, RoomType, RoomNumber) VALUES (@BookingDate, @GuestName, @ContactNumber, @IdProofType, @IdProofNumber, @RoomType, @RoomNumber)";
            public const string UpdateViewDetails = "UPDATE ViewDetails SET BookingDate = @BookingDate, GuestName = @GuestName, ContactNumber = @ContactNumber, IdProofType = @IdProofType, IdProofNumber = @IdProofNumber, RoomType = @RoomType, RoomNumber = @RoomNumber WHERE GuestId = @GuestId";
            public const string DeleteViewDetails = "DELETE FROM ViewDetails WHERE GuestId = @GuestId"; // Adjust table name
        

}
}