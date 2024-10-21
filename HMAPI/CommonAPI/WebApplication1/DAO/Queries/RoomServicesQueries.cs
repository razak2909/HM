namespace HotelManagement.Queries
{
    public static class RoomServicesQueries
    {
        public const string GetRoomServices = @"SELECT ServiceId, RoomId, ServiceType, ServiceDate, StatusOfService, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM RoomService";

        public const string GetRoomServiceById = @"SELECT ServiceId, RoomId, ServiceType, ServiceDate, StatusOfService, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM RoomService WHERE ServiceId = @ServiceId";

        public const string AddRoomService = @"INSERT INTO RoomService (RoomId, ServiceType, ServiceDate, StatusOfService, CreatedBy, CreatedAt, Status) 
                                               VALUES (@RoomId, @ServiceType, @ServiceDate, @StatusOfService, @CreatedBy, @CreatedAt, @Status)";

        public const string UpdateRoomService = @"UPDATE RoomService SET 
                                                    RoomId = @RoomId, ServiceType = @ServiceType, ServiceDate = @ServiceDate, StatusOfService = @StatusOfService, ModifiedBy = 'Admin', ModifiedAt = GETDATE()
                                                WHERE ServiceId = @ServiceId";

        public const string DeleteRoomService = @"DELETE FROM RoomService WHERE ServiceId = @ServiceId";
    }
}
