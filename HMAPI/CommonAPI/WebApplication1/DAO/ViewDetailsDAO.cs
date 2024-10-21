using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class ViewDetailsDAO 
    {
        private readonly string _connectionString;

        public ViewDetailsDAO()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString;  // Set your connection string
        }

        //public IEnumerable<ViewDetails> GetAll()
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        return connection.Query<ViewDetails>(ViewDetailsQueries.GetAllViewDetails);
        //    }
        //}

        public ViewDetails GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<ViewDetails>(ViewDetailsQueries.GetViewDetailsById, new { @GuestId = id });
            }
        }

        //public void Add(ViewDetails details)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Execute(Queries.AddViewDetails, details);
        //    }
        //}

        //public void Update(ViewDetails details)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Execute(Queries.UpdateViewDetails, details);
        //    }
        //}

        //public void Delete(int id)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Execute(Queries.DeleteViewDetails, new { GuestId = id });
        //    }
        //}
    }
}
