
using CourseManager.Models;

namespace CourseManager.Services
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course? GetCourseById(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        List<Category> GetCategories();
        
    }
}