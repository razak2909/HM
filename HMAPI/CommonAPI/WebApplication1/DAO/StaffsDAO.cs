using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class StaffsDAO
    {
        private readonly IDbConnection _db;

        public StaffsDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<object> GetStaffs()
        {
            return _db.Query(StaffsQueries.GetStaffs).ToList();
        }

        public Staff GetStaffById(int id)
        {
            return _db.Query<Staff>(StaffsQueries.GetStaffById, new { StaffId = id }).FirstOrDefault();
        }

        public void AddStaff(Staff staff)
        {
            _db.Execute(StaffsQueries.AddStaff, staff);
        }

        public Staff UpdateStaff(Staff staff)
        {
            _db.Execute(StaffsQueries.UpdateStaff, staff);
            return GetStaffById(staff.StaffId);
        }

        public Staff DeleteStaff(int id)
        {
            var staff = GetStaffById(id);
            if (staff != null)
            {
                _db.Execute(StaffsQueries.DeleteStaff, new { StaffId = id });
            }
            return staff;
        }
    }
}
