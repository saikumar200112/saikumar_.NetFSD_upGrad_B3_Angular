using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                :
        base(options)
        {
        }
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
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
