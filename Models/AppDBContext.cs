using Courses.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courses.Models
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<UserRegister> UserRegisters { get; set; }

        public DbSet<CourseType> CourseTypes { get; set; }

        public DbSet<StudyLevel> StudyLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegister>()
            .HasOne(p => p.CourseType)
            .WithMany(b => b.UserRegisters);

            modelBuilder.Entity<UserRegister>()
            .HasOne(p => p.StudyLevel)
            .WithMany(b => b.UserRegisters);

            base.OnModelCreating(modelBuilder);
        }
    }
}
