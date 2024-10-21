
namespace WebApplication1.DAO.Queries
{
    public class LogQueries
    {
        public const string INSERT_INTO_APILOGS = "INSERT INTO ApiLogs " +
            "(Controller, MethodName, UserId, Parameters, PostData, CreatedBy, ModifiedBy, Status, CreatedAt, ModifiedAt) " +
            "VALUES (@Controller, @MethodName, @UserId, @Parameters, @PostData, @CreatedBy, @ModifiedBy, @Status, @CreatedAt, @ModifiedAt); ";
    }
}
