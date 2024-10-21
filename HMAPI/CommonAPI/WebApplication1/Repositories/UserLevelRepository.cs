using System;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserLevelRepository
    {
        private readonly UserLevelDAO _userLevelDAO;

        public UserLevelRepository()
        {
            _userLevelDAO = new UserLevelDAO();
        }

        public ResultModel GetAllUserLevel()
        {
            try
            {
                var result = _userLevelDAO.GetAllUserLevel();
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
