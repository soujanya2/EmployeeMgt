using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace EmployeeMgmt.Models
{
    public class LoginDbContext:DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
