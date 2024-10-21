using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class UserRoleDAO
    {
        private readonly string _connectionString;

        public UserRoleDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public List<UserRoleModel> GetAllUserRole()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserRoleQueries.GetUserRoles;
                return (dbConnection.Query<UserRoleModel>(query)).ToList();
            }
        }

        public int PostUserRole(UserRoleModel model)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserRoleQueries.AddUserRole;
                return (dbConnection.Execute(query, model));
            }
        }
    }
}
