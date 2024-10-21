
namespace WebApplication1.DAO.Queries
{
    public static class UserRoleQueries
    {
        public const string GetUserRoles = "SELECT * FROM UserRole";
        public const string GetUserRoleById = "SELECT * FROM UserRole WHERE UserRoleId = @UserRoleId";
        public const string AddUserRole = "INSERT INTO UserRole (RoleName, Description,Status, CreatedBy,CreatedAt)VALUES (@RoleName, @Description,@Status,@CreatedBy,@CreatedAt)";
        public const string UpdateUserRole = "UPDATE UserRole SET RoleName = @RoleName, Status = @Status , ModifiedBy = @ModifiedBy , ModifiedAt = @ModifiedAt WHERE UserRoleId = @UserRoleId";
        public const string DeleteUserRole = "DELETE FROM UserRole WHERE UserRoleId = @UserRoleId";
    }
}
