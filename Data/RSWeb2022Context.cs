#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RSWeb2022.Models;

namespace RSWeb2022.Models
{
    public class RSWeb2022Context : DbContext
    {
        public RSWeb2022Context (DbContextOptions<RSWeb2022Context> options)
            : base(options)
        {
        }

        public DbSet<RSWeb2022.Models.Course> Course { get; set; }

        public DbSet<RSWeb2022.Models.CourseTeacher> CourseTeacher { get; set; }

        public DbSet<RSWeb2022.Models.Enrollment> Enrollment { get; set; }

        public DbSet<RSWeb2022.Models.Student> Student { get; set; }

        public DbSet<RSWeb2022.Models.Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Enrollment>()
                .HasOne<Student>(p => p.Student)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.StudentId);
            builder.Entity<Enrollment>()
                .HasOne<Course>(d => d.Course)
                .WithMany(d => d.Students)
                .HasForeignKey(d => d.CourseId);
            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.Teacher1)
                .WithMany(p => p.Courses1)
                .HasForeignKey(p => p.FirstTeacherId);
            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.Teacher2)
                .WithMany(p => p.Courses2)
                .HasForeignKey(p => p.SecondTeacherId);
        }
    }
}
