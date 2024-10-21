namespace HotelManagement.Queries
{
    public static class StaffsQueries
    {
        public const string GetStaffs = @"SELECT StaffId, StaffName, ContactNumber, Email, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status, RoleId FROM Staff";

        public const string GetStaffById = @"SELECT StaffId, StaffName, ContactNumber, Email, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status, RoleId FROM Staff WHERE StaffId = @StaffId";

        public const string AddStaff = @"INSERT INTO Staff (StaffName, ContactNumber, Email, CreatedBy, CreatedAt, Status, RoleId) 
                                         VALUES (@StaffName, @ContactNumber, @Email, @CreatedBy, @CreatedAt, @Status, @RoleId)";

        public const string UpdateStaff = @"UPDATE Staff SET  
                                                StaffName = @StaffName, ContactNumber = @ContactNumber, Email = @Email, ModifiedBy = 'Admin', ModifiedAt = GETDATE(), RoleId = @RoleId 
                                            WHERE StaffId = @StaffId";

        public const string DeleteStaff = @"DELETE FROM Staff WHERE StaffId = @StaffId";
    }
}
