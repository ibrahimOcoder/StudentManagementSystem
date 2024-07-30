using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Admin.Entities;
using System.Reflection;

namespace StudentManagementSystem.Admin.DbContexts
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(IEntityBase).IsAssignableFrom(type) && !type.IsAbstract);

            foreach (var entityType in entityTypes)
            {
                var method = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
                var genericMethod = method?.MakeGenericMethod(entityType);
                genericMethod?.Invoke(modelBuilder, null);
            }

            modelBuilder.Entity<Student>()
            .HasMany(s => s.StudentCourses)
            .WithOne(sc => sc.Student)
            .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Course>()
            .HasMany(s => s.StudentCourses)
            .WithOne(sc => sc.Course)
            .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<EventLog>()
                .Property(p => p.EventBody).HasColumnType("jsonb");
        }
    }
}
