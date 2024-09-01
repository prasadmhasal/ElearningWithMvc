using ElearningWithMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningWithMvc.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Auth> User { get; set; }
        public DbSet<AddCourse> AddCourses { get; set; }
        public DbSet<CourseVideo> AddSubCourse { get; set; }
    }
}
