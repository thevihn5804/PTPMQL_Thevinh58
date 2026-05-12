using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;
using ProjectMVC.Models.Entities;

namespace ProjectMVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

         public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ImportOrder> ImportOrders { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }
        public DbSet<ExportOrder> ExportOrders { get; set; }
        public DbSet<ExportDetail> ExportDetails { get; set; }
        public DbSet<Book> Books { get; set; }

         public DbSet<Faculty> Faculties { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Faculty>().HasData(
            new Faculty { FacultyID = 1, FacultyName = "Cong nghe thong tin" },
            new Faculty { FacultyID = 2, FacultyName = "Quan tri kinh doanh" },
            new Faculty { FacultyID = 3, FacultyName = "Ngon ngu Anh" });

        modelBuilder.Entity<Student>()
            .HasOne(student => student.Faculty)
            .WithMany(faculty => faculty.Students)
            .HasForeignKey(student => student.FacultyID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
}