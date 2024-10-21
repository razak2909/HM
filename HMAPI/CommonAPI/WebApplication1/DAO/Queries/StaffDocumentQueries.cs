namespace HotelManagement.Queries
{
    public static class StaffDocumentQueries
    {
        public const string GetStaffDocuments = @"SELECT DocumentsId, StaffId, DocumentName, DocumentFileName, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM StaffDocuments";

        public const string GetStaffDocumentById = @"SELECT DocumentsId, StaffId, DocumentName, DocumentFileName, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM StaffDocuments WHERE DocumentsId = @DocumentsId";

        public const string AddStaffDocument = @"INSERT INTO StaffDocuments (StaffId, DocumentName, DocumentFileName, CreatedBy, CreatedAt, Status) 
                                                 VALUES (@StaffId, @DocumentName, @DocumentFileName, @CreatedBy, @CreatedAt, @Status)";

        public const string UpdateStaffDocument = @"UPDATE StaffDocuments SET StaffId = @StaffId, DocumentName = @DocumentName, DocumentFileName = @DocumentFileName, 
                                                    ModifiedBy = 'Admin', ModifiedAt = GETDATE(), Status = @Status WHERE DocumentsId = @DocumentsId";

        public const string DeleteStaffDocument = @"DELETE FROM StaffDocuments WHERE DocumentsId = @DocumentsId";
    }
}
