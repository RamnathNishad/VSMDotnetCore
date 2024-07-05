using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Models
{
    public class EmployeeDbContext : DbContext
    {
        DbContextOptions<EmployeeDbContext> options;
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
            this.options = options;
        }

        public DbSet<Employee> tbl_employee { get; set; }    
        
    }
}
