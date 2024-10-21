using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO.Queries
{
    public class BookingListQuery
    {
        public static string GetBookedApplicationList = @"select B.Booking_ID,B.BookingDate, B.BookingStatus, G.GuestName,G.GuestId,G.ContactNumber,G.Email,G.IdProofType,G.IdProofNumber , B.TotalDays,B.TotalPrice TotalStayCost,
                R.RoomId,R.RoomNumber ,R.LatestService  , RT.RoomType , RT.Price RoomPricePerDay
                from Bookings B join Guests G on B.GuestId = G.GuestId join Rooms R on B.RoomId = R.RoomId join RoomType RT on
                R.RoomTypeId = RT.RoomTypeId where R.roomStatus = 'Booked' and B.Status = 1";

        public static string GetBookingById = @"select B.Booking_ID, B.BookingDate, G.GuestName, G.GuestId, G.ContactNumber, G.Email, 
                G.IdProofType, G.IdProofNumber, B.TotalDays, B.TotalPrice as TotalStayCost, R.RoomId,
                R.RoomNumber, R.LatestService, RT.RoomType, RT.Price as RoomPricePerDay
                from Bookings B 
                join Guests G on B.GuestId = G.GuestId 
                join Rooms R on B.RoomId = R.RoomId 
                join RoomType RT on R.RoomTypeId = RT.RoomTypeId 
                where B.Booking_ID = @Id";

        public static string AddBooking = @"insert into Bookings( GuestId, RoomId, BookingDate, NumberOfGuests, BookingStatus, TotalPrice, TotalDays, CreatedBy, CreatedAt, Status)
                                            values (@GuestId, @RoomId, @BookingDate, @NumberOfGuests,'RoomAvailable', @TotalPrice, @TotalDays, @CreatedBy, @CreatedAt, @Status)";

        public static string UpdateBookingRoom = @"UPDATE Rooms SET roomStatus = 'CheckedIn' WHERE RoomId = @RoomId";
        public static string UpdateBooking = @"UPDATE Bookings SET CheckIn =  GETDATE() where Booking_ID=@BookingId";

        public static string UpdateCheckinRoom = @"UPDATE Rooms SET roomStatus = 'CheckOut' WHERE RoomId = @RoomId";
        public static string UpdateCheckinRooms = @"UPDATE Bookings SET Status = 0, CheckOut = GETDATE() WHERE Booking_ID = @BookingId";


        public static string DeleteBooking = @"delete from Bookings where Booking_ID = @Id";



    }
 

    public class CheckInListQuery
    {
        public static string GetgetCheckInApplicationList = @"SELECT B.Booking_ID, B.BookingDate, G.GuestName, G.ContactNumber, G.Email, G.GuestId, G.IdProofType, 
G.IdProofNumber, B.TotalDays, B.TotalPrice AS TotalStayCost, R.RoomNumber,R.RoomId,R.LatestService, RT.RoomType, RT.Price AS RoomPricePerDay, B.CheckIn FROM Bookings B 
JOIN Guests G ON B.GuestId = G.GuestId JOIN Rooms R ON B.RoomId = R.RoomId JOIN RoomType RT ON R.RoomTypeId = RT.RoomTypeId WHERE R.roomStatus = 'CheckedIn' and B.Status = 1";

        public static string GetCheckInById = @"SELECT B.Booking_ID, B.BookingDate, G.GuestName, G.ContactNumber, G.Email, G.GuestId, G.IdProofType, G.IdProofNumber, B.TotalDays, B.TotalPrice AS TotalStayCost, R.RoomNumber, R.LatestService, RT.RoomType, RT.Price AS RoomPricePerDay, B.CheckIn 
                                           FROM Bookings B 
                                           JOIN Guests G ON B.GuestId = G.GuestId JOIN Rooms R ON B.RoomId = R.RoomId JOIN RoomType RT ON R.RoomTypeId = RT.RoomTypeId 
WHERE B.Booking_ID = @Id AND R.roomStatus = 'CheckedIn'";

        public static string AddCheckIn = @"INSERT INTO Bookings (BookingDate, GuestId, RoomId, TotalDays, TotalPrice, CheckIn) 
VALUES (@BookingDate, @GuestId, @RoomId, @TotalDays, @TotalPrice, @CheckIn)";


        public static string UpdateCheckIn = @"UPDATE Bookings 
SET BookingDate = @BookingDate, GuestId = @GuestId, RoomId = @RoomId, TotalDays = @TotalDays, TotalPrice = @TotalPrice, CheckIn = @CheckIn 
WHERE Booking_ID = @Booking_ID";


        public static string DeleteCheckIn = @"DELETE FROM Bookings 
WHERE Booking_ID = @Id";

    }

    public class CheckOutListQuery
    {
        public static string GetgetCheckOutApplicationList = @"select B.Booking_ID,B.BookingDate,G.GuestId, G.GuestName,G.ContactNumber,G.Email,G.IdProofType,G.IdProofNumber , B.TotalDays,B.TotalPrice TotalStayCost,
R . RoomNumber ,R.LatestService  , RT.RoomType , RT.Price RoomPricePerDay,B.CheckIn,B.CheckOut
from Bookings B join Guests G on B.GuestId = G.GuestId join Rooms R on B.RoomId = R.RoomId join  RoomType RT on 
R.RoomTypeId = RT.RoomTypeId where R.roomStatus = 'CheckOut'";


        public static string GetCheckOutByIdQuery = @"
SELECT B.Booking_ID, B.BookingDate, G.GuestId, G.GuestName, G.ContactNumber, 
       G.Email, G.IdProofType, G.IdProofNumber, B.TotalDays, 
       B.TotalPrice AS TotalStayCost, R.RoomNumber, 
       R.LatestService, RT.RoomType, RT.Price AS RoomPricePerDay, 
       B.CheckIn, B.CheckOut
FROM Bookings B 
JOIN Guests G ON B.GuestId = G.GuestId 
JOIN Rooms R ON B.RoomId = R.RoomId 
JOIN RoomType RT ON R.RoomTypeId = RT.RoomTypeId 
WHERE B.Booking_ID = @BookingId;";  /*-- Use parameter @BookingId*/


            public static string AddCheckOutQuery = @"
INSERT INTO Bookings (BookingDate, GuestId, RoomId, TotalDays, 
                      TotalPrice, CheckIn, CheckOut, BookingStatus)
VALUES (@BookingDate, @GuestId, @RoomId, @TotalDays, 
        @TotalPrice, @CheckIn, @CheckOut, @BookingStatus)";


        public static string UpdateCheckOutQuery = @"
UPDATE Bookings
SET BookingDate = @BookingDate, 
    GuestId = @GuestId, 
    RoomId = @RoomId, 
    TotalDays = @TotalDays, 
    TotalPrice = @TotalPrice, 
    CheckIn = @CheckIn, 
    CheckOut = @CheckOut
WHERE Booking_ID = @BookingId;";  /*-- Use parameter @BookingId*/


            public static string DeleteCheckOutQuery = @"
DELETE FROM Bookings 
WHERE Booking_ID = @BookingId;";  /*-- Use parameter @BookingId*/

    }
}