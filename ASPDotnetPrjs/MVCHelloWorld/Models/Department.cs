namespace MVCHelloWorld.Models
{
    public class Department
    {
        public int Deptid {  get; set; }
        public string Dname { get; set; }
        public int Dhead {  get; set; }

        public static List<Department> GetDepts()
        {
            return new List<Department>
            {
                new Department{Deptid=201,Dname="Account",Dhead=105},
                new Department{Deptid=202,Dname="Admin",Dhead=106},
                new Department{Deptid=203,Dname="Sales",Dhead=108}
            };
        }
    }
}
