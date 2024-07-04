namespace MVCEFCoreCodeFirst.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Ename { get; set; }

        //navigation
        public Department Department { get; set; }

    }
}
