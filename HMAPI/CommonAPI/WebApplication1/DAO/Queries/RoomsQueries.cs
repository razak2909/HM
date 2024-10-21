namespace HotelManagement.Queries
{
    public static class RoomsQueries
    {
        public const string GetRooms = @" select Rooms.RoomId,Rooms.RoomNumber,Rooms.LatestService,Rooms.roomStatus,Rooms.CreatedBy, Rooms.CreatedAt, Rooms.ModifiedBy, Rooms.ModifiedAt, Rooms.Status, Rooms.RoomTypeId, RoomType.RoomType from Rooms JOIN  RoomType ON Rooms.RoomTypeId = RoomType.RoomTypeId";

        public const string GetRoomTypeNumber = @"select RoomId , RoomNumber from Rooms where roomStatus = 'CheckOut' and RoomTypeId = @RoomTypeId";


        public const string GetRoomById = @"SELECT RoomId, RoomNumber, LatestService, roomStatus, RoomTypeId, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM Rooms WHERE RoomId = @RoomId";

        public const string AddRoom = @"INSERT INTO Rooms (RoomNumber, LatestService, roomStatus, RoomTypeId, CreatedBy, CreatedAt, Status)
                                        VALUES (@RoomNumber, @LatestService, @roomStatus, @RoomTypeId,@CreatedBy, @CreatedAt, @Status)";

         public const string UpdateRoom = @"UPDATE Rooms SET RoomNumber = @RoomNumber, LatestService = @LatestService, roomStatus = @roomStatus, RoomTypeId = @RoomTypeId,
                                            ModifiedBy = 'razak', ModifiedAt = GETDATE() WHERE RoomId = @RoomId";


       // public const string UpdateRoom = @"UPDATE Rooms SET RoomNumber = @RoomNumber, LatestService = @LatestService, roomStatus = @roomStatus, ModifiedBy = @ModifiedBy, ModifiedAt = GETDATE(), Status = @Status, RoomTypeId = @RoomTypeId WHERE RoomId = @RoomId; SELECT Rooms.RoomId, Rooms.RoomNumber, Rooms.LatestService, Rooms.roomStatus, Rooms.CreatedBy, Rooms.CreatedAt, Rooms.ModifiedBy, Rooms.ModifiedAt, Rooms.Status, Rooms.RoomTypeId, RoomType.RoomType FROM Rooms JOIN RoomType ON Rooms.RoomTypeId = RoomType.RoomTypeId WHERE Rooms.RoomId = @RoomId;";

        public const string DeleteRoom = @"DELETE FROM Rooms WHERE RoomId = @RoomId";
    }
}
