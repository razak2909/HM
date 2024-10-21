using HotelManagement.DAO;
using HotelManagement.Models;
using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class SalariesRepo
    {
        private readonly SalariesDAO _salariesDAO;

        public SalariesRepo()
        {
            _salariesDAO = new SalariesDAO();
        }

        public ResultModel GetSalaries()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _salariesDAO.GetSalaries();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving salaries.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetSalaryById(int id)
        {
            var result = new ResultModel();
            try
            {
                var salary = _salariesDAO.GetSalaryById(id);
                if (salary != null)
                {
                    result.Data = salary;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Salary with StaffId {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the salary.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddSalary(Salaries salary)
        {
            var result = new ResultModel();
            try
            {
                salary.CreatedBy = "Admin";
                salary.CreatedAt = DateTime.Now;
                salary.Status = true;
                _salariesDAO.AddSalary(salary);
                result.Data = salary;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the salary.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateSalary(Salaries salary)
        {
            var result = new ResultModel();
            try
            {
                var updatedSalary = _salariesDAO.UpdateSalary(salary);
                if (updatedSalary != null)
                {
                    result.Data = updatedSalary;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Salary with StaffId {salary.StaffId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the salary.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteSalary(int id)
        {
            var result = new ResultModel();
            try
            {
                var salary = _salariesDAO.DeleteSalary(id);
                if (salary != null)
                {
                    result.Data = salary;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Salary with StaffId {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the salary.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
