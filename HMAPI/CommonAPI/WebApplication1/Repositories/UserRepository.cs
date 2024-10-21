using System;
using System.Threading.Tasks;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository()
        {
            _userDAO = new UserDAO();
        }

        public async Task<User> LoginUser(string UserName, string Password)
        {
            return await _userDAO.LoginUser(UserName, Password);
        }

        public ResultModel GetSingleUser(string UserId)
        {
            try
            {
                var result = _userDAO.GetSingleUser(UserId);
                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

        public ResultModel GetUserBasedOnRole(string RoleName)
        {
            try
            {
                var result = _userDAO.GetUserBasedOnRole(RoleName);
                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

        public ResultModel GetAllUser()
        {
            try
            {
                var result = _userDAO.GetAllUser();
                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }

        public ResultModel InsertUpdateUser(User user, bool IsEdit, string loginUser)
        {
            try
            {
                if (IsEdit)
                {
                    user.CreatedBy = loginUser;
                    user.CreatedAt = DateTime.Now;
                    user.ModifiedBy = loginUser;
                    user.ModifiedAt = DateTime.Now;

                    var result = _userDAO.UpdateUser(user);
                    return new ResultModel()
                    {
                        Success = true,
                        Data = result,
                        ErrorMessage = string.Empty,
                        TechDetails = string.Empty
                    };
                }
                else
                {

                    user.Status = true;
                    user.CreatedBy = loginUser;
                    user.CreatedAt = DateTime.Now;

                    var result = _userDAO.InsertUser(user);
                    return new ResultModel()
                    {
                        Success = true,
                        Data = result,
                        ErrorMessage = string.Empty,
                        TechDetails = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }


        }

        public ResultModel DeleteUser(string UserId, string LoginUserId)
        {
            try
            {
                var result = _userDAO.DeleteUser(UserId, LoginUserId);
                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error getting data",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }


        public bool ForgotUserRepository(UserDetails user)
        {
            try
            {
                var obj = new UserDAO();
                var data = obj.ForgotPasswordQuery(user);
                return data;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ResultModel GetUserCountRepo()
        {
            try
            {
                var obj = new UserDAO();

                var result = obj.GetActiveUserCount();

                if (result == 0)
                {
                    return new ResultModel()
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "No active users found",
                        TechDetails = string.Empty
                    };
                }
                return new ResultModel()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = string.Empty,
                    TechDetails = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Error retrieving user count",
                    TechDetails = ex.Message + Environment.NewLine + ex.ToString() + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.ToString())
                };
            }
        }
    }
}
