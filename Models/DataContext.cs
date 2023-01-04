
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(p => p.CategoryId);
            base.OnModelCreating(modelBuilder);
        }
    }
}