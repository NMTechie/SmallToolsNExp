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
            modelBuilder.Entity<StudentSubject>()
                .HasOne(x=>x.Subject)
                .WithMany(x=>x.OptedBy)
                .HasForeignKey(x=>x.SubjectId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(x => x.Student)
                .WithMany(x => x.OptedSubjects)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.AllotedTeachers)
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.SubjectsAlloted)
                .HasForeignKey(x => x.TeacherId);
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SubjectTeacher> SubjectTeacher { get; set; }
        public DbSet<Score> Scores { get; set; }

    }
}
