using HotelManagement.DAO;
using HotelManagement.Models;
using System;
using WebApplication1.Models;

namespace HotelManagement.Repo
{
    public class StaffDocumentRepo
    {
        private readonly StaffDocumentDAO _staffDocumentDAO;

        public StaffDocumentRepo()
        {
            _staffDocumentDAO = new StaffDocumentDAO();
        }

        public ResultModel GetStaffDocuments()
        {
            var result = new ResultModel();
            try
            {
                result.Data = _staffDocumentDAO.GetStaffDocuments();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving staff documents.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel GetStaffDocumentById(int id)
        {
            var result = new ResultModel();
            try
            {
                var staffDocument = _staffDocumentDAO.GetStaffDocumentById(id);
                if (staffDocument != null)
                {
                    result.Data = staffDocument;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff document with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the staff document.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel AddStaffDocument(StaffDocument staffDocument)
        {
            var result = new ResultModel();
            try
            {
                staffDocument.CreatedBy = "Admin";
                staffDocument.CreatedAt = DateTime.Now;
                staffDocument.Status = true;
                _staffDocumentDAO.AddStaffDocument(staffDocument);
                result.Data = staffDocument;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while adding the staff document.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel UpdateStaffDocument(StaffDocument staffDocument)
        {
            var result = new ResultModel();
            try
            {
                var updatedStaffDocument = _staffDocumentDAO.UpdateStaffDocument(staffDocument);
                if (updatedStaffDocument != null)
                {
                    result.Data = updatedStaffDocument;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff document with ID {staffDocument.DocumentsId} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while updating the staff document.";
                result.TechDetails = ex.Message;
            }
            return result;
        }

        public ResultModel DeleteStaffDocument(int id)
        {
            var result = new ResultModel();
            try
            {
                var staffDocument = _staffDocumentDAO.DeleteStaffDocument(id);
                if (staffDocument != null)
                {
                    result.Data = staffDocument;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Staff document with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while deleting the staff document.";
                result.TechDetails = ex.Message;
            }
            return result;
        }
    }
}
