using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set;}

        // Khai báo bảng
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}