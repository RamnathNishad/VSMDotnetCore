namespace MVCEFCoreCodeFirst.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Dname { get; set; }

        //navigation
        public ICollection<Employee> Employees { get; set; }
    }
}
