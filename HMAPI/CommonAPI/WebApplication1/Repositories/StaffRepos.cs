using HotelManagement.DAO;
using HotelManagement.Models;
using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class StaffsRepo
    {
        private readonly StaffsDAO _staffsDAO;

        public StaffsRepo()
        {
            _staffsDAO = new StaffsDAO();
        }

        public ResultModel GetStaffs()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _staffsDAO.GetStaffs();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving staff.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetStaffById(int id)
        {
            var result = new ResultModel();
            try
            {
                var staff = _staffsDAO.GetStaffById(id);
                if (staff != null)
                {
                    result.Data = staff;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the staff.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddStaff(Staff staff)
        {
            var result = new ResultModel();
            try
            {
                staff.CreatedBy = "Admin";
                staff.CreatedAt = DateTime.Now;
                staff.Status = true;
                _staffsDAO.AddStaff(staff);
                result.Data = staff;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the staff.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateStaff(Staff staff)
        {
            var result = new ResultModel();
            try
            {
                var updatedStaff = _staffsDAO.UpdateStaff(staff);
                if (updatedStaff != null)
                {
                    result.Data = updatedStaff;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff with ID {staff.StaffId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the staff.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteStaff(int id)
        {
            var result = new ResultModel();
            try
            {
                var staff = _staffsDAO.DeleteStaff(id);
                if (staff != null)
                {
                    result.Data = staff;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the staff.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
