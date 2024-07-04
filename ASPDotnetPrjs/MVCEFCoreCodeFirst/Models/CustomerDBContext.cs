using Microsoft.EntityFrameworkCore;

namespace MVCEFCoreCodeFirst.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<tbl_customer> tbl_customer { get; set; }
        public DbSet<tbl_product> tbl_product {  get; set; }

        public DbSet<Manager> tbl_manager { get; set; }
        public DbSet<Project> tbl_project { get; set; }

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
