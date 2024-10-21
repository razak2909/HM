
namespace WebApplication1.DAO.Queries
{
    public class RefreshTokenQueries
    {
        public const string GET_ALL_REFRESHTOKEN = "SELECT * FROM RefreshToken";

        public const string GET_REFRESHTOKEN_FROM_USERNAME = "SELECT * FROM RefreshToken WHERE UserName = @UserName";

        public const string DELETE_REFRESHTOKEN_FROM_ID = "DELETE FROM RefreshToken WHERE ID = @Id";

        public const string INSERT_INTO_REFRESHTOKEN = "INSERT INTO RefreshToken " +
            "(ID, UserName, IssuedTime, ExpiredTime, ProtectedTicket) " +
            "VALUES (@Id, @UserName, @IssuedTime, @ExpiredTime, @ProtectedTicket); ";
    }
}
