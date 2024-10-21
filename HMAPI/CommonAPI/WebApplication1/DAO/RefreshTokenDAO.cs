using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class RefreshTokenDAO
    {
        private readonly string _connectionString;

        public RefreshTokenDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public async Task<RefreshToken> GetRefreshToken(string userName)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = RefreshTokenQueries.GET_REFRESHTOKEN_FROM_USERNAME;
                return await dbConnection.QueryFirstOrDefaultAsync<RefreshToken>(query, new { @UserName = userName });
            }
        }

        public async Task<List<RefreshToken>> GetAllRefreshToken()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = RefreshTokenQueries.GET_ALL_REFRESHTOKEN;
                return (await dbConnection.QueryAsync<RefreshToken>(query)).ToList();
            }
        }

        public async Task<string> InsertRefreshToken(RefreshToken user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = RefreshTokenQueries.INSERT_INTO_REFRESHTOKEN;
                string Id = await dbConnection.QueryFirstOrDefaultAsync<string>(query, new
                {
                    @Id = user.ID,
                    @UserName = user.UserName,
                    @IssuedTime = user.IssuedTime,
                    @ExpiredTime = user.ExpiredTime,
                    @ProtectedTicket = user.ProtectedTicket
                });

                return Id;
            }
        }

        public async Task<bool> DeleteRefreshToken(string refreshTokenId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = RefreshTokenQueries.DELETE_REFRESHTOKEN_FROM_ID;
                int rowsAffected = await dbConnection.ExecuteAsync(query, new { @Id = refreshTokenId });

                return rowsAffected > 0;
            }
        }
    }
}