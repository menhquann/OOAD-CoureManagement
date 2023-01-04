
using Microsoft.AspNetCore.Mvc;
using CourseManager.Models;
using CourseManager.Services;
namespace CourseManager.Controllersace
{
    public class CourseController : Controller
    {
        // public List<Course> Courses {get;set;}
        private readonly ICourseService service;
        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        // public CourseController()
        // {
        //     // Courses = new List<Course>()
        //     // {
        //     //     new Course() { Id =1, Name = "Iphone 10", Price = 500, Quantity = 30},
        //     //     new Course() { Id =2, Name = "Iphone 11", Price = 600, Quantity = 40},
        //     //     new Course() { Id =3, Name = "Iphone 12", Price = 700, Quantity = 50},
        //     // };
            
        // }
        public IActionResult Index()
        {   
            var categories = service.GetCategories();
            var courses = service.GetCourses();
            ViewBag.Categories= categories;
            return View(courses);
        }
        public IActionResult Create()
        {   

            var categories = service.GetCategories();
            return View(categories);
        }
        public IActionResult Update(int id)
        {   
            var course = service.GetCourseById(id);
            if ( course == null) return RedirectToAction("Create");

            var categories = service.GetCategories();
            ViewBag.Course = course;
            return View(categories);
        }
        public IActionResult Delete(int id)
        {   
            
            service.DeleteCourse(id);
            
            return RedirectToAction("Index");
        }
        public IActionResult Save(Course course)
        {   
            if (service.GetCourseById(course.Id)==null)
            service.CreateCourse(course);
            else service.UpdateCourse(course);
            return RedirectToAction("Index");
        }
        

    }
}