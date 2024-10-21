using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class VerificationStatusDAO
    {
        private readonly string _connectionString;

        public VerificationStatusDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public List<VerificationStatus> GetAllVerificationStatus()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = VerificationStatusQueries.GET_ALL_VERIFICATIONSTATUS;
                return (dbConnection.Query<VerificationStatus>(query)).ToList();
            }
        }
    }
}
