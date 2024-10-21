using System;
using System.Collections.Generic;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class ViewDetailsRepository 
    {
        private readonly ViewDetailsDAO _dao;

        public ViewDetailsRepository()
        {
            _dao = new ViewDetailsDAO(); // Use dependency injection in a real scenario
        }

        //public IEnumerable<ViewDetails> GetAll()
        //{
        //    return _dao.GetAll();
        //}

        //public ViewDetails GetById(int id)
        //{
        //    return _dao.GetById(id);
        //}

        public ResultModel GetById(int id)
        {
            var result = new ResultModel();
            try
            {
                var details = _dao.GetById(id);
                if (details != null)
                {
                    result.Data = details;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = $"Details with ID {id} not found.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "An error occurred while retrieving the details.";
                result.TechDetails = ex.Message;
            }
            return result;
        }


        //public void Add(ViewDetails details)
        //{
        //    _dao.Add(details);
        //}

        //public void Update(ViewDetails details)
        //{
        //    _dao.Update(details);
        //}

        //public void Delete(int id)
        //{
        //    _dao.Delete(id);
        //}
    }
}
