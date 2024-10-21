using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.DAO.Queries;

namespace WebApplication1.DAO
{
    public class UserDAO
    {
        private readonly string _connectionString;
        private string query;

        public UserDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;
        }

        public async Task<User> LoginUser(string UserName, string Password)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserQueries.GET_USER_FROM_USERNAME_AND_PASSWORD;
                return await dbConnection.QueryFirstOrDefaultAsync<User>(query, new
                {
                    @UserName = UserName,
                    @Password = Password
                });
            }
        }

        public UserDetails GetSingleUser(string UserId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserQueries.GET_USER_FROM_USERID;
                return dbConnection.QueryFirstOrDefault<UserDetails>(query, new { @UserId = UserId });
            }
        }

        public List<User> GetUserBasedOnRole(string RoleName)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserQueries.GET_USER_FROM_USERROLE;
                return (dbConnection.Query<User>(query, new { @RoleName = RoleName })).ToList();
            }
        }

        public List<UserDetails> GetAllUser()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string UserName = HttpContext.Current.User.Identity.Name;


                    string query1 = UserQueries.Get_All_User_Details;
                    return (dbConnection.Query<UserDetails>(query1)).ToList();
     

            }
        }

        public string InsertUser(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

               
              
              
        
                
                string query = UserQueries.INSERT_INTO_USER;
                dbConnection.Query(query, new
                {
                    @Name = user.Name,
                    @UserId = user.UserId,
                    @Password = user.Password,
                    @Photo = user.Photo,
                    @PhotoFilename = user.PhotoFileName,
                    @Designation = user.Designation,
                    @RoleName = user.RoleName,
                    @Age = user.Age,
                    @EmailId = user.EmailId,
                    @MobileNo = user.MobileNo,
                    @LandlineNo = user.LandlineNo,
                    @PermanentAddress = user.PermanentAddress,
                    @PresentAddress = user.PresentAddress,
                    @CreatedBy = user.CreatedBy, 
                    @Status = user.Status,
                    @CreatedAt = user.CreatedAt,

                });

                return user.UserId;
            }
        }

        public string UpdateUser(User user)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserQueries.UPDATE_USER_FROM_USERID;
                dbConnection.Query(query, new
                {
                    @UserId = user.UserId,
                    @Name = user.Name,
                    @Designation = user.Designation,
                    @RoleName = user.RoleName,
                    @EmailId = user.EmailId,
                    @MobileNo = user.MobileNo,
                    @PermanentAddress = user.PermanentAddress,
                    @PresentAddress = user.PresentAddress,
                    @ModifiedBy = user.ModifiedBy,
                    @ModifiedAt = user.ModifiedAt
                });

                return user.UserId;
            }
        }

        public bool DeleteUser(string UserId, string LoginUserId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string query = UserQueries.DELETE_USER_FROM_USERID;
                int rowsAffected = dbConnection.Execute(query, new
                {
                    @UserId = UserId,
                    @ModifiedBy = LoginUserId,
                    @ModifiedAt = DateTime.Now
                });

                return rowsAffected > 0;
            }
        }

        public bool ForgotPasswordQuery(UserDetails user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var sql1 = "select * from [dbo].[User] where UserId = @userid and EmailId = @emailid";
                    var q = connection.Query(sql1, new
                    {
                        userid = user.UserId,
                        emailid = user.EmailId
                    }).ToList();

                    if (q[0].UserId == user.UserId && q[0].EmailId == user.EmailId)
                    {

                        var sql = "Update [dbo].[User] set Password = @password where (UserId = @userid and EmailId = @emailid)";

                        var val = connection.Execute(sql, new
                        {
                            password = user.Password,
                            userid = user.UserId,
                            emailid = user.EmailId
                        });

                        if (val == 0)
                        {
                            return false;
                        }

                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public int GetActiveUserCount()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                var query = UserQueries.getActiveUserCount;
                return dbConnection.ExecuteScalar<int>(query);
            }
        }

    }
}
