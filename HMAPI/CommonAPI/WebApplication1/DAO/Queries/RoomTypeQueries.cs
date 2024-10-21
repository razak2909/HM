namespace HotelManagement.Queries
{
    public static class RoomTypesQueries
    {
        public const string GetRoomTypes = @"SELECT RoomTypeId, RoomType, Price, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM RoomType";

        public const string GetRoomTypeById = @"SELECT RoomTypeId, RoomType, Price, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM RoomType WHERE RoomTypeId = @RoomTypeId";

        public const string AddRoomType = @"INSERT INTO RoomType (RoomType, Price, CreatedBy, CreatedAt, Status) 
                                             VALUES (@RoomType, @Price, @CreatedBy, @CreatedAt, @Status)";

        public const string UpdateRoomType = @"UPDATE RoomType SET RoomType = @RoomType, Price = @Price, ModifiedBy = 'Admin', ModifiedAt = GETDATE(), Status = @Status 
                                               WHERE RoomTypeId = @RoomTypeId";

        public const string DeleteRoomType = @"DELETE FROM RoomType WHERE RoomTypeId = @RoomTypeId";
    }
}
