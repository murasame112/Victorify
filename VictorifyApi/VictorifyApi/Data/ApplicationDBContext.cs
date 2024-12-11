using Microsoft.EntityFrameworkCore;
using VictorifyApi.Models;

namespace VictorifyApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Students)
                .WithMany(t => t.Teachers)
                .UsingEntity(ts => ts.ToTable("TeacherStudent"));

            modelBuilder.Entity<Teacher>()
                .HasMany(l => l.Lessons)
                .WithMany(t => t.Teachers)
                .UsingEntity(lt => lt.ToTable("LessonTeacher"));

            modelBuilder.Entity<Student>()
                .HasMany(l => l.Lessons)
                .WithMany(s => s.Students)
                .UsingEntity(ls => ls.ToTable("LessonStudent"));
        }
    }
}
