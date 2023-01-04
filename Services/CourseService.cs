using Microsoft.EntityFrameworkCore;
using CourseManager.Models;
 
namespace CourseManager.Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;
        public CourseService(DataContext context)
        {
            _context = context;
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var existedCourse = GetCourseById(id);
            if (existedCourse == null) return;
            _context.Courses.Remove(existedCourse);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(p => p.Id == id);
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.Include(p => p.Category).ToList();
        }

        public void UpdateCourse(Course course)
        {
            var existedCourse = GetCourseById(course.Id);
            if (existedCourse == null) return;
            existedCourse.Name = course.Name;
            existedCourse.Slug = course.Slug;
            existedCourse.Summary = course.Summary;
            existedCourse.Detail = course.Detail;
            existedCourse.Avatar = course.Avatar;
            existedCourse.CategoryId = course.CategoryId;
            _context.Courses.Update(existedCourse);
            _context.SaveChanges();

        }



    }
}
