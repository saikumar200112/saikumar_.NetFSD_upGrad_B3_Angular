using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                :
        base(options)
        {
        }
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>().HasKey(c => c.ContactId);
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<Department>().HasKey(c => c.DepartmentId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(com => com.Contacts)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId);
        }
    }
}
