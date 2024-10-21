using Dapper;
using HotelManagement.Models;
using HotelManagement.Queries;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelManagement.DAO
{
    public class SalariesDAO
    {
        private readonly IDbConnection _db;

        public SalariesDAO()
        {
            _db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString);
        }

        public IEnumerable<Salaries> GetSalaries()
        {
            return _db.Query<Salaries>(SalaryQueries.GetSalaries).ToList();
        }

        public Salaries GetSalaryById(int id)
        {
            return _db.Query<Salaries>(SalaryQueries.GetSalaryById, new { StaffId = id }).FirstOrDefault();
        }

        public void AddSalary(Salaries salary)
        {
            _db.Execute(SalaryQueries.AddSalary, salary);
        }

        public Salaries UpdateSalary(Salaries salary)
        {
            
            _db.Execute(SalaryQueries.UpdateSalary, salary);
            return GetSalaryById(salary.StaffId);
        }

        public Salaries DeleteSalary(int id)
        {
            var salary = GetSalaryById(id);
            if (salary != null)
            {
                _db.Execute(SalaryQueries.DeleteSalary, new { StaffId = id });
            }
            return salary;
        }
    }
}
