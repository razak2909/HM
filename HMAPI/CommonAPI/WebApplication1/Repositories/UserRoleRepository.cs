using System;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRoleRepository
    {
        private readonly UserRoleDAO _userRoleDAO;

        public UserRoleRepository()
        {
            _userRoleDAO = new UserRoleDAO();
        }

        public ResultModel GetAllUserRole()
        {
            try
            {
                var result = _userRoleDAO.GetAllUserRole();
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

        public ResultModel PostUserRole(UserRoleModel model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                model.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name;
                model.Status = true;
                var result = _userRoleDAO.PostUserRole(model);
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
    }




}
