using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class UserLevelDAO
    {
        private readonly string _connectionString;

        public UserLevelDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public List<UserLevel> GetAllUserLevel()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserLevelQueries.GET_ALL_USERLEVEL;
                return (dbConnection.Query<UserLevel>(query)).ToList();
            }
        }
    }
}
