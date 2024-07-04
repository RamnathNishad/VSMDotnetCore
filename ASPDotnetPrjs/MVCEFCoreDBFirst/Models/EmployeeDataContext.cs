using Microsoft.EntityFrameworkCore;

namespace MVCEFCoreDBFirst.Models
{
    public class EmployeeDataContext : DbContext
    {
        DbContextOptions<EmployeeDataContext> dbOptions;
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> dbOptions) 
            : base(dbOptions)
        {
            this.dbOptions = dbOptions;
        }

        public DbSet<Employee> tbl_employee { get; set; }
    }
}
