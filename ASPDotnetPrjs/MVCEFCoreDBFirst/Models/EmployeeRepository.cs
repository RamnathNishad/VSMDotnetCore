
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVCEFCoreDBFirst.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDataContext dbCtx;
        public EmployeeRepository(EmployeeDataContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public void AddEmployee(Employee emp)
        {
            //dbCtx.tbl_employee.Add(emp);
            //dbCtx.SaveChanges();

            var pec = new SqlParameter("@ec", emp.Ecode);
            var pen = new SqlParameter("@en", emp.Ename);
            var psal = new SqlParameter("@sal", emp.Salary);
            var pdid = new SqlParameter("@did", emp.Deptid);

            dbCtx.Database.ExecuteSqlRaw("exec sp_insert_emp @ec,@en,@sal,@did", pec, pen, psal, pdid);
        }

        public void DeleteEmployee(int id)
        {
            var record = dbCtx.tbl_employee.Find(id);
            if (record != null)
            {
                dbCtx.tbl_employee.Remove(record);
                dbCtx.SaveChanges();
            }
        }

        public Employee GetEmpById(int id)
        {
            //return dbCtx.tbl_employee.Find(id);
            var ecParam = new SqlParameter("@ec", id);

            return dbCtx.tbl_employee
                        .FromSqlRaw("exec sp_getemp_byid @ec", ecParam)
                        .ToList()
                        .SingleOrDefault();
        }

        public List<Employee> GetEmps()
        {
            return dbCtx.tbl_employee.FromSqlRaw("exec sp_getemps").ToList();       
        }

        public void UpdateEmp(Employee emp)
        {
            var record = dbCtx.tbl_employee.Find(emp.Ecode);
            if (record != null)
            {
                record.Ename = emp.Ename;
                record.Salary = emp.Salary;
                record.Deptid = emp.Deptid;
                dbCtx.SaveChanges();
            }
        }
    }
}
