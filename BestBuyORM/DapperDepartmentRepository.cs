using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyORM
{
    public class DapperDepartmentRepository: IDepartmentRepository
    {
        //local variables to make querys 
        private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection connection)
        {
            // Constructor
            _connection = connection;

        }



        public IEnumerable<Department> GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM departments ");

            return depos;


        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentname = newDepartmentName });
        }

       
    }
}
