
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
            dbCtx.tbl_employee.Add(emp);
            dbCtx.SaveChanges();
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
            return dbCtx.tbl_employee.Find(id);
        }

        public List<Employee> GetEmps()
        {
            return dbCtx.tbl_employee.ToList();
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
