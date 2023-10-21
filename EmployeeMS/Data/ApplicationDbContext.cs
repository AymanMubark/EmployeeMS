using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmployeeMS.Data.Entities;

namespace EmployeeMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeeMS.Data.Entities.Employee> Employee { get; set; } = null!;
        public DbSet<EmployeeMS.Data.Entities.Department> Department { get; set; } = null!;
    }
}