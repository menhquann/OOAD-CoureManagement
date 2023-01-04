namespace CourseManager.Models;
public class Category
{
    public Category()
    {
        Courses = new List<Course>();
    }
    public int Id { get; set;}
    public string Name { get; set;}
    public List<Course> Courses { get; set;}
}