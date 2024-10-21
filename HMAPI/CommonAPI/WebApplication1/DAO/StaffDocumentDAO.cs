using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class StaffDocumentDAO
    {
        private readonly IDbConnection _db;

        public StaffDocumentDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<StaffDocument> GetStaffDocuments()
        {
            return _db.Query<StaffDocument>(StaffDocumentQueries.GetStaffDocuments).ToList();
        }

        public StaffDocument GetStaffDocumentById(int id)
        {
            return _db.Query<StaffDocument>(StaffDocumentQueries.GetStaffDocumentById, new { DocumentsId = id }).FirstOrDefault();
        }

        public void AddStaffDocument(StaffDocument staffDocument)
        {
            _db.Execute(StaffDocumentQueries.AddStaffDocument, staffDocument);
        }

        public StaffDocument UpdateStaffDocument(StaffDocument staffDocument)
        {
            _db.Execute(StaffDocumentQueries.UpdateStaffDocument, staffDocument);
            return GetStaffDocumentById(staffDocument.DocumentsId);
        }

        public StaffDocument DeleteStaffDocument(int id)
        {
            var staffDocument = GetStaffDocumentById(id);
            if (staffDocument != null)
            {
                _db.Execute(StaffDocumentQueries.DeleteStaffDocument, new { DocumentsId = id });
            }
            return staffDocument;
        }
    }
}
