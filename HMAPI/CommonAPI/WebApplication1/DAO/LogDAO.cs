using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.DAO.Queries;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class LogDAO
    {
        private readonly string _connectionString;

        public LogDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public void SaveLog(ApiLogs log)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = LogQueries.INSERT_INTO_APILOGS;
                dbConnection.Query(query, new
                {
                    @Controller = log.Controller,
                    @MethodName = log.MethodName,
                    @UserId = log.UserId,
                    @Parameters = log.Parameters,
                    @PostData = log.PostData,
                    @CreatedBy = log.CreatedBy,
                    @ModifiedBy = log.ModifiedBy,
                    @Status = log.Status,
                    @CreatedAt = log.CreatedAt,
                    @ModifiedAt = log.ModifiedAt
                });
            }
        }
    }
}