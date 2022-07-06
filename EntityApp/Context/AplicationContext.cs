using Microsoft.EntityFrameworkCore;
using EntityApp.Models;

namespace EntityApp.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course>? Courses { get; set; } = null;

        public DbSet<Student>? Students { get; set; } = null;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
