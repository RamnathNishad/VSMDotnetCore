using System.Security.Cryptography;

namespace MVCHelloWorld.Models
{
    public class LinqDataAccess
    {
        List<Employee> employees;
        List<Department> departments;
        public LinqDataAccess()
        {
            employees = Employee.GetEmps();
            departments=Department.GetDepts();
        }

        //linq syntax using query operator 
        //get all the records which belongs to deptid 201
        public List<Employee> GetEmpsByDid(int did)
        {
            //SQL: select * from employee where deptid=201
            var result = from e in employees
                         where e.Deptid == did && e.Salary>2000
                         select e;

            //OR:using extension method
            result = employees.Where(e => e.Deptid == did && e.Salary > 200);

            return result.ToList();
        }
        public List<Employee> SortBySalary()
        {
            //SQL: select * from employee order by salary asc
            //SQL: select ecode,ename,0.1*salary as Bonus from employee
            var result =    (from e in employees
                            orderby e.Salary descending,e.Ecode
                            select e).ToList();

            //for selected columns
            //select new 
            //{ 
            //    e.Ecode,
            //    e.Ename,
            //    Bonus=0.1*e.Salary
            //}).ToList();

            //OR: extension method
            result = employees.OrderByDescending(e => e.Salary)
                     .OrderBy(e => e.Ecode)
                     .ToList();

            return result;
        }

        public void GroupResult()
        {
            //SQL:
            //select deptid,sum(salary),avg(salary),max(salary),min(salary),count(salary)
            //from employee
            //group by deptid

            var grpResult = (from e in employees
                            group e by e.Deptid into g
                            select new
                            {
                                Deptid=g.Key,
                                TotalSalary = g.Sum(o => o.Salary),
                                AvgSalary = g.Average(o => o.Salary),
                                MaxSalary = g.Max(o => o.Salary),
                                MinSalary = g.Min(o => o.Salary),
                                NoOfEmps = g.Count()
                            }).ToList();

            //OR: extension method
            grpResult = employees.GroupBy(e => e.Deptid)
                                 .Select(g => new 
                                 {
                                    Deptid = g.Key,
                                    TotalSalary = g.Sum(o => o.Salary),
                                    AvgSalary = g.Average(o => o.Salary),
                                    MaxSalary = g.Max(o => o.Salary),
                                    MinSalary = g.Min(o => o.Salary),
                                    NoOfEmps = g.Count()
                                 }).ToList();
        }

        public void JoinResult()
        {
            var joinResult = (from e in employees
                              join d in departments on e.Deptid equals d.Deptid
                              select new
                              {
                                  e.Ecode,
                                  e.Ename,
                                  e.Salary,
                                  d.Deptid,
                                  d.Dname,
                                  d.Dhead
                              }).ToList();

            //OR: extension method
            joinResult = employees.Join(departments, 
                                        e => e.Deptid, 
                                        d => d.Deptid, 
                                        (e, d) => new 
                                        {
                                            e.Ecode,
                                            e.Ename,
                                            e.Salary,
                                            d.Deptid,
                                            d.Dname,
                                            d.Dhead
                                        }).ToList();
        }

    }
}
