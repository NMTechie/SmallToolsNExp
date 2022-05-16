using GraphQLExp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExp.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(c => c.OptedSubjects).WithMany(e=>e.OptedBy);
            modelBuilder.Entity<Student>().HasOne(c => c.ContactAddress);
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Score> Scores { get; set; }

    }
}
