namespace HotelManagement.Queries
{
    public static class BookingsQueries
    {
        public const string GetBookings = @"SELECT Booking_ID, GuestId, RoomId, BookingDate, CheckIn, CheckOut, NumberOfGuests, TotalPrice, BookingStatus, TotalDays FROM Bookings";

        public const string GetBookingById = @"SELECT Booking_ID, GuestId, RoomId, BookingDate, CheckIn, CheckOut, NumberOfGuests, TotalPrice, BookingStatus, TotalDays FROM Bookings WHERE Booking_ID = @Booking_ID";

        public const string AddBooking = @"INSERT INTO Bookings (GuestId, RoomId, BookingDate, CheckIn, CheckOut, NumberOfGuests, TotalPrice, BookingStatus, TotalDays, CreatedBy, CreatedAt, Status) 
                                           VALUES (@GuestId, @RoomId, @BookingDate, @CheckIn, @CheckOut, @NumberOfGuests, @TotalPrice, @BookingStatus, @TotalDays, @CreatedBy, @CreatedAt, @Status)";

        public const string UpdateBooking = @"UPDATE Bookings SET  
                                                  RoomId = @RoomId,  BookingDate = @BookingDate, CheckIn = @CheckIn, CheckOut = @CheckOut, NumberOfGuests = @NumberOfGuests, TotalPrice = @TotalPrice, BookingStatus = @BookingStatus, TotalDays = @TotalDays, ModifiedBy = 'razak', ModifiedAt = GETDATE()
                                              WHERE Booking_ID = @Booking_ID";

        public const string DeleteBooking = @"DELETE FROM Bookings WHERE Booking_ID = @Booking_ID";
    }
}
