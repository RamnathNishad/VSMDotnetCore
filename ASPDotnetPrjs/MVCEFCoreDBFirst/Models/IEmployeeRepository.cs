namespace MVCEFCoreDBFirst.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmps();
        Employee GetEmpById(int id);

        void AddEmployee(Employee emp);
        void DeleteEmployee(int id);
        void UpdateEmp(Employee emp);
    }
}
