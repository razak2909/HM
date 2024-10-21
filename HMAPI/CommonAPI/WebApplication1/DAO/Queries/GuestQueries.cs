namespace HotelManagement.Queries
{
    public static class GuestsQueries
    {
        public const string GetGuests = @"SELECT GuestId, GuestName, ContactNumber, Email, IdProofType, IdProofNumber, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM Guests";

        public const string GetGuestById = @"SELECT GuestId, GuestName, ContactNumber, Email, IdProofType, IdProofNumber, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM Guests WHERE GuestId = @GuestId";

        public const string AddGuest = @"INSERT INTO Guests (GuestName, ContactNumber, Email, IdProofType, IdProofNumber, CreatedBy, CreatedAt, Status,IDProofPhoto) OUTPUT INSERTED.GuestId
                                         VALUES (@GuestName, @ContactNumber, @Email, @IdProofType, @IdProofNumber, @CreatedBy, @CreatedAt, @Status,@IDProofPhoto)";

        public const string UpdateGuest = @"UPDATE Guests SET GuestName = @GuestName, ContactNumber = @ContactNumber, Email = @Email, IdProofType = @IdProofType, 
                                            IdProofNumber = @IdProofNumber, ModifiedBy = 'Admin', ModifiedAt = GETDATE(), Status = @Status WHERE GuestId = @GuestId";

        public const string DeleteGuest = @"DELETE FROM Guests WHERE GuestId = @GuestId";
    }
}
