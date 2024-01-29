using FirstDemo.Domain.Entities;
using FirstDemo.Infrastructure.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>,
        IApplicationDbContext
{
    private readonly string _connectionString;
    private readonly string _migrationAssembly;

    public ApplicationDbContext(string connectionString, string migrationAssembly)
    {
        _connectionString = connectionString;
        _migrationAssembly = migrationAssembly;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsAssembly(_migrationAssembly));
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CourseEnrollment>().ToTable("CourseEnrollments");

        builder.Entity<CourseEnrollment>().HasKey(x => new { x.CourseId, x.StudentId });

        builder.Entity<CourseEnrollment>()
            .HasOne<Course>()
            .WithMany()
            .HasForeignKey(x => x.CourseId);

        builder.Entity<CourseEnrollment>()
            .HasOne<Student>()
            .WithMany()
            .HasForeignKey(x => x.StudentId);

        builder.Entity<Course>().HasData(new Course[]
        {
            new Course{Id = new Guid("6e07762a-c636-404f-bb8f-eef11dce0d21"), Title= "Demo Course 1", Description= "Test", Fees= 3000},
            new Course{Id = new Guid("927ed339-165d-482b-8016-420a2b10d687"), Title= "Demo Course 2", Description= "Test", Fees= 4000}
        });
        base.OnModelCreating(builder);
    }


    public DbSet<Course> Courses{ get; set; }
    public DbSet<Student> Students { get; set; }
}
