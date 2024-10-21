namespace HotelManagement.Queries
{
    public static class SalaryQueries
    {
        public const string GetSalaries = @"SELECT StaffId, SalaryDate, Salary, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM Salary";

        public const string GetSalaryById = @"SELECT StaffId, SalaryDate, Salary, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, Status FROM Salary WHERE StaffId = @StaffId";

        public const string AddSalary = @"INSERT INTO Salary (StaffId, SalaryDate, Salary, CreatedBy, CreatedAt, Status) 
                                          VALUES (@StaffId, @SalaryDate, @Salary, @CreatedBy, @CreatedAt, @Status)";

        public const string UpdateSalary = @"UPDATE Salary SET  Salary = @Salary, ModifiedBy = 'Admin', ModifiedAt = GETDATE(), Status = @Status 
                                             WHERE StaffId = @StaffId";

        public const string DeleteSalary = @"DELETE FROM Salary WHERE StaffId = @StaffId";
    }
}
