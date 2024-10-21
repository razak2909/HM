using System;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class VerificationStatusRepository
    {
        private readonly VerificationStatusDAO _verificationStatusDAO;

        public VerificationStatusRepository()
        {
            _verificationStatusDAO = new VerificationStatusDAO();
        }

        public ResultModel GetVerificationStatus()
        {
            try
            {
                var result = _verificationStatusDAO.GetAllVerificationStatus();
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
