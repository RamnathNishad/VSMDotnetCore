namespace MVCHelloWorld.Models
{
    public class Employee
    {
        public int Ecode {  get; set; }
        public string Ename { get; set; }
        public int Salary {  get; set; }
        public int Deptid {  get; set; }

        public static List<Employee> GetEmps()
        {
            return new List<Employee>
            {
                new Employee{ Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
                new Employee{ Ecode=102,Ename="Rahul",Salary=1111,Deptid=202},
                new Employee{ Ecode=103,Ename="Rohit",Salary=3333,Deptid=203},
                new Employee{ Ecode=104,Ename="Raman",Salary=4444,Deptid=204},
                new Employee{ Ecode=105,Ename="Suresh",Salary=5555,Deptid=201}
            };
        }

    }
}
